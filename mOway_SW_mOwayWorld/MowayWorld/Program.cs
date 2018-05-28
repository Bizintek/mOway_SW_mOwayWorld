using System;
using System.IO;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;

using Moway.Template;


namespace Moway
{

    /// <summary>
    /// Application entry point
    /// </summary>
    /// <LastRevision>24.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    static class Program
    {
        /// <summary>
        /// Main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Detect operating system language           
            if (MowayWorld.Default.ConfigLanguage == false)
            {
                try
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(CultureInfo.InstalledUICulture.Name);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(CultureInfo.InstalledUICulture.Name);
                }
                catch
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
                }
                finally
                {
                    MowayWorld.Default.ConfigLanguage = true;
                }
            }
            else
            {
                //The application language is set
                Thread.CurrentThread.CurrentCulture = new CultureInfo(MowayWorld.Default.Language);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(MowayWorld.Default.Language);
            }

            //Alerts if another instance of the application is running
            bool mutexCreado = false;
            Mutex miMutex = new Mutex(true, "MowayWorld", out mutexCreado);
            if (!mutexCreado)
            {
                if (DialogResult.No == MessageBox.Show(ProgramMessages.WARNING_OPEN + "\r\n" + ProgramMessages.CONTINUE, "mOwayWorld", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    return;
            }

            //Alerts if an instance of MOwayScratch is running
            // Get all processes running on the local computer.
            System.Diagnostics.Process[] localAll = System.Diagnostics.Process.GetProcesses();

            foreach (System.Diagnostics.Process process in localAll)
            {
                if (process.ProcessName == "mOwayScratch")
                {
                    if (DialogResult.No == MessageBox.Show(ProgramMessages.WARNING_OPEN + "\r\n" + ProgramMessages.CONTINUE, "mOwayWorld", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        return;
                }
            }


            //It ensures the existence of the necessary directories for the MOwayWorld
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\mOwayWorld"))
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\mOwayWorld");
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\mOproj"))
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\mOproj");
            //necessary because the library is not properly initialized
            SdlDotNet.Graphics.Video.Initialize();
            //The main form is launched
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                if (args.Length == 0)
                    //The application opens with an empty project
                    Application.Run(new MainForm());
                else
                    //The application is opened from a project file
                    Application.Run(new MainForm(args[0]));
            }
            catch
            {
                //Generic error message
                MowayMessageBox.Show(ProgramMessages.GENERAL_ERROR, "mOwayWorld", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
