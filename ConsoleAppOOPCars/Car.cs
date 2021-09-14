using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppOOPCars
{
    public class Car
    {
    //All members (states or behaviors will have by default the access modefier of privet)

    //States

        //Fields
        string engine;//default value is null for string
        bool engineIsOn;//default value is false for bool
        string modelName;
        int modelYear;//default value is 0 for int
        string color;

        //Property
        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Color can´t be Null or empty.");
                }
                else
                {
                    color = value;
                }
            }
        }

        public bool EngineIsOn
        {
            get { return engineIsOn; }
        }

    //Behavior

        //Constructor(s)
        //if there is no constructor, c# will make a Zero constructor and use it.
        public Car(string modelName, string color)
        {
            this.modelName = modelName;
            Color = color;
        }

        public Car(string modelName, string color, int modelYear, string engineType) : this(modelName, color)
        {
            this.modelYear = modelYear;
            this.engine = engineType;
        }

        //Methods
        public string Drive()
        {
            if (engineIsOn)//(engineIsOn == true)
            {
                return $"The {color} {modelName} drives away.";
            }
            else
            {
                return "Can´t drive the car when the engine is off.";
            }
        }

        public string StartEngine()
        {
            if (engineIsOn)
            {
                return "Engine is already on.";
            }
            else
            {
                engineIsOn = true;
                return $"The {(engine == null ? "engine" : engine)} starts";
            }
        }

        public string Info()
        {
            return $"-- Car Info --\nModel: {modelName}\nColor: {color}\nYear: {modelYear}\nEngine: {engine}\n-----\n";
        }
    }
}
