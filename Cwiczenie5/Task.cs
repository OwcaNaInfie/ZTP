using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenie5
{
    public class Task : ITaskComponent
    {
        public string Name { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public bool IsCompleted { get; private set; } = false;
        public bool IsLate { get; private set; } = false;

        // Konstruktor klasy Task, ustawiający nazwę oraz daty początku i końca zadania
        public Task(string name, DateTime startDate, DateTime endDate)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }

        // Metoda oznaczająca zadanie jako wykonane; przyjmuje datę wykonania i sprawdza, czy zadanie wykonano na czas
        public void MarkAsCompleted(DateTime completionDate)
        {
            IsCompleted = true;
            IsLate = completionDate > EndDate;
        }

        // Zwraca status zadania: "Completed", "Completed Late" lub "Pending"
        public string GetStatus()
        {
            if (IsCompleted)
                return IsLate ? "[Completed Late]" : "[Completed]";
            return "[Pending]";
        }

        // Używana do wyświetlenia szczegółów zadania wraz ze statusem
        public override string ToString()
        {
            return $"{Name} ({StartDate:dd.MM.yyyy} to {EndDate:dd.MM.yyyy}) - Status: {GetStatus()}";
        }

        public string GenerateGanttChart(DateTime projectStart, DateTime projectEnd)
        {
            int days = (projectEnd - projectStart).Days + 1;
            char[] chart = new char[days];
            Array.Fill(chart, '.');

            int startOffset = (StartDate - projectStart).Days;
            int endOffset = (EndDate - projectStart).Days;

            if (IsCompleted)
            {
                for (int i = startOffset; i <= endOffset; i++)
                    chart[i] = IsLate ? '!' : 'X';
            }
            else if (DateTime.Now >= StartDate)
            {
                for (int i = startOffset; i <= endOffset; i++)
                    chart[i] = '#';
            }

            return $"{new string(chart)}  {Name}";
        }

    }

}