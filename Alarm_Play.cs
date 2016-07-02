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
    public partial class Alarm_Play : Form
    {
        System.IO.Stream mmusic;
        public static System.Media.SoundPlayer pplayer;
        public Alarm_Play()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            button1.Focus();

            if (MainForm.audi == 1)
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

        private void Aplay()
        {

            System.Reflection.Assembly thisExe;
            thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            mmusic =
                thisExe.GetManifestResourceStream(MainForm.difpath);
            pplayer = new System.Media.SoundPlayer(mmusic);
            pplayer.PlayLooping();
        }
        private void Atplay()
        {

            System.Reflection.Assembly thisExe;
            thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            mmusic =
                thisExe.GetManifestResourceStream(MainForm.difpath);
            pplayer = new System.Media.SoundPlayer(mmusic);
            pplayer.PlayLooping();
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
            pplayer = new SoundPlayer(temp);
            pplayer.Load();
            pplayer.PlayLooping();

        }

        private void Alarm_Play_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm.passMatch = 1;
            pplayer.Stop();
            this.Dispose();
        }
    }
}
