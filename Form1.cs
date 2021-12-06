using Cybele.Thinfinity;


namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private VirtualUI vui;
        private JSObject ro;
        private string m_Xtagdir;
        public Form1()
        {
            InitializeComponent();

            vui = new VirtualUI();
            vui.Start();

            vui = new VirtualUI();
            m_Xtagdir = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo di = new DirectoryInfo(m_Xtagdir);
            while (di != null)
            {
                m_Xtagdir = di.FullName + @"\x-tag\";
                if (Directory.Exists(m_Xtagdir)) break;
                di = di.Parent;
            }

            vui.HTMLDoc.CreateSessionURL("/x-tag/", m_Xtagdir);
            vui.HTMLDoc.LoadScript(@"/x-tag/x-tag-core.min.js");
            vui.HTMLDoc.ImportHTML(@"/x-tag/vui-jsro/vui-jsro.html");
            vui.HTMLDoc.CreateComponent("vui-gk", "vui-gk", new IntPtr(0));

            ro = new JSObject("ro");
            ro.Events.Add("getJSON");
            ro.Properties.Add("myJSON").AsJSON = "{}";
            ro.ApplyModel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ro.Events["getJSON"].Fire();
            System.Threading.Thread.Sleep(100);
            label1.Text = ro.Properties["myJSON"].AsJSON;
        }
    }
}