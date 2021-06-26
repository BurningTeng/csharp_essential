using System;
using System.Collections.Generic;

namespace ChapterEvent
{
    class MainClass
    {
        Action<int> OnTemparatureChanged { set; get; }
        private  int _CurrentTemprature = 0;
        public int CurrentTemparature
        {
            get { return _CurrentTemprature; }
            set
            {
                if (_CurrentTemprature != value) {
                    _CurrentTemprature = value;
                    List<Exception> exceptionList = new List<Exception>();
                    Action<int> onTemparatureChanged = this.OnTemparatureChanged;


                    foreach (Action<int> handle in onTemparatureChanged.GetInvocationList())
                    {
                        try
                        {
                            handle(value);

                        } catch (Exception e)
                        {
                            exceptionList.Add(e);
                        }
                    }

                   /* foreach (Exception e in exceptionList)
                    {
                        throw new AggregateException(e);
                    }*/
                }
                

            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Heater heater = new Heater(30);
            Cooler cooler = new Cooler(40);
            MainClass mainClass = new MainClass();
            mainClass.OnTemparatureChanged += 
                (value) => {
                    throw new InvalidOperationException();
                    };
            mainClass.OnTemparatureChanged += cooler.OnTemparatureChanged;
            int temparature = int.Parse(Console.ReadLine());
            mainClass.CurrentTemparature = temparature;
        }
    }
}
