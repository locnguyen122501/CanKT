using CanKT.FormChucNang;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CanKT
{
    internal static class Program
    {
        private static string _apppath = "";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain("Loc","Admin"));
        }

        public static string AppPath
        {
            get
            {
                if (_apppath != "")
                    return _apppath;
                _apppath = (Application.StartupPath.ToLower());
                _apppath = _apppath.Replace(@"\bin\debug", @"\").Replace(@"\bin\release", @"\");
                _apppath = _apppath.Replace(@"\bin\x86\debug", @"\").Replace(@"\bin\x86\release", @"\");
                _apppath = _apppath.Replace(@"\bin\x64\debug", @"\").Replace(@"\bin\x64\release", @"\");

                _apppath = _apppath.Replace(@"\\", @"\");

                if (!_apppath.EndsWith(@"\"))
                    _apppath += @"\";
                Directory.SetCurrentDirectory(_apppath);
                return _apppath;
            }
        }
    }
}
