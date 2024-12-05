using System;
namespace Tumakovlabatory_7;
//Упражнение 7.1 Создать класс счет в банке с закрытыми полями: номер счета, баланс, тип
//банковского счета(использовать перечислимый тип из упр. 3.1). Предусмотреть методы для
//доступа к данным – заполнения и чтения.Создать объект класса, заполнить его поля и
//вывести информацию об объекте класса на печать.

//Упражнение 7.2 Изменить класс счет в банке из упражнения 7.1 таким образом, чтобы номер счета генерировался сам и был уникальным.Для этого надо создать в классе
//статическую переменную и метод, который увеличивает значение этого переменной.

//Упражнение 7.3 Добавить в класс счет в банке два метода: снять со счета и положить насчет.Метод снять со счета проверяет, возможно ли снять запрашиваемую сумму, и в случае
//положительного результата изменяет баланс.

//Домашнее задание 7.1 Реализовать класс для описания здания (уникальный номер здания,
//высота, этажность, количество квартир, подъездов). Поля сделать закрытыми,
//предусмотреть методы для заполнения полей и получения значений полей для печати.
//Добавить методы вычисления высоты этажа, количества квартир в подъезде, количества
//квартир на этаже и т.д.Предусмотреть возможность, чтобы уникальный номер здания
//генерировался программно.Для этого в классе предусмотреть статическое поле, которое бы
//хранило последний использованный номер здания, и предусмотреть метод, который
//увеличивал бы значение этого поля.
public enum AccountType
{
    Checking,
    Savings,
    Business
}

public class BankAccount
{
    private string accountNumber;
    private decimal balance;
    private AccountType accountType;

    private static int accountNumberCounter = 1000000000;

    public BankAccount(decimal balance, AccountType accountType)
    {
        this.accountNumber = GenerateAccountNumber();
        this.balance = balance;
        this.accountType = accountType;
    }

    private static string GenerateAccountNumber()
    {
        accountNumberCounter++;
        return accountNumberCounter.ToString();
    }

    public string GetAccountNumber()
    {
        return accountNumber;
    }

    public decimal GetBalance()
    {
        return balance;
    }

    public AccountType GetAccountType()
    {
        return accountType;
    }

    public void PrintAccountInfo()
    {
        Console.WriteLine($"Номер счета: {accountNumber}");
        Console.WriteLine($"Баланс: {balance} руб.");
        Console.WriteLine($"Тип счета: {accountType}");
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Сумма для снятия должна быть положительной.");
            return false;
        }

        if (amount > balance)
        {
            Console.WriteLine("Недостаточно средств на счете для снятия.");
            return false;
        }

        balance -= amount;
        Console.WriteLine($"Снято {amount} руб. Новый баланс: {balance} руб.");
        return true;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Сумма для внесения должна быть положительной.");
            return;
        }

        balance += amount;
        Console.WriteLine($"Внесено {amount} руб. Новый баланс: {balance} руб.");
    }
}

public class Building
{
    private static int lastBuildingNumber = 1000;

    private int buildingNumber;
    private double height;
    private int numberOfFloors;
    private int numberOfApartments;
    private int numberOfEntrances;

    public Building(double height, int numberOfFloors, int numberOfApartments, int numberOfEntrances)
    {
        this.buildingNumber = GenerateBuildingNumber();
        this.height = height;
        this.numberOfFloors = numberOfFloors;
        this.numberOfApartments = numberOfApartments;
        this.numberOfEntrances = numberOfEntrances;
    }

    private static int GenerateBuildingNumber()
    {
        return ++lastBuildingNumber;
    }

    public int GetBuildingNumber()
    {
        return buildingNumber;
    }

    public double GetHeight()
    {
        return height;
    }

    public int GetNumberOfFloors()
    {
        return numberOfFloors;
    }

    public int GetNumberOfApartments()
    {
        return numberOfApartments;
    }

    public int GetNumberOfEntrances()
    {
        return numberOfEntrances;
    }

