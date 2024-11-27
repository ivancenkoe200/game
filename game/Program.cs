using System;
class Program
{
    static string PlayerName;
    static bool HasKey = false;
    static bool HasPickLock = false;
    static bool[] artifactsFound = new bool[3];
    static void Main(string[] args)
    {
        StartGame();
    }
    static void StartGame()
    {
        Console.WriteLine(" Вы проснулись в комнате и пытаетесь вспомнить свое имя. ");
        Console.Write(" Как вас зовут?: ");
        PlayerName = Console.ReadLine();
        Console.WriteLine($" Добро пожаловать, {PlayerName}!");
        while (true)
        {
            Console.WriteLine(" \nДействия:");
            Console.WriteLine("1. Открыть дверь ");
            Console.WriteLine("2. Заглянуть под кровать");
            Console.WriteLine("3. Открыть ящик в углу комнаты");
            Console.WriteLine("4. Открыть вентиляцию");
            Console.WriteLine("5. Взглянуть на тумбочку");
            Console.WriteLine("6. Взглянуть на статую рядом с дверью");
            Console.WriteLine(" Введите номер действия (или 'Выход' для выхода):");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    OpenDoor();
                    break;
                case "2":
                    LookUnderBed();
                    break;
                case "3":
                    OpenBox();
                    break;
                case "4":
                    OpenVentilation();
                    break;
                case "5":
                    LookAtNightstand();
                    break;
                case "6":
                    LookAtStatue();
                    break;
                case "Выход":
                    Console.WriteLine("Вы покидаете игру.");
                    return;
                default:
                    Console.WriteLine("Неверный ввод. Попробуйте еще раз.");
                    break;
            }
        }
    }
    static void OpenDoor()
    {
        if (HasPickLock)
        {
            Console.WriteLine($" {PlayerName}, вы выбрались!");
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine($"{PlayerName},дверь закрыта. Вам нужна отмычка.");
        }
    }
    static void LookUnderBed()
    {
        if (!artifactsFound[0])
        {
            artifactsFound[0] = true;
            Console.WriteLine($"{PlayerName}, вы нашли первый артефакт. ");
        }
        else
        {
            Console.WriteLine($"{PlayerName}, под кроватью ничего нет");
        }
    }
    static void OpenBox()
    {
        if (HasKey)
        {
            HasPickLock = true;
            Console.WriteLine($"{PlayerName}, вы открыли ящик и нашли отмычку");
        }
        else
        {
            Console.WriteLine($"{PlayerName}, ящик закрыт. Активируете статую, чтобы получить ключ. ");
        }
    }
    static void OpenVentilation()
    {
        int attempts = 0;
        while (true)
        {
            if (artifactsFound[1])
            {
                Console.WriteLine($"{PlayerName}, вы нашли артефакт. ");
                break;
            }
            Console.Write(" Попробуйте открыть вентиляцию. ");
            string input = Console.ReadLine();
            if (input.ToLower() == "стоп")
            {
                break;
            }
            attempts++;
            if (attempts == 3)
            {
                artifactsFound[1] = true;
                Console.WriteLine($"{PlayerName}, вы нашли второй артефакт. ");
                break;
            }
        }
    }
    static void LookAtNightstand()
    {
        if (!artifactsFound[2])
        {
            artifactsFound[2] = true;
            Console.WriteLine($"{PlayerName}, вы нашли третий артефакт. ");
        }
        else
        {
            Console.WriteLine($"{PlayerName}, ничего нет. ");
        }
    }
    static void LookAtStatue()
    {
        if (artifactsFound[0] && artifactsFound[1] && artifactsFound[2])
        {
            HasKey = true;
            Console.WriteLine($"{PlayerName}, вы активировали статую и получили ключ!");
        }
        else
        {
            Console.WriteLine($"{PlayerName}, вам нужно собрать три артефакта. ");
        }
    }
}