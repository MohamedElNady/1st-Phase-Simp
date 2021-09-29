using System;
using System.Threading;

namespace SchoolSDAProject
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolFunctions school = new SchoolFunctions();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "------ Rainbow School ------"));
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "                      ------ Created By Mohamedashash27@gmail.com ------"));
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "------ Created For SDA.Simplilearn ------"));

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n \n > Rainbow School System for teachers data [GET], [Create], [Search]  and [Update]\n");
            bool BoolValue = true;
            while (BoolValue)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n     Select Number  ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n 1- Get All Teachers \n 2- Add Teacher \n 3- Search for Teacher \n 4- Update Teacher informations  \n 5- Exit");

                int? select = null;
                try
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("                > ");
                    int SelectedService = int.Parse(Console.ReadLine());
                    select = SelectedService;
                }
                catch (Exception C0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(C0.Message.ToString());
                    
                }
                switch (select)
                {
                    case 2:

                        try
                        {
                            Console.Write("Enter ID : ");
                            int Id = int.Parse(Console.ReadLine());
                            Console.Write("Enter teacher Name : ");
                            string name = Console.ReadLine();
                            Console.Write("Class Name : ");
                            string _class = Console.ReadLine();
                            Console.Write("Section Name : ");
                            string section = Console.ReadLine();
                            school.AddTeacher(Id, name, _class, section);

                        }
                        catch (Exception C1)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine( C1.Message.ToString());

                        }
                        break;

                    case 3:
                        Console.Write("Insert the ID to Search > ");
                        int id_ToSearch = int.Parse(Console.ReadLine());
                        Teacher teacherSearch = school.GetTeacher(id_ToSearch);
                        if (teacherSearch != null)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(" > Teacher data has been Retrieved");
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine($" > ID:{teacherSearch.ID}\n > Name: {teacherSearch.Name}\n > Class: {teacherSearch.Class}\n > Section: {teacherSearch.Section}");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine($"\ninserted ID:{id_ToSearch} may be wrong try other one");
                        }
                        break;
                    case 4:
                        Console.Write("Insert the ID of teacher to Update > ");
                        int oldID = int.Parse(Console.ReadLine());
                        Teacher teacherUpdate = school.GetTeacher(oldID);
                        if (teacherUpdate != null)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(" > Teacher data retrieved To Update");
                            Console.ForegroundColor = ConsoleColor.DarkCyan;

                            Console.WriteLine($"> ID: {teacherUpdate.ID}\n> Name: {teacherUpdate.Name}\n> Class: {teacherUpdate.Class}\n> Section: {teacherUpdate.Section}");
                            Console.WriteLine("\n> Insert the new informations : ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            int old_id = teacherUpdate.ID;
                            Console.Write("\n> Insert new ID : ");
                            int new_id = int.Parse(Console.ReadLine());
                            Console.Write("> Insert new Name : ");
                            string new_name = Console.ReadLine();
                            Console.Write("> Enter the new Class : ");
                            string new_class = Console.ReadLine();
                            Console.Write("> Enter the new Section : ");
                            string new_section = Console.ReadLine();
                            school.UpdateTeacher(old_id, new_id, new_name, new_class, new_section);
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine($"\ninserted ID:{ oldID} may be wrong try other one");
                        }
                        break;
                    case 5:
                        BoolValue = false;
                       
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\n::::::::::::::::::::::::::::: Goodbye ::::::::::::::::::::::::::::: ");
                        Thread.Sleep(2000);
                        break;
                    case 1:
                      
                        var AllTeachers = school.GetAllTeacher();
                        if (AllTeachers != null)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(" > Teachers data has been Retrieved");
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            if (AllTeachers.Length == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("No Avaliable Teachers Please Add Some");
                            }
                            else
                            {
                                foreach (var tech in AllTeachers)
                                {

                                    Console.WriteLine(tech);
                                }
                            }
                            
  
                        }
                        
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(" Welcome, How Can We Help?:");

                        break;

                }
            }
        }
    }

}
