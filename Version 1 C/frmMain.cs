using System;
using System.Windows.Forms;
using Version_1_C.Delegates;

namespace Version_1_C
{
    public sealed partial class frmMain : Form
    {
        private readonly static frmMain _instance = new frmMain();

        [field: NonSerializedAttribute()]
        public event Notify GalleryNameChanged;

        /// <summary>
        /// Matthias Otto, NMIT, 2010-2016
        /// </summary>
        private frmMain()
        {
            InitializeComponent();

            _artistList =
                new clsArtistList(new MainFormUpdateDelegate(UpdateDisplay));
        }

        private void updateTitle(string prGalleryName)
        {
            if (!string.IsNullOrEmpty(prGalleryName))
                Text = "Gallery - " + prGalleryName;
        }

        private clsArtistList _artistList;

        public static frmMain Instance
        {
            get
            {
                return _instance;
            }
        }

        private void UpdateDisplay()
        {
            string[] lcDisplayList = new string[_artistList.Count];

            lstArtists.DataSource = null;
            _artistList.Keys.CopyTo(lcDisplayList, 0);
            lstArtists.DataSource = lcDisplayList;
            lblValue.Text = Convert.ToString(_artistList.GetTotalValue());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _artistList.NewArtist();
        }

        private void lstArtists_DoubleClick(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstArtists.SelectedItem);
            if (lcKey != null)
            {
                if (_artistList.ContainsKey(lcKey))
                {
                    _artistList.EditArtist(lcKey);
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
                _artistList.Remove(lcKey);
                UpdateDisplay();
            }
        }

        private void Save()
        {
            try
            {
                _artistList.Save();
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
                _artistList = clsArtistList.Retrieve(new MainFormUpdateDelegate(UpdateDisplay));
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

            GalleryNameChanged = new Notify(updateTitle);
            GalleryNameChanged("Test title.");
        }
    }
}