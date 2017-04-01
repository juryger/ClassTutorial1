using System;
//using System.Collections;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmArtist : Form
    {
        public frmArtist()
        {
            InitializeComponent();
        }

        private clsArtist _artist;
        private clsArtistList _artistList;
        private clsWorksList _worksList;

        private void UpdateDisplay()
        {
            txtName.Enabled = txtName.Text == "";
            if (_worksList.SortOrder == 0)
            {
                _worksList.SortByName();
                rbByName.Checked = true;
            }
            else
            {
                _worksList.SortByDate();
                rbByDate.Checked = true;
            }

            lstWorks.DataSource = null;
            lstWorks.DataSource = _worksList;
            lblTotal.Text = Convert.ToString(_worksList.GetTotalValue());
        }

        public void SetDetails(clsArtist pArtist)
        {
            _artist = pArtist;
            UpdateForm();
            UpdateDisplay();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _worksList.DeleteWork(lstWorks.SelectedIndex);
            UpdateDisplay();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _worksList.AddWork();
            UpdateDisplay();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                PushData();
                DialogResult = DialogResult.OK;
            }
        }

        public virtual Boolean isValid()
        {
            if (txtName.Enabled && txtName.Text != "")
                if (_artistList.Contains(txtName.Text))
                {
                    MessageBox.Show("Artist with that name already exists!");
                    return false;
                }
                else
                    return true;
            else
                return true;
        }

        private void lstWorks_DoubleClick(object sender, EventArgs e)
        {
            int lcIndex = lstWorks.SelectedIndex;
            if (lcIndex >= 0)
            {
                _worksList.EditWork(lcIndex);
                UpdateDisplay();
            }
        }

        private void rbByDate_CheckedChanged(object sender, EventArgs e)
        {
            _worksList.SortOrder = Convert.ToByte(rbByDate.Checked);
            UpdateDisplay();
        }

        private void UpdateForm()
        {
            txtName.Text = _artist.Name;
            txtSpeciality.Text = _artist.Speciality;
            txtPhone.Text = _artist.Phone;
            _artistList = _artist.ArtistList;
            _worksList = _artist.WorksList;
        }

        private void PushData()
        {
            _artist.Name = txtName.Text;
            _artist.Speciality = txtSpeciality.Text;
            _artist.Phone = txtPhone.Text;
        }

    }
}