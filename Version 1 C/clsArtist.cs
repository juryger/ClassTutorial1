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

        public string Speciality
        {
            get
            {
                return _speciality;
            }

            set
            {
                _speciality = value;
            }
        }

        public string Phone
        {
            get
            {
                return _phone;
            }

            set
            {
                _phone = value;
            }
        }

        public decimal TotalValue
        {
            get
            {
                return _totalValue;
            }
        }

        public clsWorksList WorksList
        {
            get
            {
                return _worksList;
            }
        }

        public clsArtistList ArtistList
        {
            get
            {
                return _artistList;
            }
        }

        public clsArtist(clsArtistList prArtistList)
        {
            _worksList = new clsWorksList();
            _artistList = prArtistList;

            EditDetails();
        }

        public void EditDetails()
        {
            _artistDialog.SetDetails(this);
            if (_artistDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _totalValue = _worksList.GetTotalValue();
            }
        }
    }
}
