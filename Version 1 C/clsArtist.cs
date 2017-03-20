using System;

namespace Version_1_C
{
    [Serializable()]
    public class clsArtist
    {
        private string _name;
        private string _speciality;
        private string _phone;

        private decimal _totalValue;

        private clsWorksList _worksList;
        private clsArtistList _artistList;

        private static frmArtist _artistDialog = new frmArtist();
        private byte sortOrder;

        public clsArtist(clsArtistList prArtistList)
        {
            _worksList = new clsWorksList();
            _artistList = prArtistList;

            EditDetails();
        }

        public void EditDetails()
        {
            _artistDialog.SetDetails(_name, _speciality, _phone, sortOrder, _worksList, _artistList);
            if (_artistDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _artistDialog.GetDetails(ref _name, ref _speciality, ref _phone, ref sortOrder);
                _totalValue = _worksList.GetTotalValue();
            }
        }

        public string GetKey()
        {
            return _name;
        }

        public decimal GetWorksValue()
        {
            return _totalValue;
        }
    }
}
