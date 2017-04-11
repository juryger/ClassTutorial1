using System;
using Version_1_C.Delegates;

namespace Version_1_C
{
    [Serializable()]
    public class clsPhotograph : clsWork
    {
        private float _width;
        private float _height;
        private string _type;

        [field: NonSerializedAttribute()]
        public static LoadWorkFormDelegate LoadPhotographForm;

        public float Width
        {
            get
            {
                return _width;
            }

            set
            {
                _width = value;
            }
        }

        public float Height
        {
            get
            {
                return _height;
            }

            set
            {
                _height = value;
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        public override void EditDetails()
        {
            LoadPhotographForm(this);
        }
    }
}
