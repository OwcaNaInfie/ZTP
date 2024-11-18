using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenie5
{
    public interface ITaskComponent
    {
        string Name { get; }
        DateTime StartDate { get; }
        DateTime EndDate { get; }
        bool IsCompleted { get; }
        string GetStatus();
        void MarkAsCompleted(DateTime completionDate);
        string GenerateGanttChart(DateTime projectStart, DateTime projectEnd);
    }

}