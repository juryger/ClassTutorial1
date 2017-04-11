using System;
using System.Windows.Forms;

namespace Version_1_C
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            clsPainting.LoadPaintingForm = new clsWork.LoadWorkFormDelegate(frmPainting.Instance.Run);
            clsPhotograph.LoadPhotographForm = new clsWork.LoadWorkFormDelegate(frmPhotograph.Instance.Run);
            clsSculpture.LoadSculptureForm = new clsWork.LoadWorkFormDelegate(frmSculpture.Instance.Run);

            Application.Run(frmMain.Instance);
        }
    }
}