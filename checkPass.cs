using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace mdi2
{
    public partial class checkPass : Form
    {
        System.IO.Stream music;
        public static string audiopath="";
        public static System.Media.SoundPlayer player;

        public static int charo = 0;

        public checkPass()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            textBox1.Focus();


            this.AcceptButton = button1;

                if ( MainForm.audi == 1)
                {
                    Aplay();
                }
                else
                {
                    try
                    {
                        alplay();
                    }
                    catch
                    {

                        Atplay();

                    }
                }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == MainForm.savedpass)
            {
               
                MainForm.passMatch = 1;
                player.Stop();
                this.Dispose();
            
            }
            else
            {
                label1.Text = "Wrong Password!!";
                textBox1.Clear();
                textBox1.Focus();
            
            }
            
        }

        private void Aplay()
        {

            System.Reflection.Assembly thisExe;
            thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            music =
                thisExe.GetManifestResourceStream(MainForm.difpath);
            player = new System.Media.SoundPlayer(music);
            player.PlayLooping();
        }
        private void Atplay()
        {

            System.Reflection.Assembly thisExe;
            thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            music =
                thisExe.GetManifestResourceStream(MainForm.difpath);
            player = new System.Media.SoundPlayer(music);
            player.PlayLooping();
        }
        private void alplay()
        {
            string temp = "";
            for (int i = 0; i < MainForm.alarmpath.Length; i++)
            {
                if (MainForm.alarmpath[i] == '\0')
                    break;
                else
                    temp += MainForm.alarmpath[i];


            }
            player = new SoundPlayer(temp);
            player.Load();
            player.PlayLooping();

        }

        private void checkPass_Load(object sender, EventArgs e)
        {

        }

       

        protected override void WndProc(ref Message m)
        {


            if (m.Msg == 0x10) // WM_CLOSE
            {
                // Process the form closing. Call the base method if required,
                // and return from the function if not.
                // For example:
                if (MainForm.passMatch == 0)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                charo = 1;
                textBox1.PasswordChar = '\0';

            }
            else
            {
                charo = 1;

                textBox1.PasswordChar = '*';
            }
        }
    }
}
