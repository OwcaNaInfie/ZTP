using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenie5
{
    public class OptionalTaskGroup : ITaskComponent
    {
        private readonly List<ITaskComponent> _components = new();

        public string Name { get; }
        public DateTime StartDate => _components.Min(c => c.StartDate);
        public DateTime EndDate => _components.Max(c => c.EndDate);
        public bool IsCompleted => _components.Any(c => c.IsCompleted);

        public OptionalTaskGroup(string name)
        {
            Name = name;
        }

        public void AddComponent(ITaskComponent component)
        {
            _components.Add(component);
        }

        public void MarkAsCompleted(DateTime completionDate)
        {
            if (!IsCompleted)
            {
                var uncompletedTask = _components.FirstOrDefault(c => !c.IsCompleted);
                uncompletedTask?.MarkAsCompleted(completionDate);
            }
        }

        public string GetStatus()
        {
            return IsCompleted ? "[Partially Completed]" : "[Pending]";
        }

        public override string ToString()
        {
            string output;
            output = $"{Name} - Status: {GetStatus()}\n";
            foreach (var component in _components)
            {
                output += component + "\n";
            }
            return output;
        }

        public string GenerateGanttChart(DateTime projectStart, DateTime projectEnd)
        {
            var chart = new System.Text.StringBuilder();
            chart.AppendLine($"{Name}:");

            foreach (var component in _components)
            {
                chart.AppendLine(component.GenerateGanttChart(projectStart, projectEnd));
            }

            return chart.ToString();
        }
    }

}