    public double CalculateFloorHeight()
    {
        return height / numberOfFloors;
    }

    public int CalculateApartmentsPerEntrance()
    {
        if (numberOfEntrances == 0) return 0;
        return numberOfApartments / numberOfEntrances;
    }

    public int CalculateApartmentsPerFloor()
    {
        if (numberOfFloors == 0) return 0;
        return numberOfApartments / numberOfFloors;
    }

    public void PrintBuildingInfo()
    {
        Console.WriteLine($"Номер здания: {buildingNumber}");
        Console.WriteLine($"Высота здания: {height} м");
        Console.WriteLine($"Этажность: {numberOfFloors} этажей");
        Console.WriteLine($"Количество квартир: {numberOfApartments}");
        Console.WriteLine($"Количество подъездов: {numberOfEntrances}");
    }
}

class Program
{
    static void Exercise7_1()
    {
        BankAccount myAccount1 = new BankAccount(5000.75m, AccountType.Checking);
        Console.WriteLine("Информация о счете (упражнение 7.1):");
        myAccount1.PrintAccountInfo();
    }

    static void Exercise7_2()
    {
        BankAccount myAccount2 = new BankAccount(10000.50m, AccountType.Savings);
        BankAccount myAccount3 = new BankAccount(2000.25m, AccountType.Business);
        Console.WriteLine("\nИнформация о счетах (упражнение 7.2):");
        myAccount2.PrintAccountInfo();
        myAccount3.PrintAccountInfo();
    }

    static void Exercise7_3()
    {
        BankAccount myAccount = new BankAccount(5000.00m, AccountType.Checking);
        Console.WriteLine("Информация о счете (упражнение 7.3):");
        myAccount.PrintAccountInfo();

        Console.WriteLine("\nПопытка снять 1500 руб.");
        myAccount.Withdraw(1500m);  

        Console.WriteLine("\nПопытка положить 2000 руб.");
        myAccount.Deposit(2000m);   
    }

    static void Homework7_1()
    {
        Building building1 = new Building(50.0, 10, 100, 2);
        building1.PrintBuildingInfo();
        Console.WriteLine($"Высота этажа: {building1.CalculateFloorHeight()} м");
        Console.WriteLine($"Квартир в подъезде: {building1.CalculateApartmentsPerEntrance()}");
        Console.WriteLine($"Квартир на этаже: {building1.CalculateApartmentsPerFloor()}");

        Console.WriteLine();

        Building building2 = new Building(75.0, 15, 150, 3);
        building2.PrintBuildingInfo();
        Console.WriteLine($"Высота этажа: {building2.CalculateFloorHeight()} м");
        Console.WriteLine($"Квартир в подъезде: {building2.CalculateApartmentsPerEntrance()}");
        Console.WriteLine($"Квартир на этаже: {building2.CalculateApartmentsPerFloor()}");
    }

    static void ShowMenu()
    {
        Console.WriteLine("Выберите программу для выполнения:");
        Console.WriteLine("1. Упражнение 7.1 - Работа с банковским счетом");
        Console.WriteLine("2. Упражнение 7.2 - Работа с несколькими счетами");
        Console.WriteLine("3. Упражнение 7.3 - Снятие и внесение средств");
        Console.WriteLine("4. Домашняя работа 7.1 - Работа с классом Здание");
        Console.WriteLine("0. Выход");
    }

    static void Main()
    {
        bool exit = false;

        while (!exit)
        {
            ShowMenu();
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Exercise7_1();
                    break;
                case "2":
                    Exercise7_2();
                    break;
                case "3":
                    Exercise7_3();
                    break;
                case "4":
                    Homework7_1();
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Неверный ввод. Пожалуйста, выберите корректный номер.");
                    break;
            }

            if (!exit)
            {
                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
                Console.Clear(); // Очищает экран перед следующим меню
            }
        }

        Console.WriteLine("Программа завершена.");
    }
}
