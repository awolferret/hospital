using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Hospital hospital = new Hospital(); 
        }
    }

    class Hospital
    {
        private List<Patient> _patients = new List<Patient>();

        public Hospital()
        {
            CreatePatients();
            ChooseSorting();
        }

        private void ChooseSorting()
        {
            Console.WriteLine("1. Отсортировать всех больных по имени");
            Console.WriteLine("2. Отсортировать всех больных по возрасту");
            Console.WriteLine("3. Вывести больных с определенным заболеванием");
            Console.WriteLine("4. Выход");
            bool isWorking = true;

            while (isWorking)
            {
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        SortByName();
                        break;
                    case "2":
                        SortByAge();
                        break;
                    case "3":
                        SearchDisease();
                        break;
                    case "4":
                        isWorking = false;
                        break;
                    default:
                        Console.WriteLine("Ошибка");
                        break;
                }
            }
        }

        private void SortByName()
        {
            var nameSorted = _patients.OrderBy(patient => patient.Name);
            ShowInfo(nameSorted.ToList());
        }

        private void SortByAge()
        { 
            var ageSorted = _patients.OrderBy(patient => patient.Age);
            ShowInfo(ageSorted.ToList());
        }

        private void SearchDisease()
        {
            Console.WriteLine("Введите искомое заболевание");
            string input = Console.ReadLine();
            var diseaseSearched = _patients.Where(patient => patient.Disease == input);
            ShowInfo(diseaseSearched.ToList());
        }

        private void ShowInfo(List<Patient> list)
        {
            Console.WriteLine("Список: ");

            foreach (var patient in list)
            {
                Console.WriteLine($"{patient.Name} возраст: {patient.Age} заболевание: {patient.Disease}");
            }
        }

        private void CreatePatients()
        {
            _patients.Add(new Patient("Аркадий", 18 , "Простуда"));
            _patients.Add(new Patient("Александр", 21, "Ангина"));
            _patients.Add(new Patient("Вечаслав", 18, "Перелом"));
            _patients.Add(new Patient("Юля", 24, "Грипп"));
            _patients.Add(new Patient("Екатерина", 10, "Простуда"));
            _patients.Add(new Patient("Стас", 18, "Перелом"));
            _patients.Add(new Patient("Тимур", 29, "Простуда"));
            _patients.Add(new Patient("Кирилл", 45, "Ангина"));
            _patients.Add(new Patient("Даниил", 50, "Простуда"));
            _patients.Add(new Patient("Евгений", 38, "Грипп"));
        }
    }

    class Patient
    { 
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }

        public Patient(string name, int age, string disease)
        {
            Name = name;
            Age = age;
            Disease = disease;
        }
    }
}