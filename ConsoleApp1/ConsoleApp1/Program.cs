using System;
using System.Collections.Generic;

class Worker
{
    public string Name { get; set; }
    public double Bonus { get; set; }
    public double BonusInUSD { get; set; } 
    public double BonusInEUR { get; set; } 

 
    public void EnterBonus()
    {
        Console.WriteLine("Виберіть валюту для введення премії:");
        Console.WriteLine("1. Гривня (UAH)");
        Console.WriteLine("2. Долар (USD)");
        Console.WriteLine("3. Євро (EUR)");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.Write("Введіть премію в Гривнях: ");
                Bonus = double.Parse(Console.ReadLine());
                break;
            case 2:
                Console.Write("Введіть премію в Доларах: ");
                BonusInUSD = double.Parse(Console.ReadLine());
                break;
            case 3:
                Console.Write("Введіть премію в Євро: ");
                BonusInEUR = double.Parse(Console.ReadLine());
                break;
            default:
                Console.WriteLine("Невірний вибір.");
                break;
        }
    }

    public void DisplayBonus()
    {
        Console.WriteLine($"{Name} - Премія в Гривнях: {Bonus}, Долари: {BonusInUSD}, Євро: {BonusInEUR}");
    }
}

class Program
{
    static void Main()
    {
        Dictionary<int, Worker> workers = new Dictionary<int, Worker>();

        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Додати працівника");
            Console.WriteLine("2. Ввести премію для працівника");
            Console.WriteLine("3. Вивести інформацію про премію працівників");
            Console.WriteLine("4. Видалити працівника");
            Console.WriteLine("5. Переглянути кількість працівників");
            Console.WriteLine("6. Очистити всі дані");
            Console.WriteLine("7. Вихід");
            Console.Write("Виберіть опцію: ");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.Write("Введіть ID працівника: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Введіть ім'я працівника: ");
                    string name = Console.ReadLine();
                    workers.Add(id, new Worker { Name = name });
                    Console.WriteLine("Працівник доданий.");
                    break;

                case 2:
                    Console.Write("Введіть ID працівника для введення премії: ");
                    int workerId = int.Parse(Console.ReadLine());
                    if (workers.ContainsKey(workerId))
                    {
                        workers[workerId].EnterBonus();
                    }
                    else
                    {
                        Console.WriteLine("Працівника з таким ID не існує.");
                    }
                    break;

                case 3:
                    Console.WriteLine("Інформація про премії працівників:");
                    foreach (var worker in workers.Values)
                    {
                        worker.DisplayBonus();
                    }
                    break;

                case 4:
                    Console.Write("Введіть ID працівника для видалення: ");
                    int removeId = int.Parse(Console.ReadLine());
                    if (workers.Remove(removeId))
                    {
                        Console.WriteLine("Працівника видалено.");
                    }
                    else
                    {
                        Console.WriteLine("Працівника з таким ID не знайдено.");
                    }
                    break;

                case 5:
                    Console.WriteLine($"Кількість працівників: {workers.Count}");
                    break;

                case 6:
                    workers.Clear();
                    Console.WriteLine("Усі дані очищено.");
                    break;

                case 7:
                    Console.WriteLine("Вихід.");
                    return;

                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }
}
