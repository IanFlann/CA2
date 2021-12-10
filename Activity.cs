using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    //---------------------------------------------------------------------------------------------------------
    // Name : Ian
    // Date : December 2021
    // Task : CA2 
    //---------------------------------------------------------------------------------------------------------
    class Activity :IComparable
    {
        private string Name { get; set; }
        public ActivityType TypeOfActivity { get; set; } 
        public decimal Cost { get; set; }
        public DateTime Date { get; set; }
        public string Desc { get; set; }

        public enum ActivityType
        {
        Air,
        Water,
        Land
        }

        public Activity(string name, decimal cost, DateTime date, string desc, ActivityType type)
        {
            Name = name;
            TypeOfActivity = type;
            Cost = cost;
            Date = date;
            Desc = $"{desc}  Cost - {cost:c}";
        }

        public override string ToString()
        {
            return string.Format($"{Name} - {Date:d}");
        }

        int IComparable.CompareTo(object obj)
        {
            Activity toCompare = (Activity)obj;
            return this.Date.CompareTo(toCompare.Date);
        }
    }
}
