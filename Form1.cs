using System.Diagnostics;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using MaterialSkin;
using MaterialSkin.Animations;
using MaterialSkin.Controls;
using System.Runtime.InteropServices;

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

            // Add the process names to the ListBox
            foreach (Process process in processes)
            {
                listBox1.Items.Add(process.ProcessName);
            }



        }






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

        [DllImport("user32.dll")]
        static extern int SetWindowText(IntPtr hWnd, string text);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("kernel32.dll")]
        static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FreeConsole();

        private Process process;
        private IntPtr threadHandle;

        [DllImport("kernel32.dll")]
        static extern uint SuspendThread(IntPtr hThread);

        [DllImport("kernel32.dll")]
        static extern uint ResumeThread(IntPtr hThread);

        [DllImport("psapi.dll")]
        static extern uint GetModuleFileNameEx(IntPtr hProcess, IntPtr hModule, [Out] StringBuilder lpBaseName, [In][MarshalAs(UnmanagedType.U4)] int nSize);



        private const int SW_MINIMIZE = 6;
        private const int SW_MAXIMIZE = 3;












        private void ChangeProcessWindowTitle(string processName, string newTitle)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            foreach (Process process in processes)
            {
                SetWindowText(process.MainWindowHandle, newTitle);
            }
        }




        private void MinimizeProcessWindow(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            foreach (Process process in processes)
            {
                ShowWindow(process.MainWindowHandle, SW_MINIMIZE);
            }
        }

        private void MaximizeProcessWindow(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            foreach (Process process in processes)
            {
                ShowWindow(process.MainWindowHandle, SW_MAXIMIZE);
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
                Process[] processes = Process.GetProcesses();

                // Add the process names to the ListBox
                foreach (Process process in processes)
                {
                    listBox1.Items.Add(process.ProcessName);
                }

                string processName = listBox1.SelectedItem.ToString();
                Process[] processesdetection = Process.GetProcessesByName(processName);

                string selectedItem = listBox1.SelectedItem.ToString();

                if (processesdetection.Length > 0)
                {

                }
                else
                {
                    label2.Text = "No Dlls Injected";
                }





                Thread.Sleep(500);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            CheckForIllegalCrossThreadCalls = false;

            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                listBox1.Items.Add(process.ProcessName);
            }


            backgroundWorker1.RunWorkerAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {


            string processName = listBox1.SelectedItem.ToString();
            string dllPath = textBox1.Text;

            Process process = Process.GetProcessesByName(processName)[0];
            IntPtr processHandle = OpenProcess(0x1F0FFF, false, process.Id);

            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            IntPtr allocMemAddr = VirtualAllocEx(processHandle, IntPtr.Zero, (uint)dllPath.Length, 0x1000, 0x40);

            IntPtr bytesWritten;
            WriteProcessMemory(processHandle, allocMemAddr, Encoding.ASCII.GetBytes(dllPath), (uint)dllPath.Length, out bytesWritten);

            CreateRemoteThread(processHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddr, 0, IntPtr.Zero);

            label2.Text = "Dll has ben injected";
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

        private void button4_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcesses();

            // Add the process names to the ListBox
            foreach (Process process in processes)
            {
                listBox1.Items.Add(process.ProcessName);
            }

            string processName = listBox1.SelectedItem.ToString();
            Process[] processesdetection = Process.GetProcessesByName(processName);

            string selectedItem = listBox1.SelectedItem.ToString();

            if (processesdetection.Length > 0)
            {

            }
            else
            {
                label2.Text = "No Dlls Injected";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string selectedTask = listBox1.SelectedItem.ToString();
            Process[] processes = Process.GetProcessesByName(selectedTask);
            foreach (Process process in processes)
            {
                process.Kill();
            }
        }



        private void button6_Click(object sender, EventArgs e)
        {
            string selectedItem = listBox1.SelectedItem.ToString();
            Process.Start(selectedItem);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string processName = listBox1.SelectedItem.ToString();
            string newTitle = textBox2.Text;
            ChangeProcessWindowTitle(processName, newTitle);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string processName = listBox1.SelectedItem.ToString(); ;
            MinimizeProcessWindow(processName);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string processNamea = listBox1.SelectedItem.ToString(); ;
            MaximizeProcessWindow(processNamea);
        }




        private void button10_Click_1(object sender, EventArgs e)
        {




            int selectedIndex = listBox1.SelectedIndex;


            process = Process.GetProcesses()[selectedIndex];
            foreach (ProcessThread thread in process.Threads)
            {
                IntPtr threadHandle = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)thread.Id);
                SuspendThread(threadHandle);
            }

            MessageBox.Show("Process frozen");
        }




        [DllImport("kernel32.dll")]
        static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);

        private void button11_Click(object sender, EventArgs e)
        {
            foreach (ProcessThread thread in process.Threads)
            {
                IntPtr threadHandle = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)thread.Id);
                ResumeThread(threadHandle);
            }

            MessageBox.Show("Process unfrozen");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string processName = listBox1.SelectedItem.ToString();
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                Process process = processes[0];
                listBox2.Items.Clear();
                listBox2.Items.Add("Process Name: " + process.ProcessName);
                listBox2.Items.Add("Process ID: " + process.Id);
                listBox2.Items.Add("Start Time: " + process.StartTime.ToString());
                listBox2.Items.Add("Total Processor Time: " + process.TotalProcessorTime.ToString());
                listBox2.Items.Add("Working Set: " + process.WorkingSet64.ToString());
                listBox2.Items.Add("Loaded Modules:");
                foreach (ProcessModule module in process.Modules)
                {
                    listBox2.Items.Add(module.FileName);
                }
            }
            else
            {
                MessageBox.Show("Process not found!");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public enum ThreadAccess : int
        {
            TERMINATE = (0x0001),
            SUSPEND_RESUME = (0x0002),
            GET_CONTEXT = (0x0008),
            SET_CONTEXT = (0x0010),
            SET_INFORMATION = (0x0020),
            QUERY_INFORMATION = (0x0040),
            SET_THREAD_TOKEN = (0x0080),
            IMPERSONATE = (0x0100),
            DIRECT_IMPERSONATION = (0x0200)
        }

    }
}
