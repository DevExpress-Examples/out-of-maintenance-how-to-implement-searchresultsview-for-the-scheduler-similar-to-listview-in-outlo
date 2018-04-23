Imports Microsoft.VisualBasic
Imports System
Namespace ListViewComponent
	Partial Public Class ListViewControl
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.layoutControl1 = New DevExpress.XtraLayout.LayoutControl()
			Me.GridControlAppointments = New DevExpress.XtraGrid.GridControl()
			Me.gridViewAppointments = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.gridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.repositoryItemPictureEditIcon = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
			Me.gridColumnReminder = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.gridColumnSubject = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.gridColumnDuration = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.gridColumnLocation = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.gridColumnAgendaDate = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.gridColumnRecurrencePattern = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.gridColumnAppointmentID = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
			Me.layoutControlItemAppointments = New DevExpress.XtraLayout.LayoutControlItem()
			CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.layoutControl1.SuspendLayout()
			CType(Me.GridControlAppointments, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridViewAppointments, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.repositoryItemPictureEditIcon, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItemAppointments, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' layoutControl1
			' 
			Me.layoutControl1.Controls.Add(Me.GridControlAppointments)
			Me.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.layoutControl1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControl1.Name = "layoutControl1"
			Me.layoutControl1.Root = Me.layoutControlGroup1
			Me.layoutControl1.Size = New System.Drawing.Size(777, 562)
			Me.layoutControl1.TabIndex = 0
			Me.layoutControl1.Text = "layoutControl1"
			' 
			' GridControlAppointments
			' 
			Me.GridControlAppointments.Location = New System.Drawing.Point(2, 2)
			Me.GridControlAppointments.MainView = Me.gridViewAppointments
			Me.GridControlAppointments.Name = "GridControlAppointments"
			Me.GridControlAppointments.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() { Me.repositoryItemPictureEditIcon})
			Me.GridControlAppointments.Size = New System.Drawing.Size(773, 558)
			Me.GridControlAppointments.TabIndex = 0
			Me.GridControlAppointments.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridViewAppointments})
			' 
			' gridViewAppointments
			' 
			Me.gridViewAppointments.Appearance.Preview.Font = New System.Drawing.Font("Tahoma", 10F, (CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle)))
			Me.gridViewAppointments.Appearance.Preview.ForeColor = System.Drawing.Color.Blue
			Me.gridViewAppointments.Appearance.Preview.Options.UseFont = True
			Me.gridViewAppointments.Appearance.Preview.Options.UseForeColor = True
			Me.gridViewAppointments.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 10F)
			Me.gridViewAppointments.Appearance.Row.Options.UseFont = True
			Me.gridViewAppointments.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.gridColumnStatus, Me.gridColumnReminder, Me.gridColumnSubject, Me.gridColumnDuration, Me.gridColumnLocation, Me.gridColumnAgendaDate, Me.gridColumnRecurrencePattern, Me.gridColumnAppointmentID})
			Me.gridViewAppointments.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
			Me.gridViewAppointments.GridControl = Me.GridControlAppointments
			Me.gridViewAppointments.GroupCount = 1
			Me.gridViewAppointments.GroupFormat = "{1}"
			Me.gridViewAppointments.GroupRowHeight = 50
			Me.gridViewAppointments.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() { New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ListViewRecurrencePattern", Nothing, "(Recurrence Pattern: Count={0})")})
			Me.gridViewAppointments.Name = "gridViewAppointments"
			Me.gridViewAppointments.OptionsBehavior.AutoExpandAllGroups = True
			Me.gridViewAppointments.OptionsBehavior.Editable = False
			Me.gridViewAppointments.OptionsSelection.EnableAppearanceFocusedCell = False
			Me.gridViewAppointments.OptionsSelection.EnableAppearanceFocusedRow = False
			Me.gridViewAppointments.OptionsView.ColumnAutoWidth = False
			Me.gridViewAppointments.OptionsView.ShowGroupedColumns = True
			Me.gridViewAppointments.RowHeight = 30
			Me.gridViewAppointments.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() { New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.gridColumnRecurrencePattern, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.gridColumnAgendaDate, DevExpress.Data.ColumnSortOrder.Ascending)})
