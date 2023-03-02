namespace ボタン受信
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbxRxData = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbCOMPort = new System.Windows.Forms.ComboBox();
            this.btnScan = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.位置座標 = new System.Windows.Forms.TextBox();
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnopen2 = new System.Windows.Forms.Button();
            this.btnclose2 = new System.Windows.Forms.Button();
            this.set = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.取得座標 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbxRxData
            // 
            this.tbxRxData.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.tbxRxData.Location = new System.Drawing.Point(12, 336);
            this.tbxRxData.Multiline = true;
            this.tbxRxData.Name = "tbxRxData";
            this.tbxRxData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxRxData.Size = new System.Drawing.Size(465, 665);
            this.tbxRxData.TabIndex = 0;
            this.tbxRxData.TextChanged += new System.EventHandler(this.tbxRxData_TextChanged);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 50000;
            this.serialPort1.PortName = "COM10";
            this.serialPort1.ReadBufferSize = 1000;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(712, 220);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(102, 196);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open1";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Enabled = false;
            this.btnClose.Location = new System.Drawing.Point(712, 456);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 191);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close2";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbCOMPort
            // 
            this.cmbCOMPort.FormattingEnabled = true;
            this.cmbCOMPort.Location = new System.Drawing.Point(78, 43);
            this.cmbCOMPort.Name = "cmbCOMPort";
            this.cmbCOMPort.Size = new System.Drawing.Size(458, 32);
            this.cmbCOMPort.TabIndex = 3;
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(526, 336);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(159, 225);
            this.btnScan.TabIndex = 4;
            this.btnScan.Text = "Re-Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(701, 63);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(189, 100);
            this.Start.TabIndex = 5;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            
            // 
            // 位置座標
            // 
            this.位置座標.Font = new System.Drawing.Font("MS UI Gothic", 30F);
            this.位置座標.Location = new System.Drawing.Point(78, 140);
            this.位置座標.Multiline = true;
            this.位置座標.Name = "位置座標";
            this.位置座標.Size = new System.Drawing.Size(607, 171);
            this.位置座標.TabIndex = 6;
            this.位置座標.Text = "位置座標";
            this.位置座標.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // serialPort2
            // 
            this.serialPort2.BaudRate = 50000;
            this.serialPort2.PortName = "COM6";
            this.serialPort2.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort2_DataReceived);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(979, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(979, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(979, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(979, 360);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(979, 436);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(979, 497);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 24);
            this.label6.TabIndex = 13;
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(979, 564);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 24);
            this.label7.TabIndex = 14;
            this.label7.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(979, 623);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 24);
            this.label8.TabIndex = 15;
            this.label8.Text = "label8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(979, 680);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 24);
            this.label9.TabIndex = 16;
            this.label9.Text = "label9";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(979, 745);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 24);
            this.label10.TabIndex = 17;
            this.label10.Text = "label10";
            // 
            // btnopen2
            // 
            this.btnopen2.Location = new System.Drawing.Point(842, 220);
            this.btnopen2.Name = "btnopen2";
            this.btnopen2.Size = new System.Drawing.Size(103, 196);
            this.btnopen2.TabIndex = 18;
            this.btnopen2.Text = "Open2";
            this.btnopen2.UseVisualStyleBackColor = true;
            this.btnopen2.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnclose2
            // 
            this.btnclose2.Enabled = false;
            this.btnclose2.Location = new System.Drawing.Point(842, 456);
            this.btnclose2.Name = "btnclose2";
            this.btnclose2.Size = new System.Drawing.Size(103, 191);
            this.btnclose2.TabIndex = 19;
            this.btnclose2.Text = "Close2";
            this.btnclose2.UseVisualStyleBackColor = true;
            this.btnclose2.Click += new System.EventHandler(this.button2_Click);
            // 
            // set
            // 
            this.set.Location = new System.Drawing.Point(924, 63);
            this.set.Name = "set";
            this.set.Size = new System.Drawing.Size(194, 63);
            this.set.TabIndex = 20;
            this.set.Text = "set";
            this.set.UseVisualStyleBackColor = true;
            // 
            // timer2
            // 
            this.timer2.Interval = 15;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // 取得座標
            // 
            this.取得座標.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.取得座標.Location = new System.Drawing.Point(533, 675);
            this.取得座標.Multiline = true;
            this.取得座標.Name = "取得座標";
            this.取得座標.Size = new System.Drawing.Size(411, 93);
            this.取得座標.TabIndex = 21;
            this.取得座標.Text = "取得座標";
            this.取得座標.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(979, 816);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 24);
            this.label11.TabIndex = 22;
            this.label11.Text = "label11";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(979, 887);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 24);
            this.label12.TabIndex = 23;
            this.label12.Text = "label12";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(979, 966);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 24);
            this.label13.TabIndex = 24;
            this.label13.Text = "label13";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1681, 1229);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.取得座標);
            this.Controls.Add(this.set);
            this.Controls.Add(this.btnclose2);
            this.Controls.Add(this.btnopen2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.位置座標);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.cmbCOMPort);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.tbxRxData);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxRxData;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmbCOMPort;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.TextBox 位置座標;
        private System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnopen2;
        private System.Windows.Forms.Button btnclose2;
        private System.Windows.Forms.Button set;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox 取得座標;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}

