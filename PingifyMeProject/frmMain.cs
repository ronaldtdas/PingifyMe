using System.ComponentModel;
using System.Net;
using System.Net.NetworkInformation;

namespace PingifyMeProject
{
	public partial class frmMain : Form
	{
		private BackgroundWorker worker;
		public frmMain()
		{
			InitializeComponent();
			txtIP.Text = "192.168.0.1";
		}
		private void btnAction_Click(object sender, EventArgs e)
		{
			if (btnAction.Text == "Start")
			{
				worker = new BackgroundWorker();
				worker.WorkerSupportsCancellation = true; // Set WorkerSupportsCancellation to true
				worker.DoWork += Worker_DoWork;
				worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
				worker.RunWorkerAsync();
				btnAction.Text = "Stop";
			}
			else
			{
				if (worker != null && worker.IsBusy) // Check if the worker is running
				{
					worker.CancelAsync();
				}
				btnAction.Text = "Start";
			}
		}






		private void Worker_DoWork(object sender, DoWorkEventArgs e)
		{
			var ipAddresses = txtIP.Lines; // Get IP addresses from TextBox
			while (!worker.CancellationPending)
			{
				string result = $"{DateTime.Now:dd/MM/yyyy HH:mm:ss}:\n";
				foreach (var ipAddress in ipAddresses)
				{
					string response = PingAddress(ipAddress);
					result += response;
					Thread.Sleep(1000); // Ping every second
				}
				// Invoke to update UI with each ping result
				this.Invoke((MethodInvoker)delegate
				{
					rtxtLog.AppendText(result + Environment.NewLine);
					rtxtLog.ScrollToCaret(); // Auto scroll to bottom
				});
			}
		}




		private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				// Handle error
			}
			else
			{
				// Prompt to export log
				if (MessageBox.Show("Export log to a text file?", "Export Log", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					SaveFileDialog saveFileDialog = new SaveFileDialog();
					saveFileDialog.Filter = "Text files (*.txt)|*.txt";
					if (saveFileDialog.ShowDialog() == DialogResult.OK)
					{
						File.WriteAllText(saveFileDialog.FileName, rtxtLog.Text);
					}
				}
			}
		}
		private string PingAddress(string ipAddress)
		{
			try
			{
				using (var ping = new Ping())
				{
					var reply = ping.Send(ipAddress);
					if (reply.Status == IPStatus.Success)
					{
						return $"Reply from {ipAddress}: bytes={reply.Buffer.Length} time={reply.RoundtripTime}ms TTL={reply.Options.Ttl}\n";
					}
					else
					{
						return $"Ping failed with status: {reply.Status}\n";
					}
				}
			}
			catch (Exception ex)
			{
				return $"Error pinging {ipAddress}: {ex.Message}\n";
			}
		}

		private void txtIP_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
