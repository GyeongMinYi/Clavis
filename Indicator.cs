using System.IO.Ports;

namespace Clavis
{
	internal class Indicator
	{
		private SerialPort port;
		private string port_name = "COM1";
		private int baud_rate = (int)38400;
		private int data_bits = (int)8;
		private Parity parity = Parity.None;
		private StopBits stop_bits = StopBits.One;
		private int read_timeout = (int)500;
		private int write_timeout = (int)500;

		public bool connect_flag = false;
		public string send_str { get; set; }

		public Indicator()
		{
			port = new SerialPort();
			port.PortName = port_name;
			port.BaudRate = baud_rate;
			port.DataBits = data_bits;
			port.Parity = parity;
			port.StopBits = stop_bits;
			port.ReadTimeout = read_timeout;
			port.WriteTimeout = write_timeout;
		}

		public Indicator(string _port_name) : this()
		{
			port.PortName = _port_name;
		}

		public Indicator(string _port_name, int _baud_rate) : this(_port_name)
		{
			port.BaudRate = baud_rate;
		}

		public bool connect()
		{
			try
			{
				port.Open();
				connect_flag = true;
			}
			catch
			{
				disconnect();
				throw new Exception("Connect Error");
			}

			if (port.IsOpen) return true;
			else return false;
		}

		public void disconnect()
		{
			port.Close();
			connect_flag = false;
		}

		public double get_data()
		{
			string data_str = string.Empty;

			port.WriteLine(send_str);

			data_str = port.ReadLine();

			return double.Parse(data_str.Substring(11, 7));
		}
	}
}
