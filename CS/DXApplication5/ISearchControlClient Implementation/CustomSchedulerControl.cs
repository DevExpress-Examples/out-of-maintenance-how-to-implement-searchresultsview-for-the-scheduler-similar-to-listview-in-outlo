using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraScheduler;
using DevExpress.Utils;
using DevExpress.Data.Filtering;

namespace DXApplication5 {
    public class CustomSchedulerControl : SchedulerControl, ISearchControlClient {
        #region ISearchControlClient Members

        public void ApplyFindFilter(SearchInfoBase searchInfo) {
            if (searchInfo == null)
                return;
            SchedulerSearchInfo si = searchInfo as SchedulerSearchInfo;
            FilterCondition filterCondition = si.FilterCondition;
            string searchtext = si.SearchText;

            if (searchtext == null) {
                ResetFilter();
                return;
            }

            CriteriaOperator filterCriteria = PrepareFilter(searchtext, filterCondition);
            this.Storage.Appointments.Filter = filterCriteria.ToString();
        }

        private void ResetFilter() {
            if (this.Storage != null)
                this.Storage.Appointments.Filter = null;
        }
        CriteriaOperator PrepareFilter(string searchString, FilterCondition condition) {
            switch (condition) {
                case FilterCondition.Contains:
                    return GroupOperator.Or(new FunctionOperator(FunctionOperatorType.Contains, "Subject", searchString),
                        new FunctionOperator(FunctionOperatorType.Contains, "Location", searchString));
                case FilterCondition.StartsWith:
                    return GroupOperator.Or(new FunctionOperator(FunctionOperatorType.StartsWith, new OperandProperty("Subject"), searchString),
                         new FunctionOperator(FunctionOperatorType.StartsWith, new OperandProperty("Location"), searchString));
                case FilterCondition.Like:
                    return GroupOperator.Or(new FunctionOperator(FunctionOperatorType.Contains, new OperandProperty("Subject"), searchString),
                     new FunctionOperator(FunctionOperatorType.Contains, new OperandProperty("Location"), searchString));
                case FilterCondition.Default:
                    return GroupOperator.Or(new FunctionOperator(FunctionOperatorType.Contains, new OperandProperty("Subject"), searchString),
                         new FunctionOperator(FunctionOperatorType.Contains, new OperandProperty("Location"), searchString));
                case FilterCondition.Equals:
                    return GroupOperator.Or(new BinaryOperator("Subject", searchString, BinaryOperatorType.Equal),
                         new BinaryOperator("Location", searchString, BinaryOperatorType.Equal));
                default:
                    return null;
            }

        }


        public SearchControlProviderBase CreateSearchProvider() {
            return new SchedulerSearchProvider();
        }
        ISearchControl srchControl;
        public bool IsAttachedToSearchControl {
            get {
                return srchControl != null;
            }
        }

        public void SetSearchControl(ISearchControl searchControl) {

            if (srchControl == searchControl)
                return;
            ResetFilter();
            srchControl = searchControl;

        }

        #endregion
    }
}
