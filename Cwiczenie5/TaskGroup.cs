using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenie5
{
    public class TaskGroup : ITaskComponent
    {
        private readonly List<ITaskComponent> _components = new();

        public string Name { get; }
        public DateTime StartDate => _components.Min(c => c.StartDate);
        public DateTime EndDate => _components.Max(c => c.EndDate);
        public bool IsCompleted => _components.All(c => c.IsCompleted);

        public TaskGroup(string name)
        {
            Name = name;
        }

        public void AddComponent(ITaskComponent component)
        {
            _components.Add(component);
        }

        public void MarkAsCompleted(DateTime completionDate)
        {
            foreach (var component in _components)
            {
                component.MarkAsCompleted(completionDate);
            }
        }

        public string GetStatus()
        {
            return IsCompleted ? "[Completed]" : "[Pending]";
        }

        public override string ToString()
        {
            return $"{Name} - Status: {GetStatus()}";
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