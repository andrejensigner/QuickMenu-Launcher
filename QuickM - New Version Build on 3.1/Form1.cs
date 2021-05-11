using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Threading;


namespace QuickM___New_Version_Build_on_3._1
{
    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();
        }
        

        //--> Posúvanie Window ---------------------------------------------------
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2; 


        // --> START BTN ---------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "fivem://"); //Nové spúštanie FiveM ako Shell
            
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Waiting for FiveM started!"); // Console Oznámenie
                Thread.Sleep(10000); // <= Časovanie / potom spustí zostávajuce scripty (10000 = 20sekund)
            }

            Process prs = Process.GetCurrentProcess(); 
            try
            {
                prs.MinWorkingSet = (IntPtr)(300000); 
            }
            catch (Exception)
            {
                throw new Exception();
            }

            
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); // Upresnuje %localappdata%
            //System.Diagnostics.Process.Start(System.IO.Path.Combine(appData, @"FiveM\FiveM.exe")); // Staré spúštanie FiveM
            Process[] processes = Process.GetProcessesByName("FiveM");
            

            foreach (Process proc in processes)
            proc.PriorityClass = ProcessPriorityClass.RealTime; // High; AboveHigh;
            

            Process[] processes2 = Process.GetProcessesByName("FiveM_GTAProcess");
            foreach (Process proc2 in processes2)
                proc2.PriorityClass = ProcessPriorityClass.RealTime;

            Process[] processes3 = Process.GetProcessesByName("FiveM_ChromeBrowser");
            foreach (Process proc3 in processes3)
                proc3.PriorityClass = ProcessPriorityClass.AboveNormal;
        }

        // --> CLOSE BTN ---------------------------------------------------
        private void button1_Click_1(object sender, EventArgs e)
        {
            Process[] Processes = Process.GetProcessesByName("explorer");
            if (Processes.Length == 0)
            {
                string ExplorerShell = string.Format("{0}\\{1}", Environment.GetEnvironmentVariable("WINDIR"), "explorer.exe");
                System.Diagnostics.Process prcExplorerShell = new System.Diagnostics.Process();
                prcExplorerShell.StartInfo.FileName = ExplorerShell;
                prcExplorerShell.StartInfo.UseShellExecute = true;
                prcExplorerShell.Start();
            }
            System.Diagnostics.Process.Start("cmd.exe", "/c taskkill /F /IM FiveM.exe /T");
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Text = "High Performance Mode";
                Process.Start(@"C:\Windows\System32\taskkill.exe", @"/F /IM explorer.exe");
                MessageBox.Show("High Performance mode Started!");


            }
            else
            {
                checkBox1.Text = "High Performance Mode";
                Process.Start(@"C:\Windows\explorer.exe");
                MessageBox.Show("High Performance mode Disabled!");
            }
        }

        // --> MINIMIZE BTN ---------------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // -- > MOUSE EVENTS !!! ----------------

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void facebook_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "https://www.facebook.com/cloudensigner");
        }
        // --> 
    }

}
