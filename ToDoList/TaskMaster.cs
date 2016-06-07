using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ToDoList
{

    public class Task
    {
        //class to store tasks
        public string Description { get; set; }
        public int Priority { get; set; }
        public DateTime DueDate { get; set; }
    }

    class TaskMaster
    {
        private List<Task> tasks = new List<Task>();

        public List<Task> Tasks { get { return tasks; } }

        //returns all tasks in one string 
        public TaskMaster()
        {
            tasks.Add(new Task(){Description = "My first task"});
            tasks.Add(new Task(){Description = "My second task"});
            tasks.Add(new Task() {Description = "My third task"});
        }

        public string GetTaskDescriptions()
        {
            string descriptions = "";

            foreach(Task t in tasks)
            {
                descriptions += t.Description + "\n\r";
            }
            return descriptions;
        }

        //add task to list

        public void AddTask(string description)
        {
            var task = new Task() { Description = description };
            tasks.Add(task);
        }

    }
}