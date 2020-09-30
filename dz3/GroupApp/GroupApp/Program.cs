using System;
using System.Collections.Generic;
using System.Text.Encodings;

namespace GroupApp
{
    class Program
    {
        private abstract class Student
        {
            public string Name { get; set; }
            public string State { get; set; } 

            public Student(string name)
            {
                this.Name = name;
                this.State = "";
            }

            public void Read()
            {
                this.State += "Read ";
            }

            public void Write()
            {
                this.State += "Write ";
            }

            public void Relax()
            {
                this.State += "Relax "; 
            }

            public abstract void Study();
        } 

        private class GoodStudent : Student
        {
            public GoodStudent(string name) : base(name)
            {
                this.State = "good ";
            }

            public override void Study()
            {
                this.Read();
                this.Write();
                this.Read();
                this.Write();
                this.Relax();
            }
        }

        private class BadStudent : Student
        {
            public BadStudent(string name) : base(name)
            {
                this.State = "bad ";
            }

            public override void Study()
            {
               this.Relax();
               this.Relax();
               this.Relax();
               this.Relax();
               this.Read();
            }
        }

        private class Group
        {
            public string Name { get; set; }
            public List<Student> Students { get; set; }

            public Group(string name)
            {
                this.Name = name;
                this.Students = new List<Student>();
            }

            public void AddStudent(Student student)
            {
                this.Students.Add(student);
            }

            public void Study()
            {
                foreach(Student student in this.Students)
                {
                    student.Study();
                }
            }

            public void GetInfo()
            {
                Console.Write($"{this.Name} ");
                foreach(Student student in this.Students)
                {
                    Console.Write($"{student.Name} ");
                }
                Console.Write("\n");
            }

            public void GetFullInfo()
            {
                Console.WriteLine($"{this.Name} ");
                foreach (Student student in this.Students)
                {
                    Console.WriteLine($"{student.Name} {student.State}");
                }
                Console.Write("\n");
            }
        }

        static void Main(string[] args)
        {
            bool exit = false;
            Console.WriteLine("Максим Ошийко К-24");

            while (!exit)
            {
                Console.Write("Введiть назву групи: ");
                string groupName = Console.ReadLine();

                Console.Write("Введiть iмена 3 студентiв через пробiл: ");
                string[] studentNames = Console.ReadLine().Split(' ');
                
                Group group = new Group(groupName);
                group.AddStudent(new GoodStudent(studentNames[0]));
                group.AddStudent(new BadStudent(studentNames[1]));
                group.AddStudent(new GoodStudent(studentNames[2]));

                group.Study();

                Console.WriteLine("Бажаєте переглянути часткову(1) чи повну(2) iнформацiю? ");
                int num = Int32.Parse(Console.ReadLine());

                if(num == 1)
                {
                    group.GetInfo();
                }
                else
                {
                    group.GetFullInfo();
                }

                Console.WriteLine("Бажаєте створити нову групу(1) чи завершити виконання програми(2)?");
                num = Int32.Parse(Console.ReadLine());

                if(num == 2)
                {
                    exit = true;
                }
                else
                {
                    exit = false;
                }
            }

            Console.WriteLine("Программа завершена.");
        }
    }
}
