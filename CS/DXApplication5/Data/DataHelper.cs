using DevExpress.XtraScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace DXApplication5
{
    public static class DataHelper
    {


        private static string[] Users = new string[] { "Peter Dolan", "Ryan Fischer", "Andrew Miller", "Tom Hamlett",
                                                            "Jerry Campbell", "Carl Lucas", "Mark Hamilton", "Steve Lee" };

        public static void FillResources(SchedulerStorage storage, int count)
        {
           
            int cnt = Math.Min(count, Users.Length);
            for (int i = 1; i <= cnt; i++)
            {
                Resource resource = storage.CreateResource(i);
                resource.Caption = Users[i - 1];
                storage.Resources.Add(resource);
            }
        }

        public static void GenerateEvents(SchedulerStorage storage, int count)
        {

            for (int i = 0; i < count; i++)
            {
                Resource resource = storage.Resources[i];
                string subjPrefix = resource.Caption + "'s ";
                if (i % 2 == 0)
                {
                    storage.Appointments.Add(CreateEvent(storage, subjPrefix + "meeting", resource.Id, 2, 5));
                    storage.Appointments.Add(CreateEvent(storage, subjPrefix + "travel", resource.Id, 3, 6));
                    storage.Appointments.Add(CreateEvent(storage, subjPrefix + "phone call", resource.Id, 0, 10));
                }
                else
                {
                    storage.Appointments.Add(CreateRecurrentEvent(storage, subjPrefix + "meeting", resource.Id, 2, 5));
                }
            }
        }
        private static Appointment CreateRecurrentEvent(SchedulerStorage storage, string subject, object resourceId, int status, int label)
        {
            Appointment apt = storage.CreateAppointment(AppointmentType.Pattern);
            apt.Subject = subject;
            apt.ResourceId = resourceId;
            apt.Start = DateTime.Today.AddHours(9).AddMinutes(30);
            apt.End = apt.Start.AddHours(2);
            apt.StatusId = status;
            apt.LabelId = label;

            apt.RecurrenceInfo.Type = RecurrenceType.Daily;
            apt.RecurrenceInfo.Start = apt.Start;
            apt.RecurrenceInfo.Periodicity = 5;
            apt.RecurrenceInfo.Range = RecurrenceRange.EndByDate;
            apt.RecurrenceInfo.End = apt.RecurrenceInfo.Start.AddMonths(1);
            return apt;
        }

        private static Appointment CreateEvent(SchedulerStorage storage, string subject, object resourceId, int status, int label)
        {
            Appointment apt = storage.CreateAppointment(AppointmentType.Normal);
            apt.Subject = subject;
            apt.ResourceId = resourceId;
            apt.Start = DateTime.Today.AddHours(9).AddMinutes(30);
            apt.End = apt.Start.AddHours(2);
            apt.StatusId = status;
            apt.LabelId = label;
            return apt;
        }
    }
}