'			Me.gridViewAppointments.CustomDrawCell += New DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(Me.gridViewAppointments_CustomDrawCell);
'			Me.gridViewAppointments.RowStyle += New DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(Me.gridViewAppointments_RowStyle);
'			Me.gridViewAppointments.PopupMenuShowing += New DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(Me.gridViewAppointments_PopupMenuShowing);
'			Me.gridViewAppointments.CustomUnboundColumnData += New DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(Me.gridViewAppointments_CustomUnboundColumnData);
'			Me.gridViewAppointments.CustomColumnDisplayText += New DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(Me.gridViewAppointments_CustomColumnDisplayText);
'			Me.gridViewAppointments.DoubleClick += New System.EventHandler(Me.gridViewAppointments_DoubleClick);
			' 
			' gridColumnStatus
			' 
			Me.gridColumnStatus.Caption = " "
			Me.gridColumnStatus.ColumnEdit = Me.repositoryItemPictureEditIcon
			Me.gridColumnStatus.FieldName = "ListViewStatus"
			Me.gridColumnStatus.Name = "gridColumnStatus"
			Me.gridColumnStatus.OptionsColumn.AllowEdit = False
			Me.gridColumnStatus.OptionsColumn.FixedWidth = True
			Me.gridColumnStatus.Visible = True
			Me.gridColumnStatus.VisibleIndex = 0
			Me.gridColumnStatus.Width = 41
			' 
			' repositoryItemPictureEditIcon
			' 
			Me.repositoryItemPictureEditIcon.Name = "repositoryItemPictureEditIcon"
			Me.repositoryItemPictureEditIcon.NullText = " "
			' 
			' gridColumnReminder
			' 
			Me.gridColumnReminder.Caption = " "
			Me.gridColumnReminder.ColumnEdit = Me.repositoryItemPictureEditIcon
			Me.gridColumnReminder.FieldName = "gridColumnReminder"
			Me.gridColumnReminder.Name = "gridColumnReminder"
			Me.gridColumnReminder.OptionsColumn.FixedWidth = True
			Me.gridColumnReminder.UnboundType = DevExpress.Data.UnboundColumnType.Object
			Me.gridColumnReminder.Visible = True
			Me.gridColumnReminder.VisibleIndex = 1
			Me.gridColumnReminder.Width = 20
			' 
			' gridColumnSubject
			' 
			Me.gridColumnSubject.Caption = "Subject"
			Me.gridColumnSubject.FieldName = "ListViewSubject"
			Me.gridColumnSubject.Name = "gridColumnSubject"
			Me.gridColumnSubject.Visible = True
			Me.gridColumnSubject.VisibleIndex = 2
			Me.gridColumnSubject.Width = 166
			' 
			' gridColumnDuration
			' 
			Me.gridColumnDuration.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25F, (CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle)))
			Me.gridColumnDuration.AppearanceCell.Options.UseFont = True
			Me.gridColumnDuration.Caption = "Duration"
			Me.gridColumnDuration.FieldName = "ListViewDuration"
			Me.gridColumnDuration.Name = "gridColumnDuration"
			Me.gridColumnDuration.Visible = True
			Me.gridColumnDuration.VisibleIndex = 3
			Me.gridColumnDuration.Width = 128
			' 
			' gridColumnLocation
			' 
			Me.gridColumnLocation.Caption = "Location"
			Me.gridColumnLocation.FieldName = "ListViewLocation"
			Me.gridColumnLocation.Name = "gridColumnLocation"
			Me.gridColumnLocation.Visible = True
			Me.gridColumnLocation.VisibleIndex = 4
			Me.gridColumnLocation.Width = 98
			' 
			' gridColumnAgendaDate
			' 
			Me.gridColumnAgendaDate.DisplayFormat.FormatString = "dd (dddd) - MMMM - yyyy"
			Me.gridColumnAgendaDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
			Me.gridColumnAgendaDate.FieldName = "ListViewDate"
			Me.gridColumnAgendaDate.GroupFormat.FormatString = "dd (dddd) - MMMM - yyyy"
			Me.gridColumnAgendaDate.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime
			Me.gridColumnAgendaDate.Name = "gridColumnAgendaDate"
			Me.gridColumnAgendaDate.Visible = True
			Me.gridColumnAgendaDate.VisibleIndex = 5
			Me.gridColumnAgendaDate.Width = 170
			' 
			' gridColumnRecurrencePattern
			' 
			Me.gridColumnRecurrencePattern.Caption = "Recurrence Pattern"
			Me.gridColumnRecurrencePattern.FieldName = "ListViewRecurrencePattern"
			Me.gridColumnRecurrencePattern.Name = "gridColumnRecurrencePattern"
			Me.gridColumnRecurrencePattern.Visible = True
			Me.gridColumnRecurrencePattern.VisibleIndex = 6
			Me.gridColumnRecurrencePattern.Width = 200
			' 
			' gridColumnAppointmentID
			' 
			Me.gridColumnAppointmentID.Caption = "Appointment ID"
			Me.gridColumnAppointmentID.FieldName = "ListViewAppointmentID"
			Me.gridColumnAppointmentID.Name = "gridColumnAppointmentID"
			' 
			' layoutControlGroup1
			' 
			Me.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1"
			Me.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
			Me.layoutControlGroup1.GroupBordersVisible = False
			Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() { Me.layoutControlItemAppointments})
			Me.layoutControlGroup1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlGroup1.Name = "layoutControlGroup1"
			Me.layoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
			Me.layoutControlGroup1.Size = New System.Drawing.Size(777, 562)
			Me.layoutControlGroup1.TextVisible = False
			' 
			' layoutControlItemAppointments
			' 
			Me.layoutControlItemAppointments.Control = Me.GridControlAppointments
			Me.layoutControlItemAppointments.CustomizationFormText = "layoutControlItemAppointments"
			Me.layoutControlItemAppointments.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlItemAppointments.Name = "layoutControlItemAppointments"
			Me.layoutControlItemAppointments.Size = New System.Drawing.Size(777, 562)
			Me.layoutControlItemAppointments.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItemAppointments.TextVisible = False
			' 
			' ListViewControl
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.layoutControl1)
			Me.Name = "ListViewControl"
			Me.Size = New System.Drawing.Size(777, 562)
			CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.layoutControl1.ResumeLayout(False)
			CType(Me.GridControlAppointments, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridViewAppointments, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.repositoryItemPictureEditIcon, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItemAppointments, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private layoutControl1 As DevExpress.XtraLayout.LayoutControl
		Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
		Private GridControlAppointments As DevExpress.XtraGrid.GridControl
		Private WithEvents gridViewAppointments As DevExpress.XtraGrid.Views.Grid.GridView
		Private layoutControlItemAppointments As DevExpress.XtraLayout.LayoutControlItem
		Private gridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
		Private gridColumnReminder As DevExpress.XtraGrid.Columns.GridColumn
		Private gridColumnSubject As DevExpress.XtraGrid.Columns.GridColumn
		Private gridColumnDuration As DevExpress.XtraGrid.Columns.GridColumn
		Private gridColumnLocation As DevExpress.XtraGrid.Columns.GridColumn
		Private gridColumnAgendaDate As DevExpress.XtraGrid.Columns.GridColumn
		Private repositoryItemPictureEditIcon As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
		Private gridColumnRecurrencePattern As DevExpress.XtraGrid.Columns.GridColumn
		Private gridColumnAppointmentID As DevExpress.XtraGrid.Columns.GridColumn
	End Class
End Namespace
