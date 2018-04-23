using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraScheduler;
using System.ComponentModel;
using System.Drawing;

namespace ListViewComponent {
    public static class ListViewDataGenerator {
        public static object GenerateResourcesCollection(SchedulerStorage storage) {
            return storage.Resources.Items;        
        }

        public static object GenerateListViewAppointmentCollection(AppointmentStorage storage, AppointmentBaseCollection sourceAppointments, DayOfWeek dayOfWeek) {
            BindingList<ListViewAppointment> listViewAppointments = new BindingList<ListViewAppointment>();
            foreach(Appointment appointment in sourceAppointments) {
                listViewAppointments.Add(CreateListViewAppointment(storage, appointment, dayOfWeek));
                
            }
            return listViewAppointments;
        }

        public static ListViewAppointment CreateListViewAppointment(AppointmentStorage storage, Appointment sourceAppointment, DayOfWeek dayOfWeek)
        {
            ListViewAppointment listViewAppointment = new ListViewAppointment();
            listViewAppointment.ListViewDate = sourceAppointment.Start;
           
            listViewAppointment.ListViewSubject = sourceAppointment.Subject;
            listViewAppointment.ListViewRecurrencePattern = RecurrenceInfo.GetDescription(sourceAppointment, dayOfWeek);
            listViewAppointment.ListViewIsRecurring = sourceAppointment.IsRecurring;
            listViewAppointment.ListViewDuration = sourceAppointment.Duration.ToString();
            listViewAppointment.ListViewAppointmentID = sourceAppointment.Id;
            listViewAppointment.ListViewLocation = sourceAppointment.Location;
            listViewAppointment.ListViewStatus = storage.Statuses[sourceAppointment.StatusId]; ;
            listViewAppointment.ListViewLabel = storage.Labels[sourceAppointment.LabelId].Color;
            listViewAppointment.SourceAppointment = sourceAppointment;
            return listViewAppointment;
        }
    }

    // ListView appointment
    public class ListViewAppointment {
        public AppointmentStatus ListViewStatus { get; set; }
        public string ListViewSubject { get; set; }
        public string ListViewDuration { get; set; }
        public string ListViewLocation { get; set; }
        public string ListViewRecurrencePattern { get; set; }
        public bool ListViewIsRecurring { get; set; }
        public DateTime ListViewDate { get; set; }
        public Color ListViewLabel { get; set; }
        public Appointment SourceAppointment { get; set; }
        public object ListViewAppointmentID {
            get;
            set;
        }
    }
}
