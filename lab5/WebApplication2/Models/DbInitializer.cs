using System;
using System.Linq;

namespace Lab_1.Models
{
    public static class DbInitializer
    {
        public static void Initialize(SportContext db)
        {
            db.Database.EnsureCreated();

            if (db.Visitors.Any())
            {
                return;   // База данных инициализирована
            }

            int visitors_number = 35;
            int groups_number = 10;
            int instructors_number = 10;
            int timetables_number = 10;
            string name;
            string surname;
            string midname;
            string nameins;
            string surnameins;
            string midnameins;
            string passport;
            string name_group;
            int visitor_count;
            string aducation;
            int experience;
            int days;
            string times;


            Random randObj = new Random(1);
            //Заполнение таблицы instructors
            string[] names_voc = { "Василий", "Андрей", "Максим", "Станислав", "Александр" };
            string[] surnames_voc = { "Анелькин", "Астапенко", "Михалев", "Антимоник", "Кириллов" };
            string[] midnames_voc = { "Иванович", "Андреевич", "Максимович", "Александрович", "Станиславович" };
            string[] aducation_voc = { "Высшее", "Среднее" };
            int count_names_voc = names_voc.GetLength(0);
            int count_surnames_voc = surnames_voc.GetLength(0);
            int count_midnames_voc = midnames_voc.GetLength(0);
            int count_aducation_voc = aducation_voc.GetLength(0);


            for (int instructorID = 1; instructorID <= instructors_number; instructorID++)
            {

                nameins = names_voc[randObj.Next(count_names_voc)];
                surnameins = surnames_voc[randObj.Next(count_surnames_voc)];
                midnameins = midnames_voc[randObj.Next(count_midnames_voc)];
                aducation = aducation_voc[randObj.Next(count_aducation_voc)];
                experience = randObj.Next(1, 20);
                db.Instructors.Add(new Instructor { Name = nameins, Surname = surnameins, Midname = midnameins, Aducation = aducation, Experience = experience });
            }

            db.SaveChanges();
            ////Groups


            for (int groupID = 1; groupID <= groups_number; groupID++)
            {
                int instructorID = randObj.Next(1, instructors_number - 1);
                name_group = Convert.ToString(randObj.Next(1000, 8000)); ;
                visitor_count = randObj.Next(10, 20);


                db.Groups.Add(new Group { InstructorID = instructorID, Name = name_group, Count_of_visitor = visitor_count });
            }

            db.SaveChanges();
            //Заполнение таблицы visitors
            string[] name_voc = { "Василий", "Андрей", "Максим", "Станислав", "Александр" };
            string[] surname_voc = { "Иванов", "Андреев", "Максимов", "Александров", "Станиславов" };
            string[] midname_voc = { "Иванович", "Андреевич", "Максимович", "Александрович", "Станиславович" };
            int count_name_voc = name_voc.GetLength(0);
            int count_surname_voc = surname_voc.GetLength(0);
            int count_midname_voc = midname_voc.GetLength(0);


            for (int visitorID = 1; visitorID <= visitors_number; visitorID++)
            {
                int groupID = randObj.Next(1, groups_number - 1);
                name = name_voc[randObj.Next(count_name_voc)];
                surname = surname_voc[randObj.Next(count_surname_voc)];
                midname = midname_voc[randObj.Next(count_midname_voc)];
                passport = Convert.ToString(randObj.Next(1000000, 9999999));
                db.Visitors.Add(new Visitor { Name = name, Surname = surname, Midname = midname, GroupID = groupID, Passport = passport });
            }

            db.SaveChanges();

            //Заполнение таблицы timetables
            string[] times_voc = { "14:00", "18:00", "20:00", "22:00", "16:00" };
            //string[] days_voc = { "Понедельник", "Вторник","Среда","Четверг","Пятница" };
            int count_times_voc = name_voc.GetLength(0);
            //int count_days_voc = surname_voc.GetLength(0);
            for (int timetableID = 1; timetableID <= timetables_number; timetableID++)
            {
                //days = days_voc[randObj.Next(count_days_voc)];
                days = randObj.Next(1, 5);
                times = times_voc[randObj.Next(count_times_voc)];
                int groupID = randObj.Next(1, groups_number - 1);
                db.Timetables.Add(new TimeTable { GroupID = groupID, Days_of_the_week = days, Time_visits = times });
            }

            db.SaveChanges();
        }
    }
}

