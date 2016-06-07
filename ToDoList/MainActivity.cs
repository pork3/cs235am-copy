using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Xml.Serialization;
using System.IO;

namespace ToDoList
{
    [Activity(Label = "ToDoList", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        TaskMaster taskMaster; 

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            if (bundle == null)
            {
                taskMaster = new TaskMaster();
            }
            else
            {
                XmlSerializer x = new XmlSerializer(typeof(TaskMaster));
                taskMaster = (TaskMaster)x.Deserialize(
                    new StringReader(bundle.GetString("Tasks", "")));
            }
            TextView taskTextView = FindViewById<TextView>(Resource.Id.TaskTextView);
            taskTextView.Text = taskMaster.GetTaskDescriptions();


            Button button = FindViewById<Button>(Resource.Id.TaskButton);
            var taskEdit = FindViewById<EditText>(Resource.Id.TaskEditText);
            button.Click += delegate
            {//add task to list
                taskMaster.AddTask(taskEdit.Text);
                taskTextView.Text = taskMaster.GetTaskDescriptions();
                taskEdit.Text = "";
            };
            
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            StringWriter writer = new StringWriter();

            XmlSerializer taskMasterSerializer = new XmlSerializer(typeof(TaskMaster));
            taskMasterSerializer.Serialize(writer, taskMaster);

            outState.PutString("Tasks", writer.ToString());
            base.OnSaveInstanceState(outState);
        }

    }
}

