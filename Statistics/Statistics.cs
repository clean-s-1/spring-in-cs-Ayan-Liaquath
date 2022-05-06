using System;
using System.Collections.Generic;
using System.Linq;

namespace Statistics
{
    public class StatsComputer
    {
        public Stats CalculateStatistics(List<float> numbers) {
            var stats = new Stats();
           if (numbers != null && numbers.Count > 0) {
               stats.average = numbers.Average();
               stats.max = numbers.Max();
               stats.min = numbers.Min();
           }
           else {
               stats.average = Double.NaN;
               stats.max = Double.NaN;
               stats.min = Double.NaN;
           }
           return stats;
        }
    }
        
    public class Stats
    {
        public double average { get; set; }
        public double max { get; set; }
        public double min { get; set; }
    }
    
    public class StatsAlerter 
    {
        private readonly float MaxThreshold;
        private readonly IAlerter[] Alerters;
        
        public StatsAlerter(float maxThreshold, IAlerter[] alerters)
        {
            MaxThreshold = maxThreshold;
            Alerters = alerters;
        }
        
        public void checkAndAlert(List<float> numbers)
        {
            if (numbers != null && numbers.Count > 0) {
                var max = numbers.Max();
                if (max > MaxThreshold && Alerters != null)
                {
                    foreach(var alerter in Alerters) {
                        alerter.SendAlert();
                    }                    
                }
            }            
        }        
    }   
    
    public class EmailAlert : IAlerter
    {
        public bool emailSent {get; set;} = false;
        
        public void SendAlert()
        {
            emailSent = true;
        }
    }
    
    public class LEDAlert : IAlerter
    {
        public bool ledGlows {get; set;} = false;
        
        public void SendAlert()
        {
            ledGlows = true;
        }
    }
    
    public interface IAlerter
    {
        void SendAlert();
    }
}
