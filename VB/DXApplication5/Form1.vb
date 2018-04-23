Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraEditors
Imports DevExpress.XtraScheduler
Imports ListViewComponent


Namespace DXApplication5
	Partial Public Class Form1
		Inherits XtraForm
		Public Sub New()
			InitializeComponent()
			schedulerControl.Start = System.DateTime.Now
			searchControl1.Client = schedulerControl
			schedulerControl.GroupType = SchedulerGroupType.Resource

			InitResources()
			InitAppointments()

			ListViewHelper.AddListView(schedulerControl, dateNavigator, searchControl1)
		End Sub
		#Region "data"
		Private Sub InitResources()
			DataHelper.FillResources(schedulerStorage, 5)
		End Sub
		Private Sub InitAppointments()
			Dim count As Integer = schedulerStorage.Resources.Count
			DataHelper.GenerateEvents(schedulerStorage, count)
		End Sub
		#End Region
		#Region "events"
		Private Sub searchControl1_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles searchControl1.EditValueChanged
			ListViewHelper.SwitchToListView()
		End Sub
		Private Sub searchControl1_ButtonPressed(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles searchControl1.ButtonPressed
			If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
				ListViewHelper.SwitchToNormalView()
				schedulerControl.SetSearchControl(searchControl1)
			End If
		End Sub

		#End Region

		Private Sub schedulerControl_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles schedulerControl.PreviewKeyDown
			If e.Control AndAlso e.KeyCode = System.Windows.Forms.Keys.E Then
				searchControl1.Focus()
				e.IsInputKey = False
			End If
		End Sub
	End Class

End Namespace