using System;
using System.Windows.Forms;
using Version_1_C.Delegates;

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

            clsPainting.LoadPaintingForm = new LoadWorkFormDelegate(frmPainting.Instance.Run);
            clsPhotograph.LoadPhotographForm = new LoadWorkFormDelegate(frmPhotograph.Instance.Run);
            clsSculpture.LoadSculptureForm = new LoadWorkFormDelegate(frmSculpture.Instance.Run);

            Application.Run(frmMain.Instance);
        }
    }
}