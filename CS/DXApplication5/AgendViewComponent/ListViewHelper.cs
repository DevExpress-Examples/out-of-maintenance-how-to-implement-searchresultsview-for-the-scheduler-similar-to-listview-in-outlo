using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraScheduler;
using DevExpress.XtraLayout;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Drawing;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;

namespace ListViewComponent {
    public static class ListViewHelper {
        private static ListViewControl ListView;
        private static SchedulerControl CurrentScheduler;
        private static DateNavigator navigator;
        private static SearchControl SearchControlInstance;
        public static void AddListView(SchedulerControl scheduler, DateNavigator dateNavigator, SearchControl searchControl) {
            CurrentScheduler = scheduler;
            navigator = dateNavigator;
            SearchControlInstance = searchControl;
            if(!(scheduler.Parent is LayoutControl)) {
                MessageBox.Show("SchedulerControl should be located within a LayoutControl to enable ListView functionality");                
            }
            else {
                ListView = new ListViewControl(CurrentScheduler);
                LayoutControl currentLayout = scheduler.Parent as LayoutControl;
                LayoutControlItem schedulerLayoutItem = currentLayout.GetItemByControl(CurrentScheduler);
                //Create a layout item and add it to the root group.    
                LayoutControlItem itemAgendaView = currentLayout.Root.AddItem(schedulerLayoutItem, DevExpress.XtraLayout.Utils.InsertType.Top) as LayoutControlItem;
                // Set the item's Control and caption.
                itemAgendaView.Name = "layoutControlItemAgendaView";
                itemAgendaView.Control = ListView;
                itemAgendaView.TextVisible = false;

                ChangeControlsVisibility(CurrentScheduler, true);
                if(navigator != null) ChangeControlsVisibility(navigator, true);
                ChangeControlsVisibility(ListView, false);
            }
        }

        public static void SwitchToListView() {
            ChangeControlsVisibility(CurrentScheduler, false);
            if(navigator != null) ChangeControlsVisibility(navigator, false);

            ListView.SetSearchControl(SearchControlInstance);
            ChangeControlsVisibility(ListView, true);                
        }

        public static void SwitchToNormalView() {
            ChangeControlsVisibility(CurrentScheduler, true);
            if(navigator != null) ChangeControlsVisibility(navigator, true);

            ChangeControlsVisibility(ListView, false);                
        }

        static void ChangeControlsVisibility(Control someControl, bool visibility) {
            if(someControl.Parent is LayoutControl) {
                (someControl.Parent as LayoutControl).GetItemByControl(someControl).Visibility = visibility ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            }
            else someControl.Visible = visibility;
        }

    }
}
