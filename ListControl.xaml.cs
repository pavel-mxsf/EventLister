using System;
using System.Windows;
using System.Windows.Controls;
using Autodesk.Max;
using Autodesk.Max.Plugins;

namespace EventsListControl
{
    public partial class ListControl : UserControl
    {
        public ListControl()
        {
            InitializeComponent();
            foreach (SystemNotificationCode systemNotificationCode in Enum.GetValues(typeof(SystemNotificationCode)))
            {
                GlobalInterface.Instance.RegisterNotification((new GlobalDelegates.Delegate5(OnChanged)), null, systemNotificationCode);
            }
            MyCallback cb = new MyCallback(listView);
            IISceneEventManager sceneEventMgr = Global.ISceneEventManager;
            sceneEventMgr.RegisterCallback(cb, false, 50, true);
        }

        private void OnChanged(IntPtr obj, IntPtr info)
        {
            string str = DateTime.Now.ToShortTimeString() + "Notification: ";
            INotifyInfo inf = Global.NotifyInfo.Marshal(info);
            str += inf.CallParam + "  ..  ";
            str += (SystemNotificationCode) inf.Intcode;
            listView.Items.Add(str);
            listView.ScrollIntoView(listView.Items[listView.Items.Count - 1]);
        }

        private class MyCallback : INodeEventCallback
        {
            private ListView listView;
            public MyCallback(ListView lv)
            {
                listView = lv;
            }

            private void DoLog(ITab<UIntPtr> nodes, string name)
            {
                string str = DateTime.Now.ToShortTimeString() + "CallbackEvent: " + name + " .. ";
                str += nodes.Count + " node(s) -- ";
                for (int i = 0; i < nodes.Count; i++)
                {
                    using (var n = Global.NodeEventNamespace.GetNodeByKey(nodes[(IntPtr)i]))
                    {
                        if (n == null) throw new ArgumentNullException("nodes");
                        str += n.Name+"  ";
                    }
                }
                listView.Items.Add(str);
                listView.ScrollIntoView(listView.Items[listView.Items.Count - 1]);
            }

            public override void Added(ITab<UIntPtr> nodes)
            {
                string name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                DoLog(nodes, name);
            }
            public override void Deleted(ITab<UIntPtr> nodes)
            {
                string name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                DoLog(nodes, name);
            }
            public override void LinkChanged(ITab<UIntPtr> nodes)
            {
                string name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                DoLog(nodes, name);
            }
            public override void LayerChanged(ITab<UIntPtr> nodes)
            {
                string name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                DoLog(nodes, name);
            }
            public override void GroupChanged(ITab<UIntPtr> nodes)
            {
                string name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                DoLog(nodes, name);
            }
            public override void HierarchyOtherEvent(ITab<UIntPtr> nodes)
            {
                string name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                DoLog(nodes, name);
            }
            public override void ModelStructured(ITab<UIntPtr> nodes)
            {
                string name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                DoLog(nodes, name);
            }
            public override void GeometryChanged(ITab<UIntPtr> nodes)
            {
                string name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                DoLog(nodes, name);
            }
            public override void TopologyChanged(ITab<UIntPtr> nodes)
            {
                string name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                DoLog(nodes, name);
            }
            public override void MappingChanged(ITab<UIntPtr> nodes)
            {
                string name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                DoLog(nodes, name);
            }
            public override void ExtentionChannelChanged(ITab<UIntPtr> nodes)
            {
                string name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                DoLog(nodes, name);
            }
            public override void ModelOtherEvent(ITab<UIntPtr> nodes)
            {
                string name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                DoLog(nodes, name);
            }
            public override void MaterialStructured(ITab<UIntPtr> nodes)
            {
                string name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                DoLog(nodes, name);
            }
            public override void MaterialOtherEvent(ITab<UIntPtr> nodes)
            {
                string name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                DoLog(nodes, name);
            }
            public override void ControllerStructured(ITab<UIntPtr> nodes)
            {
                string name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                DoLog(nodes, name);
            }
            public override void ControllerOtherEvent(ITab<UIntPtr> nodes)
            {
                string name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                DoLog(nodes, name);
            }
            public override void NameChanged(ITab<UIntPtr> nodes)
            {
                string name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                DoLog(nodes, name);
            }
            public override void WireColorChanged(ITab<UIntPtr> nodes)
            {
                string name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                DoLog(nodes, name);
            }
            public override void RenderPropertiesChanged(ITab<UIntPtr> nodes)
            {
                string name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                DoLog(nodes, name);
            }
            public override void DisplayPropertiesChanged(ITab<UIntPtr> nodes)
            {
                string name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                DoLog(nodes, name);
            }
            public override void UserPropertiesChanged(ITab<UIntPtr> nodes)
            {
                string name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                DoLog(nodes, name);
            }
            public override void PropertiesOtherEvent(ITab<UIntPtr> nodes)
            {
                string name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                DoLog(nodes, name);
            }
            public override void SubobjectSelectionChanged(ITab<UIntPtr> nodes)
            {
                string name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                DoLog(nodes, name);
            }
            public override void SelectionChanged(ITab<UIntPtr> nodes)
            {
                string name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                DoLog(nodes, name);
            }
            public override void HideChanged(ITab<UIntPtr> nodes)
            {
                string name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                DoLog(nodes, name);
            }
            public override void FreezeChanged(ITab<UIntPtr> nodes)
            {
                string name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                DoLog(nodes, name);
            }
            public override void DisplayOtherEvent(ITab<UIntPtr> nodes)
            {
                string name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                DoLog(nodes, name);
            }
        }

        public static IInterface14 Interface
        {
            get
            {
                return Global.COREInterface14;
            }
        }

        public static IGlobal Global
        {
            get
            {
                return GlobalInterface.Instance;
            }
        }

        private void OnClearClick(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();
        }
    }
}
