using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mdi2
{

    
    public partial class MainForm : Form
    {//user control
        public static mdi2.UserControls.Pass ucForm1;
        public static mdi2.UserControls.UCForm2 ucForm2;
        public static mdi2.UserControls.MainWin ucForm3;

        public static string pass = "", alarmpath = "", difpath = "mdi2.sw.wav",savedpass="";
        public static int stateprev = 1,statenow=1, passMatch=1,audi=0; //1 for default 2 for customized
        public MainForm()
        {
            
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            notifyIcon1.Visible = true;
            

        // Instantiate the User Controls
            ucForm3 = new mdi2.UserControls.MainWin();
            this.Controls.Add(ucForm3);

        ucForm1 = new mdi2.UserControls.Pass();
        this.Controls.Add(ucForm1);
        ucForm2 = new mdi2.UserControls.UCForm2();
        this.Controls.Add(ucForm2);
            

        ucForm3.Visible = true;
        ucForm3.Dock = DockStyle.Fill;

            
        ucForm3.BringToFront();
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void uCForm1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            

            ucForm1.Visible = true;
            ucForm1.Dock = DockStyle.Fill;
            ucForm1.BringToFront();
            ucForm1.clr();
        }

        
         private void uCForm2ToolStripMenuItem_Click(object sender, EventArgs e)
         {
             ucForm2.Visible = true;
             ucForm2.Dock = DockStyle.Fill;
             ucForm2.BringToFront();
         }

         private void homeToolStripMenuItem_Click(object sender, EventArgs e)
         {
             MainForm.ucForm3.Visible = true;
             MainForm.ucForm3.Dock = DockStyle.Fill;
             MainForm.ucForm3.BringToFront();
         }


         

    


         protected override void WndProc(ref Message m)
         {
             
             
                 if (m.Msg == 0x10) // WM_CLOSE
                 {
                     // Process the form closing. Call the base method if required,
                     // and return from the function if not.
                     // For example:
                     if (MainForm.passMatch==0)
                         return;
                     else
                     {
                         //this.Close();
                         Environment.Exit(1);
                         Application.Exit();


                     }
                 }
                 base.WndProc(ref m);
             
             
         }

         private void sendToSystemTrayToolStripMenuItem_Click(object sender, EventArgs e)
         {
            // notifyIcon1.Icon = SystemIcons.
             notifyIcon1.Visible = true;

            // notifyIcon1.ShowBalloonTip(500,"hi");
             notifyIcon1.Text = "Bat_Stat";

             notifyIcon1.ShowBalloonTip(100, "Bat_Stat", "Keeping an eye on power plug.", ToolTipIcon.Info);

             this.Hide();
         }

         private void notifyIcon1_MouseDoubleClick_1(object sender, MouseEventArgs e)
         {
             this.Show();
             this.WindowState = FormWindowState.Normal;
         }
    }
}
