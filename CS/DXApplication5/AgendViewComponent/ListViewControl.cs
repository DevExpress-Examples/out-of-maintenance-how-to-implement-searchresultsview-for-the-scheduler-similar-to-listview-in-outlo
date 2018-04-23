using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;

namespace ListViewComponent {
    public partial class ListViewControl : UserControl
    {
        #region Fields
        SchedulerControl OwnerScheduler;
        ImageCollection appointmentImages;
        RepositoryItemImageComboBox reStatus;
        #endregion
        public ListViewControl(SchedulerControl scheduler) {
            InitializeComponent();
            OwnerScheduler = scheduler;

            appointmentImages = DevExpress.Utils.Controls.ImageHelper.CreateImageCollectionFromResources("ListViewComponent.Resources.AppointmentImages.png", System.Reflection.Assembly.GetExecutingAssembly(), new Size(15, 15));
            reStatus = GridControlAppointments.RepositoryItems.Add("ImageComboBoxEdit") as RepositoryItemImageComboBox;
            gridViewAppointments.Columns["ListViewStatus"].ColumnEdit = reStatus;
          
        }



        #region Methods
        private ListViewAppointment FindRow(Appointment apt, out BindingList<ListViewAppointment> dataSource) {
            dataSource = gridViewAppointments.DataSource as BindingList<ListViewAppointment>;
            return dataSource.Where(listViewApt => listViewApt.ListViewAppointmentID == apt.Id).FirstOrDefault();
        }
        public void DeleteAppointment(Appointment apt) {
            BindingList<ListViewAppointment> dataSource;
            ListViewAppointment result = FindRow(apt, out dataSource);
           
            if (result != null)
                dataSource.Remove(result);

        }
        
        public void ChangeAppointment(Appointment apt) {
            DeleteAppointment(apt);
            BindingList<ListViewAppointment> datasource =gridViewAppointments.DataSource as BindingList<ListViewAppointment>;
            datasource.Add(ListViewDataGenerator.CreateListViewAppointment(OwnerScheduler.Storage.Appointments, apt, OwnerScheduler.FirstDayOfWeek));
        }
        private AppointmentBaseCollection GetFilteredAppointments(TimeInterval interval) {
            AppointmentBaseCollection aptCollection = OwnerScheduler.Storage.GetAppointments(interval);
            AppointmentBaseCollection copyCollection = new AppointmentBaseCollection();
            for(int i = 0; i < aptCollection.Count; i++) {
                if(aptCollection[i].Type != AppointmentType.Occurrence)
                    copyCollection.Add(aptCollection[i]);
                else {
                    if(!copyCollection.Contains(aptCollection[i].RecurrencePattern))
                        copyCollection.Add(aptCollection[i].RecurrencePattern);
                }
            }

            return copyCollection;
        }
        private void InitializeGridControlAppointments()
        {
            AppointmentBaseCollection sourceAppointmentCollection = GetFilteredAppointments(new TimeInterval(DateTime.MinValue, DateTime.MaxValue));
            GridControlAppointments.DataSource = ListViewDataGenerator.GenerateListViewAppointmentCollection(OwnerScheduler.Storage.Appointments, sourceAppointmentCollection, OwnerScheduler.FirstDayOfWeek);
        }
        public void SetSearchControl(SearchControl searchControl) {
            InitializeGridControlAppointments();
            searchControl.Client = GridControlAppointments;
            
            gridViewAppointments.ExpandAllGroups();
           
            CreateCustomColorsForStatuses(reStatus);
        }
        private Color GetLightenColor(Color inColor, double inAmount) {
            return Color.FromArgb(
              inColor.A,
              (int)Math.Min(255, inColor.R + 255 * inAmount),
              (int)Math.Min(255, inColor.G + 255 * inAmount),
              (int)Math.Min(255, inColor.B + 255 * inAmount));
        }

