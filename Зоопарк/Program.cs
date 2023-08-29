using System;
using System.Collections.Generic;

namespace Зоопарк
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();

            zoo.Work();
        }
    }

    class Animal
    {
        public Animal(string name, string sound)
        {
            Name = name;
            Gender = AnimalFactory.CreateRandomGender();
            Sound = sound;
        }

        public string Name { get; private set; }
        public string Gender { get; private set; }
        public string Sound { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name}, {Gender}, {Sound}");
        }
    }

    class AnimalFactory
    {
        private List<Animal> _animals;

        public AnimalFactory()
        {
            _animals = new List<Animal>()
            {
                new Animal("Горилла", "Бьет в грудь"),
                new Animal("Тигр", "Ррраааау"),
                new Animal("Лошадь", "Иииигого"),
                new Animal("Змея", "Шшшшссссссссс"),
                new Animal("Кролик", "Хрум-Хрум"),
                new Animal("Ястреб", "Каррррррррррр"),
            };
        }

        public static string CreateRandomGender()
        {
            string[] genders = { "Мальчик", "Девочка" };

            int randomGender = Utils.GetRandomValue(genders.Length);

            return genders[randomGender];
        }

        public List<Animal> CreateRandomAnimals()
        {
            List<Animal> animals = new List<Animal>();

            int minSizeList = 3;
            int maxSizeList = 7;
            int randomSize = Utils.GetRandomValue(minSizeList, maxSizeList);

            int randomIndex = Utils.GetRandomValue(_animals.Count);

            for (int i = 0; i < randomSize; i++)
            {

                animals.Add(_animals[randomIndex]);
            }

            return animals;
        }

    }

    class Aviary
    {
        private List<Animal> _animals = new List<Animal>();

        public Aviary(List<Animal> animals)
        {
            _animals = animals;
        }

        public List<Animal> Animals => new List<Animal>(_animals);

        public void ShowInfo()
        {
            for (int i = 0; i < _animals.Count; i++)
            {
                _animals[i].ShowInfo();
            }
        }
    }

    class AviaryFaсtory
    {
        public Aviary Create()
        {
            AnimalFactory animalFactory = new AnimalFactory();
            List<Animal> animals = new List<Animal>();

            animals = animalFactory.CreateRandomAnimals();

            return new Aviary(animals);
        }
    }

    class Zoo
    {

        private List<Aviary> _aviarys = new List<Aviary>();

        public void CreateAviarys()
        {
            AviaryFaсtory aviaryFaсtory = new AviaryFaсtory();

            int minRandomValueAviarys = 3;
            int maxRandomValueAviarys = 7;
            int randomNumberAviarys = Utils.GetRandomValue(minRandomValueAviarys, maxRandomValueAviarys);

            for (int i = 0; i < randomNumberAviarys; i++)
            {
                _aviarys.Add(aviaryFaсtory.Create());
            }
        }

        public void Work()
        {
            CreateAviarys();

            do
            {
                Console.Clear();

                for (int i = 0; i < _aviarys.Count; i++)
                {
                    Console.WriteLine($"Подойти к вальеру номер {i + 1}");
                }

                int aviaryIndex = ReadIndex() - 1;

                _aviarys[aviaryIndex].ShowInfo();
            }
            while (TryExite() == false);
        }

        private bool TryExite()
        {
            bool result = false;
            string completeProgram = "exit";

            Console.WriteLine($"Для завершения программы введите - {completeProgram}");
            string userInput = Console.ReadLine();

            if (userInput == completeProgram)
            {
                result = true;
                return result;
            }

            return result;
        }

        private int ReadIndex()
        {
            int number = 0;

            bool result = false;

            while (result == false)
            {
                result = int.TryParse(Console.ReadLine(), out number);

                if (result == false)
                {
                    Console.WriteLine("Ошибка. Введите год.");
                }
            }

            return number;
        }
    }
    public static class Utils
    {
        private static Random _random = new Random();

        public static int GetRandomValue(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }

        public static int GetRandomValue(int value)
        {
            return _random.Next(value);
        }
    }
}


