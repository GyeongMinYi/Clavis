namespace Clavis
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			Indicator test = new Indicator();
			test.send_str = " ¦¤0102R0100D6¦¦";
			double db = test.get_data();
		}
	}
}