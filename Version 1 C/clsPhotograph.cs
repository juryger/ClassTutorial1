using System;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()]
    public class clsPhotograph : clsWork
    {
        private float _width;
        private float _height;
        private string _type;

        [NonSerialized()]
        private static frmPhotograph _photoDialog;

        public override void EditDetails()
        {
            if (_photoDialog == null)
            {
                _photoDialog = new frmPhotograph();
            }

            _photoDialog.SetDetails(_name, _date, _value, _width, _height, _type);

            if (_photoDialog.ShowDialog() == DialogResult.OK)
            {
                _photoDialog.GetDetails(ref _name, ref _date, ref _value, ref _width, ref _height, ref _type);
            }
        }
    }
}
