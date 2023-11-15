using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticsModule5
{
    internal class Program
    {
        static bool Check(string CheckValue, out int value)//Проверка введенных значений
        {
            bool result = int.TryParse(CheckValue, out value);

            if (value <= 0)
            {
                Console.WriteLine("Введено неверное значение");
                return false;
            }
            else
            {
                return result;
            }
        }
        static string[] Arr(int value)//Заполнение массива
        {
            string[] Array = new string[value];


            for (int i = 0; i < Array.Length; i++)
            {
                Array[i] = Console.ReadLine();
            }
            return Array;
        }
        static void ShowAnketa((string Name, string Surname, int Age, string[] Pets, string[] FavColors) User)
        {
            Console.WriteLine("\nАнкета пользователя");
            Console.WriteLine("Имя - " + User.Name);
            Console.WriteLine("Фамилия - " + User.Surname);
            Console.WriteLine("Возраст - " + User.Age);
            Console.WriteLine("Информация о питомцах:");
            for (int i = 0; i < User.Pets.Length; i++)
            {
                Console.WriteLine(User.Pets[i]);
            }
            Console.WriteLine("Любимые цвета:");
            for (int i = 0; i < User.FavColors.Length; i++)
            {
                Console.WriteLine(User.FavColors[i]);
            }
        }//Вывод кортежа в консоль
        static (string, string, int, string[], string[]) Anketa()//Заполнение кортежа
        {
            string CheckValue; //Получает введенные int значения для проверки
            int SizeArray; //Получает количество элеметнов для массивов

            (string Name, string Surname, int Age, string[] Pets, string[] FavColors) User;
            Console.WriteLine("Здравствуйте! Введите Ваше имя");
            User.Name = Console.ReadLine();
            Console.WriteLine("Введите фамилию");
            User.Surname = Console.ReadLine();

            do
            {
                Console.WriteLine("Введите возраст");
                CheckValue = Console.ReadLine();
            }
            while (!Check(CheckValue, out User.Age));

            Console.WriteLine("Есть ли у Вас питомец? Да или Нет");
            var Pet = Console.ReadLine();
            if (Pet == "Да")
            {
                do
                {
                    Console.WriteLine("Введите количество питомцев");
                    CheckValue = Console.ReadLine();
                }
                while (!Check(CheckValue, out SizeArray));
                Console.WriteLine("Введите имена питомцев");
                User.Pets = Arr(SizeArray);
            }
            else
            {
                User.Pets = new string[1];
                User.Pets[0] = "У пользователя нет питомцев";
            }

            do
            {
                Console.WriteLine("Введите количество любимых цветов");
                CheckValue = Console.ReadLine();
            }
            while (!Check(CheckValue, out SizeArray));
            Console.WriteLine("Введите любимые цвета");
            User.FavColors = Arr(SizeArray);


            return User;
        }
        static void Main(string[] args)
        {
            var User = Anketa();

            ShowAnketa(User);
        }
    }
}
