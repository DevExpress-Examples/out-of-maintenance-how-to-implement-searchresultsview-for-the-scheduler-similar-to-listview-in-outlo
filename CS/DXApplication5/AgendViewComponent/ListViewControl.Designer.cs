namespace ListViewComponent {
    partial class ListViewControl {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.GridControlAppointments = new DevExpress.XtraGrid.GridControl();
            this.gridViewAppointments = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEditIcon = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.gridColumnReminder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDuration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAgendaDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRecurrencePattern = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAppointmentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemAppointments = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlAppointments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAppointments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEditIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.GridControlAppointments);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(777, 562);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // GridControlAppointments
            // 
            this.GridControlAppointments.Location = new System.Drawing.Point(2, 2);
            this.GridControlAppointments.MainView = this.gridViewAppointments;
            this.GridControlAppointments.Name = "GridControlAppointments";
            this.GridControlAppointments.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEditIcon});
            this.GridControlAppointments.Size = new System.Drawing.Size(773, 558);
            this.GridControlAppointments.TabIndex = 0;
            this.GridControlAppointments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewAppointments});
            // 
            // gridViewAppointments
            // 
            this.gridViewAppointments.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.gridViewAppointments.Appearance.Preview.ForeColor = System.Drawing.Color.Blue;
            this.gridViewAppointments.Appearance.Preview.Options.UseFont = true;
            this.gridViewAppointments.Appearance.Preview.Options.UseForeColor = true;
            this.gridViewAppointments.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridViewAppointments.Appearance.Row.Options.UseFont = true;
            this.gridViewAppointments.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnStatus,
            this.gridColumnReminder,
            this.gridColumnSubject,
            this.gridColumnDuration,
            this.gridColumnLocation,
            this.gridColumnAgendaDate,
            this.gridColumnRecurrencePattern,
            this.gridColumnAppointmentID});
            this.gridViewAppointments.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridViewAppointments.GridControl = this.GridControlAppointments;
            this.gridViewAppointments.GroupCount = 1;
            this.gridViewAppointments.GroupFormat = "{1}";
            this.gridViewAppointments.GroupRowHeight = 50;
            this.gridViewAppointments.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ListViewRecurrencePattern", null, "(Recurrence Pattern: Count={0})")});
            this.gridViewAppointments.Name = "gridViewAppointments";
            this.gridViewAppointments.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridViewAppointments.OptionsBehavior.Editable = false;
            this.gridViewAppointments.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewAppointments.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridViewAppointments.OptionsView.ColumnAutoWidth = false;
            this.gridViewAppointments.OptionsView.ShowGroupedColumns = true;
            this.gridViewAppointments.RowHeight = 30;
            this.gridViewAppointments.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumnRecurrencePattern, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumnAgendaDate, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewAppointments.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridViewAppointments_CustomDrawCell);
            this.gridViewAppointments.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewAppointments_RowStyle);
            this.gridViewAppointments.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridViewAppointments_PopupMenuShowing);
            this.gridViewAppointments.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridViewAppointments_CustomUnboundColumnData);
            this.gridViewAppointments.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewAppointments_CustomColumnDisplayText);
            this.gridViewAppointments.DoubleClick += new System.EventHandler(this.gridViewAppointments_DoubleClick);
            // 
            // gridColumnStatus
            // 
            this.gridColumnStatus.Caption = " ";
            this.gridColumnStatus.ColumnEdit = this.repositoryItemPictureEditIcon;
            this.gridColumnStatus.FieldName = "ListViewStatus";
            this.gridColumnStatus.Name = "gridColumnStatus";
            this.gridColumnStatus.OptionsColumn.AllowEdit = false;
            this.gridColumnStatus.OptionsColumn.FixedWidth = true;
            this.gridColumnStatus.Visible = true;
            this.gridColumnStatus.VisibleIndex = 0;
            this.gridColumnStatus.Width = 41;
            // 
            // repositoryItemPictureEditIcon
            // 
            this.repositoryItemPictureEditIcon.Name = "repositoryItemPictureEditIcon";
            this.repositoryItemPictureEditIcon.NullText = " ";
            // 
            // gridColumnReminder
            // 
            this.gridColumnReminder.Caption = " ";
            this.gridColumnReminder.ColumnEdit = this.repositoryItemPictureEditIcon;
            this.gridColumnReminder.FieldName = "gridColumnReminder";
            this.gridColumnReminder.Name = "gridColumnReminder";
            this.gridColumnReminder.OptionsColumn.FixedWidth = true;
            this.gridColumnReminder.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.gridColumnReminder.Visible = true;
            this.gridColumnReminder.VisibleIndex = 1;
            this.gridColumnReminder.Width = 20;
            // 
            // gridColumnSubject
            // 
            this.gridColumnSubject.Caption = "Subject";
            this.gridColumnSubject.FieldName = "ListViewSubject";
            this.gridColumnSubject.Name = "gridColumnSubject";
            this.gridColumnSubject.Visible = true;
            this.gridColumnSubject.VisibleIndex = 2;
            this.gridColumnSubject.Width = 166;
            // 
            // gridColumnDuration
            // 
            this.gridColumnDuration.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.gridColumnDuration.AppearanceCell.Options.UseFont = true;
            this.gridColumnDuration.Caption = "Duration";
            this.gridColumnDuration.FieldName = "ListViewDuration";
            this.gridColumnDuration.Name = "gridColumnDuration";
            this.gridColumnDuration.Visible = true;
            this.gridColumnDuration.VisibleIndex = 3;
            this.gridColumnDuration.Width = 128;
            // 
            // gridColumnLocation
            // 
            this.gridColumnLocation.Caption = "Location";
            this.gridColumnLocation.FieldName = "ListViewLocation";
            this.gridColumnLocation.Name = "gridColumnLocation";
            this.gridColumnLocation.Visible = true;
            this.gridColumnLocation.VisibleIndex = 4;
            this.gridColumnLocation.Width = 98;
            // 
            // gridColumnAgendaDate
            // 
            this.gridColumnAgendaDate.DisplayFormat.FormatString = "dd (dddd) - MMMM - yyyy";
            this.gridColumnAgendaDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnAgendaDate.FieldName = "ListViewDate";
            this.gridColumnAgendaDate.GroupFormat.FormatString = "dd (dddd) - MMMM - yyyy";
            this.gridColumnAgendaDate.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnAgendaDate.Name = "gridColumnAgendaDate";
            this.gridColumnAgendaDate.Visible = true;
            this.gridColumnAgendaDate.VisibleIndex = 5;
            this.gridColumnAgendaDate.Width = 170;
            // 
            // gridColumnRecurrencePattern
            // 
            this.gridColumnRecurrencePattern.Caption = "Recurrence Pattern";
            this.gridColumnRecurrencePattern.FieldName = "ListViewRecurrencePattern";
            this.gridColumnRecurrencePattern.Name = "gridColumnRecurrencePattern";
            this.gridColumnRecurrencePattern.Visible = true;
            this.gridColumnRecurrencePattern.VisibleIndex = 6;
            this.gridColumnRecurrencePattern.Width = 200;
            // 
            // gridColumnAppointmentID
            // 
            this.gridColumnAppointmentID.Caption = "Appointment ID";
            this.gridColumnAppointmentID.FieldName = "ListViewAppointmentID";
            this.gridColumnAppointmentID.Name = "gridColumnAppointmentID";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemAppointments});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(777, 562);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItemAppointments
            // 
            this.layoutControlItemAppointments.Control = this.GridControlAppointments;
            this.layoutControlItemAppointments.CustomizationFormText = "layoutControlItemAppointments";
            this.layoutControlItemAppointments.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemAppointments.Name = "layoutControlItemAppointments";
            this.layoutControlItemAppointments.Size = new System.Drawing.Size(777, 562);
            this.layoutControlItemAppointments.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemAppointments.TextVisible = false;
            // 
            // ListViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "ListViewControl";
            this.Size = new System.Drawing.Size(777, 562);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlAppointments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAppointments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEditIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemAppointments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl GridControlAppointments;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAppointments;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemAppointments;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnReminder;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSubject;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDuration;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLocation;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAgendaDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEditIcon;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRecurrencePattern;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAppointmentID;
    }
}
