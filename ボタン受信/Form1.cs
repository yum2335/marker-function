using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Runtime.Remoting;
using FNF.Utility;
using System.Threading;
using System.IO;

namespace ボタン受信
{

    public partial class Form1 : Form
    {
        private BouyomiChanClient BouyomiChan;
        private sousarireki sousa;
        bool marker1 = false, marker2 = false, marker3 = false, marker4 = false,
            marker5 = false, marker6 = false, marker7 = false, marker8 = false, marker9 = false, marker10 = false,
            marker11 = false, marker12 = false, marker13 = false;

        int[] tyusinX = new int[13];
        int[] tyusinY = new int[13];
        int A = 42 * 42;
        int B = 70 * 70;

            

        private void tbxRxData_TextChanged(object sender, EventArgs e)
        {

        }

        static void Sleep()
        {
            Thread.Sleep(700);
        }

        static void Sleep2()
        {
            Thread.Sleep(600);
        }

        static void Sleep3()
        {
            Thread.Sleep(10000);
        }

        static async void Delay()
        {
            await Task.Delay(5000);
        }

        public Form1()
        {
            InitializeComponent();
            scanCOMPorts();
            //棒読みちゃんに接続
            BouyomiChan = new BouyomiChanClient();
            sousa = new sousarireki();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort2.PortName = cmbCOMPort.Text; // COM名設定
                serialPort2.Open();                     // ポート接続
                btnopen2.Enabled = false;                // 接続　Off
                btnclose2.Enabled = true;                // 切断　On
                btnScan.Enabled = false;                // 更新　Off
                cmbCOMPort.Enabled = false;             // COMリスト　Off

                                      // 画面クリア
                tbxRxData.AppendText("接続2\r\n");  // 接続と表示
            }
            catch
            {
                btnClose_Click(this, null);     // 切断ボタンを押す
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnopen2.Enabled = true;             // 接続　On
            btnclose2.Enabled = false;           // 切断　Off
            btnScan.Enabled = true;             // 更新　On
            cmbCOMPort.Enabled = true;          // COMリスト　On

            try
            {
                serialPort2.DiscardInBuffer();  // 入力バッファを破棄
                serialPort2.DiscardOutBuffer(); // 出力バッファを破棄
                serialPort2.Close();             // COMポートを閉じる
            }
            catch { };
        }

        private void scanCOMPorts()
        {
            cmbCOMPort.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            foreach (string p in ports)
            {
                cmbCOMPort.Items.Add(p);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = cmbCOMPort.Text; // COM名設定
                serialPort1.Open();                     // ポート接続
                btnOpen.Enabled = false;                // 接続　Off
                btnClose.Enabled = true;                // 切断　On
                btnScan.Enabled = false;                // 更新　Off
                          // COMリスト　Off
               
                tbxRxData.Clear();                      // 画面クリア
                tbxRxData.AppendText("接続1\r\n");  // 接続と表示
            }
            catch
            {
                btnClose_Click(this, null);     // 切断ボタンを押す
            }
        }

       

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                if (Start.Text == "Start")
                {
                    Start.Text = "Stop";
                    timer2.Enabled = true;
                    timer1.Enabled = true;
                }
                else
                {
                    Start.Text = "Start";
                    timer2.Enabled = false;
                    timer1.Enabled = false;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            取得座標.Text = Control.MousePosition.ToString();
            //this.label1.Text = Cursor.Position.ToString();

            //マウスポインタの位置を取得する
            //X座標を取得する
            int x = System.Windows.Forms.Cursor.Position.X;
            //Y座標を取得する
            int y = System.Windows.Forms.Cursor.Position.Y;
            sousa.sousa();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnOpen.Enabled = true;             // 接続　On
            btnClose.Enabled = false;           // 切断　Off
            btnScan.Enabled = true;             // 更新　On
            cmbCOMPort.Enabled = true;          // COMリスト　On

            try
            {
                serialPort1.DiscardInBuffer();  // 入力バッファを破棄
                serialPort1.DiscardOutBuffer(); // 出力バッファを破棄
                serialPort1.Close();             // COMポートを閉じる
            }
            catch { };
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            scanCOMPorts();
        }
        

        delegate void SetTextCallback(string text);

