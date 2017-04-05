using System;

namespace Version_1_C
{
    [Serializable()]
    public class clsSculpture : clsWork
    {
        private float _weight;
        private string _material;

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
            frmSculpture.Instance.SetDetails(this);

            frmSculpture.Instance.ShowDialog();
        }
    }
}
