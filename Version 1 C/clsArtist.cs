using System;
using Version_1_C.Delegates;

namespace Version_1_C
{
    [Serializable()]
    public class clsArtist
    {
        private string _name;
        private string _speciality;
        private string _phone;

        private clsWorksList _worksList;

        private frmArtist _artistDialog;

        public clsArtist()
        {
            _worksList = new clsWorksList();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pIsDuplicateArtist">ref to function which checks on dublicate artists by name</param>
        /// <param name="pFinishArtistEditing">ref to function which will be called when artist editing finish</param>
        public clsArtist(IsDuplicateArtistDelegate pIsDuplicateArtist, FinishArtistEditingDelegate pFinishArtistEditing) : this()
        {
            _artistDialog = new frmArtist(pIsDuplicateArtist, pFinishArtistEditing);

            EditDetails();
        }

        public void InitArtistAfterDeserialization(IsDuplicateArtistDelegate pIsDuplicateArtist, FinishArtistEditingDelegate pFinishArtistEditing)
        {
            _artistDialog = new frmArtist(pIsDuplicateArtist, pFinishArtistEditing);
        }

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
                return _worksList.GetTotalValue();
            }
        }

        public clsWorksList WorksList
        {
            get
            {
                return _worksList;
            }
        }

        public void EditDetails()
        {
            _artistDialog.SetDetails(this);
            _artistDialog.Show();
            _artistDialog.Activate();
        }
    }
}
