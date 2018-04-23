using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReminderCustomActions {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            #region #StatusOutOfOfficeColor
            DevExpress.XtraScheduler.SchedulerCompatibility.StatusOutOfOfficeColor = System.Drawing.Color.FromArgb(0xD9,0x53,0x53);
            #endregion #StatusOutOfOfficeColor
            Application.Run(new Form1());
        }
    }
}
