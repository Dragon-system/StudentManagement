namespace StudentManagement
{
    class Instructor(int id, string? name, string? specialization)
    {
        public int instructorId = id;
        public string? InstructorName = name;
        public string? Specialization = specialization;
      
        public string GetInstructorDetails()
        {
            return $"ID: {instructorId}, Name: {InstructorName}, Specialization: {Specialization}";
        }
    }
    //============================
    class Course(int id, string? title, Instructor instruct)
    {
        public int courseId = id;
        public string? Title = title;
        public Instructor instructor = instruct;
        public string? GetCourseDetails()
        {
            return $"Course ID: {courseId}, Title: {Title}, Instructor: {instructor.GetInstructorDetails()}";
        }
    }
    //============================
    class Student(int id, string? Sname, int age, List<Course> courses)
    {
        public int studentId = id;
        public string? StudentName = Sname;
        public int Age = age;
        public List<Course> Courses = courses;
            public bool Enroll(Course course)//داله اضافه طالب
        {
            // نلف على كل الكورسات اللي الطالب مسجل فيها
            for (int i = 0; i < Courses.Count; i++)
            {
                // نقارن بالـ ID
                if (Courses[i].courseId == course.courseId)
                {
                    // الطالب متسجل قبل كده
                    return false;
                }
            }

            // لو وصلنا هنا يبقى مش متسجل
            Courses.Add(course);
            return true;
        }

           
        
        public string? GetStudentDetails()//داله الطباعه
        {
            string? courseDetails = "";
            for (int i = 0; i < Courses.Count; i++)
            {
                courseDetails += Courses[i].GetCourseDetails(); // نجمع كل التفاصيل courseDetails = courseDetails + Courses[i].GetCourseDetails();
                if (i < Courses.Count - 1)
                    courseDetails += " , "; // فاصلة بين الكورسات
            }
            return $"Student ID: {studentId}, StudentName: {StudentName}, Age: {Age},Courses:{courseDetails}";
        }
    }
    //============================
    class StudentManager(List<Student> Listudents, List<Course> listcourses, List<Instructor> listinstructors)
    {
        public List<Student> stuDents= Listudents;
        public List<Course> couRses= listcourses;
        public List<Instructor> instRuctors= listinstructors;
        public bool AddStudent(Student student)
        {
            for (int i = 0; i < stuDents.Count; i++)//لوب لي اضيفه طالب داخل الليست
            {
                if (stuDents[i].studentId == student.studentId)
                {
                    return false;
                }
            }
            stuDents.Add(student);
            return true;
        }
        public bool AddCourse(Course course)
        {
            for (int i = 0; i < couRses.Count; i++)
            {
                if (couRses[i].courseId == course.courseId)
                {
                    return false;
                }
            }
            couRses.Add(course);
            return true;
        }
        public  bool AddInstructor(Instructor instructor)
        {
            for (int i = 0; i < instRuctors.Count; i++)
            {
                if (instRuctors[i].instructorId == instructor.instructorId)
                {
                    return false;
                }
            }
            instRuctors.Add(instructor);
            return true;
        }
        public string? GetAllStudents()
        {
            string? allDetails = "";
            for (int i = 0; i < stuDents.Count; i++)
            {
                allDetails += stuDents[i].GetStudentDetails();
                if (i < stuDents.Count - 1)
                    allDetails += "\n"; // سطر جديد بين الطلاب
            }
            return allDetails;
        }
    }
   //============================
    internal class Program
    {
        static void Main(string[] args)
        {

          
            List<Instructor> instructors = [];
            List<Course> courses = [];
            List<Student> students = [];
            StudentManager studentManager = new(students, courses, instructors);
            StudentManager manager =studentManager;

            
            bool exit =false;

            do
            {
                Console.WriteLine("|___________________________________________________________| ");
                Console.WriteLine("|=========>Welcome to the Student Management System!<=======|");
                Console.WriteLine("|=======================>{MENU}<============================|");
                Console.WriteLine("|========>{1.Add Student}<==================================|");
                Console.WriteLine("|========>{2.Add Instructor}<===============================|");
                Console.WriteLine("|========>{3.Add Course}<===================================|");
                Console.WriteLine("|========>{4.Enroll Student in Course}<=====================|");
                Console.WriteLine("|========>{5.Show All Students}<============================|");
                Console.WriteLine("|========>{6.Show All Courses}<=============================|");
                Console.WriteLine("|========>{7.Show All Instructors}<=========================|");
                Console.WriteLine("|========>{8.Find Student}<=================================|");
                Console.WriteLine("|============>{9.Find Course}<==============================|");
                Console.WriteLine("|===>{10.Check if the student enrolled in specific course}<=|");
                Console.WriteLine("|========>{11.Return the instructor name by course name}<===|");
                Console.WriteLine("|=======================>{12.Exit}<=========================|");
                Console.WriteLine("|___________________________________________________________|");
              
                int ENTR = Convert.ToInt32(Console.ReadLine());
                switch (ENTR)
                {

                    case 1:// Add Student
                    { 
                        Console.Write("ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Name: ");
                        string? name = Console.ReadLine();

                        Console.Write("Age: ");
                        int age = Convert.ToInt32(Console.ReadLine());

                        // ليست كورسات فاضية (مهم جدًا)
                        List<Course> emptyCourses = [];

                        var newStudent = new Student(id, name, age, emptyCourses);

                        bool added = manager.AddStudent(newStudent);

                        if (added)
                            Console.WriteLine("Student added");
                        else
                            Console.WriteLine(" Student already exists");
                    }
                        break;

                    case 2:// Add Instructor
                    { 
                        Console.Write("ID: ");
                        int insId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Name: ");
                        string? insName = Console.ReadLine();
                        Console.Write("Specialization: ");
                        string? specialization = Console.ReadLine();
                        Instructor newInstructor = new Instructor(insId, insName, specialization);
                        bool insAdded = manager.AddInstructor(newInstructor);
                        if (insAdded)
                            Console.WriteLine("Instructor added");
                        else
                            Console.WriteLine("Instructor already exists");
                    }
                        break;

                    case 3:// Add Course
                    {
                            Console.Write("ID: ");

                        int courseId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Title: ");

                        string? title = Console.ReadLine();

                        Console.Write("Instructor ID: ");

                        int InstructorId = Convert.ToInt32(Console.ReadLine());

                        Instructor? courseInstructor = null;

                        for (int i = 0; i < instructors.Count; i++)
                        {
                            if (instructors[i].instructorId == InstructorId)
                            {
                                courseInstructor = instructors[i];
                                break;
                            }
                        }
                        if (courseInstructor == null)
                        {
                            Console.WriteLine("Instructor not found");
                            break;
                        }
                        Course newCourse = new Course(courseId, title, courseInstructor);
                        bool courseAdded = manager.AddCourse(newCourse);
                        if (courseAdded)
                            Console.WriteLine("Course added");
                        else
                            Console.WriteLine("Course already exists");
                    }
                        break;
                    case 4:// Enroll Student in Course
                    {
                            Console.Write("Student ID: ");
                        int stuId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Studint name");
                        string? studname = Console.ReadLine();
                        Console.Write("Course ID: ");
                        int courId = Convert.ToInt32(Console.ReadLine());
                        Student? enrollStudent = null;
                        Course? enrollCourse = null;
                        for (int i = 0; i < students.Count; i++)
                        {
                            if (students[i].studentId == stuId && students[i].StudentName == studname)
                            {
                                enrollStudent = students[i];
                                break;
                            }
                        }
                        for (int i = 0; i < courses.Count; i++)
                        {
                            if (courses[i].courseId == courId)
                            {
                                enrollCourse = courses[i];
                                break;
                            }
                        }
                        if (enrollStudent == null)
                        {
                            Console.WriteLine("Student not found");
                            break;
                        }
                        if (enrollCourse == null)
                        {
                            Console.WriteLine("Course not found");
                            break;
                        }
                        bool enrolled = enrollStudent.Enroll(enrollCourse);
                        if (enrolled)
                            Console.WriteLine("Student enrolled in course");
                        else
                            Console.WriteLine("Student already enrolled in course");
                     }
                        break;

                    case 5:// Show All Students
                    { 
                            Console.WriteLine(manager.GetAllStudents());
                    }
                        break;
                    case 6:// Show All Courses
                    {   for (int i = 0; i < courses.Count; i++)
                        {
                            Console.WriteLine(courses[i].GetCourseDetails());
                        }
                    }   
                    break;

                    case 7:// Show All Instructors
                    {
                            for (int i = 0; i < instructors.Count; i++)
                            {
                                Console.WriteLine(instructors[i].GetInstructorDetails());
                            }
                     }  
                    break;

                    case 8:// Find Student
                    { 
                            Console.Write("Student ID: ");
                        int findStuId = Convert.ToInt32(Console.ReadLine());
                        Student? foundStudent = null;
                        for (int i = 0; i < students.Count; i++)
                        {
                            if (students[i].studentId == findStuId)
                            {
                                foundStudent = students[i];
                                break;
                            }
                        }
                        if (foundStudent != null)
                            Console.WriteLine(foundStudent.GetStudentDetails());
                        else
                            Console.WriteLine("Student not found");
                    }
                        break;
                    case 9:// Find Course
                    {   
                            Console.Write("Course ID: ");
                        int findCourseId = Convert.ToInt32(Console.ReadLine());
                        Course? foundCourse = null;
                        for (int i = 0; i < courses.Count; i++)
                        {
                            if (courses[i].courseId == findCourseId)
                            {
                                foundCourse = courses[i];
                                break;
                            }
                        }
                        if (foundCourse != null)
                            Console.WriteLine(foundCourse.GetCourseDetails());
                        else
                            Console.WriteLine("Course not found");
                    }  
                        break;
                    case 10:// Check if the student enrolled in specific course
                    { 
                        Console.Write("Student ID: ");
                        int checkStuId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Course ID: ");
                        int checkCourseId = Convert.ToInt32(Console.ReadLine());
                        Student? checkStudent = null;
                        for (int i = 0; i < students.Count; i++)
                        {
                            if (students[i].studentId == checkStuId)
                            {
                                checkStudent = students[i];
                                break;
                            }
                        }
                        if (checkStudent == null)
                        {
                            Console.WriteLine("Student not found");
                            break;
                        }
                        bool isEnrolled = false;
                        for (int i = 0; i < checkStudent.Courses.Count; i++)
                        {
                            if (checkStudent.Courses[i].courseId == checkCourseId)
                            {
                                isEnrolled = true;
                                break;
                            }
                        }
                        if (isEnrolled)
                            Console.WriteLine("Student is enrolled in the course");
                        else
                            Console.WriteLine("Student is not enrolled in the course");
                    }
                        break;
                    case 11:// Return the instructor name by course name
                        { 
                        Console.Write("Course Title: ");
                        string? courseTitle = Console.ReadLine();
                        Course? titleCourse = null;
                        for (int i = 0; i < courses.Count; i++)
                        {
                            if (courses[i].Title == courseTitle)
                            {
                                titleCourse = courses[i];
                                break;
                            }
                        }
                        if (titleCourse != null)
                            Console.WriteLine($"Instructor Name: {titleCourse.instructor.InstructorName}");
                        else
                            Console.WriteLine("Course not found");
                        }
                        break;
                    case 12:// Exit
                        {
                            exit = true;
                            Console.WriteLine("Exiting program...");
                        }
                        break;
                    default:
                       {
                            Console.WriteLine("Invalid choice. Try again."); 
                       }
                        Console.WriteLine();
                        break;

                }
            } while (!exit);

        }
    }
}
