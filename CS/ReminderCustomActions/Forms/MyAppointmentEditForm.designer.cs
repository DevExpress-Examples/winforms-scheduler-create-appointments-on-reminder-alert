namespace ReminderCustomActions {
	partial class MyAppointmentEditForm {
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnRecurrence = new DevExpress.XtraEditors.SimpleButton();
            this.lblSubject = new System.Windows.Forms.Label();
            this.txSubject = new DevExpress.XtraEditors.TextEdit();
            this.edLabel = new DevExpress.XtraScheduler.UI.AppointmentLabelEdit();
            this.edStatus = new DevExpress.XtraScheduler.UI.AppointmentStatusEdit();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblLabel = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtStart = new DevExpress.XtraEditors.DateEdit();
            this.dtEnd = new DevExpress.XtraEditors.DateEdit();
            this.timeStart = new DevExpress.XtraEditors.TimeEdit();
            this.timeEnd = new DevExpress.XtraEditors.TimeEdit();
            this.checkAllDay = new DevExpress.XtraEditors.CheckEdit();
            this.appointmentResourcesEdit1 = new DevExpress.XtraScheduler.UI.AppointmentResourcesEdit();
            this.lblResource = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.calcPrice = new DevExpress.XtraEditors.CalcEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edLabel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAllDay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentResourcesEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcPrice.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(11, 253);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 27);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(108, 253);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            // 
            // btnRecurrence
            // 
            this.btnRecurrence.Location = new System.Drawing.Point(203, 253);
            this.btnRecurrence.Name = "btnRecurrence";
            this.btnRecurrence.Size = new System.Drawing.Size(80, 27);
            this.btnRecurrence.TabIndex = 12;
            this.btnRecurrence.Text = "Recurrence";
            this.btnRecurrence.Click += new System.EventHandler(this.btnAddRec_Click);
            // 
            // lblSubject
            // 
            this.lblSubject.Location = new System.Drawing.Point(8, 9);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(48, 18);
            this.lblSubject.TabIndex = 4;
            this.lblSubject.Text = "Subject:";
            // 
            // txSubject
            // 
            this.txSubject.EditValue = "";
            this.txSubject.Location = new System.Drawing.Point(96, 8);
            this.txSubject.Name = "txSubject";
            this.txSubject.Size = new System.Drawing.Size(192, 20);
            this.txSubject.TabIndex = 0;
            // 
            // edLabel
            // 
            this.edLabel.Location = new System.Drawing.Point(96, 136);
            this.edLabel.Name = "edLabel";
            this.edLabel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edLabel.Size = new System.Drawing.Size(192, 20);
            this.edLabel.TabIndex = 7;
            // 
            // edStatus
            // 
            this.edStatus.Location = new System.Drawing.Point(96, 112);
            this.edStatus.Name = "edStatus";
            this.edStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edStatus.Size = new System.Drawing.Size(192, 20);
            this.edStatus.TabIndex = 6;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(8, 112);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(48, 18);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Status:";
            // 
            // lblLabel
            // 
            this.lblLabel.Location = new System.Drawing.Point(8, 139);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(48, 19);
            this.lblLabel.TabIndex = 11;
            this.lblLabel.Text = "Label:";
            // 
            // lblStart
            // 
            this.lblStart.Location = new System.Drawing.Point(8, 41);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(56, 18);
            this.lblStart.TabIndex = 12;
            this.lblStart.Text = "Start:";
            // 
            // lblEnd
            // 
            this.lblEnd.Location = new System.Drawing.Point(8, 65);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(48, 18);
            this.lblEnd.TabIndex = 13;
            this.lblEnd.Text = "End:";
            // 
            // dtStart
            // 
            this.dtStart.EditValue = new System.DateTime(2008, 6, 27, 0, 0, 0, 0);
            this.dtStart.Location = new System.Drawing.Point(96, 40);
            this.dtStart.Name = "dtStart";
            this.dtStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtStart.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtStart.Size = new System.Drawing.Size(96, 20);
            this.dtStart.TabIndex = 1;
            this.dtStart.EditValueChanged += new System.EventHandler(this.dtStart_EditValueChanged);
            // 
            // dtEnd
            // 
            this.dtEnd.EditValue = new System.DateTime(2008, 6, 27, 0, 0, 0, 0);
            this.dtEnd.Location = new System.Drawing.Point(96, 64);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtEnd.Size = new System.Drawing.Size(96, 20);
            this.dtEnd.TabIndex = 3;
            this.dtEnd.EditValueChanged += new System.EventHandler(this.dtEnd_EditValueChanged);
            // 
            // timeStart
            // 
            this.timeStart.EditValue = new System.DateTime(2006, 3, 28, 0, 0, 0, 0);
            this.timeStart.Location = new System.Drawing.Point(208, 40);
            this.timeStart.Name = "timeStart";
            this.timeStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeStart.Size = new System.Drawing.Size(80, 20);
            this.timeStart.TabIndex = 2;
            this.timeStart.EditValueChanged += new System.EventHandler(this.timeStart_EditValueChanged);
            // 
            // timeEnd
            // 
            this.timeEnd.EditValue = new System.DateTime(2006, 3, 28, 0, 0, 0, 0);
            this.timeEnd.Location = new System.Drawing.Point(208, 64);
            this.timeEnd.Name = "timeEnd";
            this.timeEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEnd.Size = new System.Drawing.Size(80, 20);
            this.timeEnd.TabIndex = 4;
            this.timeEnd.EditValueChanged += new System.EventHandler(this.timeEnd_EditValueChanged);
            // 
            // checkAllDay
            // 
            this.checkAllDay.Location = new System.Drawing.Point(94, 88);
            this.checkAllDay.Name = "checkAllDay";
            this.checkAllDay.Properties.Caption = "All day event";
            this.checkAllDay.Size = new System.Drawing.Size(88, 19);
            this.checkAllDay.TabIndex = 5;
            this.checkAllDay.CheckedChanged += new System.EventHandler(this.checkAllDay_CheckedChanged);
            // 
            // appointmentResourcesEdit1
            // 
            this.appointmentResourcesEdit1.EditValue = "(None)";
            this.appointmentResourcesEdit1.Location = new System.Drawing.Point(96, 162);
            this.appointmentResourcesEdit1.Name = "appointmentResourcesEdit1";
            this.appointmentResourcesEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.appointmentResourcesEdit1.Size = new System.Drawing.Size(192, 20);
            this.appointmentResourcesEdit1.TabIndex = 17;
            // 
            // lblResource
            // 
            this.lblResource.AutoSize = true;
            this.lblResource.Location = new System.Drawing.Point(8, 169);
            this.lblResource.Name = "lblResource";
            this.lblResource.Size = new System.Drawing.Size(61, 13);
            this.lblResource.TabIndex = 18;
            this.lblResource.Text = "Resources:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(8, 208);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(34, 13);
            this.lblPrice.TabIndex = 20;
            this.lblPrice.Text = "Price:";
            // 
            // calcPrice
            // 
            this.calcPrice.Location = new System.Drawing.Point(96, 205);
            this.calcPrice.Name = "calcPrice";
            this.calcPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calcPrice.Properties.DisplayFormat.FormatString = "C";
            this.calcPrice.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.calcPrice.Size = new System.Drawing.Size(100, 20);
            this.calcPrice.TabIndex = 21;
            // 
            // MyAppointmentEditForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(298, 292);
            this.Controls.Add(this.calcPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblResource);
            this.Controls.Add(this.appointmentResourcesEdit1);
            this.Controls.Add(this.checkAllDay);
            this.Controls.Add(this.timeEnd);
            this.Controls.Add(this.timeStart);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.dtStart);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblLabel);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.edStatus);
            this.Controls.Add(this.edLabel);
            this.Controls.Add(this.txSubject);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.btnRecurrence);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MyAppointmentEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Custom Appointment Form";
            this.Activated += new System.EventHandler(this.MyAppointmentEditForm_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.txSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edLabel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAllDay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentResourcesEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcPrice.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private DevExpress.XtraEditors.SimpleButton btnOK;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.TextEdit txSubject;
		private DevExpress.XtraEditors.SimpleButton btnRecurrence;
		private DevExpress.XtraScheduler.UI.AppointmentLabelEdit edLabel;
		private DevExpress.XtraScheduler.UI.AppointmentStatusEdit edStatus;
		private System.Windows.Forms.Label lblSubject;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Label lblLabel;
		private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblEnd;
		private DevExpress.XtraEditors.DateEdit dtStart;
		private DevExpress.XtraEditors.DateEdit dtEnd;
		private DevExpress.XtraEditors.TimeEdit timeStart;
		private DevExpress.XtraEditors.TimeEdit timeEnd;
        private DevExpress.XtraScheduler.UI.AppointmentResourcesEdit appointmentResourcesEdit1;
        private System.Windows.Forms.Label lblResource;
        private System.Windows.Forms.Label lblPrice;
        private DevExpress.XtraEditors.CalcEdit calcPrice;
	}
}
