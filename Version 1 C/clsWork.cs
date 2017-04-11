using System;

namespace Version_1_C
{
    [Serializable()]
    public abstract class clsWork
    {
        private string _name;
        private DateTime _date = DateTime.Now;
        private decimal _value;

        public delegate void LoadWorkFormDelegate(clsWork prWork);

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return _date;
            }

            set
            {
                _date = value;
            }
        }

        public decimal Value
        {
            get
            {
                return _value;
            }

            set
            {
                this._value = value;
            }
        }

        public clsWork()
        {
            EditDetails();
        }

        public abstract void EditDetails();

        public static clsWork NewWork(WorkType pworkType)
        {
            switch (pworkType)
            {
                case WorkType.Painting:
                    return new clsPainting();
                case WorkType.Sculpture:
                    return new clsSculpture();
                case WorkType.Photograph:
                    return new clsPhotograph();
                default:
                    return null;
            }
        }

        public override string ToString()
        {
            return _name + "\t" + _date.ToShortDateString();
        }
    }
}
