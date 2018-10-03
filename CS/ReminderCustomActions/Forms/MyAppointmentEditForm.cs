using System;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.UI;


namespace ReminderCustomActions {
	public partial class MyAppointmentEditForm : DevExpress.XtraEditors.XtraForm {
		SchedulerControl control;
		Appointment apt;
		bool openRecurrenceForm = false;
		int suspendUpdateCount;
		private DevExpress.XtraEditors.CheckEdit checkAllDay;
		// Note that the MyAppointmentFormController class is inherited from
		// the AppointmentFormController one to add custom properties.
		// See its declaration at the end of this file.
		MyAppointmentFormController controller;

		public MyAppointmentEditForm(SchedulerControl control, Appointment apt, bool openRecurrenceForm) {
			this.openRecurrenceForm = openRecurrenceForm;
			this.controller = new MyAppointmentFormController(control, apt);
			this.apt = apt;
			this.control = control;
			//
			// Required for Windows Form Designer support
			//
			SuspendUpdate();
			InitializeComponent();
			ResumeUpdate();

			UpdateForm();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		protected IAppointmentStorage Appointments {
			get { return control.DataStorage.Appointments; }
		}
		protected bool IsUpdateSuspended { get { return suspendUpdateCount > 0; } }

		protected void SuspendUpdate() {
			suspendUpdateCount++;
		}
		protected void ResumeUpdate() {
			if (suspendUpdateCount > 0)
				suspendUpdateCount--;
		}

		private void btnAddRec_Click(object sender, System.EventArgs e) {
			OnRecurrenceButton();
		}

		void OnRecurrenceButton() {
			ShowRecurrenceForm();
		}

		void ShowRecurrenceForm() {

			if (!control.SupportsRecurrence)
				return;

			// Prepare to edit appointment's recurrence.
			Appointment editedAptCopy = controller.EditedAppointmentCopy;
			Appointment editedPattern = controller.EditedPattern;
			Appointment patternCopy = controller.PrepareToRecurrenceEdit();

			AppointmentRecurrenceForm dlg = new AppointmentRecurrenceForm(patternCopy, control.OptionsView.FirstDayOfWeek, controller);

			// Required for skins support.
			dlg.LookAndFeel.ParentLookAndFeel = this.LookAndFeel.ParentLookAndFeel;

			DialogResult result = dlg.ShowDialog(this);
			dlg.Dispose();

			if (result == DialogResult.Abort)
				controller.RemoveRecurrence();
			else
				if (result == DialogResult.OK) {
					controller.ApplyRecurrence(patternCopy);
					if (controller.EditedAppointmentCopy != editedAptCopy)
						UpdateForm();
				}
			UpdateIntervalControls();
		}

		private void btnOK_Click(object sender, System.EventArgs e) {
			// Required to check appointment's conflicts.
			if (!controller.IsConflictResolved())
				return;

			controller.Subject = txSubject.Text;
			controller.SetStatus(edStatus.AppointmentStatus);
			controller.SetLabel(edLabel.AppointmentLabel);
			controller.AllDay = this.checkAllDay.Checked;
			controller.Start = this.dtStart.DateTime.Date + this.timeStart.Time.TimeOfDay;
			controller.End = this.dtEnd.DateTime.Date + this.timeEnd.Time.TimeOfDay;
            controller.ResourceIds.AddRange(appointmentResourcesEdit1.ResourceIds);
            
            controller.CustomPrice = calcPrice.Value;

			// Save all changes made to the appointment edited in a form.
			controller.ApplyChanges();
		}

		void UpdateForm() {
			SuspendUpdate();
			try {
				txSubject.Text = controller.Subject;
				edStatus.AppointmentStatus = Appointments.Statuses.GetById(controller.StatusKey);
				edLabel.AppointmentLabel = Appointments.Labels.GetById(controller.LabelKey);

				dtStart.DateTime = controller.Start.Date;
				dtEnd.DateTime = controller.End.Date;

				timeStart.Time = DateTime.MinValue.AddTicks(controller.Start.TimeOfDay.Ticks);
				timeEnd.Time = DateTime.MinValue.AddTicks(controller.End.TimeOfDay.Ticks);
				checkAllDay.Checked = controller.AllDay;

				edStatus.Storage = control.DataStorage;
				edLabel.Storage = control.DataStorage;
                appointmentResourcesEdit1.SchedulerControl=control;

                AppointmentResourceIdCollection resourceIds = appointmentResourcesEdit1.ResourceIds;
                resourceIds.BeginUpdate();
                try {
                    resourceIds.Clear();
                    resourceIds.AddRange(controller.ResourceIds);
                }
                finally {
                    resourceIds.EndUpdate();
                }
                bool canEditResource = controller.CanEditResource;
                appointmentResourcesEdit1.Enabled = canEditResource;
                lblResource.Enabled = canEditResource;

                calcPrice.Value = controller.CustomPrice;
			}
			finally {
				ResumeUpdate();
			}
			UpdateIntervalControls();
		}

		private void MyAppointmentEditForm_Activated(object sender, System.EventArgs e) {
			// Required to show the recurrence form.
			if (openRecurrenceForm) {
				openRecurrenceForm = false;
				OnRecurrenceButton();
			}
		}

		private void dtStart_EditValueChanged(object sender, System.EventArgs e) {
			if (!IsUpdateSuspended)
				controller.Start = dtStart.DateTime.Date + timeStart.Time.TimeOfDay;
			UpdateIntervalControls();
		}
		protected virtual void UpdateIntervalControls() {
			if (IsUpdateSuspended)
				return;

			SuspendUpdate();
			try {
				dtStart.EditValue = controller.Start.Date;
				dtEnd.EditValue = controller.End.Date;
				timeStart.EditValue = controller.Start.TimeOfDay;
				timeEnd.EditValue = controller.End.TimeOfDay;

				dtStart.Enabled = !controller.AllDay;
				dtEnd.Enabled = !controller.AllDay;
				timeStart.Enabled = !controller.AllDay;
				timeEnd.Enabled = !controller.AllDay;

			}
			finally {
				ResumeUpdate();
			}
		}

        
        private void timeStart_EditValueChanged(object sender, System.EventArgs e) {
			if (!IsUpdateSuspended)
				controller.Start = dtStart.DateTime.Date + timeStart.Time.TimeOfDay;
			UpdateIntervalControls();
		}
		private void timeEnd_EditValueChanged(object sender, System.EventArgs e) {
			if (IsUpdateSuspended) return;
			if (IsIntervalValid())
				controller.End = dtEnd.DateTime + timeEnd.Time.TimeOfDay;
			else
				timeEnd.EditValue = controller.End.TimeOfDay;
		}
		private void dtEnd_EditValueChanged(object sender, System.EventArgs e) {
			if (IsUpdateSuspended) return;
			if (IsIntervalValid())
				controller.End = dtEnd.DateTime + timeEnd.Time.TimeOfDay;
			else
				dtEnd.EditValue = controller.End.Date;
		}
		bool IsIntervalValid() {
			DateTime start = dtStart.DateTime + timeStart.Time.TimeOfDay;
			DateTime end = dtEnd.DateTime + timeEnd.Time.TimeOfDay;
			return end >= start;
		}

		private void checkAllDay_CheckedChanged(object sender, System.EventArgs e) {
			controller.AllDay = this.checkAllDay.Checked;
			if (!IsUpdateSuspended)
				UpdateAppointmentStatus();

			UpdateIntervalControls();
		}
		void UpdateAppointmentStatus() {
			IAppointmentStatus currentStatus = edStatus.AppointmentStatus;
			IAppointmentStatus newStatus = controller.UpdateStatus (currentStatus);
			if (newStatus != currentStatus)
				edStatus.AppointmentStatus = newStatus;
		}
	}
	public class MyAppointmentFormController : AppointmentFormController {

        public decimal CustomPrice { get { return EditedAppointmentCopy.CustomFields["CustomPrice"] != null ? (decimal)EditedAppointmentCopy.CustomFields["CustomPrice"] : 0; } set { EditedAppointmentCopy.CustomFields["CustomPrice"] = value; } }




       decimal SourceCustomPrice { get { return (decimal)SourceAppointment.CustomFields["CustomPrice"]; } set { SourceAppointment.CustomFields["CustomPrice"] = value; } }

		public MyAppointmentFormController(SchedulerControl control, Appointment apt)
			: base(control, apt) {
		}

		public override bool IsAppointmentChanged() {
			if (base.IsAppointmentChanged())
				return true;
			return 
                SourceCustomPrice != CustomPrice;
		}

		protected override void ApplyCustomFieldsValues() {
            SourceCustomPrice = CustomPrice;
		}
	}
}