        private void CreateCustomColorsForStatuses(RepositoryItemImageComboBox riImageComboBox) {
            foreach(AppointmentStatus status in OwnerScheduler.Storage.Appointments.Statuses) {
                riImageComboBox.Items.Add(new ImageComboBoxItem(status.Color.ToString(), status));
            }

            ImageList imagesColors = new ImageList();
            riImageComboBox.SmallImages = imagesColors;

            foreach(ImageComboBoxItem item in riImageComboBox.Items) {
                int iWidth = 16;
                int iHeight = 16;
                Bitmap bmp = new Bitmap(iWidth, iHeight);
                using(Graphics g = Graphics.FromImage(bmp)) {
                    g.DrawRectangle(new Pen(Color.Black, 2), 0, 0, iWidth, iHeight);
                    g.FillRectangle(new SolidBrush((item.Value as AppointmentStatus).Color), 1, 1, iWidth - 2, iHeight - 2);

                }
                imagesColors.Images.Add(bmp);
                item.ImageIndex = imagesColors.Images.Count - 1;
            }
        }

        #endregion


        #region Event Handlers
        private void gridViewAppointments_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e) {
            Appointment currentApt = (e.Row as ListViewAppointment).SourceAppointment;
            if(e.Column.FieldName == "gridColumnReminder" && e.IsGetData && currentApt.HasReminder) {
                e.Value = appointmentImages.Images[4];
            }
        }

        private void gridViewAppointments_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e) {
            GridView currentView = sender as GridView;
            if(!currentView.IsGroupRow(e.RowHandle)) {
                ListViewAppointment currentAppointment = (sender as GridView).GetRow(e.RowHandle) as ListViewAppointment;
                e.Appearance.BackColor = currentAppointment.ListViewLabel;
            }
        }

        private void gridViewAppointments_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e) {
            if(e.HitInfo.HitTest == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell) {
                GridView currentView = sender as GridView;
                ListViewAppointment agendaAppointment = currentView.GetRow(e.HitInfo.RowHandle) as ListViewAppointment;
                ListViewMenuBuilder.GenerateContextMenu(this, e.Menu, OwnerScheduler, agendaAppointment.SourceAppointment);
            }
            if(e.HitInfo.HitTest == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.EmptyRow) {
                if(e.Menu == null)
                    e.Menu = new DevExpress.XtraGrid.Menu.GridViewMenu(sender as GridView);
                ListViewMenuBuilder.GenerateContextMenu(this, e.Menu, OwnerScheduler, null);
            }
        }

        private void gridViewAppointments_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e) {
            GridView view = sender as GridView;
            if(e.RowHandle == view.FocusedRowHandle) {
                if(!view.IsGroupRow(e.RowHandle)) {
                    ListViewAppointment currentAppointment = (sender as GridView).GetRow(e.RowHandle) as ListViewAppointment;
                    e.Appearance.BackColor = GetLightenColor(currentAppointment.ListViewLabel, 0.1);
                }
            }
        }

        private void gridViewAppointments_DoubleClick(object sender, EventArgs e) {
            GridView currentView = sender as GridView;
            if(!currentView.IsGroupRow(currentView.FocusedRowHandle)) {
                ListViewMenuBuilder.Scheduler = OwnerScheduler;
                ListViewAppointment listViewAppointment = currentView.GetRow(currentView.FocusedRowHandle) as ListViewAppointment;
                ListViewMenuBuilder.CurrentAppointment = listViewAppointment.SourceAppointment;
                ListViewMenuBuilder.ViewControl = this;
                ListViewMenuBuilder.OnOpenCurrentAppointment(null, null);
            }
        }
        private void gridViewAppointments_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.IsForGroupRow)
            {
                GridGroupSummaryItem groupSummary = gridViewAppointments.GroupSummary[0] as GridGroupSummaryItem;
                object groupSummaryValue = gridViewAppointments.GetGroupSummaryValue(e.GroupRowHandle, groupSummary);
                e.DisplayText = e.DisplayText == string.Empty ? String.Format("{0}: none: {1} items", e.Column.Caption, Convert.ToInt32(groupSummaryValue)) : String.Format("{0}: {1}: {2} items", e.Column.Caption, e.DisplayText, Convert.ToInt32(groupSummaryValue));

            }
        }
      
        #endregion 

   
    }
}
