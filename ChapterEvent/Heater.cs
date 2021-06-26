using System;
namespace ChapterEvent
{
    public class Heater
    {
        private int temparature;

        public Heater(int temparature)
        {
            this.temparature = temparature;


        }
        public void OnTemparatureChanged(int newTemparature)
        {
            if (newTemparature > temparature)
            {
                Console.WriteLine("Heater:off");
            }
            else
            {
                Console.WriteLine("Heater:on");
            }
        }
    }
}
