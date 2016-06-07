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

namespace App1
{
    public class Bugs
    {
        int patches = 99;

        public Bugs() { }

        public int Sum { get { return patches; } }

        public void fixBugs() { patches -= 1; }

        public void otherFix() { patches -= 2; }

    }
}