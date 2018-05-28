using System;
using System.IO;
using System.Threading;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Moway.Compiler
{
    /// <summary>
    /// Represents a variable in the graphic project
    /// </summary>
    /// <LastRevision>24.09.2011</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class AsmCompiler
    {
        #region Constants

        /// <summary>
        /// Compiler native error codes
        /// </summary>
        const int ERROR_FILE_NOT_FOUND = 2;
        const int ERROR_ACCESS_DENIED = 5;

        #endregion

        /// <summary>
        /// Compile an asm file with the mpaswin compiler from Microchip
        /// </summary>
        /// <param name="asmFile"> Asm file to compile</param>
        /// <returns> True if the compilation has been correct, False otherwise</returns>
        public static bool Compile_mpasmwin(string asmFile)
        {
            string hexFile = Path.ChangeExtension(asmFile, ".hex");
            
            if (File.Exists(hexFile))
                File.Delete(hexFile);

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = Application.StartupPath + "\\mpasmwin.exe";
            proc.StartInfo.Arguments = "/q+ " + asmFile;
            proc.EnableRaisingEvents = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            proc.WaitForExit();

            if (File.Exists(hexFile))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Compile an asm file with the gpasm compiler
        /// </summary>
        /// <param name="asmFile">Asm file to compile</param>
        /// <returns>True if the compilation has been correct, False otherwise</returns>
        public static bool Compile(string asmFile)
        {
            string hexFile = Path.ChangeExtension(asmFile, ".hex");

            if (File.Exists(hexFile))
                File.Delete(hexFile);

            try
            {
                string shortpath = "gpasm.exe -o \"" + hexFile + "\" -I \"" + Application.StartupPath + "\" \"" + asmFile + "\"";

                System.Diagnostics.ProcessStartInfo sinf = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + shortpath);

                //Necessary for it to work. We take the errors and messages from gpasm
                sinf.RedirectStandardOutput = true;
                sinf.RedirectStandardError = true;
                sinf.WorkingDirectory = Application.StartupPath;
                sinf.UseShellExecute = false;
                sinf.CreateNoWindow = true;
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = sinf;
                p.Start();
                p.WaitForExit();

                //Necessary for it to work. We take the errors and messages from gpasm
                string res = p.StandardOutput.ReadToEnd();
                string reserror = p.StandardError.ReadToEnd();
            }
            catch (Win32Exception e)
            {
                switch (e.NativeErrorCode)
                {
                    case ERROR_FILE_NOT_FOUND:
                        throw new CompilerException("File not found");
                    case ERROR_ACCESS_DENIED:
                        throw new CompilerException("Access denied");
                    default:
                        throw new CompilerException("Compiler Error");
                }
            }

            if (File.Exists(hexFile))
                return true;
            else
                return false;
        }
    }
}
