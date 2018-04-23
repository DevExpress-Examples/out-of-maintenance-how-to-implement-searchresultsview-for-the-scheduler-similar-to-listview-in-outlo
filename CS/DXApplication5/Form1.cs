using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using ListViewComponent;


namespace DXApplication5
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            schedulerControl.Start = System.DateTime.Now;
            searchControl1.Client = schedulerControl;
            schedulerControl.GroupType = SchedulerGroupType.Resource;

            InitResources();
            InitAppointments();

            ListViewHelper.AddListView(schedulerControl, dateNavigator, searchControl1);
        }
        #region data
        private void InitResources()
        {
            DataHelper.FillResources(schedulerStorage, 5);
        }
        void InitAppointments()
        {
            int count = schedulerStorage.Resources.Count;
            DataHelper.GenerateEvents(schedulerStorage, count);
        }
        #endregion
        #region events
        private void searchControl1_EditValueChanged(object sender, EventArgs e) {
            ListViewHelper.SwitchToListView();
        }
        private void searchControl1_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e) {
            if(e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Clear) {
                ListViewHelper.SwitchToNormalView();
                schedulerControl.SetSearchControl(searchControl1);
            }
        }
        
        #endregion

        private void schedulerControl_PreviewKeyDown(object sender, System.Windows.Forms.PreviewKeyDownEventArgs e)
        {
            if (e.Control && e.KeyCode == System.Windows.Forms.Keys.E)
            {
                searchControl1.Focus();
                e.IsInputKey = false;
            }
        }
    }
   
}