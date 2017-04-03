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
            if (MessageBox.Show("Are you sure?", "Deleting work", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _worksList.DeleteWork(lstWorks.SelectedIndex);
                UpdateDisplay();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var inputBox = new InputBox("Enter P for Painting, S for Sculpture and H for Photograph");
            if (inputBox.ShowDialog() != DialogResult.OK)
            {
                inputBox.Close();
                return;
            }

            WorkType lcWorkType;
            var lcReply = Convert.ToChar(inputBox.getAnswer());
            switch (char.ToUpper(lcReply))
            {
                case 'P':
                    lcWorkType = WorkType.Painting;
                    break;
                case 'S':
                    lcWorkType = WorkType.Sculpture;
                    break;
                case 'H':
                    lcWorkType = WorkType.Photograph;
                    break;
                default:
                    lcWorkType = WorkType.None;
                    break;
            }

            _worksList.AddWork(lcWorkType);
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
                if (_artist.IsDuplicate(txtName.Text))
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
            if (lcIndex >= 0 && lcIndex < _worksList.Count)
            {
                _worksList.EditWork(lcIndex);
                UpdateDisplay();
            }
            else
            {
                MessageBox.Show("Sorry no work selected #" + Convert.ToString(lcIndex));
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