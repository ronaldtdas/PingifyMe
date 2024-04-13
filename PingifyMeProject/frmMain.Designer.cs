namespace PingifyMeProject
{
	partial class frmMain
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			txtIP = new TextBox();
			rtxtLog = new RichTextBox();
			btnAction = new Button();
			tableLayoutPanel1 = new TableLayoutPanel();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// txtIP
			// 
			txtIP.BackColor = Color.MidnightBlue;
			txtIP.BorderStyle = BorderStyle.FixedSingle;
			txtIP.Dock = DockStyle.Fill;
			txtIP.ForeColor = Color.WhiteSmoke;
			txtIP.Location = new Point(0, 0);
			txtIP.Margin = new Padding(0);
			txtIP.Multiline = true;
			txtIP.Name = "txtIP";
			txtIP.PlaceholderText = "IP Addresses:";
			txtIP.Size = new Size(100, 220);
			txtIP.TabIndex = 0;
			// 
			// rtxtLog
			// 
			rtxtLog.BackColor = Color.MidnightBlue;
			rtxtLog.BorderStyle = BorderStyle.FixedSingle;
			rtxtLog.Dock = DockStyle.Fill;
			rtxtLog.Font = new Font("MS Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			rtxtLog.ForeColor = Color.White;
			rtxtLog.Location = new Point(100, 0);
			rtxtLog.Margin = new Padding(0);
			rtxtLog.Name = "rtxtLog";
			rtxtLog.ReadOnly = true;
			tableLayoutPanel1.SetRowSpan(rtxtLog, 2);
			rtxtLog.Size = new Size(464, 270);
			rtxtLog.TabIndex = 1;
			rtxtLog.Text = "";
			// 
			// btnAction
			// 
			btnAction.Dock = DockStyle.Fill;
			btnAction.FlatStyle = FlatStyle.Flat;
			btnAction.Font = new Font("Ink Free", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnAction.Location = new Point(0, 220);
			btnAction.Margin = new Padding(0);
			btnAction.Name = "btnAction";
			btnAction.Size = new Size(100, 50);
			btnAction.TabIndex = 2;
			btnAction.Text = "Start";
			btnAction.UseVisualStyleBackColor = true;
			btnAction.Click += btnAction_Click;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel1.Controls.Add(txtIP, 0, 0);
			tableLayoutPanel1.Controls.Add(rtxtLog, 1, 0);
			tableLayoutPanel1.Controls.Add(btnAction, 0, 1);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
			tableLayoutPanel1.Size = new Size(564, 270);
			tableLayoutPanel1.TabIndex = 3;
			// 
			// frmMain
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(564, 270);
			Controls.Add(tableLayoutPanel1);
			Name = "frmMain";
			Text = "PingifyMe";
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private TextBox txtIP;
		private RichTextBox rtxtLog;
		private Button btnAction;
		private TableLayoutPanel tableLayoutPanel1;
	}
}
