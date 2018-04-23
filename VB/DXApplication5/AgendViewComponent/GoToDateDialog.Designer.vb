' Developer Express Code Central Example:
' How to display appointments in Agenda View by using the GridControl component
' 
' In fact, the Agenda view is a list of upcoming events grouped by the
' appointment's date. This list can be displayed in the GridControl component
' (https://documentation.devexpress.com/#WindowsForms/CustomDocument3464).
' 
' This
' example demonstrates how to implement this behavior.
' 
' 
' Switching between the
' SchedulerControl's view and a GridControl instance (used as an AgendaView) is
' implemented by switching the visibility of the SchedulerControl and GridControl
' instances.
' 
' Since multi-day appointments should be displayed as several
' GridView rows (such appointments should be displayed in each "Day" group in
' accordance with the appointment's duration), we used a separate
' AgendaAppointment class to store the appointment's data.
' 
' To get existing
' appointments from the SchedulerStorage and generate a corresponding collection
' of AgendaAppointment instances, the SchedulerStorage.GetAppointments
' (https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraSchedulerSchedulerStorageBase_GetAppointmentstopic1830)
' method is used.
' 
' By default, a month interval is used to fetch appointments for
' the AgendaView.
' 
' 
' Please see the "Implementation Details" (click the
' corresponding link below this text) to learn more about technical aspects of
' this approach implementation.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E5186


Imports Microsoft.VisualBasic
Imports System
Namespace ListViewComponent
	Partial Public Class GoToDateDialog
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

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.layoutControl1 = New DevExpress.XtraLayout.LayoutControl()
			Me.simpleButtonCancel = New DevExpress.XtraEditors.SimpleButton()
			Me.simpleButtonOk = New DevExpress.XtraEditors.SimpleButton()
			Me.dateEditGoToDate = New DevExpress.XtraEditors.DateEdit()
			Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
			Me.layoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.layoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.layoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.emptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
			CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.layoutControl1.SuspendLayout()
			CType(Me.dateEditGoToDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dateEditGoToDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.emptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' layoutControl1
			' 
			Me.layoutControl1.Controls.Add(Me.simpleButtonCancel)
			Me.layoutControl1.Controls.Add(Me.simpleButtonOk)
			Me.layoutControl1.Controls.Add(Me.dateEditGoToDate)
			Me.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.layoutControl1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControl1.Name = "layoutControl1"
			Me.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(410, 394, 250, 350)
			Me.layoutControl1.Root = Me.layoutControlGroup1
			Me.layoutControl1.Size = New System.Drawing.Size(245, 74)
			Me.layoutControl1.TabIndex = 0
			Me.layoutControl1.Text = "layoutControl1"
			' 
			' simpleButtonCancel
			' 
			Me.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.simpleButtonCancel.Location = New System.Drawing.Point(108, 36)
			Me.simpleButtonCancel.Name = "simpleButtonCancel"
			Me.simpleButtonCancel.Size = New System.Drawing.Size(79, 22)
			Me.simpleButtonCancel.StyleController = Me.layoutControl1
			Me.simpleButtonCancel.TabIndex = 6
			Me.simpleButtonCancel.Text = "Cancel"
			' 
			' simpleButtonOk
			' 
			Me.simpleButtonOk.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.simpleButtonOk.Location = New System.Drawing.Point(12, 36)
			Me.simpleButtonOk.Name = "simpleButtonOk"
			Me.simpleButtonOk.Size = New System.Drawing.Size(92, 22)
			Me.simpleButtonOk.StyleController = Me.layoutControl1
			Me.simpleButtonOk.TabIndex = 5
			Me.simpleButtonOk.Text = "OK"
			' 
			' dateEditGoToDate
			' 
			Me.dateEditGoToDate.EditValue = Nothing
			Me.dateEditGoToDate.Location = New System.Drawing.Point(70, 12)
			Me.dateEditGoToDate.Name = "dateEditGoToDate"
			Me.dateEditGoToDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.dateEditGoToDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.dateEditGoToDate.Size = New System.Drawing.Size(163, 20)
			Me.dateEditGoToDate.StyleController = Me.layoutControl1
			Me.dateEditGoToDate.TabIndex = 4
			' 
			' layoutControlGroup1
			' 
			Me.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1"
			Me.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
			Me.layoutControlGroup1.GroupBordersVisible = False
			Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() { Me.layoutControlItem1, Me.layoutControlItem2, Me.layoutControlItem3, Me.emptySpaceItem1})
			Me.layoutControlGroup1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlGroup1.Name = "layoutControlGroup1"
			Me.layoutControlGroup1.Size = New System.Drawing.Size(245, 74)
			Me.layoutControlGroup1.Text = "layoutControlGroup1"
			Me.layoutControlGroup1.TextVisible = False
			' 
			' layoutControlItem1
			' 
			Me.layoutControlItem1.Control = Me.dateEditGoToDate
			Me.layoutControlItem1.CustomizationFormText = "Go to date:"
			Me.layoutControlItem1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlItem1.Name = "layoutControlItem1"
			Me.layoutControlItem1.Size = New System.Drawing.Size(225, 24)
			Me.layoutControlItem1.Text = "Go to date:"
			Me.layoutControlItem1.TextSize = New System.Drawing.Size(55, 13)
			' 
			' layoutControlItem2
			' 
			Me.layoutControlItem2.Control = Me.simpleButtonOk
			Me.layoutControlItem2.CustomizationFormText = "layoutControlItem2"
			Me.layoutControlItem2.Location = New System.Drawing.Point(0, 24)
			Me.layoutControlItem2.Name = "layoutControlItem2"
			Me.layoutControlItem2.Size = New System.Drawing.Size(96, 30)
			Me.layoutControlItem2.Text = "layoutControlItem2"
			Me.layoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem2.TextToControlDistance = 0
			Me.layoutControlItem2.TextVisible = False
			' 
			' layoutControlItem3
			' 
			Me.layoutControlItem3.Control = Me.simpleButtonCancel
			Me.layoutControlItem3.CustomizationFormText = "layoutControlItem3"
			Me.layoutControlItem3.Location = New System.Drawing.Point(96, 24)
			Me.layoutControlItem3.Name = "layoutControlItem3"
			Me.layoutControlItem3.Size = New System.Drawing.Size(83, 30)
			Me.layoutControlItem3.Text = "layoutControlItem3"
			Me.layoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem3.TextToControlDistance = 0
			Me.layoutControlItem3.TextVisible = False
			' 
			' emptySpaceItem1
			' 
			Me.emptySpaceItem1.AllowHotTrack = False
			Me.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1"
			Me.emptySpaceItem1.Location = New System.Drawing.Point(179, 24)
			Me.emptySpaceItem1.Name = "emptySpaceItem1"
			Me.emptySpaceItem1.Size = New System.Drawing.Size(46, 30)
			Me.emptySpaceItem1.Text = "emptySpaceItem1"
			Me.emptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
			' 
			' GoToDateDialog
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(245, 74)
			Me.Controls.Add(Me.layoutControl1)
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "GoToDateDialog"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Select a date"

			CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.layoutControl1.ResumeLayout(False)
			CType(Me.dateEditGoToDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dateEditGoToDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.emptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private layoutControl1 As DevExpress.XtraLayout.LayoutControl
		Private simpleButtonCancel As DevExpress.XtraEditors.SimpleButton
		Private simpleButtonOk As DevExpress.XtraEditors.SimpleButton
		Private dateEditGoToDate As DevExpress.XtraEditors.DateEdit
		Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
		Private layoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
		Private layoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
		Private layoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
		Private emptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
	End Class
End Namespace