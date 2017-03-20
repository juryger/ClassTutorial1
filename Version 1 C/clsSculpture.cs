using System;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()]
    public class clsSculpture : clsWork
    {
        private float _weight;
        private string _material;

        [NonSerialized()]
        private static frmSculpture _sculptureDialog;

        public override void EditDetails()
        {
            if (_sculptureDialog == null)
            {
                _sculptureDialog = new frmSculpture();
            }

            _sculptureDialog.SetDetails(_name, _date, _value, _weight, _material);

            if (_sculptureDialog.ShowDialog() == DialogResult.OK)
            {
                _sculptureDialog.GetDetails(ref _name, ref _date, ref _value, ref _weight, ref _material);
            }
        }
    }
}
