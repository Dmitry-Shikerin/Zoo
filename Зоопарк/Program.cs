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
        public Animal(string name, string gender, string sound)
        {
            Name = name;
            Gender = gender;
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
        public int AnimalsCount { get; private set; }

        public Animal CreateRandom(int index)
        {
            string[] genders = { "Мальчик", "Девочка" };

            int randomGender = Utils.GetRandomValue(genders.Length);


            List<Animal> animals = new List<Animal>()
            {
                new Animal("Горилла", genders[randomGender], "Бьет в грудь"),
                new Animal("Тигр", genders[randomGender], "Ррраааау"),
                new Animal("Лошадь", genders[randomGender], "Иииигого"),
                new Animal("Змея", genders[randomGender], "Шшшшссссссссс"),
                new Animal("Кролик", genders[randomGender], "Хрум-Хрум"),
                new Animal("Ястреб", genders[randomGender], "Каррррррррррр"),
            };

            AnimalsCount = animals.Count;

            return animals[index];
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
        private AnimalFactory _animalFactory = new AnimalFactory();

        public Aviary CreateRandomAnimals()
        {
            List<Animal> animals = new List<Animal>();

            //int animalsCount = 6;
            int randomIndex = Utils.GetRandomValue(_animalFactory.AnimalsCount);

            int minAvairySize = 3;
            int maxAvairySize = 7;
            int avairySize = Utils.GetRandomValue(minAvairySize, maxAvairySize);

            for (int i = 0; i < avairySize; i++)
            {
                Animal animal = _animalFactory.CreateRandom(randomIndex/*, out animalsCount*/);
                animals.Add(animal);
            }

            return new Aviary(animals);
        }
    }

    class Zoo
    {
        private AviaryFaсtory _aviaryFaсtory = new AviaryFaсtory();

        private List<Aviary> _aviarys = new List<Aviary>();

        public void CreateAviarys()
        {
            int minRandomValueAviarys = 3;
            int maxRandomValueAviarys = 7;
            int randomNumberAviarys = Utils.GetRandomValue(minRandomValueAviarys, maxRandomValueAviarys);

            for (int i = 0; i < randomNumberAviarys; i++)
            {
                _aviarys.Add(_aviaryFaсtory.CreateRandomAnimals());
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


