using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraScheduler;
using DevExpress.XtraGrid.Menu;
using System.Drawing;
using System.Reflection;

namespace ListViewComponent {
    public static class ListViewMenuBuilder {
        public static SchedulerControl Scheduler { get; set; }
        public static Appointment CurrentAppointment { get; set; }

        public static ListViewControl ViewControl {
            get;
            set;
        }

        public static void GenerateContextMenu(ListViewControl viewControl, GridViewMenu contextMenu, SchedulerControl control, Appointment apt) {
            Scheduler = control;
            CurrentAppointment = apt;
            ViewControl = viewControl;
            if(apt != null) {
                contextMenu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Open appointment", OnOpenCurrentAppointment));
                contextMenu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Delete appointment", OnDeleteCurrentAppointment, Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("ListViewComponent.Resources.Delete.png"))));                
            }
            

            DevExpress.Utils.Menu.DXSubMenuItem switchView = new DevExpress.Utils.Menu.DXSubMenuItem("Change view to");
            switchView.BeginGroup = true;
            contextMenu.Items.Add(switchView);

            if (Scheduler.DayView.Enabled) switchView.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Day View", OnSwitchToDayView, Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("ListViewComponent.Resources.DayView.png"))));
            if (Scheduler.WorkWeekView.Enabled) switchView.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Work Week View", OnSwitchToWorkWeekView, Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("ListViewComponent.Resources.WorkWeekView.png"))));
            if (Scheduler.WeekView.Enabled) switchView.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Week View", OnSwitchToWeekView, Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("ListViewComponent.Resources.WeekView.png"))));
            if (Scheduler.MonthView.Enabled) switchView.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Month View", OnSwitchToMonthView, Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("ListViewComponent.Resources.MonthView.png"))));
            if (Scheduler.TimelineView.Enabled) switchView.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Timeline View", OnSwitchToTimelineView, Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("ListViewComponent.Resources.TimelineView.png"))));
            if (Scheduler.GanttView.Enabled) switchView.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Gantt View", OnSwitchToGanttView, Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("ListViewComponent.Resources.GanttView.png"))));

            
        }

        public static void OnOpenCurrentAppointment(object sender, EventArgs e) {
            Scheduler.ShowEditAppointmentForm(CurrentAppointment, CurrentAppointment.IsRecurring);
            ViewControl.ChangeAppointment(CurrentAppointment);
            
        }

        public static void OnDeleteCurrentAppointment(object sender, EventArgs e) {
            ViewControl.DeleteAppointment(CurrentAppointment);
            Scheduler.DeleteAppointment(CurrentAppointment);
      
        }
     
        public static void OnSwitchToDayView(object sender, EventArgs e) {
            Scheduler.ActiveViewType = SchedulerViewType.Day;
            ListViewHelper.SwitchToNormalView();
        }

        public static void OnSwitchToWorkWeekView(object sender, EventArgs e) {
            Scheduler.ActiveViewType = SchedulerViewType.WorkWeek;
            ListViewHelper.SwitchToNormalView();
        }

        public static void OnSwitchToWeekView(object sender, EventArgs e) {
            Scheduler.ActiveViewType = SchedulerViewType.Week;
            ListViewHelper.SwitchToNormalView();
        }

        public static void OnSwitchToMonthView(object sender, EventArgs e) {
            Scheduler.ActiveViewType = SchedulerViewType.Month;
            ListViewHelper.SwitchToNormalView();
        }

        public static void OnSwitchToTimelineView(object sender, EventArgs e) {
            Scheduler.ActiveViewType = SchedulerViewType.Timeline;
            ListViewHelper.SwitchToNormalView();
        }

        public static void OnSwitchToGanttView(object sender, EventArgs e) {
            Scheduler.ActiveViewType = SchedulerViewType.Gantt;
            ListViewHelper.SwitchToNormalView();
        }

        
    }
}
