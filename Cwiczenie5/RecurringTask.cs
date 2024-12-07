using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenie5
{
    public class RecurringTask : ITaskComponent
    {
        public string Name { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public int IntervalInDays { get; }
        private readonly Dictionary<DateTime, bool?> _occurrences = new();

        public bool IsCompleted => _occurrences.Values.All(status => status.HasValue);

        public RecurringTask(string name, DateTime startDate, DateTime endDate, int intervalInDays)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            IntervalInDays = intervalInDays;

            for (var date = startDate; date <= endDate; date = date.AddDays(intervalInDays))
            {
                _occurrences[date] = null;
            }
        }

        public void MarkAsCompleted(DateTime completionDate)
        {
            foreach (var occurrence in _occurrences.Keys.ToList())
            {
                if (occurrence <= completionDate && !_occurrences[occurrence].HasValue)
                {
                    _occurrences[occurrence] = completionDate <= occurrence;
                }
            }
        }

        public string GetStatus()
        {
            return IsCompleted ? "[Completed]" : "[Pending]";
        }

        public string GenerateGanttChart(DateTime projectStart, DateTime projectEnd)
        {
            int days = (projectEnd - projectStart).Days + 1;
            char[] chart = new char[days];
            Array.Fill(chart, '.');

            foreach (var occurrence in _occurrences)
            {
                int offset = (occurrence.Key - projectStart).Days;
                if (offset >= 0 && offset < days)
                {
                    chart[offset] = occurrence.Value == true ? 'X' : (occurrence.Value == false ? '!' : '#');
                }
            }

            return $"{new string(chart)}  {Name}";
        }

        public override string ToString()
        {
            return $"{Name} ({StartDate:dd.MM.yyyy} to {EndDate:dd.MM.yyyy}) - Status: {GetStatus()}";
        }
    }

}