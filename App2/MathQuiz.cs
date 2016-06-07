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

namespace App2
{
    public class MathQuiz
    {
        //public functions and variables

        Random randGen = new Random();

        public int firstNumber { get { return _firstNumber; } }
        public int secondNumber { get { return _secondNumber; } }

        public MathQuiz()
        {
            MakeRandom();
        }



        public int calcSum()
        {
            return _firstNumber + secondNumber;
        }

        public void MakeRandom()
        {
            _firstNumber = randGen.Next (0, 101);
            _secondNumber = randGen.Next (0, 101); 
        }

        //private variables/functions
        private int _firstNumber = 0;
        private int _secondNumber = 0; 

    }
}