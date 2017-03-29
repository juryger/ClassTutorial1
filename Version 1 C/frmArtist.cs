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

        private clsArtistList theArtistList;
        private clsWorksList theWorksList;

        private void UpdateDisplay()
        {
            txtName.Enabled = txtName.Text == "";
            if (theWorksList.SortOrder == 0)
            {
                theWorksList.SortByName();
                rbByName.Checked = true;
            }
            else
            {
                theWorksList.SortByDate();
                rbByDate.Checked = true;
            }

            lstWorks.DataSource = null;
            lstWorks.DataSource = theWorksList;
            lblTotal.Text = Convert.ToString(theWorksList.GetTotalValue());
        }

        public void SetDetails(string prName, string prSpeciality, string prPhone,
                               clsWorksList prWorksList, clsArtistList prArtistList)
        {
            txtName.Text = prName;
            txtSpeciality.Text = prSpeciality;
            txtPhone.Text = prPhone;
            theArtistList = prArtistList;
            theWorksList = prWorksList;
            UpdateDisplay();
        }

        public void GetDetails(ref string prName, ref string prSpeciality, ref string prPhone)
        {
            prName = txtName.Text;
            prSpeciality = txtSpeciality.Text;
            prPhone = txtPhone.Text;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            theWorksList.DeleteWork(lstWorks.SelectedIndex);
            UpdateDisplay();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            theWorksList.AddWork();
            UpdateDisplay();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                DialogResult = DialogResult.OK;
            }
        }

        public virtual Boolean isValid()
        {
            if (txtName.Enabled && txtName.Text != "")
                if (theArtistList.Contains(txtName.Text))
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
                theWorksList.EditWork(lcIndex);
                UpdateDisplay();
            }
        }

        private void rbByDate_CheckedChanged(object sender, EventArgs e)
        {
            theWorksList.SortOrder = Convert.ToByte(rbByDate.Checked);
            UpdateDisplay();
        }

    }
}