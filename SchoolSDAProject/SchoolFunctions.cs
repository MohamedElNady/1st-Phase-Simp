using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SchoolSDAProject
{
    class SchoolFunctions
    {
        private readonly string path;
        StreamWriter writer;
        public SchoolFunctions()
        {
            path = @"D:\.Net Course\App\SchoolSDAProject\School.txt";
            if (!File.Exists(path))
            {
                var myFile = File.Create(path);
                myFile.Close();
            }
        }


        public void AddTeacher(int id, string name, string Class, string section)
        {
            writer = File.AppendText(path);
            string value = id + "-" + name + "-" + Class + "-" + section + "\n";
            writer.Write(value);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" > Teacher data has been Added");
            writer.Close();
        }
        public string[] GetAllTeacher()
        {
            var lines = File.ReadAllLines(path);

            return lines;
        }

        public Teacher GetTeacher(int id)
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string s in lines)
            {
                string[] line = s.Split('-');
                try
                {
                    if (int.Parse(line[0]) == id)
                    {
                        Teacher teacher = new Teacher
                        {
                            ID = int.Parse(line[0]),
                            Name = line[1],
                            Class = line[2],
                            Section = line[3]
                        };
                        return teacher;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message.ToString());
                }
            }
            return null;
        }


        public void UpdateTeacher(int oldID, int NewId, string NewName, string NewClass, string NewSection)
        {
            string[] lines = File.ReadAllLines(path);
            bool status = false;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] line = lines[i].Split('-');
                if (int.Parse(line[0]) == oldID)
                {
                    lines[i] = NewId + "-" + NewName + "-" + NewClass + "-" + NewSection;
                    status = true;
                }
            }
            if (status)
            {
                File.WriteAllLines(path, lines);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" > Teacher data has been Updated");
            }


        }


    }

}
