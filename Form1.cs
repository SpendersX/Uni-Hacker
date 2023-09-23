using System.Diagnostics;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace UniHook
{
    public partial class Form1 : Form
    {
        Point lastPoint;
        public Form1()
        {
            InitializeComponent();

            // Get an array of all running processes
            Process[] processes = Process.GetProcesses();

            // Add each process name to the combo box
            foreach (Process process in processes)
            {
                comboBox1.Items.Add(process.ProcessName);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        string DLLP { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = @"C:\";
                ofd.Title = "Select Dll File";
                ofd.DefaultExt = "dll";
                ofd.Filter = "Dll Files (*.dll |*.dll";
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                ofd.ShowDialog();

                textBox1.Text = ofd.FileName;
                DLLP = ofd.FileName;
            }
            catch (Exception ed)
            {
                MessageBox.Show(ed.Message);
            }

        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (true)
            {
                // Get an array of all running processes
                Process[] processes = Process.GetProcesses();

                // Add each process name to the combo box
                foreach (Process process in processes)
                {
                    comboBox1.Items.Add(process.ProcessName);
                }

                Thread.Sleep(5000);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr GetModuleHandle(string lpModuleName);

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out IntPtr lpNumberOfBytesWritten);

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);



            string processName = comboBox1.SelectedItem.ToString();
            string dllPath = textBox1.Text;

            Process process = Process.GetProcessesByName(processName)[0];
            IntPtr processHandle = OpenProcess(0x1F0FFF, false, process.Id);

            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            IntPtr allocMemAddr = VirtualAllocEx(processHandle, IntPtr.Zero, (uint)dllPath.Length, 0x1000, 0x40);

            IntPtr bytesWritten;
            WriteProcessMemory(processHandle, allocMemAddr, Encoding.ASCII.GetBytes(dllPath), (uint)dllPath.Length, out bytesWritten);

            CreateRemoteThread(processHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddr, 0, IntPtr.Zero);

            MessageBox.Show("DLL injected successfully.");
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }

        }
    }
}
