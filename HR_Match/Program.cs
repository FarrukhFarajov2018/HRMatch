using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using Newtonsoft.Json;

namespace HR_Match
{
    class Program
    {
        static void Main(string[] args)
        {

            Action act = new Action();

            act.createUser();

            MemoryStream stream1 = new MemoryStream();




            // var result = JsonConvert.SerializeObject(employee);


        }
    }

    public enum Category
    {
        Doctor = 0,
        Engineer = 1,
        Programmer = 2,
        Teacher = 3,
        Carpenter = 4,
        Mechanic = 5,
        Painter = 6,
        Constructor = 7,
        Farmer = 8,
        Seller = 9
    }
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }

        public User() { }

        public User(string username, string password, string email, string status)
        {
            Username = username;
            Password = password;
            Email = email;
            Status = status;
        }
    }

    class Employee : User
    {
        public Employee() { }

        public Employee(string username, string password, string email, string status)
            : base(username, password, email, status) { }

        public CV userCv { get; set; }
    }

    class Employer : User
    {
        public Employer() { }

        public Employer(string username, string password, string email, string status)
            : base(username, password, email, status) { }

        public List<JobOffer> OffersList = new List<JobOffer>();

    }

    class JobOffer
    {
        public JobOffer() { }

        public int ID { get; set; }
        public string Offertitle { get; set; }
        public string Company { get; set; }
        public string Offercategory { get; set; }
        public string Jobnfo { get; set; }
        public string City { get; set; }
        public int Minsalary { get; set; }
        public int Age { get; set; }
        public string Study { get; set; }
        public int Workexperience { get; set; }
        public string Phonenumber { get; set; }

        public JobOffer(int id, string offertitle, string company, string offercategory, string jobnfo, string city,
        int minsalary, int age, string study, int workexperience, string phonenumber)
        {
            ID = id;
            Offertitle = offertitle;
            Company = company;
            Offercategory = offercategory;
            Jobnfo = jobnfo;
            City = city;
            Minsalary = minsalary;
            Age = age;
            Study = study;
            Workexperience = workexperience;
            Phonenumber = phonenumber;
        }
    }

    class CV
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Study { get; set; }
        public string City { get; set; }
        public int Workexperience { get; set; }
        public string Workcategory;
        public int Minsalary { get; set; }
        public string Phonenumber { get; set; }

        public CV() { }

        public CV(int id, string name, string surname, string gender, int age, string study, string city, int workexperience, string workcategory, int minsalary, string phonenumber)
        {
            ID = id;
            Name = name;
            Surname = surname;
            Gender = gender;
            Age = age;
            Study = study;
            City = city;
            Workexperience = workexperience;
            Workcategory = workcategory;
            Minsalary = minsalary;
            Phonenumber = phonenumber;
        }
    }


    class Action
    {
        //file system  

        //
        public List<Employee> empyee = new List<Employee>();

        Employer myEmployer = new Employer("HasanM", "hhh", "hhh@hhh.com", "Programmer");
        Employee myEmployee = new Employee("Aqui", "hhh", "kkk@hhh.com", "Programmer");

        Employee employee = new Employee();
        Employer emp = new Employer();



        public void createUser()
        {
            if (File.Exists("Employers.json") && File.Exists("Workers.json"))
            {
                string jsonEmployees = File.ReadAllText("Employee.json");
                empyee = JsonConvert.DeserializeObject<List<Employee>>(jsonEmployees);

                string jsonEmployers = File.ReadAllText("Employers.json");
                emp.OffersList = JsonConvert.DeserializeObject<List<JobOffer>>(jsonEmployers);
            }
                myEmployer.OffersList = new List<JobOffer> { new JobOffer(1,"First offer", "Microsoft", "Programmer", "Good job", "Baku", 1000, 30, "Uni", 5, "0555555"),
            new JobOffer(2,"First offer2", "Microsoft2", "Programmer", "Good job2", "Baku", 500, 25, "Inst", 4, "05511111") };

            myEmployee.userCv = new CV(1, "Anders", "Hejlsberg", "Male", 40, "Uni", "Baku", 12, "Programmer", 1000, "0509999999");


            while (true)
            {
                JobOffer offer = new JobOffer();

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("  \\  SIGN IN  \\   ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("  \\  SIGN UP  \\   ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" \\ EXIT  \\        ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\n");
                Console.WriteLine();
                Console.WriteLine("Please SIGN IN/SIGN UP by pressing 1  ");
                Console.WriteLine();
                Console.WriteLine("Please SIGN OUT by pressing 2 to go to beginning  ");
                Console.WriteLine();
                Console.WriteLine("Please EXIT by pressing 3 to leave the site  ");
                Console.WriteLine();
                // Console.WriteLine("Please SIGN UP by 2 if you have own account");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                int mys = int.Parse(Console.ReadLine());

                if (mys == 1)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Please enter  1 IF YOU ARE LOOKING FOR A JOB");
                    Console.WriteLine();
                    Console.WriteLine("Please enter  2 IF YOU ARE LOOKING FOR AN EMPLOYEE");
                    Console.WriteLine();
                    int mystatus = Int32.Parse(Console.ReadLine());//STATUS
                    Console.WriteLine();



                    if (mystatus == 1) //status to OBJ
                    {
                        Console.Clear();
                        employee.Status = "jobsearcher";
                        Console.WriteLine();
                        Console.WriteLine($"Your status is : {employee.Status}");
                        Console.WriteLine();

                        Console.WriteLine("Please enter your username");
                        Console.WriteLine();
                        string myusername = Console.ReadLine();//USERNAME
                        Console.WriteLine();
                        employee.Username = myusername;//name To OBJ

                        const string pattern = @"^[0-9a-zA-Z_.-]+\@[0-9a-zA-Z_-]+\.[a-zA-Z]{2,4}$";
                        const string pattern2 = @"^[a-zA-Z0-9._-]{2,15}$";

                        Regex regex1 = new Regex(pattern);
                        Regex regex2 = new Regex(pattern2);

                        string myemail;

                        while (true)
                        {
                            Console.WriteLine("Please enter your email");
                            Console.WriteLine();
                            myemail = Console.ReadLine();//EMAIL

                            if (myemail == " ")
                                continue;

                            bool success = regex1.IsMatch(myemail);

                            Console.WriteLine(success ? " Well done!  " :
                                                      " Please try again ");

                            if (success) break;

                        }

                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("You email address is received");

                        employee.Email = myemail;//mail to OBJ

                        string mypassword;

                        while (true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Please enter your password");
                            Console.WriteLine();
                            mypassword = Console.ReadLine();//PASSWORD
                            Console.WriteLine();
                            if (mypassword == " ")
                            {
                                Console.WriteLine("Please enter correct symbols");
                                continue;
                            }

                            bool success2 = regex2.IsMatch(mypassword);

                            Console.WriteLine(success2 ? "Well done!  " :
                                                      " Please try again ");
                            Console.WriteLine();
                            Console.WriteLine("Enter your password again to chek it out");
                            Console.WriteLine();
                            string mypassword2 = Console.ReadLine();
                            Console.WriteLine();
                            if (mypassword2 == " ")
                            {
                                Console.WriteLine("Please enter correct symbols");
                                continue;
                            }

                            var chars = "ABC012345DEFGHIJ6789KLMNO01234PQRSTUVWX56789YZabcde01234fghijklmnopq0123456789rstuv56789wxyz";
                            var stringChars = new char[4];
                            var random = new Random();

                            for (int i = 0; i < stringChars.Length; i++)
                            {
                                stringChars[i] = chars[random.Next(chars.Length)];
                            }

                            var antiRobot = new String(stringChars);
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine($"RANDOM CODE : {antiRobot}");
                            Console.WriteLine();

                            Console.WriteLine("Please repeat \" RANDOME CODE\" You see, to find out you're not a robot ");
                            Console.WriteLine();
                            string antiRobot2 = Console.ReadLine();
                            Console.WriteLine();

                            if (success2 && mypassword == mypassword2 && antiRobot == antiRobot2)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Your password is not correct! Try it again");
                                continue;
                            }
                        }

                        employee.Password = mypassword;//password to OBJ

                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("You Password is completely received");

                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Please Press 1 to create CV and to Print");
                        Console.WriteLine();
                        Console.WriteLine("Please Press 2 to to find Announcements matching you ");
                        Console.WriteLine();
                        Console.WriteLine("Please Press 3 to print ALL Announcements");
                        Console.WriteLine();
                        Console.WriteLine("Please Press 4 Search by Options");
                        Console.WriteLine();
                        Console.WriteLine("Please Press 5 Search by Category Show what you choose");
                        Console.WriteLine("and Apply for a job");
                        Console.WriteLine();
                        Console.WriteLine("Please Press any other button to go to beginning");
                        Console.WriteLine();
                        Console.WriteLine();


                        int choiceCV = Int32.Parse(Console.ReadLine());

                        switch (choiceCV)
                        {
                            case 1:

                                employee.userCv = new CV();
                                Console.WriteLine();
                                Console.WriteLine("Please create your CV ");
                                Console.WriteLine();
                                Console.WriteLine("Please enter your ID ");
                                Console.WriteLine();
                                int id = Int32.Parse(Console.ReadLine());//Age

                                employee.userCv.ID = id;
                                Console.WriteLine("Please enter your Name ");
                                Console.WriteLine();

                                string myname = (Console.ReadLine());//Name

                                employee.userCv.Name = myname;
                                Console.WriteLine();
                                Console.WriteLine("Please enter your Surname ");
                                Console.WriteLine();

                                string mysurname = (Console.ReadLine());//Surame

                                employee.userCv.Surname = mysurname;
                                Console.WriteLine();
                                Console.WriteLine("Please enter your Gender ");
                                Console.WriteLine();

                                string mygender = (Console.ReadLine());//Gender

                                employee.userCv.Gender = mygender;
                                Console.WriteLine();
                                Console.WriteLine("Please enter your Age ");
                                Console.WriteLine();

                                int myage = Int32.Parse(Console.ReadLine());//Age

                                employee.userCv.Age = myage;
                                Console.WriteLine();
                                Console.WriteLine("Please enter your Study ");
                                Console.WriteLine();

                                string mystudy = (Console.ReadLine());//Study

                                employee.userCv.Study = mystudy;
                                Console.WriteLine();
                                Console.WriteLine("Please enter your Work Experience ");
                                Console.WriteLine();

                                int myexperience = Int32.Parse(Console.ReadLine());//Experience

                                employee.userCv.Workexperience = myexperience;
                                Console.WriteLine();
                                Console.WriteLine("Please enter your Workcategory ");
                                Console.WriteLine();

                                Console.WriteLine("Press 1 for Doctor, 2 for Engineer, 3 for Programmer, 4 for Teacher");
                                Console.WriteLine("Press 5 for Carpenter, 6 for Mechanic, 7 for Painter");
                                Console.WriteLine("Press 8 for Constructor , 9 for Farmer, 10 for Seller Category");
                                Console.WriteLine();

                                int myNcat = Convert.ToInt32(Console.ReadLine());


                                switch (myNcat)
                                {
                                    case 1:

                                        employee.userCv.Workcategory = "Doctor";

                                        break;
                                    case 2:
                                        employee.userCv.Workcategory = "Engineer";
                                        break;
                                    case 3:
                                        employee.userCv.Workcategory = "Programmer";
                                        break;
                                    case 4:
                                        employee.userCv.Workcategory = "Teacher";
                                        break;
                                    case 5:
                                        employee.userCv.Workcategory = "Carpenter";
                                        break;
                                    case 6:
                                        employee.userCv.Workcategory = "Mechanic";
                                        break;
                                    case 7:
                                        employee.userCv.Workcategory = "Painter";
                                        break;
                                    case 8:
                                        employee.userCv.Workcategory = "Constructor";
                                        break;
                                    case 9:
                                        employee.userCv.Workcategory = "Farmer";
                                        break;
                                    case 10:
                                        employee.userCv.Workcategory = "Seller";
                                        break;
                                    default:
                                        Console.WriteLine("Wrong choice");
                                        break;
                                }


                                Console.WriteLine();
                                Console.WriteLine("Please enter your City ");
                                Console.WriteLine();

                                string mycity = Console.ReadLine();//City

                                employee.userCv.City = mycity;
                                Console.WriteLine();
                                Console.WriteLine("Please enter Minimum salary accessable for you ");
                                Console.WriteLine();

                                int mysalary = Int32.Parse(Console.ReadLine());//salary

                                employee.userCv.Minsalary = mysalary;


                                Console.WriteLine();
                                Console.WriteLine("Please enter your phonenumber ");
                                Console.WriteLine();

                                string myphone = Console.ReadLine();//phone

                                employee.userCv.Phonenumber = myphone;

                                empyee.Add(employee);


                                if (employee.Status == "jobsearcher")
                                {
                                    Console.Clear();
                                    Console.WriteLine();
                                    Console.WriteLine(new string('-', 40));
                                    Console.WriteLine(new string('-', 40));
                                    Console.WriteLine($"NAME :  {employee.userCv.Name}");
                                    Console.WriteLine(new string('-', 40));
                                    Console.WriteLine($"SURNAME :  {employee.userCv.Surname}");
                                    Console.WriteLine(new string('-', 40));
                                    Console.WriteLine($"GENDER :  {employee.userCv.Gender}");
                                    Console.WriteLine(new string('-', 40));
                                    Console.WriteLine($"STUDY :  {employee.userCv.Study}");
                                    Console.WriteLine(new string('-', 40));
                                    Console.WriteLine($"WORK EXPERIENCE :  {employee.userCv.Workexperience}");
                                    Console.WriteLine(new string('-', 40));
                                    Console.WriteLine($"WORK CATEGORY :  {employee.userCv.Workcategory}");
                                    Console.WriteLine(new string('-', 40));
                                    Console.WriteLine($"CITY :  {employee.userCv.City}");
                                    Console.WriteLine(new string('-', 40));
                                    Console.WriteLine($"MINIMUM SALARY :  {employee.userCv.Minsalary}");
                                    Console.WriteLine(new string('-', 40));
                                    Console.WriteLine($"CELLPHONE :  {employee.userCv.Phonenumber}");
                                    Console.WriteLine(new string('-', 40));
                                    Console.WriteLine(new string('-', 40));

                                }
                                Console.WriteLine("\n\n");
                                Console.WriteLine("Enter any key to go back to beginning");
                                Console.ReadKey();

                                break;

                            case 2:
                                {
                                    //searchOffer(myEmployer, myEmployee);IF you want to get directly 
                                    //not from Console use this function invoke
                                    searchOffer(emp, employee);

                                    Console.ReadKey();
                                }
                                break;

                            case 3:

                                foreach (var item in emp.OffersList)
                                {
                                    Console.WriteLine(new string('-', 100));
                                    Console.WriteLine($"OFFERTITLE :{item.Offertitle} , COMPANY : {item.Company}, AGE : { item.Age} , " +
                                        $"JOBINFO :{item.Jobnfo} , CATEGORY {item.Offercategory} , STUDY {item.Study} , SALARY {item.Minsalary} ," +
                                        $" SALARY {item.City} , NUMBER {item.Phonenumber}");
                                    Console.WriteLine(new string('-', 100));
                                }

                                Console.WriteLine();

                                Console.ReadKey();

                                break;

                            case 4:
                                {
                                    Console.WriteLine("Please Press 1 Search by Study");
                                    Console.WriteLine();

                                    Console.WriteLine("Please Press 2 Search by City");
                                    Console.WriteLine();

                                    Console.WriteLine("Please Press 3 Search by Salary");
                                    Console.WriteLine();

                                    Console.WriteLine("Please Press 4 Search by Work Experience");
                                    Console.WriteLine();

                                    int searchChoice = Int32.Parse(Console.ReadLine());

                                    //Category Ncat9 = (Category)myNcat9;

                                    switch (searchChoice)
                                    {
                                        case 1:

                                            Console.WriteLine("Please enter study category as a search priority to filter the list");
                                            string studychoice = Console.ReadLine();

                                            Func1(emp, studychoice);
                                            Console.ReadKey();
                                            break;

                                        case 2:

                                            Console.WriteLine("Please enter city category as a search priority to filter the list");

                                            string citychoice = Console.ReadLine();
                                            Func2(emp, citychoice);
                                            Console.ReadKey();
                                            break;
                                        case 3:

                                            Console.WriteLine("Please enter salary category as a search priority to filter the list");

                                            int salarychoice = Int32.Parse(Console.ReadLine());

                                            Func3(emp, salarychoice);

                                            Console.ReadKey();
                                            break;

                                        case 4:

                                            Console.WriteLine("Please enter experience category as a search priority to filter the list");

                                            int expchoice = Int32.Parse(Console.ReadLine());
                                            Func4(emp, expchoice);
                                            Console.ReadKey();
                                            break;

                                        default:
                                            Console.WriteLine("Wrong choice");
                                            Console.ReadKey();
                                            break;
                                    }



                                }
                                break;

                            case 5:

                                int index = 0;
                                foreach (var item in emp.OffersList)
                                {
                                    index++;
                                    Console.WriteLine(new string('-', 40));
                                    Console.WriteLine($"Announce NUMBER :{index} ,  CATEGORY {item.Offercategory} ");
                                    Console.WriteLine(new string('-', 40));
                                }

                                Console.WriteLine();
                                Console.WriteLine("Please choose number of Announcement to look it Fully");

                                int indexNum = Int32.Parse(Console.ReadLine());

                                Console.WriteLine(new string('-', 120));
                                Console.WriteLine($"OFFERTITLE :{emp.OffersList[indexNum - 1].Offertitle} , COMPANY : {emp.OffersList[indexNum - 1].Company}, AGE : { emp.OffersList[indexNum - 1].Age} , " +
                                    $"JOBINFO :{emp.OffersList[indexNum - 1].Jobnfo} , CATEGORY {emp.OffersList[indexNum - 1].Offercategory} , STUDY {emp.OffersList[indexNum - 1].Study} , SALARY {emp.OffersList[indexNum - 1].Minsalary} ," +
                                    $" SALARY {emp.OffersList[indexNum - 1].City} , NUMBER {emp.OffersList[indexNum - 1].Phonenumber}");
                                Console.WriteLine(new string('-', 120));

                                Console.WriteLine("If you want to APPLY For a JOB press \"Y\"");
                                Console.WriteLine();
                                Console.WriteLine("If you want to go back to beginning press \"L\" to LOG OUT");

                                string app = Console.ReadLine();//offerchoice
                                string app22 = app.ToLower();
                                if (app22 == "y")
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Your Application is accepted");
                                    Console.WriteLine();

                                    Console.ReadKey();
                                }
                                else if (app22 == "l")
                                {
                                    continue;
                                }
                                Console.ReadKey();

                                break;

                            default:

                                break;
                        }

                    }

                    else if (mystatus == 2) //status to OBJ
                    {
                        Console.Clear();
                        emp.Status = "jobofferer";

                        Console.WriteLine();
                        Console.WriteLine($"Your status is : {emp.Status}");
                        Console.WriteLine();

                        Console.WriteLine();
                        Console.WriteLine();

                        Console.WriteLine("Please enter your username");
                        Console.WriteLine();
                        string myusername2 = Console.ReadLine();//USERNAME
                        Console.WriteLine();
                        emp.Username = myusername2;//name To OBJ

                        const string pattern3 = @"^[0-9a-zA-Z_.-]+\@[0-9a-zA-Z_-]+\.[a-zA-Z]{2,4}$";
                        const string pattern4 = @"^[a-zA-Z0-9._-]{2,15}$";

                        Regex regex3 = new Regex(pattern3);
                        Regex regex4 = new Regex(pattern4);

                        string myemail2;




                        while (true)
                        {
                            Console.WriteLine("Please enter your email");
                            Console.WriteLine();
                            myemail2 = Console.ReadLine();//EMAIL

                            if (myemail2 == " ")
                                continue;

                            bool success = regex3.IsMatch(myemail2);

                            Console.WriteLine(success ? " Well done!  " :
                                                      " Please try again ");

                            if (success) break;

                        }

                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("You email address is received");

                        emp.Email = myemail2;//mail to OBJ


                        string mypassword3;

                        while (true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Please enter your password");
                            Console.WriteLine();
                            mypassword3 = Console.ReadLine();//PASSWORD
                            Console.WriteLine();
                            if (mypassword3 == " ")
                            {
                                Console.WriteLine("Please enter correct symbols");
                                continue;
                            }

                            bool success2 = regex4.IsMatch(mypassword3);

                            Console.WriteLine(success2 ? "Well done!  " :
                                                      " Please try again ");
                            Console.WriteLine();
                            Console.WriteLine("Enter your password again to chek it out");
                            Console.WriteLine();
                            string mypassword4 = Console.ReadLine();
                            Console.WriteLine();
                            if (mypassword4 == " ")
                            {
                                Console.WriteLine("Please enter correct symbols");
                                continue;
                            }

                            var chars = "ABC012345DEFGHIJ6789KLMNO01234PQRSTUVWX56789YZabcde01234fghijklmnopq0123456789rstuv56789wxyz";
                            var stringChars = new char[4];
                            var random = new Random();

                            for (int i = 0; i < stringChars.Length; i++)
                            {
                                stringChars[i] = chars[random.Next(chars.Length)];
                            }

                            var antiRobot = new String(stringChars);
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine($"RANDOM CODE : {antiRobot}");
                            Console.WriteLine();

                            Console.WriteLine("Please repeat \"RANDOM CODE\" You see, to find out you're not a robot ");
                            Console.WriteLine();
                            string antiRobot2 = Console.ReadLine();
                            Console.WriteLine();

                            if (success2 && mypassword3 == mypassword4 && antiRobot == antiRobot2)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Your password is not correct! Try it again");
                                continue;
                            }
                        }

                        emp.Password = mypassword3;//password to OBJ

                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("You Password is completely received");

                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("If you want to create job announsement press \"Y\"");
                            Console.WriteLine();
                            Console.WriteLine("If you want to go back to beginning press any other symbol");

                            string joboff = Console.ReadLine();//offerchoice
                            string joboff2 = joboff.ToLower();
                            if (joboff2 == "y")
                            {

                                if (emp.Status == "jobofferer")
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Please create your JOB Announcement ");
                                    Console.WriteLine();
                                    Console.WriteLine("Please enter ID of employee");
                                    Console.WriteLine();

                                    int id = Int32.Parse(Console.ReadLine());//Id
                                    offer.ID = id;
                                    Console.WriteLine();

                                    Console.WriteLine("Please enter Job Offer Title ");
                                    Console.WriteLine();

                                    string mytitle = (Console.ReadLine());//Title

                                    offer.Offertitle = mytitle;
                                    Console.WriteLine();
                                    Console.WriteLine("Please enter Company name ");
                                    Console.WriteLine();

                                    string mycompname = (Console.ReadLine());//Company

                                    offer.Company = mycompname;
                                    Console.WriteLine();


                                    Console.WriteLine();
                                    Console.WriteLine("Please enter Age of employee you need");
                                    Console.WriteLine();

                                    int myage9 = Int32.Parse(Console.ReadLine());//Age

                                    offer.Age = myage9;
                                    Console.WriteLine();

                                    Console.WriteLine("Please enter Study you need ");
                                    Console.WriteLine();
                                    string mystudy9 = (Console.ReadLine());//Study

                                    offer.Study = mystudy9;
                                    Console.WriteLine();

                                    Console.WriteLine("Please enter Work Experience you need ");
                                    Console.WriteLine();

                                    int myexperience9 = Int32.Parse(Console.ReadLine());//Experience

                                    offer.Workexperience = myexperience9;
                                    Console.WriteLine();

                                    Console.WriteLine("Please enter Workcategory you need ");
                                    Console.WriteLine();

                                    Console.WriteLine("Press 1 for Doctor, 2 for Engineer, 3 for Programmer, 4 for Teacher");
                                    Console.WriteLine("Press 5 for Carpenter, 6 for Mechanic, 7 for Painter");
                                    Console.WriteLine("Press 8 for Constructor , 9 for Farmer, 10 for Seller Category");
                                    Console.WriteLine();

                                    int myNcat9 = Int32.Parse(Console.ReadLine());

                                    //Category Ncat9 = (Category)myNcat9;


                                    switch (myNcat9)
                                    {
                                        case 1:

                                            offer.Offercategory = "Doctor";

                                            break;
                                        case 2:
                                            offer.Offercategory = "Engineer";
                                            break;
                                        case 3:
                                            offer.Offercategory = "Programmer";
                                            break;
                                        case 4:
                                            offer.Offercategory = "Teacher";
                                            break;
                                        case 5:
                                            offer.Offercategory = "Carpenter";
                                            break;
                                        case 6:
                                            offer.Offercategory = "Mechanic";
                                            break;
                                        case 7:
                                            offer.Offercategory = "Painter";
                                            break;
                                        case 8:
                                            offer.Offercategory = "Constructor";
                                            break;
                                        case 9:
                                            offer.Offercategory = "Farmer";
                                            break;
                                        case 10:
                                            offer.Offercategory = "Seller";
                                            break;
                                        default:
                                            Console.WriteLine("Wrong choice");
                                            break;
                                    }


                                    Console.WriteLine();
                                    Console.WriteLine("Please enter City you want  ");
                                    Console.WriteLine();

                                    string mycity9 = Console.ReadLine();//City

                                    offer.City = mycity9;
                                    Console.WriteLine();
                                    Console.WriteLine("Please enter Minimum salary you offer");
                                    Console.WriteLine();

                                    int mysalary9 = Int32.Parse(Console.ReadLine());//salary

                                    offer.Minsalary = mysalary9;


                                    Console.WriteLine();
                                    Console.WriteLine("Please enter your phonenumber ");
                                    Console.WriteLine();

                                    string myphone9 = Console.ReadLine();//phone

                                    offer.Phonenumber = myphone9;
                                    Console.WriteLine();
                                    Console.WriteLine("Please enter JOBINFO ");
                                    Console.WriteLine();

                                    string jobinfo = Console.ReadLine();//phone

                                    offer.Jobnfo = jobinfo;

                                    emp.OffersList.Add(offer);


                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine("If you want to SEE all ACCEPTED JOBLIST please press \"Y\"");
                                    Console.WriteLine();
                                    Console.WriteLine("If you want to go back to beginning press \"L\" to LOG OUT");

                                    string app3 = Console.ReadLine();//offerchoice
                                    string app23 = app3.ToLower();

                                    if (app23 == "y")
                                    {
                                        var query = from a in empyee
                                                    join m in emp.OffersList on a.userCv.ID equals m.ID
                                                    select new
                                                    {
                                                        a.userCv.Name,
                                                        a.userCv.Surname,
                                                        a.userCv.Workcategory,
                                                        m.Offertitle,
                                                        m.Jobnfo,
                                                        m.Offercategory
                                                    };

                                        foreach (var item in query)
                                        {

                                            Console.WriteLine($"NAME:  { item.Name},SURNAME:  { item.Surname},WORK CATEGORY :  {item.Workcategory},OFFERTITLE :{item.Offertitle} ,  " +
                                                    $"JOBINFO :{item.Jobnfo} , CATEGORY {item.Offercategory}");
                                        }

                                        Console.ReadKey();
                                    }

                                    else if (app23 == "l")
                                    {
                                        break;
                                    }

                                }

                            }

                            else { break; }

                        }
                    }

                }
                else if (mys == 2)
                {
                    continue;
                }

                else if (mys == 3)
                {
                    goto Lebel;
                }
            }

        Lebel: Console.Clear(); Console.WriteLine(); Console.WriteLine("Thanks for using our site");
            Console.WriteLine();

            string jsonEmployer = JsonConvert.SerializeObject(emp.OffersList);
            
            System.IO.File.WriteAllText("Employers.json", jsonEmployer);

            string jsonEmployee = JsonConvert.SerializeObject(empyee);

            //write string to file
            System.IO.File.WriteAllText("Employee.json", jsonEmployee);

        }


        public void searchOffer(Employer emp, Employee myEmployee)

        {
            var tmp = emp.OffersList.FindAll(x => x.Offercategory.Equals(myEmployee.userCv.Workcategory));

            foreach (var item in tmp)
            {
                Console.WriteLine(new string('-', 120));
                Console.WriteLine($"Title : {item.Offertitle} , Company :{item.Company} , Category :{item.Offercategory} , Jobinfo : {item.Jobnfo} , City : {item.City} , Salary : {item.Minsalary} , Age : {item.Age} , Study : {item.Study} , Experience : {item.Workexperience} , Number : {item.Phonenumber}");
                Console.WriteLine(new string('-', 120));
            }
        }



        public void Func1(Employer emp, string studychoice)
        {
            var listsearch = emp.OffersList.FindAll(x => x.Study == studychoice);

            foreach (var item in listsearch)
            {
                Console.WriteLine(new string('-', 120));
                Console.WriteLine($"Title : {item.Offertitle} , Company :{item.Company} , Category :{item.Offercategory} , Jobinfo : {item.Jobnfo} , City : {item.City} , Salary : {item.Minsalary} , Age : {item.Age} , Study : {item.Study} , Experience : {item.Workexperience} , Number : {item.Phonenumber}");
                Console.WriteLine(new string('-', 120));
            }
        }

        public void Func2(Employer emp, string citychoice)
        {
            var listsearch = emp.OffersList.FindAll(x => x.City.Equals(citychoice));

            foreach (var item in listsearch)
            {
                Console.WriteLine(new string('-', 120));
                Console.WriteLine($"Title : {item.Offertitle} , Company :{item.Company} , Category :{item.Offercategory} , Jobinfo : {item.Jobnfo} , City : {item.City} , Salary : {item.Minsalary} , Age : {item.Age} , Study : {item.Study} , Experience : {item.Workexperience} , Number : {item.Phonenumber}");
                Console.WriteLine(new string('-', 120));
            }
        }

        public void Func3(Employer emp, int salarychoice)
        {
            var listsearch = emp.OffersList.FindAll(x => x.Minsalary == salarychoice);

            foreach (var item in listsearch)
            {
                Console.WriteLine(new string('-', 120));
                Console.WriteLine($"Title : {item.Offertitle} , Company :{item.Company} , Category :{item.Offercategory} , Jobinfo : {item.Jobnfo} , City : {item.City} , Salary : {item.Minsalary} , Age : {item.Age} , Study : {item.Study} , Experience : {item.Workexperience} , Number : {item.Phonenumber}");
                Console.WriteLine(new string('-', 120));
            }
        }

        public void Func4(Employer emp, int expchoice)
        {
            var listsearch = emp.OffersList.FindAll(x => x.Workexperience == expchoice).ToList();

            foreach (var item in listsearch)
            {
                Console.WriteLine(new string('-', 120));
                Console.WriteLine($"Title : {item.Offertitle} , Company :{item.Company} , Category :{item.Offercategory} , Jobinfo : {item.Jobnfo} , City : {item.City} , Salary : {item.Minsalary} , Age : {item.Age} , Study : {item.Study} , Experience : {item.Workexperience} , Number : {item.Phonenumber}");
                Console.WriteLine(new string('-', 120));
            }
        }


    }




}






