using System;

namespace Version_1_C
{
    public sealed partial class frmSculpture : Version_1_C.frmWork
    {
        private static readonly frmSculpture _instance = new frmSculpture();

        public static frmSculpture Instance
        {
            get
            {
                return _instance;
            }
        }

        private frmSculpture()
        {
            InitializeComponent();
        }

        protected override void UpdateForm()
        {
            base.UpdateForm();

            var sculpture = (clsSculpture)_work;
            txtWeight.Text = Convert.ToString(sculpture.Weight);
            txtMaterial.Text = sculpture.Material;
        }

        protected override void PushData()
        {
            base.PushData();

            var sculpture = (clsSculpture)_work;
            sculpture.Weight = Convert.ToSingle(txtWeight.Text);
            sculpture.Material = txtMaterial.Text;
        }

    }
}

