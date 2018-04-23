Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraGrid.Menu
Imports System.Drawing
Imports System.Reflection

Namespace ListViewComponent
	Public NotInheritable Class ListViewMenuBuilder
		Public Shared Property Scheduler() As SchedulerControl
		Public Shared Property CurrentAppointment() As Appointment

		Public Shared Property ViewControl() As ListViewControl

		Private Sub New()
		End Sub
		Public Shared Sub GenerateContextMenu(ByVal viewControl As ListViewControl, ByVal contextMenu As GridViewMenu, ByVal control As SchedulerControl, ByVal apt As Appointment)
			Scheduler = control
			CurrentAppointment = apt
			ViewControl = viewControl
			If apt IsNot Nothing Then
				contextMenu.Items.Add(New DevExpress.Utils.Menu.DXMenuItem("Open appointment", AddressOf OnOpenCurrentAppointment))
                contextMenu.Items.Add(New DevExpress.Utils.Menu.DXMenuItem("Delete appointment", AddressOf OnDeleteCurrentAppointment, Image.FromStream(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Delete.png"))))
			End If


			Dim switchView As New DevExpress.Utils.Menu.DXSubMenuItem("Change view to")
			switchView.BeginGroup = True
			contextMenu.Items.Add(switchView)

			If Scheduler.DayView.Enabled Then
                switchView.Items.Add(New DevExpress.Utils.Menu.DXMenuItem("Day View", AddressOf OnSwitchToDayView, Image.FromStream(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DayView.png"))))
			End If
			If Scheduler.WorkWeekView.Enabled Then
                switchView.Items.Add(New DevExpress.Utils.Menu.DXMenuItem("Work Week View", AddressOf OnSwitchToWorkWeekView, Image.FromStream(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("WorkWeekView.png"))))
			End If
			If Scheduler.WeekView.Enabled Then
                switchView.Items.Add(New DevExpress.Utils.Menu.DXMenuItem("Week View", AddressOf OnSwitchToWeekView, Image.FromStream(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("WeekView.png"))))
			End If
			If Scheduler.MonthView.Enabled Then
                switchView.Items.Add(New DevExpress.Utils.Menu.DXMenuItem("Month View", AddressOf OnSwitchToMonthView, Image.FromStream(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MonthView.png"))))
			End If
			If Scheduler.TimelineView.Enabled Then
                switchView.Items.Add(New DevExpress.Utils.Menu.DXMenuItem("Timeline View", AddressOf OnSwitchToTimelineView, Image.FromStream(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("TimelineView.png"))))
			End If
			If Scheduler.GanttView.Enabled Then
                switchView.Items.Add(New DevExpress.Utils.Menu.DXMenuItem("Gantt View", AddressOf OnSwitchToGanttView, Image.FromStream(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("GanttView.png"))))
			End If


		End Sub

		Public Shared Sub OnOpenCurrentAppointment(ByVal sender As Object, ByVal e As EventArgs)
			Scheduler.ShowEditAppointmentForm(CurrentAppointment, CurrentAppointment.IsRecurring)
			ViewControl.ChangeAppointment(CurrentAppointment)

		End Sub

		Public Shared Sub OnDeleteCurrentAppointment(ByVal sender As Object, ByVal e As EventArgs)
			ViewControl.DeleteAppointment(CurrentAppointment)
			Scheduler.DeleteAppointment(CurrentAppointment)

		End Sub

		Public Shared Sub OnSwitchToDayView(ByVal sender As Object, ByVal e As EventArgs)
			Scheduler.ActiveViewType = SchedulerViewType.Day
			ListViewHelper.SwitchToNormalView()
		End Sub

		Public Shared Sub OnSwitchToWorkWeekView(ByVal sender As Object, ByVal e As EventArgs)
			Scheduler.ActiveViewType = SchedulerViewType.WorkWeek
			ListViewHelper.SwitchToNormalView()
		End Sub

		Public Shared Sub OnSwitchToWeekView(ByVal sender As Object, ByVal e As EventArgs)
			Scheduler.ActiveViewType = SchedulerViewType.Week
			ListViewHelper.SwitchToNormalView()
		End Sub

		Public Shared Sub OnSwitchToMonthView(ByVal sender As Object, ByVal e As EventArgs)
			Scheduler.ActiveViewType = SchedulerViewType.Month
			ListViewHelper.SwitchToNormalView()
		End Sub

		Public Shared Sub OnSwitchToTimelineView(ByVal sender As Object, ByVal e As EventArgs)
			Scheduler.ActiveViewType = SchedulerViewType.Timeline
			ListViewHelper.SwitchToNormalView()
		End Sub

		Public Shared Sub OnSwitchToGanttView(ByVal sender As Object, ByVal e As EventArgs)
			Scheduler.ActiveViewType = SchedulerViewType.Gantt
			ListViewHelper.SwitchToNormalView()
		End Sub


	End Class
End Namespace
