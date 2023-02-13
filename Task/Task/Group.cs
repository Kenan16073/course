using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    internal class Group
    {
        string _no;
        double _avgPoint;

        public string No
        {
            get 
            { 
                return _no;
            }
            set 
            {
                if (CheckNo(value))
                {
                    _no = value;
                }
            }
        }
        public double AvgPoint
        {
            get
            {
                return _avgPoint;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _avgPoint = value;
                }
            }
        }
        public bool CheckNo(string no)
        {
            if (no != null)
            {
                if (no.Length == 4)
                {
                    if (char.IsUpper(no[0]) && char.IsDigit(no[1]) && char.IsDigit(no[2]) && char.IsDigit(no[3]))
                        return true;
                }
            }

            return false;
        }
    }
}
