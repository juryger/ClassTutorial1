using System;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()]
    public class clsPainting : clsWork
    {
        private float _width;
        private float _height;
        private string _type;

        [NonSerialized()]
        private static frmPainting _paintDialog;

        public override void EditDetails()
        {
            if (_paintDialog == null)
            {
                _paintDialog = new frmPainting();
            }

            _paintDialog.SetDetails(_name, _date, _value, _width, _height, _type);

            if (_paintDialog.ShowDialog() == DialogResult.OK)
            {
                _paintDialog.GetDetails(ref _name, ref _date, ref _value, ref _width, ref _height, ref _type);
            }
        }
    }
}
