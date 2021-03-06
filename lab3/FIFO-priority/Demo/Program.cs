﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPlanner;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            FIFOPriorityContainer priorityContainer = new FIFOPriorityContainer(5);
            GanttDiagramBuilder diagramBuilder = new GanttDiagramBuilder();
            priorityContainer.OnElementRemoved += diagramBuilder.ProcessNextTaskExecution;

            priorityContainer.AddTask(new PlannerTask("T1", 4, 5));
            priorityContainer.AddTask(new PlannerTask("T2", 4, 4));
            priorityContainer.AddTask(new PlannerTask("T3", 4, 3));
            priorityContainer.AddTask(new PlannerTask("T4", 4, 2));
            priorityContainer.AddTask(new PlannerTask("T5", 4, 1));
            priorityContainer.AddTask(new PlannerTask("T6", 4, 0));
            priorityContainer.AddTask(new PlannerTask("T7", 4, 1));
            priorityContainer.AddTask(new PlannerTask("T8", 4, 0));
            priorityContainer.AddTask(new PlannerTask("T9", 4, 3));

            priorityContainer.DisplayEnqued();

            Planner planner = new Planner(priorityContainer);
            planner.StartExecution();

            Console.WriteLine("\n\n\nGantt Diagram:\n");
            Console.WriteLine(diagramBuilder.ToString());         
        }
    }
}