        private void timer2_Tick(object sender, EventArgs e)
        {
            bool yomiage = BouyomiChan.NowPlaying;
            int moji = BouyomiChan.TalkTaskCount;
            // マウス・カーソルの現在位置を
            // ミリ秒ごとに取得してラベルに設定
            位置座標.Text = Control.MousePosition.ToString();
            //this.label1.Text = Cursor.Position.ToString();

            //マウスポインタの位置を取得する
            //X座標を取得する
            int x = System.Windows.Forms.Cursor.Position.X;
            //Y座標を取得する
            int y = System.Windows.Forms.Cursor.Position.Y;



            

             if (marker1==true&&(x - tyusinX[0]) * (x - tyusinX[0]) + (y - tyusinY[0]) * (y - tyusinY[0]) < A)
            {
                label1.Text = string.Format(" マーカー1中心x座標 = {0}, y座標 = {1}", tyusinX[0], tyusinY[0]);
                BouyomiChan.ClearTalkTasks();
               
                if (yomiage == false)
                {

                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("1");
                        Sleep2();
                        BouyomiChan.ClearTalkTasks();

                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }
            }
            

            else if (marker2 == true && (x - tyusinX[1]) * (x - tyusinX[1]) + (y - tyusinY[1]) * (y - tyusinY[1]) < 28 * 28)
            {
                label2.Text = string.Format(" マーカー2中心x座標 = {0}, y座標 = {1}", tyusinX[1], tyusinY[1]);
                if (moji >= 1)
                {
                    BouyomiChan.ClearTalkTasks();
                }
                if (yomiage == false)
                {

                    try
                    {
                       
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("2");
                        Sleep();

                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }
            }

            else if (marker3 == true && (x - tyusinX[2]) * (x - tyusinX[2]) + (y - tyusinY[2]) * (y - tyusinY[2]) < 28 * 28)
            {
                label3.Text = string.Format(" マーカー3中心x座標 = {0}, y座標 = {1}", tyusinX[2], tyusinY[2]);
                if (moji >= 1)
                {
                    BouyomiChan.ClearTalkTasks();
                }
                if (yomiage == false)
                {

                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("3");
                        Sleep2();
                        BouyomiChan.ClearTalkTasks();

                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }
            }
            if (marker4 == true && (x - tyusinX[3]) * (x - tyusinX[3]) + (y - tyusinY[3]) * (y - tyusinY[3]) < 28 * 28)
            {
                label4.Text = string.Format(" マーカー4中心x座標 = {0}, y座標 = {1}", tyusinX[3], tyusinY[3]);
                if (moji > 1)
                {
                    BouyomiChan.ClearTalkTasks();
                }
                if (yomiage == false)
                {

                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("4");
                        Sleep2();
                        BouyomiChan.ClearTalkTasks();
                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }
            }

            if (marker5 == true && (x - tyusinX[4]) * (x - tyusinX[4]) + (y - tyusinY[4]) * (y - tyusinY[4]) < 28 * 28)
            {
                label5.Text = string.Format(" マーカー5中心x座標 = {0}, y座標 = {1}", tyusinX[4], tyusinY[4]);
                if (moji > 1)
                {
                    BouyomiChan.ClearTalkTasks();
                }
                if (yomiage == false)
                {

                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("5");
                        Sleep();
                        BouyomiChan.ClearTalkTasks();
                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }
            }

            if (marker6 == true && (x - tyusinX[5]) * (x - tyusinX[5]) + (y - tyusinY[5]) * (y - tyusinY[5]) < 28 * 28)
            {
                label6.Text = string.Format(" マーカー6中心x座標 = {0}, y座標 = {1}", tyusinX[5], tyusinY[5]);
                if (moji > 1)
                {
                    BouyomiChan.ClearTalkTasks();
                }
                if (yomiage == false)
                {

                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("6");
                        Sleep2();
                        BouyomiChan.ClearTalkTasks();
                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }
            }

            if (marker7 == true && (x - tyusinX[6]) * (x - tyusinX[6]) + (y - tyusinY[6]) * (y - tyusinY[6]) < 28 * 28)
            {
                label7.Text = string.Format(" マーカー7中心x座標 = {0}, y座標 = {1}", tyusinX[6], tyusinY[6]);
                if (moji > 1)
                {
                    BouyomiChan.ClearTalkTasks();
                }
                if (yomiage == false)
                {

                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("7");
                        Sleep2();
                        BouyomiChan.ClearTalkTasks();
                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }
            }

            if (marker8 == true && (x - tyusinX[7]) * (x - tyusinX[7]) + (y - tyusinY[7]) * (y - tyusinY[7]) < 28 * 28)
            {
                label8.Text = string.Format(" マーカー8中心x座標 = {0}, y座標 = {1}", tyusinX[7], tyusinY[7]);
                if (moji > 1)
                {
                    BouyomiChan.ClearTalkTasks();
                }
                if (yomiage == false)
                {

                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("8");
                        Sleep2();
                        BouyomiChan.ClearTalkTasks();
                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }
            }

            if (marker9 == true && (x - tyusinX[8]) * (x - tyusinX[8]) + (y - tyusinY[8]) * (y - tyusinY[8]) < 28 * 28)
            {
                label9.Text = string.Format(" マーカー9中心x座標 = {0}, y座標 = {1}", tyusinX[8], tyusinY[8]);
                if (moji > 1)
                {
                    BouyomiChan.ClearTalkTasks();
                }
                if (yomiage == false)
                {

                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("9");
                        Sleep2();
                        BouyomiChan.ClearTalkTasks();
                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }
            }

            if (marker10 == true && (x - tyusinX[9]) * (x - tyusinX[9]) + (y - tyusinY[9]) * (y - tyusinY[9]) < 28 * 28)
            {
                label10.Text = string.Format(" マーカー10中心x座標 = {0}, y座標 = {1}", tyusinX[9], tyusinY[9]);
                if (moji > 1)
                {
                    BouyomiChan.ClearTalkTasks();
                }
                if (yomiage == false)
                {

                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("10");
                        Sleep2();
                        BouyomiChan.ClearTalkTasks();
                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }
            }

            if (marker11 == true && (x - tyusinX[10]) * (x - tyusinX[10]) + (y - tyusinY[10]) * (y - tyusinY[10]) < 28 * 28)
            {
                label11.Text = string.Format(" マーカー11中心x座標 = {0}, y座標 = {1}", tyusinX[10], tyusinY[10]);
                if (moji > 1)
                {
                    BouyomiChan.ClearTalkTasks();
                }
                if (yomiage == false)
                {

                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("11");
                        Sleep2();
                        BouyomiChan.ClearTalkTasks();
                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }
            }

            if (marker12 == true && (x - tyusinX[11]) * (x - tyusinX[11]) + (y - tyusinY[11]) * (y - tyusinY[11]) < 28 * 28)
            {
                label12.Text = string.Format(" マーカー12中心x座標 = {0}, y座標 = {1}", tyusinX[11], tyusinY[11]);
                if (moji > 1)
                {
                    BouyomiChan.ClearTalkTasks();
                }
                if (yomiage == false)
                {

                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("12");
                        Sleep2();
                        BouyomiChan.ClearTalkTasks();
                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }
            }

            if (marker13 == true && (x - tyusinX[12]) * (x - tyusinX[12]) + (y - tyusinY[12]) * (y - tyusinY[12]) < 28 * 28)
            {
                label13.Text = string.Format(" マーカー13中心x座標 = {0}, y座標 = {1}", tyusinX[12], tyusinY[12]);
                if (moji > 1)
                {
                    BouyomiChan.ClearTalkTasks();
                }
                if (yomiage == false)
                {

                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("13");
                        Sleep2();
                        BouyomiChan.ClearTalkTasks();
                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }
            }

        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            try
            {
                SetText(serialPort1.ReadExisting());
            }
            catch
            {
                
            }
        }

        private void SetText(string text)
        {
         
            位置座標.Text = Control.MousePosition.ToString();
            int x = System.Windows.Forms.Cursor.Position.X;
           
            int y = System.Windows.Forms.Cursor.Position.Y;
            
            if (tbxRxData.InvokeRequired)
                {
                
                if (marker1==false)
                {
                    tyusinX[0] = x;
                    tyusinY[0] = y;
                    
                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("マーカー1としてマークしました");

                        sousa.marker(1,tyusinX[0], tyusinY[0]);


                        SetTextCallback d = new SetTextCallback(SetText);
                        Invoke(d, new object[] { "マーカ1つけた\r\n" });
                        

                        marker1 = true;


                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }

                
                if (marker2 == false && (x - tyusinX[0]) * (x - tyusinX[0]) + (y - tyusinY[0]) * (y - tyusinY[0]) > B)
                {
                    tyusinX[1] = x;
                    tyusinY[1] = y;
                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("マーカー2としてマークしました");

                        sousa.marker(2, tyusinX[1], tyusinY[1]);


                        marker2 = true;
                        SetTextCallback d = new SetTextCallback(SetText);
                        Invoke(d, new object[] { "マーカ2つけた\r\n" });
                       
                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }
               
                if (marker3 == false && (x - tyusinX[0]) * (x - tyusinX[0]) + (y - tyusinY[0]) * (y - tyusinY[0]) > B &&
                    (x - tyusinX[1]) * (x - tyusinX[1]) + (y - tyusinY[1]) * (y - tyusinY[1]) > 56 * 56)
                {
                    tyusinX[2] = x;
                    tyusinY[2] = y;
                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("マーカー3としてマークしました");

                        sousa.marker(3, tyusinX[2], tyusinY[2]);
                        marker3 = true;

                        SetTextCallback d = new SetTextCallback(SetText);
                        Invoke(d, new object[] { "マーカ3つけた\r\n" });
                    }

                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }
               
                if (marker4 == false && (x - tyusinX[0]) * (x - tyusinX[0]) + (y - tyusinY[0]) * (y - tyusinY[0]) > B &&
                    (x - tyusinX[1]) * (x - tyusinX[1]) + (y - tyusinY[1]) * (y - tyusinY[1]) > 56 * 56 &&
                    (x - tyusinX[2]) * (x - tyusinX[2]) + (y - tyusinY[2]) * (y - tyusinY[2]) > 56 * 56)
                {
                    tyusinX[3] = x;
                    tyusinY[3] = y;
                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("マーカー4としてマークしました");

                        sousa.marker(4, tyusinX[3], tyusinY[3]);
                        marker4 = true;
                       
                        SetTextCallback d = new SetTextCallback(SetText);
                        Invoke(d, new object[] { "マーカ4つけた\r\n" });
                       

                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }

                if (marker5 == false && (x - tyusinX[0]) * (x - tyusinX[0]) + (y - tyusinY[0]) * (y - tyusinY[0]) > B &&
                   (x - tyusinX[1]) * (x - tyusinX[1]) + (y - tyusinY[1]) * (y - tyusinY[1]) > 56 * 56 &&
                    (x - tyusinX[2]) * (x - tyusinX[2]) + (y - tyusinY[2]) * (y - tyusinY[2]) > 56 * 56 &&
                    (x - tyusinX[3]) * (x - tyusinX[3]) + (y - tyusinY[3]) * (y - tyusinY[3]) > 56 * 56)
                {
                    tyusinX[4] = x;
                    tyusinY[4] = y;
                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("マーカー5としてマークしました");

                        sousa.marker(5, tyusinX[4], tyusinY[4]);
                        marker5 = true;

                        SetTextCallback d = new SetTextCallback(SetText);
                        Invoke(d, new object[] { "マーカ5つけた\r\n" });


                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }

                if (marker6 == false && (x - tyusinX[0]) * (x - tyusinX[0]) + (y - tyusinY[0]) * (y - tyusinY[0]) > B &&
                   (x - tyusinX[1]) * (x - tyusinX[1]) + (y - tyusinY[1]) * (y - tyusinY[1]) > 56 * 56 &&
                    (x - tyusinX[2]) * (x - tyusinX[2]) + (y - tyusinY[2]) * (y - tyusinY[2]) > 56 * 56 &&
                    (x - tyusinX[3]) * (x - tyusinX[3]) + (y - tyusinY[3]) * (y - tyusinY[3]) > 56 * 56 &&
                    (x - tyusinX[4]) * (x - tyusinX[4]) + (y - tyusinY[4]) * (y - tyusinY[4]) > 56 * 56)
                {
                    tyusinX[5] = x;
                    tyusinY[5] = y;
                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("マーカー6としてマークしました");

                        sousa.marker(6, tyusinX[5], tyusinY[5]);
                        marker6 = true;

                        SetTextCallback d = new SetTextCallback(SetText);
                        Invoke(d, new object[] { "マーカ6つけた\r\n" });


                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }

                if (marker7 == false && (x - tyusinX[0]) * (x - tyusinX[0]) + (y - tyusinY[0]) * (y - tyusinY[0]) > B &&
                    (x - tyusinX[1]) * (x - tyusinX[1]) + (y - tyusinY[1]) * (y - tyusinY[1]) > 56 * 56 &&
                    (x - tyusinX[2]) * (x - tyusinX[2]) + (y - tyusinY[2]) * (y - tyusinY[2]) > 56 * 56 &&
                    (x - tyusinX[3]) * (x - tyusinX[3]) + (y - tyusinY[3]) * (y - tyusinY[3]) > 56 * 56 &&
                    (x - tyusinX[4]) * (x - tyusinX[4]) + (y - tyusinY[4]) * (y - tyusinY[4]) > 56 * 56 &&
                    (x - tyusinX[5]) * (x - tyusinX[5]) + (y - tyusinY[5]) * (y - tyusinY[5]) > 56 * 56)
                   

                {
                    tyusinX[6] = x;
                    tyusinY[6] = y;
                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("マーカー7としてマークしました");

                        sousa.marker(7, tyusinX[6], tyusinY[6]);
                        marker7 = true;

                        SetTextCallback d = new SetTextCallback(SetText);
                        Invoke(d, new object[] { "マーカ7つけた\r\n" });


                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }

                if (marker8 == false && (x - tyusinX[0]) * (x - tyusinX[0]) + (y - tyusinY[0]) * (y - tyusinY[0]) > B &&
                    (x - tyusinX[1]) * (x - tyusinX[1]) + (y - tyusinY[1]) * (y - tyusinY[1]) > 56 * 56 &&
                    (x - tyusinX[2]) * (x - tyusinX[2]) + (y - tyusinY[2]) * (y - tyusinY[2]) > 56 * 56 &&
                    (x - tyusinX[3]) * (x - tyusinX[3]) + (y - tyusinY[3]) * (y - tyusinY[3]) > 56 * 56 &&
                    (x - tyusinX[4]) * (x - tyusinX[4]) + (y - tyusinY[4]) * (y - tyusinY[4]) > 56 * 56 &&
                    (x - tyusinX[5]) * (x - tyusinX[5]) + (y - tyusinY[5]) * (y - tyusinY[5]) > 56 * 56 &&
                    (x - tyusinX[6]) * (x - tyusinX[6]) + (y - tyusinY[6]) * (y - tyusinY[6]) > 56 * 56)
                {
                    tyusinX[7] = x;
                    tyusinY[7] = y;
                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("マーカー8としてマークしました");

                        sousa.marker(8, tyusinX[7], tyusinY[7]);
                        marker8 = true;

                        SetTextCallback d = new SetTextCallback(SetText);
                        Invoke(d, new object[] { "マーカ8つけた\r\n" });


                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }

                if (marker9 == false && (x - tyusinX[0]) * (x - tyusinX[0]) + (y - tyusinY[0]) * (y - tyusinY[0]) > B &&
                    (x - tyusinX[1]) * (x - tyusinX[1]) + (y - tyusinY[1]) * (y - tyusinY[1]) > 56 * 56 &&
                    (x - tyusinX[2]) * (x - tyusinX[2]) + (y - tyusinY[2]) * (y - tyusinY[2]) > 56 * 56 &&
                    (x - tyusinX[3]) * (x - tyusinX[3]) + (y - tyusinY[3]) * (y - tyusinY[3]) > 56 * 56 &&
                    (x - tyusinX[4]) * (x - tyusinX[4]) + (y - tyusinY[4]) * (y - tyusinY[4]) > 56 * 56 &&
                    (x - tyusinX[5]) * (x - tyusinX[5]) + (y - tyusinY[5]) * (y - tyusinY[5]) > 56 * 56 &&
                    (x - tyusinX[6]) * (x - tyusinX[6]) + (y - tyusinY[6]) * (y - tyusinY[6]) > 56 * 56 &&
                    (x - tyusinX[7]) * (x - tyusinX[7]) + (y - tyusinY[7]) * (y - tyusinY[7]) > 56 * 56)
                {
                    tyusinX[8] = x;
                    tyusinY[8] = y;
                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("マーカー9としてマークしました");

                        sousa.marker(9, tyusinX[8], tyusinY[8]);
                        marker9 = true;

                        SetTextCallback d = new SetTextCallback(SetText);
                        Invoke(d, new object[] { "マーカ9つけた\r\n" });


                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }

                if (marker10 == false && (x - tyusinX[0]) * (x - tyusinX[0]) + (y - tyusinY[0]) * (y - tyusinY[0]) > B &&
                    (x - tyusinX[1]) * (x - tyusinX[1]) + (y - tyusinY[1]) * (y - tyusinY[1]) > 56 * 56 &&
                    (x - tyusinX[2]) * (x - tyusinX[2]) + (y - tyusinY[2]) * (y - tyusinY[2]) > 56 * 56 &&
                    (x - tyusinX[3]) * (x - tyusinX[3]) + (y - tyusinY[3]) * (y - tyusinY[3]) > 56 * 56 &&
                    (x - tyusinX[4]) * (x - tyusinX[4]) + (y - tyusinY[4]) * (y - tyusinY[4]) > 56 * 56 &&
                    (x - tyusinX[5]) * (x - tyusinX[5]) + (y - tyusinY[5]) * (y - tyusinY[5]) > 56 * 56 &&
                    (x - tyusinX[6]) * (x - tyusinX[6]) + (y - tyusinY[6]) * (y - tyusinY[6]) > 56 * 56 &&
                    (x - tyusinX[7]) * (x - tyusinX[7]) + (y - tyusinY[7]) * (y - tyusinY[7]) > 56 * 56 &&
                    (x - tyusinX[8]) * (x - tyusinX[8]) + (y - tyusinY[8]) * (y - tyusinY[8]) > 56 * 56)
                {
                    tyusinX[9] = x;
                    tyusinY[9] = y;
                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("マーカー10としてマークしました");

                        sousa.marker(10, tyusinX[9], tyusinY[9]);
                        marker10 = true;

                        SetTextCallback d = new SetTextCallback(SetText);
                        Invoke(d, new object[] { "マーカ10つけた\r\n" });


                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }

                if (marker11 == false && (x - tyusinX[0]) * (x - tyusinX[0]) + (y - tyusinY[0]) * (y - tyusinY[0]) > B &&
                   (x - tyusinX[1]) * (x - tyusinX[1]) + (y - tyusinY[1]) * (y - tyusinY[1]) > 56 * 56 &&
                   (x - tyusinX[2]) * (x - tyusinX[2]) + (y - tyusinY[2]) * (y - tyusinY[2]) > 56 * 56 &&
                   (x - tyusinX[3]) * (x - tyusinX[3]) + (y - tyusinY[3]) * (y - tyusinY[3]) > 56 * 56 &&
                   (x - tyusinX[4]) * (x - tyusinX[4]) + (y - tyusinY[4]) * (y - tyusinY[4]) > 56 * 56 &&
                   (x - tyusinX[5]) * (x - tyusinX[5]) + (y - tyusinY[5]) * (y - tyusinY[5]) > 56 * 56 &&
                   (x - tyusinX[6]) * (x - tyusinX[6]) + (y - tyusinY[6]) * (y - tyusinY[6]) > 56 * 56 &&
                   (x - tyusinX[7]) * (x - tyusinX[7]) + (y - tyusinY[7]) * (y - tyusinY[7]) > 56 * 56 &&
                   (x - tyusinX[8]) * (x - tyusinX[8]) + (y - tyusinY[8]) * (y - tyusinY[8]) > 56 * 56&&
                   (x - tyusinX[9]) * (x - tyusinX[9]) + (y - tyusinY[9]) * (y - tyusinY[9]) > 56 * 56)
                {
                    tyusinX[10] = x;
                    tyusinY[10] = y;
                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("マーカー11としてマークしました");

                        sousa.marker(11, tyusinX[10], tyusinY[10]);
                        marker11 = true;

                        SetTextCallback d = new SetTextCallback(SetText);
                        Invoke(d, new object[] { "マーカ11つけた\r\n" });


                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }

                if (marker12 == false && (x - tyusinX[0]) * (x - tyusinX[0]) + (y - tyusinY[0]) * (y - tyusinY[0]) > B &&
                  (x - tyusinX[1]) * (x - tyusinX[1]) + (y - tyusinY[1]) * (y - tyusinY[1]) > 56 * 56 &&
                  (x - tyusinX[2]) * (x - tyusinX[2]) + (y - tyusinY[2]) * (y - tyusinY[2]) > 56 * 56 &&
                  (x - tyusinX[3]) * (x - tyusinX[3]) + (y - tyusinY[3]) * (y - tyusinY[3]) > 56 * 56 &&
                  (x - tyusinX[4]) * (x - tyusinX[4]) + (y - tyusinY[4]) * (y - tyusinY[4]) > 56 * 56 &&
                  (x - tyusinX[5]) * (x - tyusinX[5]) + (y - tyusinY[5]) * (y - tyusinY[5]) > 56 * 56 &&
                  (x - tyusinX[6]) * (x - tyusinX[6]) + (y - tyusinY[6]) * (y - tyusinY[6]) > 56 * 56 &&
                  (x - tyusinX[7]) * (x - tyusinX[7]) + (y - tyusinY[7]) * (y - tyusinY[7]) > 56 * 56 &&
                  (x - tyusinX[8]) * (x - tyusinX[8]) + (y - tyusinY[8]) * (y - tyusinY[8]) > 56 * 56 &&
                  (x - tyusinX[9]) * (x - tyusinX[9]) + (y - tyusinY[9]) * (y - tyusinY[9]) > 56 * 56&&
                  (x - tyusinX[10]) * (x - tyusinX[10]) + (y - tyusinY[10]) * (y - tyusinY[10]) > 56 * 56)
                {
                    tyusinX[11] = x;
                    tyusinY[11] = y;
                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("マーカー12としてマークしました");

                        sousa.marker(12, tyusinX[11], tyusinY[11]);
                        marker12 = true;

                        SetTextCallback d = new SetTextCallback(SetText);
                        Invoke(d, new object[] { "マーカ12つけた\r\n" });


                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }

                if (marker13 == false && (x - tyusinX[0]) * (x - tyusinX[0]) + (y - tyusinY[0]) * (y - tyusinY[0]) > B &&
                 (x - tyusinX[1]) * (x - tyusinX[1]) + (y - tyusinY[1]) * (y - tyusinY[1]) > 56 * 56 &&
                 (x - tyusinX[2]) * (x - tyusinX[2]) + (y - tyusinY[2]) * (y - tyusinY[2]) > 56 * 56 &&
                 (x - tyusinX[3]) * (x - tyusinX[3]) + (y - tyusinY[3]) * (y - tyusinY[3]) > 56 * 56 &&
                 (x - tyusinX[4]) * (x - tyusinX[4]) + (y - tyusinY[4]) * (y - tyusinY[4]) > 56 * 56 &&
                 (x - tyusinX[5]) * (x - tyusinX[5]) + (y - tyusinY[5]) * (y - tyusinY[5]) > 56 * 56 &&
                 (x - tyusinX[6]) * (x - tyusinX[6]) + (y - tyusinY[6]) * (y - tyusinY[6]) > 56 * 56 &&
                 (x - tyusinX[7]) * (x - tyusinX[7]) + (y - tyusinY[7]) * (y - tyusinY[7]) > 56 * 56 &&
                 (x - tyusinX[8]) * (x - tyusinX[8]) + (y - tyusinY[8]) * (y - tyusinY[8]) > 56 * 56 &&
                 (x - tyusinX[9]) * (x - tyusinX[9]) + (y - tyusinY[9]) * (y - tyusinY[9]) > 56 * 56 &&
                 (x - tyusinX[10]) * (x - tyusinX[10]) + (y - tyusinY[10]) * (y - tyusinY[10]) > 56 * 56&&
                 (x - tyusinX[11]) * (x - tyusinX[11]) + (y - tyusinY[11]) * (y - tyusinY[11]) > 56 * 56)
                {
                    tyusinX[12] = x;
                    tyusinY[12] = y;
                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("マーカー13としてマークしました");

                        sousa.marker(13, tyusinX[12], tyusinY[12]);
                        marker13 = true;

                        SetTextCallback d = new SetTextCallback(SetText);
                        Invoke(d, new object[] { "マーカ13つけた\r\n" });


                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }


            }
            else
            {
                tbxRxData.AppendText(text);
            }

        }

