using System;

namespace Version_1_C
{
    [Serializable()]
    public class clsPainting : clsWork
    {
        private float _width;
        private float _height;
        private string _type;

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
            frmPainting.Instance.SetDetails(this);

            frmPainting.Instance.ShowDialog();
        }
    }
}
