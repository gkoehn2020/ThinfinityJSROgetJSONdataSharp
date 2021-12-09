using Cybele.Thinfinity;


namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private VirtualUI vui;
        private JSObject ro;
        private string jsDir;
        private IJSProperty aProp;

        public Form1()
        {
            InitializeComponent();

            vui = new VirtualUI();
            vui.Start();

            vui = new VirtualUI();
            jsDir = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo di = new(jsDir);
            while (di != null)
            {
                jsDir = di.FullName + @"\js\";
                if (Directory.Exists(jsDir)) break;
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                di = di.Parent;
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            }

            ro = new JSObject("ro");
            ro.Events.Add("getStringFromBrowser");
            aProp = ro.Properties.Add("stringdata");
            aProp.AsString = "";
            aProp.OnSet(new JSBinding(
                  // This anonymous procedure do the actual set
                  delegate (IJSObject Parent, IJSProperty Prop)
                  {
                      string value = Prop.AsString;
                      MessageBox.Show(value);
                  }));
            ro.ApplyModel();

            vui.HTMLDoc.CreateSessionURL("/js/", jsDir);
            vui.HTMLDoc.LoadScript(@"/js/vui-jsro.js");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ro.Events["getStringFromBrowser"].Fire();
        }
    }
}