using System;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// Matthias Otto, NMIT, 2010-2016
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
        }

        private clsArtistList _theArtistList = new clsArtistList();

        private void UpdateDisplay()
        {
            string[] lcDisplayList = new string[_theArtistList.Count];

            lstArtists.DataSource = null;
            _theArtistList.Keys.CopyTo(lcDisplayList, 0);
            lstArtists.DataSource = lcDisplayList;
            lblValue.Text = Convert.ToString(_theArtistList.GetTotalValue());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _theArtistList.NewArtist();
            UpdateDisplay();
        }

        private void lstArtists_DoubleClick(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstArtists.SelectedItem);
            if (lcKey != null)
            {
                _theArtistList.EditArtist(lcKey);
                UpdateDisplay();
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Save();
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstArtists.SelectedItem);
            if (lcKey != null)
            {
                lstArtists.ClearSelected();
                _theArtistList.Remove(lcKey);
                UpdateDisplay();
            }
        }

        private void Save()
        {
            try
            {
                _theArtistList.Save();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "File Save Error");
            }
        }


        private void Retrieve()
        {
            try
            {
                _theArtistList = clsArtistList.Retrieve();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "File Retrieve Error");
            };
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Retrieve();
            UpdateDisplay();
        }
    }
}