        private void serialPort2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            try
            {
                
                SetText2(serialPort2.ReadExisting());
            }
            catch
            {
               
            }
        }

        private void SetText2(string text)
        {
            位置座標.Text = Control.MousePosition.ToString();
            int x = System.Windows.Forms.Cursor.Position.X;

            int y = System.Windows.Forms.Cursor.Position.Y;
            
            if (tbxRxData.InvokeRequired)
            {


                if (marker1 == true && (x - tyusinX[0]) * (x - tyusinX[0]) + (y - tyusinY[0]) * (y - tyusinY[0]) < A)
                {

                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("マーカー1を削除しました");
                        sousa.deletemarker(1);

                        SetTextCallback d = new SetTextCallback(SetText);
                        Invoke(d, new object[] { "マーカ1消した\r\n" });

                        marker1 = false;


                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }
                if (marker2 == true && (x - tyusinX[1]) * (x - tyusinX[1]) + (y - tyusinY[1]) * (y - tyusinY[1]) < 28 * 28)
                {

                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("マーカー2を削除しました");
                        sousa.deletemarker(2);


                        SetTextCallback d = new SetTextCallback(SetText);
                        Invoke(d, new object[] { "マーカ2消した\r\n" });

                        marker2 = false;


                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }

                if (marker3 == true && (x - tyusinX[2]) * (x - tyusinX[2]) + (y - tyusinY[2]) * (y - tyusinY[2]) < 28 * 28)
                {

                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("マーカー3を削除しました");
                        sousa.deletemarker(3);

                        SetTextCallback d = new SetTextCallback(SetText);
                        Invoke(d, new object[] { "マーカ3消した\r\n" });

                        marker3 = false;


                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }

                if (marker4 == true && (x - tyusinX[3]) * (x - tyusinX[3]) + (y - tyusinY[3]) * (y - tyusinY[3]) < 28 * 28)
                {

                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("マーカー4を削除しました");
                        sousa.deletemarker(4);
                        SetTextCallback d = new SetTextCallback(SetText);
                        Invoke(d, new object[] { "マーカ4消した\r\n" });

                        marker4 = false;


                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }

                if (marker5 == true && (x - tyusinX[4]) * (x - tyusinX[4]) + (y - tyusinY[4]) * (y - tyusinY[4]) < 28 * 28)
                {

                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("マーカー5を削除しました");
                        sousa.deletemarker(5);

                        SetTextCallback d = new SetTextCallback(SetText);
                        Invoke(d, new object[] { "マーカ5消した\r\n" });

                        marker5 = false;


                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }

                if (marker6 == true && (x - tyusinX[5]) * (x - tyusinX[5]) + (y - tyusinY[5]) * (y - tyusinY[5]) < 28 * 28)
                {

                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("マーカー6を削除しました");
                        sousa.deletemarker(6);

                        SetTextCallback d = new SetTextCallback(SetText);
                        Invoke(d, new object[] { "マーカ6消した\r\n" });

                        marker6 = false;


                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }

                if (marker7 == true && (x - tyusinX[6]) * (x - tyusinX[6]) + (y - tyusinY[6]) * (y - tyusinY[6]) < 28 * 28)
                {

                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("マーカー7を削除しました");
                        sousa.deletemarker(7);

                        SetTextCallback d = new SetTextCallback(SetText);
                        Invoke(d, new object[] { "マーカ7消した\r\n" });

                        marker7 = false;


                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }

                if (marker8 == true && (x - tyusinX[7]) * (x - tyusinX[7]) + (y - tyusinY[7]) * (y - tyusinY[7]) < 28 * 28)
                {

                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("マーカー8を削除しました");
                        sousa.deletemarker(8);

                        SetTextCallback d = new SetTextCallback(SetText);
                        Invoke(d, new object[] { "マーカ8消した\r\n" });

                        marker8 = false;


                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }

                if (marker9 == true && (x - tyusinX[8]) * (x - tyusinX[8]) + (y - tyusinY[8]) * (y - tyusinY[8]) < 28 * 28)
                {

                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("マーカー9を削除しました");
                        sousa.deletemarker(9);

                        SetTextCallback d = new SetTextCallback(SetText);
                        Invoke(d, new object[] { "マーカ9消した\r\n" });

                        marker9 = false;


                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }

                if (marker10 == true && (x - tyusinX[9]) * (x - tyusinX[9]) + (y - tyusinY[9]) * (y - tyusinY[9]) < 28 * 28)
                {

                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("マーカー10を削除しました");
                        sousa.deletemarker(10);

                        SetTextCallback d = new SetTextCallback(SetText);
                        Invoke(d, new object[] { "マーカ10消した\r\n" });

                        marker10 = false;


                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }

                if (marker11 == true && (x - tyusinX[10]) * (x - tyusinX[10]) + (y - tyusinY[10]) * (y - tyusinY[10]) < 28 * 28)
                {

                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("マーカー11を削除しました");
                        sousa.deletemarker(11);

                        SetTextCallback d = new SetTextCallback(SetText);
                        Invoke(d, new object[] { "マーカ11消した\r\n" });

                        marker11 = false;


                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }

                if (marker12 == true && (x - tyusinX[11]) * (x - tyusinX[11]) + (y - tyusinY[11]) * (y - tyusinY[11]) < 28 * 28)
                {

                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("マーカー12を削除しました");
                        sousa.deletemarker(12);

                        SetTextCallback d = new SetTextCallback(SetText);
                        Invoke(d, new object[] { "マーカ12消した\r\n" });

                        marker12 = false;


                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }

                if (marker13 == true && (x - tyusinX[12]) * (x - tyusinX[12]) + (y - tyusinY[12]) * (y - tyusinY[12]) < 28 * 28)
                {

                    try
                    {
                        //BouyomiChan.AddTalkTask(textBoxMessage.Text);　←旧形式（タスクIDが必要ないならこちらでもOK）
                        int taskId = BouyomiChan.AddTalkTask2("マーカー13を削除しました");
                        sousa.deletemarker(13);
                        SetTextCallback d = new SetTextCallback(SetText);
                        Invoke(d, new object[] { "マーカ13消した\r\n" });

                        marker13 = false;


                    }
                    catch (RemotingException)
                    {
                        MessageBox.Show("接続できません");
                    }
                }


            }
            else
            {
                tbxRxData.AppendText(text);
            }

        }
       
      
    }


}
