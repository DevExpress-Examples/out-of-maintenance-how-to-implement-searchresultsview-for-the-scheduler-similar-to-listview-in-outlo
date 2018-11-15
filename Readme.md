<!-- default file list -->
*Files to look at*:

* [GoToDateDialog.cs](./CS/DXApplication5/AgendViewComponent/GoToDateDialog.cs)
* [ListViewControl.cs](./CS/DXApplication5/AgendViewComponent/ListViewControl.cs) (VB: [ListViewControl.vb](./VB/DXApplication5/AgendViewComponent/ListViewControl.vb))
* [ListViewDataGenerator.cs](./CS/DXApplication5/AgendViewComponent/ListViewDataGenerator.cs) (VB: [ListViewDataGenerator.vb](./VB/DXApplication5/AgendViewComponent/ListViewDataGenerator.vb))
* [ListViewHelper.cs](./CS/DXApplication5/AgendViewComponent/ListViewHelper.cs) (VB: [ListViewHelper.vb](./VB/DXApplication5/AgendViewComponent/ListViewHelper.vb))
* [ListViewMenuBuilder.cs](./CS/DXApplication5/AgendViewComponent/ListViewMenuBuilder.cs) (VB: [ListViewMenuBuilder.vb](./VB/DXApplication5/AgendViewComponent/ListViewMenuBuilder.vb))
* [DataHelper.cs](./CS/DXApplication5/Data/DataHelper.cs)
* [Form1.cs](./CS/DXApplication5/Form1.cs) (VB: [Form1.vb](./VB/DXApplication5/Form1.vb))
* [CustomSchedulerControl.cs](./CS/DXApplication5/ISearchControlClient Implementation/CustomSchedulerControl.cs) (VB: [CustomSchedulerControl.vb](./VB/DXApplication5/ISearchControlClient Implementation/CustomSchedulerControl.vb))
* [SchedulerSearchProvider.cs](./CS/DXApplication5/ISearchControlClient Implementation/SchedulerSearchProvider.cs) (VB: [SchedulerSearchProvider.vb](./VB/DXApplication5/ISearchControlClient Implementation/SchedulerSearchProvider.vb))
* [Program.cs](./CS/DXApplication5/Program.cs)
<!-- default file list end -->
# How to implement SearchResultsView for the scheduler (similar to ListView in Outlook)  


<p>This example demonstrates how to implement SearchResultsView in SchedulerControl by analogy with ListView in Outlook. ListView in Outlook appears when you search for an appointment and displays summary information regarding found entries. This view does not support the concept of a visible time interval; i.e, all found appointments should be shown. This view provides similar context menus and editor forms to manage appointments.<br /><br /><img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-implement-searchresultsview-for-the-scheduler-similar-to-listview-in-outlook-t274749/15.1.5+/media/3ba07ea5-481d-11e5-80bf-00155d62480c.png"></p>
<br /><strong>Please see the "Implementation Details" (click the corresponding link below this text) to learn more about technical aspects of this approach implementation.</strong>


<h3>Description</h3>

<p>To enter&nbsp;a&nbsp; search request from an end-user and&nbsp; filter appointments in a SchedulerControl, a&nbsp;<a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraEditorsSearchControltopic">SearchControl&nbsp;</a>&nbsp;is used. By default, this control&nbsp; cannot be attached to the SchedulerControl, since the latter does not implement the&nbsp;<strong>ISearchControlClient</strong>&nbsp;interface. In this example, the&nbsp;<strong>ISearchControlClient</strong>&nbsp;interface is implemented for the&nbsp;SchedulerControl. See the&nbsp;<strong>CustomSchedulerControl</strong>&nbsp;class implementation for clarification.<br /><br />If you wish to use a more complex criteria to filter appointments, override the&nbsp;<strong>PrepareFilter</strong>&nbsp;method which builds the filter operator&nbsp;from the passed string. Then, the resulting criteria operator is passed to the&nbsp;<strong>ApplyFindFilter</strong>&nbsp;method to filter the scheduler storage.&nbsp;<br /><br />Switching between the SchedulerControl's view and a SearchResultsView (ListView) is implemented by switching the visibility of the SchedulerControl and GridControl instances.&nbsp;<br /><br />All classes to implement the ListView&nbsp;functionality are created within a separate Class Library project. To include the ListView&nbsp;functionality into the existing application, you can simply add a reference to the&nbsp;<strong>ListViewComponent.dll</strong>&nbsp;library and write the following code line in the main form:</p>
<code lang="cs">  ListViewHelper.AddListView(schedulerControl, dateNavigator, searchControl1);</code>
<code lang="vb">  ListViewHelper.AddListView(schedulerControl, dateNavigator, searchControl1)</code>

<br/>


