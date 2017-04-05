using System;
using System.Collections.Generic;

namespace Version_1_C
{
    public sealed class clsDateComparer : IComparer<clsWork>
    {
        private static readonly clsDateComparer _instance = new clsDateComparer();

        private clsDateComparer()
        {
        }

        public static clsDateComparer Instance
        {
            get
            {
                return _instance;
            }
        }

        public int Compare(clsWork x, clsWork y)
        {
            DateTime lcDateX = x.Date;
            DateTime lcDateY = y.Date;

            return lcDateX.CompareTo(lcDateY);
        }
    }
}
