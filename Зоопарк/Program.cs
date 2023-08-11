using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Зоопарк
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();

            zoo.CreateAviarys();

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
        //сделать свойство каунта

        public Animal CreateRandom(int index/*, out int animalsCount*/)
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

            //animalsCount = animals.Count;

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

            int animalsCount = 6;
            int randomIndex = Utils.GetRandomValue(animalsCount);

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
        //private List<Animal> _animals = new List<Animal>();

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
            //_aviaryFaсtory.CreateRandom();

            for (int i = 0; i < _aviarys.Count; i++)
            {
                Console.WriteLine($"Подойти к вальеру номер {i + 1}");
            }

            int aviaryIndex = ReadIndex() - 1;

            for (int i = 0; i < _aviarys[aviaryIndex].Animals.Count; i++)  //Правильно ли я обращаюсь?
            {
                _aviarys[aviaryIndex].ShowInfo();
            }

        }

        static int ReadIndex()
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


