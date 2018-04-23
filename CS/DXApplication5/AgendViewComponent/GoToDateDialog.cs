using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;

namespace ListViewComponent {
    public partial class GoToDateDialog : XtraForm {
        public GoToDateDialog() {
            InitializeComponent();
        }

        public DateTime SelectedDate {
            get { return dateEditGoToDate.DateTime; }
            set { dateEditGoToDate.EditValue = value; }
        }
    }
}
