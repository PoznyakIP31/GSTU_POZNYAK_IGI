using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Lab_1.Models;
using System.Collections;

namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {


            using (SportContext db = new SportContext())
            {
                DbInitializer.Initialize(db);
                Console.WriteLine("1");
                Print("Выборка данных из таблицы Инструкторы", db.Instructors.ToArray());
                Console.WriteLine("\n2\n");

                Print("Выборка данных с заданным условием из таблицы Инструкторы", db.Instructors.Where(a => a.Name == "Александр").ToArray());
                Console.WriteLine("\n3\n");

                var query1 = from o in db.Groups
                             group o.Count_of_visitor by o.GroupID into gr
                             select new
                             {
                                 groupsId = gr.Key,
                                 Количество_занятий = gr.Sum()
                             };
                Print("Выборка данных из таблицы стоящей на стороне 'многие':", query1.ToArray());
                Console.WriteLine("\n4\n");

                var query2 = from o in db.Instructors
                             join c in db.Groups
                             on o.InstructorID equals c.InstructorID
                             orderby c.Name descending
                             select new
                             {
                                 Имя = o.Name,
                                 Фамилия = o.Surname,
                                 Отчество = o.Midname,
                                 Id_группы = c.GroupID,
                                 Количество_посетителей = c.Count_of_visitor,
                                 
                             };

                Print("Выборка данных из двух таблиц стоящих на стороне 'один-ко-многим':", query2.ToArray());
                Console.WriteLine("\n5\n");

                int count = 16;
                var query3 = from i in db.Instructors
                             join g in db.Groups
                             on i.InstructorID equals g.InstructorID
                             where (g.Count_of_visitor >= count)
                             orderby g.Name descending
                             select new
                             {
                                 Имя = i.Name,
                                 Фамилия = i.Surname,
                                 Отчество = i.Midname,
                                 Id_группы = g.GroupID,
                                 Количество_посетителей = g.Count_of_visitor,
                             };

                Print("Выборка данных с условием по полям двух таблиц стоящих на стороне 'один-ко-многим':", query3.ToArray());
                Console.WriteLine("\n6\n");

                
                Instructor ins = new Instructor
                {
                    Name = "Василий",
                    Surname = "Александров",
                    Midname = "Андреевич",
                    Aducation = "Среднее",
                    Experience = 10
                };
                db.Instructors.Add(ins);                
                db.SaveChanges();
                Print("Таблица инструкторы после добавления записи: ", db.Instructors.ToArray());
                Console.WriteLine("\n7\n");
          
                Group group = new Group
                {
                    InstructorID=5,
                    Name = "6666",
                    Count_of_visitor = 20,
                    
                };
                db.Groups.Add(group);
                db.SaveChanges();
                Print("Таблица группы после добавления записи: ", db.Groups.ToArray());
                Console.WriteLine("\n8\n");

                var del = db.Instructors.Where(i => i.InstructorID == 8);
                db.Instructors.RemoveRange(del);
                db.SaveChanges();
                Print("Таблица инструкторы после удаления записи: ", db.Instructors.ToArray());

                Console.WriteLine("\n9\n");

                db.Groups.Remove(db.Groups.ToArray()[5]);
                db.SaveChanges();
                Print("Таблица группы после удаления записи: ", db.Groups.ToArray());

                Console.WriteLine("\n10\n");
                db.Instructors.SingleOrDefault(o => o.InstructorID == db.Instructors.First().InstructorID).Experience =5;
                db.SaveChanges();
                Print("Обновлённая таблица инструкторы", db.Instructors.ToArray());
            }
            
        }
        static void Print(string sqltext, IEnumerable items)
        {
            Console.WriteLine(sqltext);
            Console.WriteLine("Записи: ");
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
