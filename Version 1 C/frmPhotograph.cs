using System;

namespace Version_1_C
{
    public sealed partial class frmPhotograph : Version_1_C.frmWork
    {
        private static readonly frmPhotograph _instance = new frmPhotograph();

        public static frmPhotograph Instance
        {
            get
            {
                return _instance;
            }
        }

        private frmPhotograph()
        {
            InitializeComponent();
        }

        protected override void UpdateForm()
        {
            base.UpdateForm();

            var photograph = (clsPhotograph)_work;
            txtWidth.Text = Convert.ToString(photograph.Width);
            txtHeight.Text = Convert.ToString(photograph.Height);
            txtType.Text = photograph.Type;
        }

        protected override void PushData()
        {
            base.PushData();

            var photograph = (clsPhotograph)_work;
            photograph.Width = Convert.ToSingle(txtWidth.Text);
            photograph.Height = Convert.ToSingle(txtHeight.Text);
            photograph.Type = txtType.Text;
        }
    }
}

