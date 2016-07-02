using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices; 

namespace mdi2.UserControls
{   
    

    public partial class MainWin : UserControl
    {
        

        System.IO.Stream music;
        private static Thread passm;

        public MainWin()
        {
            InitializeComponent();

            UCForm2 uc2 = new UCForm2();
        }

        [DllImport("user32")]
        public static extern void LockWorkStation();

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (UCForm2.alrm == 1||UCForm2.alrmnopas==1)
                label5.Text = "Alarm : Activated";
            else
                label5.Text = "Alarm : Deactivated";

            if (UCForm2.lck == 1)
                label7.Text = "Lock : Activated";
            else
                label7.Text = "Lock : Deactivated";

            if (UCForm2.alrmnopas == 0)
                label6.Text = "Password : Activated";
            else
                label6.Text = "Password : Deactivated";

            


            PowerStatus powerStatus = SystemInformation.PowerStatus;

            label3.Text = powerStatus.PowerLineStatus.ToString();
            label4.Text = (powerStatus.BatteryLifePercent * 100).ToString() + "%";

            if (powerStatus.PowerLineStatus == PowerLineStatus.Online)
            {
                //label1.Text="Running On Power," + Convert.ToString(powerStatus.BatteryLifePercent * 100) + "%";
                MainForm.statenow = 1;
                MainForm.stateprev = 1;
            }
            else if (powerStatus.PowerLineStatus == PowerLineStatus.Offline)
            {
                MainForm.stateprev = 2;
                if(MainForm.statenow!=MainForm.stateprev && (UCForm2.alrm==1||UCForm2.lck==1||UCForm2.alrmnopas==1))
                 {  //label2.Text="Running On Battery,"+ Convert.ToString(powerStatus.BatteryLifePercent * 100) + "%";
                     MainForm.passMatch = 0;
                    if(UCForm2.lck==1)
                        LockWorkStation(); 

                    // passm.Start(checkPass);

                     //this.Enabled = false;
                    if(UCForm2.alrm==1)
                    {    
                        checkPass cp = new checkPass();
                        cp.Show();
                    }
                    else if (UCForm2.alrmnopas == 1)
                    {
                        Alarm_Play ap = new Alarm_Play();
                        ap.Show();
                    
                    }

                     
                    // this.Enabled = true;

                        MainForm.statenow = 2;
                }
            }
        }

        private void MainWin_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        
        
    }
}
