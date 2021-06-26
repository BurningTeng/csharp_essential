using System;
namespace ChapterEvent
{
    
    public class Cooler
    {
        private int temparature;

        public Cooler(int temparature)
        {
            this.temparature = temparature;
        }

        public void OnTemparatureChanged(int newTemparature)
        {
            if (newTemparature > temparature)
            {
                Console.WriteLine("Cooler: on");
            }
            else
            {
                Console.WriteLine("Cooler:off");
            }

        }
    }
}
