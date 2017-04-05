using System;
using System.Windows.Forms;

namespace Version_1_C
{
    public sealed partial class frmMain : Form
    {
        private readonly static frmMain _instance = new frmMain();

        /// <summary>
        /// Matthias Otto, NMIT, 2010-2016
        /// </summary>
        private frmMain()
        {
            InitializeComponent();
        }

        private clsArtistList _theArtistList = new clsArtistList();

        public static frmMain Instance
        {
            get
            {
                return _instance;
            }
        }

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
            var errorMsg = string.Empty;
            if (_theArtistList.NewArtist(out errorMsg))
            {
                MessageBox.Show("Artist added!");
                UpdateDisplay();
            }
            else
            {
                MessageBox.Show(errorMsg);
            }
        }

        private void lstArtists_DoubleClick(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstArtists.SelectedItem);
            if (lcKey != null)
            {
                if (_theArtistList.ContainsKey(lcKey))
                {
                    _theArtistList.EditArtist(lcKey);
                    UpdateDisplay();
                }
                else
                {
                    MessageBox.Show("Sorry no artist by this name");
                }
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