Imports Microsoft.VisualBasic
Imports System
Namespace DXApplication5
	Partial Public Class Form1
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
			Me.components = New System.ComponentModel.Container()
			Dim timeRuler1 As New DevExpress.XtraScheduler.TimeRuler()
			Dim timeRuler2 As New DevExpress.XtraScheduler.TimeRuler()
			Me.schedulerStorage = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
			Me.searchControl1 = New DevExpress.XtraEditors.SearchControl()
			Me.layoutControl1 = New DevExpress.XtraLayout.LayoutControl()
			Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
			Me.layoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.emptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
			Me.dateNavigator = New DevExpress.XtraScheduler.DateNavigator()
			Me.schedulerControl = New DXApplication5.CustomSchedulerControl()
			Me.layoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.layoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
			CType(Me.schedulerStorage, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.searchControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.layoutControl1.SuspendLayout()
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.emptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dateNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.schedulerControl, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' schedulerStorage
			' 
			Me.schedulerStorage.Appointments.AutoReload = False
			' 
			' searchControl1
			' 
			Me.searchControl1.Location = New System.Drawing.Point(767, 12)
			Me.searchControl1.Name = "searchControl1"
			Me.searchControl1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Repository.ClearButton(), New DevExpress.XtraEditors.Repository.SearchButton()})
			Me.searchControl1.Properties.EditValueChangedDelay = 2000
			Me.searchControl1.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
			Me.searchControl1.Properties.NullValuePrompt = "Search Calendar (Ctrl+E)"
			Me.searchControl1.Size = New System.Drawing.Size(321, 20)
			Me.searchControl1.StyleController = Me.layoutControl1
			Me.searchControl1.TabIndex = 4
'			Me.searchControl1.ButtonPressed += New DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(Me.searchControl1_ButtonPressed);
'			Me.searchControl1.EditValueChanged += New System.EventHandler(Me.searchControl1_EditValueChanged);
			' 
			' layoutControl1
			' 
			Me.layoutControl1.Controls.Add(Me.searchControl1)
			Me.layoutControl1.Controls.Add(Me.dateNavigator)
			Me.layoutControl1.Controls.Add(Me.schedulerControl)
			Me.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.layoutControl1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControl1.Name = "layoutControl1"
			Me.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(820, 499, 250, 350)
			Me.layoutControl1.Root = Me.layoutControlGroup1
			Me.layoutControl1.Size = New System.Drawing.Size(1100, 700)
			Me.layoutControl1.TabIndex = 8
			Me.layoutControl1.Text = "layoutControl1"
			' 
			' layoutControlGroup1
			' 
			Me.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
			Me.layoutControlGroup1.GroupBordersVisible = False
			Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() { Me.layoutControlItem1, Me.layoutControlItem2, Me.layoutControlItem3, Me.emptySpaceItem1})
			Me.layoutControlGroup1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlGroup1.Name = "Root"
			Me.layoutControlGroup1.Size = New System.Drawing.Size(1100, 700)
			Me.layoutControlGroup1.TextVisible = False
			' 
			' layoutControlItem3
			' 
			Me.layoutControlItem3.Control = Me.searchControl1
			Me.layoutControlItem3.Location = New System.Drawing.Point(755, 0)
			Me.layoutControlItem3.Name = "layoutControlItem3"
			Me.layoutControlItem3.Size = New System.Drawing.Size(325, 24)
			Me.layoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem3.TextVisible = False
			' 
			' emptySpaceItem1
			' 
			Me.emptySpaceItem1.AllowHotTrack = False
			Me.emptySpaceItem1.Location = New System.Drawing.Point(0, 0)
			Me.emptySpaceItem1.Name = "emptySpaceItem1"
			Me.emptySpaceItem1.Size = New System.Drawing.Size(755, 24)
			Me.emptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
			' 
			' dateNavigator
			' 
			Me.dateNavigator.HighlightTodayCell = DevExpress.Utils.DefaultBoolean.Default
			Me.dateNavigator.HotDate = Nothing
			Me.dateNavigator.Location = New System.Drawing.Point(835, 36)
			Me.dateNavigator.Name = "dateNavigator"
			Me.dateNavigator.SchedulerControl = Me.schedulerControl
			Me.dateNavigator.Size = New System.Drawing.Size(253, 652)
			Me.dateNavigator.TabIndex = 1
			' 
			' schedulerControl
			' 
			Me.schedulerControl.Location = New System.Drawing.Point(12, 36)
			Me.schedulerControl.LookAndFeel.UseDefaultLookAndFeel = False
			Me.schedulerControl.Name = "schedulerControl"
			Me.schedulerControl.Size = New System.Drawing.Size(819, 652)
			Me.schedulerControl.Start = New System.DateTime(2014, 12, 26, 0, 0, 0, 0)
			Me.schedulerControl.Storage = Me.schedulerStorage
			Me.schedulerControl.TabIndex = 2
			Me.schedulerControl.Text = "schedulerControl1"
			Me.schedulerControl.Views.DayView.TimeRulers.Add(timeRuler1)
			Me.schedulerControl.Views.WeekView.Enabled = False
			Me.schedulerControl.Views.WorkWeekView.TimeRulers.Add(timeRuler2)
'			Me.schedulerControl.PreviewKeyDown += New System.Windows.Forms.PreviewKeyDownEventHandler(Me.schedulerControl_PreviewKeyDown);
			' 
			' layoutControlItem1
			' 
			Me.layoutControlItem1.Control = Me.schedulerControl
			Me.layoutControlItem1.Location = New System.Drawing.Point(0, 24)
			Me.layoutControlItem1.Name = "layoutControlItem1"
			Me.layoutControlItem1.Size = New System.Drawing.Size(823, 656)
			Me.layoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem1.TextVisible = False
			' 
			' layoutControlItem2
			' 
			Me.layoutControlItem2.Control = Me.dateNavigator
			Me.layoutControlItem2.Location = New System.Drawing.Point(823, 24)
			Me.layoutControlItem2.Name = "layoutControlItem2"
			Me.layoutControlItem2.Size = New System.Drawing.Size(257, 656)
			Me.layoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem2.TextVisible = False
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(1100, 700)
			Me.Controls.Add(Me.layoutControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
			CType(Me.schedulerStorage, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.searchControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.layoutControl1.ResumeLayout(False)
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.emptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dateNavigator, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.schedulerControl, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private schedulerStorage As DevExpress.XtraScheduler.SchedulerStorage
		Private WithEvents searchControl1 As DevExpress.XtraEditors.SearchControl
		Private layoutControl1 As DevExpress.XtraLayout.LayoutControl
		Private dateNavigator As DevExpress.XtraScheduler.DateNavigator
		Private WithEvents schedulerControl As CustomSchedulerControl
		Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
		Private layoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
		Private layoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
		Private layoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
		Private emptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem

	End Class
End Namespace
