Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace ReminderCustomActions
	Friend Module Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread>
		Sub Main()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
'			#Region "#StatusOutOfOfficeColor"
			DevExpress.XtraScheduler.SchedulerCompatibility.StatusOutOfOfficeColor = System.Drawing.Color.FromArgb(&HD9,&H53,&H53)
'			#End Region ' #StatusOutOfOfficeColor
			Application.Run(New Form1())
		End Sub
	End Module
End Namespace
