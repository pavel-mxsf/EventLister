using System;
using UiViewModels.Actions;

namespace EventsListControl
{
    public class Loader : CuiDockableContentAdapter
    {
        public override string ActionText { get { return "EventLister"; } }
        public override string Category { get { return "..sdk tools"; } }

        public override string WindowTitle
        {
            get { return "Event Lister"; }
        }

        public override Type ContentType
        {
            get { return typeof(ListControl); }
        }

        public override object CreateDockableContent()
        {
            return new ListControl();
        }

        public override DockStates.Dock DockingModes
        {
            get { return DockStates.Dock.Floating; }
        }
    }
}
