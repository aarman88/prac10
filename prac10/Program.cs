using System;
using System.Collections.Generic;

// Интерфейс для части дома
interface IPart
{
    string Name { get; }
    bool IsBuilt { get; set; }
}

// Класс фундамента
class Basement : IPart
{
    public string Name { get { return "Basement"; } }
    public bool IsBuilt { get; set; }
}

// Класс стен
class Wall : IPart
{
    public string Name { get { return "Wall"; } }
    public bool IsBuilt { get; set; }
}

// Класс двери
class Door : IPart
{
    public string Name { get { return "Door"; } }
    public bool IsBuilt { get; set; }
}

// Класс окна
class Window : IPart
{
    public string Name { get { return "Window"; } }
    public bool IsBuilt { get; set; }
}

// Класс крыши
class Roof : IPart
{
    public string Name { get { return "Roof"; } }
    public bool IsBuilt { get; set; }
}

// Интерфейс для рабочего
interface IWorker
{
    void Build(IPart part);
}

// Класс строителя
class Worker : IWorker
{
    public string Name { get; }
    public Worker(string name)
    {
        Name = name;
    }

    public void Build(IPart part)
    {
        part.IsBuilt = true;
        Console.WriteLine($"{Name} построил {part.Name}");
    }
}

// Класс бригадира
class TeamLeader
{
    public void Report(List<IPart> parts)
    {
        Console.WriteLine("Отчёт бригадира:");
        foreach (var part in parts)
        {
            if (part.IsBuilt)
            {
                Console.WriteLine($"{part.Name} построено.");
            }
            else
            {
                Console.WriteLine($"{part.Name} еще не построено.");
            }
        }
    }
}

// Класс бригады строителей
class Team
{
    private List<Worker> workers;
    private TeamLeader teamLeader;
    private List<IPart> houseParts;

    public Team()
    {
        workers = new List<Worker>
        {
            new Worker("Строитель 1"),
            new Worker("Строитель 2"),
            new Worker("Строитель 3"),
            new Worker("Строитель 4"),
        };
        teamLeader = new TeamLeader();
        houseParts = new List<IPart>
        {
            new Basement(),
            new Wall(),
            new Wall(),
            new Wall(),
            new Wall(),
            new Door(),
            new Window(),
            new Window(),
            new Window(),
            new Window(),
            new Roof(),
        };
    }

    public void StartBuilding()
    {
        Console.WriteLine("Строительство началось:");
        foreach (var part in houseParts)
        {
            Worker worker = workers[0];
            worker.Build(part);
            workers.RemoveAt(0);
            workers.Add(worker);
        }
        Console.WriteLine("Строительство завершено.");
    }

    public void ReportProgress()
    {
        teamLeader.Report(houseParts);
    }
}

class Program
{
    static void Main()
    {
        Team team = new Team();
        team.StartBuilding();
        team.ReportProgress();
    }
}
