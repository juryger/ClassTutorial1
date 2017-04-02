using System;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmWork : Form
    {
        protected clsWork _work;

        public frmWork()
        {
            InitializeComponent();
        }

        public void SetDetails(clsWork pWork)
        {
            _work = pWork;
            UpdateForm();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (isValid() == true)
            {
                PushData();
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public virtual bool isValid()
        {
            return true;
        }

        protected virtual void UpdateForm()
        {
            txtName.Text = _work.Name;
            txtCreation.Text = _work.Date.ToShortDateString();
            txtValue.Text = _work.Value.ToString();
        }

        protected virtual void PushData()
        {
            _work.Name = txtName.Text;
            _work.Date = Convert.ToDateTime(txtCreation.Text);
            _work.Value = Convert.ToDecimal(txtValue.Text);
        }

    }
}