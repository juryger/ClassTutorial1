using System;

namespace Version_1_C
{
    public sealed partial class frmPainting : Version_1_C.frmWork
    {
        private static readonly frmPainting _instance = new frmPainting();

        public static frmPainting Instance
        {
            get
            {
                return _instance;
            }
        }

        private frmPainting()
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


