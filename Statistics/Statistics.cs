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
}
