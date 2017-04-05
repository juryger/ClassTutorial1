using System.Collections.Generic;

namespace Version_1_C
{
    public sealed class clsNameComparer : IComparer<clsWork>
    {
        private static readonly clsNameComparer _instance = new clsNameComparer();

        private clsNameComparer()
        {
        }

        public static clsNameComparer Instance
        {
            get
            {
                return _instance;
            }
        }

        public int Compare(clsWork x, clsWork y)
        {
            string lcNameX = x.Name;
            string lcNameY = y.Name;

            return string.Compare(lcNameX, lcNameY, true);
        }
    }
}
