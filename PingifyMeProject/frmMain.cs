using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace PingifyMeProject
{
	public partial class frmMain : Form
	{
		private BackgroundWorker worker;
		int delay = 1000; // Delay in milliseconds
		int timeout = 1000; // Delay in milliseconds
		public frmMain()
		{
			InitializeComponent();
			this.Focus();
		}

		private async void btnAction_Click(object sender, EventArgs e)
		{
			var ipAddresses = txtIP.Lines; // Get IP addresses from TextBox
			if (ipAddresses.Length == 0)
			{
				MessageBox.Show("Please enter at least one IP address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (btnAction.Text == "Start")
			{
				worker = new BackgroundWorker();
				worker.WorkerSupportsCancellation = true; // Set WorkerSupportsCancellation to true
				worker.DoWork += Worker_DoWork;
				worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
				worker.RunWorkerAsync();
				btnAction.Text = "Stop";

				txtIP.Enabled = false;
				rtxtLog.Clear();
				delay = delay * 1; //user input for delay
				timeout = timeout * 10; //user input for delay
			}
			else
			{
				if (worker != null && worker.IsBusy) // Check if the worker is running
				{
					worker.CancelAsync();
				}

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

				txtIP.Enabled = true;
				btnAction.Text = "Start";
				delay = 1000; //reset delay
				timeout = 1000; //reset timeout
			}
		}

		private async void TimerCallback(object state)
		{
			string logResult = $"{DateTime.Now:dd/MM/yyyy HH:mm:ss}:\n";
			var ipAddresses = txtIP.Lines; // Get IP addresses from TextBox
			foreach (var ipAddress in ipAddresses)
			{
				string response = await PingAddressAsync(ipAddress);
				logResult += response;
			}
			// Invoke to update UI with each ping result
			this.Invoke((MethodInvoker)delegate
			{
				rtxtLog.AppendText(logResult + Environment.NewLine);
				rtxtLog.ScrollToCaret(); // Auto scroll to bottom
			});
		}
		private void Worker_DoWork(object sender, DoWorkEventArgs e)
		{
			// Log results every second
			Timer timer = new Timer(TimerCallback, null, 0, delay);

			while (!worker.CancellationPending)
			{
			}
			timer.Dispose(); // Stop the timer
		}

		private async Task<string> PingAddressAsync(string ipAddress)
		{
			try
			{
				using (var ping = new Ping())
				{
					var reply = await ping.SendPingAsync(ipAddress, timeout);
					if (reply.Status == IPStatus.Success)
					{
						return $"Reply from {ipAddress}: bytes={reply.Buffer.Length} time={reply.RoundtripTime}ms TTL={reply.Options.Ttl}\n";
					}
					else if (reply.Status == IPStatus.TimedOut)
					{
						return $"Request timed out for {ipAddress}\n";
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

		private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				// Handle error
			}
			else
			{

			}
		}
	}
}
