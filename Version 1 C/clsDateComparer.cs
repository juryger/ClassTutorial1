using System;
using System.Collections;

namespace Version_1_C
{
    class clsDateComparer : IComparer
    {
        public int Compare(Object x, Object y)
        {
            clsWork lcWorkX = (clsWork)x;
            clsWork lcWorkY = (clsWork)y;
            DateTime lcDateX = lcWorkX.Date;
            DateTime lcDateY = lcWorkY.Date;

            return lcDateX.CompareTo(lcDateY);
        }
    }
}
