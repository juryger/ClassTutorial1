using System;

namespace Version_1_C
{
    [Serializable()]
    public class clsSculpture : clsWork
    {
        private float _weight;
        private string _material;

        [NonSerialized()]
        private static frmSculpture _sculptureDialog;

        public float Weight
        {
            get
            {
                return _weight;
            }

            set
            {
                _weight = value;
            }
        }

        public string Material
        {
            get
            {
                return _material;
            }

            set
            {
                _material = value;
            }
        }

        public override void EditDetails()
        {
            if (_sculptureDialog == null)
            {
                _sculptureDialog = new frmSculpture();
            }

            _sculptureDialog.SetDetails(this);

            _sculptureDialog.ShowDialog();
        }
    }
}
