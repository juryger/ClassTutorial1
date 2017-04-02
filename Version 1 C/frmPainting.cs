using System;

namespace Version_1_C
{
    public partial class frmPainting : Version_1_C.frmWork
    {
        public frmPainting()
        {
            InitializeComponent();
        }

        protected override void UpdateForm()
        {
            base.UpdateForm();

            var painting = (clsPainting)_work;
            txtWidth.Text = Convert.ToString(painting.Width);
            txtHeight.Text = Convert.ToString(painting.Height);
            txtType.Text = painting.Type;
        }

        protected override void PushData()
        {
            base.PushData();

            var painting = (clsPainting)_work;
            painting.Width = Convert.ToSingle(txtWidth.Text);
            painting.Height = Convert.ToSingle(txtHeight.Text);
            painting.Type = txtType.Text;
        }
    }
}


