Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraLayout
Imports System.Windows.Forms
Imports System.Reflection
Imports System.IO
Imports System.Drawing
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraEditors

Namespace ListViewComponent
	Public NotInheritable Class ListViewHelper
		Private Shared ListView As ListViewControl
		Private Shared CurrentScheduler As SchedulerControl
		Private Shared navigator As DateNavigator
		Private Shared SearchControlInstance As SearchControl
		Private Sub New()
		End Sub
		Public Shared Sub AddListView(ByVal scheduler As SchedulerControl, ByVal dateNavigator As DateNavigator, ByVal searchControl As SearchControl)
			CurrentScheduler = scheduler
			navigator = dateNavigator
			SearchControlInstance = searchControl
			If Not(TypeOf scheduler.Parent Is LayoutControl) Then
				MessageBox.Show("SchedulerControl should be located within a LayoutControl to enable ListView functionality")
			Else
				ListView = New ListViewControl(CurrentScheduler)
				Dim currentLayout As LayoutControl = TryCast(scheduler.Parent, LayoutControl)
				Dim schedulerLayoutItem As LayoutControlItem = currentLayout.GetItemByControl(CurrentScheduler)
				'Create a layout item and add it to the root group.    
				Dim itemAgendaView As LayoutControlItem = TryCast(currentLayout.Root.AddItem(schedulerLayoutItem, DevExpress.XtraLayout.Utils.InsertType.Top), LayoutControlItem)
				' Set the item's Control and caption.
				itemAgendaView.Name = "layoutControlItemAgendaView"
				itemAgendaView.Control = ListView
				itemAgendaView.TextVisible = False

				ChangeControlsVisibility(CurrentScheduler, True)
				If navigator IsNot Nothing Then
					ChangeControlsVisibility(navigator, True)
				End If
				ChangeControlsVisibility(ListView, False)
			End If
		End Sub

		Public Shared Sub SwitchToListView()
			ChangeControlsVisibility(CurrentScheduler, False)
			If navigator IsNot Nothing Then
				ChangeControlsVisibility(navigator, False)
			End If

			ListView.SetSearchControl(SearchControlInstance)
			ChangeControlsVisibility(ListView, True)
		End Sub

		Public Shared Sub SwitchToNormalView()
			ChangeControlsVisibility(CurrentScheduler, True)
			If navigator IsNot Nothing Then
				ChangeControlsVisibility(navigator, True)
			End If

			ChangeControlsVisibility(ListView, False)
		End Sub

		Private Shared Sub ChangeControlsVisibility(ByVal someControl As Control, ByVal visibility As Boolean)
			If TypeOf someControl.Parent Is LayoutControl Then
				TryCast(someControl.Parent, LayoutControl).GetItemByControl(someControl).Visibility = If(visibility, DevExpress.XtraLayout.Utils.LayoutVisibility.Always, DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization)
			Else
				someControl.Visible = visibility
			End If
		End Sub

	End Class
End Namespace
