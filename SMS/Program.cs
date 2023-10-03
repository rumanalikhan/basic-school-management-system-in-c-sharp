using System;
using System.IO;

namespace SMS
{
    class Program
    {
        public static string[] lines;
        public static string[] results;
        public static void Create(string sname, string spass, string sid)
        {
            string[] newlines = new string[lines.Length + 1];

            for (int i = 0; i < lines.Length; i++)
            {
                newlines[i] = lines[i];
            }

            newlines[newlines.Length - 1] = "\t" + sname + "\t" + spass + "\t" + sid;
            lines = newlines;
           
        }

        public static void Update(string sname, string spass, string sid)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                string[] cells = lines[i].Split('\t');
                if (cells[1] == sname)
                {
                    Console.WriteLine("Previously: " + lines[i]);

                    lines[i] = "\t" + sname + "\t" + spass + "\t" + sid;

                    Console.WriteLine("Updated: " + lines[i]);
                    
                }
            }
            //Console.WriteLine("Press 1 for exiting Or 2 for menue options");
            //int Opt = Convert.ToInt32(Console.ReadLine());
            //if (Opt == 1)
            //{
            //    Console.Clear();
            //    Exit();
            //}
            //else if (Opt == 2)
            //{
            //    Console.Clear();
            //    Smenue();
            //}
            //else
            //{
            //    Console.WriteLine("\t====================Invalid Input====================");
            //}
        }

        public static void Read(string sname)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                string[] cells = lines[i].Split('\t');
                if (cells[1] == sname)
                {
                    Console.WriteLine("\tName\tPassword\tSID");
                    Console.WriteLine(lines[i]);
                }
            }
           
        }

        public static void Delete(string sname)
        {
            string[] newlines = new string[lines.Length - 1];

            int lineno = 0;
            for (int i = 0; i < newlines.Length; i++)
            {
                string[] cells = lines[i].Split('\t');
                if (cells[1] != sname)
                {
                    newlines[lineno] = lines[i];

                }
            }
           
        }

        public static void OpenFile()
        {
            //Creating a file
            //string path = @"Slist.txt";
            //if (File.Exists(path) == false)
            //{
            //    File.CreateText(path);
            //}
            string path = @"Slist.txt";
            lines = File.ReadAllLines(path);
        }

        public static void Save()
        {
            string path = @"Slist.txt";
            File.WriteAllLines(path, lines);
        }

        public static void CombinedData()
        {
            string path = @"Slist.txt";
            lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine(lines[i]);
            }
            Console.WriteLine("Press 1 for exiting Or 2 for menue options");
            int Opt = Convert.ToInt32(Console.ReadLine());
            if (Opt == 1)
            {
                Console.Clear();
                Exit();
            }
            else if (Opt == 2)
            {
                Console.Clear();
                Tmenue();
            }
            else
            {
                Console.WriteLine("\t====================Invalid Input====================");
            }
        }

        public static void IndividualView()
        {
            string path = @"Slist.txt";
            lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] cells = lines[i].Split('\t');
                Console.WriteLine("Student Name:  " + cells[1]);
                Console.WriteLine("Student Password:  " + cells[1 + 1]);
                Console.WriteLine("SID: " + cells[1 + 2]);
                Console.WriteLine("============================================================");

            }
            Console.WriteLine("Press 1 for exiting Or 2 for menue options");
            int Opt = Convert.ToInt32(Console.ReadLine());
            if (Opt == 1)
            {
                Console.Clear();
                Exit();
            }
            else if (Opt == 2)
            {
                Console.Clear();
                Tmenue();
            }
            else
            {
                Console.WriteLine("\t====================Invalid Input====================");
            }
        }
        static void Main(string[] args)
        {

            Console.WriteLine("\t===================================================================");
            Console.WriteLine("\t==================== SCHOOL MANAGEMENT SYSTEM =====================");
            Console.WriteLine("\t===================================================================");
            Console.WriteLine("\t========================== Login Here =============================");
            Console.WriteLine("\t===================================================================");
            Console.WriteLine("\t\t\t\tLogin As Teacher.");
            Console.WriteLine("\t\t\t\tLogin As Student.");
            //user login options
            Console.Write("\t\tEnter 'E' if you are are new student and wants to enroll yourself.\n\t\tEnter 'T' if you want to login as a Teacher or\n\t\tEnter 'S' if you want to login as a Student: ");
            string OPT = Console.ReadLine();
            Console.Clear();
            switch (OPT)
            {
                //for student
                case "E":
                    OpenFile();
                    Console.Write("Enter Your Name: ");
                    string ename = Console.ReadLine();
                    Console.Write("Enter your password : ");
                    string epass = Console.ReadLine();
                    Console.Write("Enter Your SID: ");
                    string sid = Console.ReadLine();
                    Create(ename, epass, sid);
                    Save();
                    break;
                case "S":
                    Console.Write("Enter Your Name: ");
                    string sname = Console.ReadLine();
                    Console.Write("Enter Your Password: ");
                    string spass = Console.ReadLine();

                    //invoking login method for student
                    Slogin(sname, spass);
                    Smenue();
                    break;

                //for teachers
                case "T":
                    Console.Write("Enter Your Name: ");
                    string tname = Console.ReadLine();
                    Console.Write("Enter Your password: ");
                    string tpass = Console.ReadLine();
                    //invoking login method for teacher
                    Tlogin(tname, tpass);
                    Tmenue();
                    break;
                default:
                    Console.WriteLine("\n\t====================Invalid Input====================\n");
                    break;
            }
        }
        public static void Smenue()
        {
            Console.WriteLine("===================================================================");
            Console.WriteLine("------------------------ Select an option -------------------------");
            Console.WriteLine("===================================================================\n");
            Console.WriteLine("\t\tPress 1 for checking your details");
            Console.WriteLine("\t\tPress 2 for updating your details");
            Console.WriteLine("\t\tPress 3 for checking marks");
            Console.WriteLine("\t\tPress 4 for viewing grades");
            Console.WriteLine("\t\tPress 5 for checking attendence");
            Console.WriteLine("\t\tPress 6 for exiting");
            Console.WriteLine("\n===================================================================");
            string opt = Console.ReadLine();
            Console.Clear();
            switch (opt)
            {
                case "1":
                    OpenFile();
                    Console.Write("Student Name: ");
                    string sname = Console.ReadLine();
                    Read(sname);
                    Save();
                    break;
                case "2":
                    OpenFile();
                    Console.WriteLine(" Student Name:  ");
                    sname = Console.ReadLine();
                    Read(sname);
                    Console.WriteLine();
                    Console.WriteLine("Above is your Previous Data");
                    Console.WriteLine("================================");
                    Console.WriteLine(" Now you may Update your Data ");
                    Console.Write("Enter Your Name: ");
                    sname = Console.ReadLine();
                    Console.Write("Enter your password :  ");
                    string spass = Console.ReadLine();
                    Console.Write("Enter Your SID: ");
                    string sid = Console.ReadLine();
                    Update(sname, spass, sid);
                    Save();
                    break;

                case "3":
                    viewmarks();
                    break;
                case "4":
                    ViewGrades();
                    break;
                case "5":
                    viewatt();
                    break;
                case "6":
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\t====================Invalid Input====================");
                    break;
            }
        }
        public static void Tmenue()
        {
            Console.WriteLine("===================================================================");
            Console.WriteLine("------------------------ Select an option -------------------------");
            Console.WriteLine("===================================================================\n");
            Console.WriteLine("\t\tPress 1 for viewing students");
            Console.WriteLine("\t\tPress 2 for viewing students details individually");
            Console.WriteLine("\t\tPress 3 for marking");
            Console.WriteLine("\t\tPress 4 for grading");
            Console.WriteLine("\t\tPress 5 for marking attendence");
            Console.WriteLine("\t\tPress 6 for deleting a student");
            Console.WriteLine("\t\tPress 7 for exiting");
            Console.WriteLine("\n===================================================================");
            String opt = Console.ReadLine();
            Console.Clear();
            switch (opt)
            {
                case "1":
                    Console.WriteLine("Combined Data of All the Students");
                    Console.WriteLine("");
                    CombinedData();
                    break;
                case "2":
                    Console.WriteLine("Individual Data of Students");
                    Console.WriteLine();
                    IndividualView();
                    break;
                case "3":
                    marking();
                    break;
                case "4":
                    grades();
                    break;
                case "5":
                    attendence();
                    break;
                case "6":
                    OpenFile();
                    Console.Write(" Student Name: ");
                    string sname = Console.ReadLine();
                    Delete(sname);
                    Save();
                    break;
                case "7":
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\t====================Invalid Input====================");
                    break;
            }
        }

        public static void Slogin(string sname, string spass)
        {

            //writing text lines to our file 
            //lines = new string[5];
            //lines[0] = "\tRuman\tpass1\t12730";
            //Save();
            //compiling lines
            OpenFile();
            //checking names and passwords of student and then giving a break
            for (int i = 0; i < lines.Length; i++)
            {
                string[] cells = lines[i].Split('\t');
                if (cells[1] == sname && cells[1 + 1] == spass)
                {
                    break;
                }
            }
            bool found = false;
            //If found then giving access
            for (int i = 0; i < lines.Length; i++)
            {
                string[] cells = lines[i].Split('\t');
                if (cells[1] == sname && cells[1 + 1] == spass)
                {
                    Console.WriteLine("\n\t\t\0 ~Succeful Login~");
                    Console.WriteLine("\t\t\0 -----------------");
                    found = true;
                    //if yes then asking for ID
                    Console.Write("\tYou're are required to enter your Student ID\n\tfor verification: ");
                    string sid = Console.ReadLine();
                    Console.Clear();
                    //Checking Id is valid or not
                    if (sid == cells[1 + 2])
                    {
                        //entering in the class
                        Console.WriteLine("\t\t\t~Welcome To The Class~");
                        Console.WriteLine("\t\t\t-----------------------");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\t~Wrong SID~");
                        Console.WriteLine("\t-------------");
                        System.Environment.Exit(0);
                        break;

                    }
                }
            }
            //if not found don't allowing to enter in MS
            if (found != true)
            {
                Console.WriteLine("\t====================Invalid Input====================");
                //closing the program
                System.Environment.Exit(0);
            }
        }

        public static void TOpenFile()
        {
            string path = @"Tlist.txt";
            lines = File.ReadAllLines(path);
        }
        public static void TSave()
        {
            string path = @"Tlist.txt";
            File.WriteAllLines(path, lines);
        }
        public static void Tlogin(string tname, string tpass)
        {
            //Creating a file
            string path = @"Tlist.txt";
            if (File.Exists(path) == false)
            {
                File.CreateText(path);
            }

            //writing text lines to our file 
            lines = new string[3];
            lines[0] = "\tSir Zubair\tpass4";
            lines[1] = "\tSir Ubaid\tpass5";
            lines[2] = "\t\t";
            TSave();
            //compiling lines
            TOpenFile();
            //checking names and passwords of teachers and then giving a break
            for (int i = 0; i < lines.Length; i++)
            {
                string[] cells = lines[i].Split('\t');
                if (cells[1] == tname && cells[1 + 1] == tpass)
                {
                    break;
                }
            }
            bool found = false;
            //If found then giving access
            for (int i = 0; i < lines.Length; i++)
            {
                string[] cells = lines[i].Split('\t');
                if (cells[1] == tname && cells[1 + 1] == tpass)
                {
                    Console.WriteLine("\t~Succeful Login~");
                    Console.WriteLine("\t-----------------");
                    found = true;
                    break;
                }
            }
            //if not found don't allowing to enter in MS
            if (found != true)
            {
                Console.WriteLine("\tInvalid input");
                Console.WriteLine("===================================================================");
                //closing the program
                System.Environment.Exit(0);
            }
        }

        public static void AtOpenFile()
        {
            string path = @"Attendence.txt";
            lines = File.ReadAllLines(path);
        }

        public static void AtSave()
        {
            string path = @"Attendence.txt";
            File.WriteAllLines(path, lines);
        }
        public static void attendence()
        {
            string att;
            string path = @"Attendence.txt";
            if (File.Exists(path) == false)
            {
                File.CreateText(path);
            }
            Console.WriteLine("\tMark your attendence on call.");
            OpenFile();
            for (int i = 0; i < 3; i++)
            {
                string[] cells = lines[i].Split('\t');
                Console.Write("\t" + cells[1] + " : ");
                att = Console.ReadLine();
                lines[i] = "\t" + cells[1] + "\t" + att;
                AtSave();
                break;
            }
            Console.WriteLine("|Press 1 to exit Or 2 to return to menu|");
            int Opt = Convert.ToInt32(Console.ReadLine());
            if (Opt == 1)
            {
                Console.Clear();
                Exit();
            }
            else if (Opt == 2)
            {
                Console.Clear();
                Tmenue();
            }
            else
            {
                Console.WriteLine("\t====================Invalid Input====================");
            }
        }

        public static void viewatt()
        {
            AtOpenFile();
            //if we want to print lines on console
            Console.Write("\tEnter your name : ");
            string name = Console.ReadLine();
            for (int i = 0; i < 3; i++)
            {
                string[] cells = lines[i].Split('\t');
                if (cells[1] == name)
                {
                    Console.WriteLine("\tStatus :" + lines[i]);

                }
                break;
                
            }
            Console.WriteLine("|Press 1 to exit Or 2 to return to menu|");
            int Opt = Convert.ToInt32(Console.ReadLine());
            if (Opt == 1)
            {
                Console.Clear();
                Exit();
            }
            else if (Opt == 2)
            {
                Console.Clear();
                Smenue();
            }
            else
            {
                Console.WriteLine("\t====================Invalid Input====================");
            }

        }

        public static void MOpenFile()
        {
            string path = @"Marks.txt";
            results = File.ReadAllLines(path);
        }
        public static void MSave()
        {
            string path = @"Marks.txt";
            File.WriteAllLines(path, results);
        }
        public static void marking()
        {
            string path1 = @"Marks.txt";
            if (File.Exists(path1) == false)
            {
                File.CreateText(path1);
            }


            Console.Write("\tEnter the name of student : ");
            string sname = Console.ReadLine();
            Console.Write("\tEnter the ID of student : ");
            string sid = Console.ReadLine();
            OpenFile();
            for (int i = 0; i < lines.Length; i++)
            {
                string[] cells = lines[i].Split('\t');
                if (cells[1] == sname && cells[1 + 2] == sid)
                {
                    break;
                }
            }
            for (int i = 0; i < lines.Length; i++)
            {
                string[] cells = lines[i].Split('\t');
                if (cells[1] == sname && cells[1 + 2] == sid)
                {
                    results = new string[8];
                    Console.Write("\tEnter the marks of PF : ");
                    int pf = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\tEnter the marks of IICT : ");
                    int iict = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\tEnter the marks of VLM : ");
                    int vlm = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\tEnter the marks of PIS : ");
                    int pis = Convert.ToInt32(Console.ReadLine());
                    results[0] = "\t" + sname + "\t" + sid;
                    results[1] = "\t" + pf;
                    results[2] = "\t" + iict;
                    results[3] = "\t" + vlm;
                    results[4] = "\t" + pis;
                    MSave();
                }
            }
            Console.WriteLine("|Press 1 to exit Or 2 to return to menu|");
            int Opt = Convert.ToInt32(Console.ReadLine());
            if (Opt == 1)
            {
                Console.Clear();
                Exit();
            }
            else if (Opt == 2)
            {
                Console.Clear();
                Tmenue();
            }
            else
            {
                Console.WriteLine("\t====================Invalid Input====================");
            }
        }
        public static void viewmarks()
        {
            MOpenFile();
            Console.WriteLine("\tThe Marks of Student in respective courses are");
            Console.WriteLine("===========Marks Obtained=============");
            Console.WriteLine("\tSubject Name\tMarks");
            Console.WriteLine("\tPF\t" + results[1]);
            Console.WriteLine("\tIICT\t" + results[2]);
            Console.WriteLine("\tVLM\t" + results[3]);
            Console.WriteLine("\tPIS\t" + results[4]);
            Console.WriteLine("======================================\n");

            Console.WriteLine("|Press 1 to exit Or 2 to return to menu|");
            int Opt = Convert.ToInt32(Console.ReadLine());
            if (Opt == 1)
            {
                Console.Clear();
                Exit();
            }
            else if (Opt == 2)
            {
                Console.Clear();
                Smenue();
            }
            else
            {
                Console.WriteLine("\t====================Invalid Input====================");
            }
        }


        public static void GOpenFile()
        {
            string path = @"Grades.txt";
            results = File.ReadAllLines(path);
        }
        public static void GSave()
        {
            string path = @"Grades.txt";
            File.WriteAllLines(path, results);
        }
        public static int grades()
        {
            string path1 = @"Grades.txt";
            if (File.Exists(path1) == false)
            {
                File.CreateText(path1);
            }
            MOpenFile();
            results[0] = "================Grade================";
            GSave();
            Console.WriteLine("================Grade================");
            int pf = Convert.ToInt32(results[1]);
            int iict = Convert.ToInt32(results[2]);
            int vlm = Convert.ToInt32(results[3]);
            int pis = Convert.ToInt32(results[4]);
            int sum = pf + iict + vlm + pis;
            int p = sum * 100 / 400;
            if (p >= 80)
            {
                Console.WriteLine("\tPercentage " + p + "%\tA1 Grade ");
                results[1] = "\tPercentage " + p + "%\tA1 Grade ";
                GSave();
            }
            else if (p <= 79 && p >= 70)
            {
                Console.WriteLine("\tPercentage " + p + "%\tA Grade ");
                results[1] = "\tPercentage " + p + "%\tA Grade ";
                GSave();
            }
            else if (p <= 69 && p >= 60)
            {
                Console.WriteLine("\tPercentage " + p + "%\tB Grade ");
                results[1] = "\tPercentage " + p + "%\tB Grade ";
                GSave();
            }
            else if (p <= 59 && p >= 50)
            {
                Console.WriteLine("\tPercentage " + p + "%\tC Grade ");
                results[1] = "\tPercentage " + p + "%\tC Grade ";
                GSave();
            }
            else if (p <= 49 && p >= 40)
            {
                Console.WriteLine("\tPercentage " + p + "%\tD Grade ");
                results[1] = "\tPercentage " + p + "%\tD Grade ";
                GSave();
            }
            else
            {
                Console.WriteLine("\tYou are Failed");
                results[1] = "\tPercentage " + p + "%\tF";
                GSave();
            }
            Console.WriteLine("==========Course Wise Grades==========");
            Console.WriteLine("\tCourses\t\0Obt Marks\0Grades");
            int[] course = { pf, iict, vlm, pis };
            string[] cnames = { "PF", "IICT", "VLM", "PIS" };
            string[] grade = { "A1", "A", "B", "C", "F" };
            for (int i = 0; i < course.Length; i++)
            {
                results[2] = "\t==========Course Wise Grades==========";
                results[3] = "\tCourses\t\0Obt Marks\0Grades";
                GSave();
                if (course[i] >= 50 && course[i] <= 59)
                {
                    Console.WriteLine("\t" + cnames[i] + "\t\0\0" + course[i] + "\t\tC");
                    results[4] = "\t" + cnames[i] + "\t\0\0" + course[i] + "\t\t" + grade[3];
                    GSave();
                }
                else if (course[i] >= 60 && course[i] <= 69)
                {
                    Console.WriteLine("\t" + cnames[i] + "\t\0\0" + course[i] + "\t\tB");
                    results[5] = "\t" + cnames[i] + "\t\0\0" + course[i] + "\t\t" + grade[2];
                    GSave();
                }
                else if (course[i] >= 70 && course[i] <= 79)
                {
                    Console.WriteLine("\t" + cnames[i] + "\t\0\0" + course[i] + "\t\tA");
                    results[6] = "\t" + cnames[i] + "\t\0\0" + course[i] + "\t\t" + grade[1];
                    GSave();
                }
                else if (course[i] >= 80 && course[i] <= 99)
                {
                    Console.WriteLine("\t" + cnames[i] + "\t\0\0" + course[i] + "\t\tA1");
                    results[7] = "\t" + cnames[i] + "\t\0\0" + course[i] + "\t\t" + grade[0];
                    GSave();
                }
                else
                {
                    Console.WriteLine("\t" + cnames[i] + "\t\0\0" + course[i] + "\t\tF");
                    results[8] = "\t" + cnames[i] + "\t\0\0" + course[i] + "\t\t" + grade[4];
                    GSave();
                }
            }
            Console.WriteLine("======================================");
            Console.WriteLine("|Press 1 to exit Or 2 to return to menu|");
            int Opt = Convert.ToInt32(Console.ReadLine());
            if (Opt == 1)
            {
                Console.Clear();
                Exit();
            }
            else if (Opt == 2)
            {
                Console.Clear();
                Tmenue();
            }
            else
            {
                Console.WriteLine("\t====================Invalid Input====================");
            }
            return p;

        }
        public static void ViewGrades()
        {
            GOpenFile();
            for (int i = 0; i < results.Length; i++)
            {
                Console.WriteLine(results[i]);
            }
            Console.WriteLine("|Press 1 to exit Or 2 to return to menu|");
            int Opt = Convert.ToInt32(Console.ReadLine());
            if (Opt == 1)
            {
                Console.Clear();
                Exit();
            }
            else if (Opt == 2)
            {
                Console.Clear();
                Smenue();
            }
            else
            {
                Console.WriteLine("\t====================Invalid Input====================");
            }
        }

        public static void Exit()
        {
            Console.WriteLine("===================================================================");
            Console.WriteLine("\t------------------------ ~Thank You~ -----------------------------");
            Console.WriteLine("===================================================================");
            System.Environment.Exit(0);
        }
    }
}