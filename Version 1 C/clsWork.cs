using System;

namespace Version_1_C
{
    [Serializable()]
    public abstract class clsWork
    {
        private string _name;
        private DateTime _date = DateTime.Now;
        private decimal _value;

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

        public static clsWork NewWork()
        {
            char lcReply;
            InputBox inputBox = new InputBox("Enter P for Painting, S for Sculpture and H for Photograph");
            //inputBox.ShowDialog();
            //if (inputBox.getAction() == true)
            if (inputBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lcReply = Convert.ToChar(inputBox.getAnswer());

                switch (char.ToUpper(lcReply))
                {
                    case 'P': return new clsPainting();
                    case 'S': return new clsSculpture();
                    case 'H': return new clsPhotograph();
                    default: return null;
                }
            }
            else
            {
                inputBox.Close();
                return null;
            }
        }

        public override string ToString()
        {
            return _name + "\t" + _date.ToShortDateString();
        }
    }
}
