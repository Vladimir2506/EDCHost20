using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EDC20HOST
{
    public partial class SetWindow : Form
    {
        private MyFlags _flags;
        private Game _game;
        public SetWindow(ref MyFlags flags, ref Game game)
        {
            InitializeComponent();
            _flags = flags;
            _game = game;
            nudHue1L.Value = flags.configs.hue1Lower;
            nudHue1H.Value = flags.configs.hue1Upper;
            nudHue2L.Value = flags.configs.hue2Lower;
            nudHue2H.Value = flags.configs.hue2Upper;
            nudSat1L.Value = flags.configs.saturation1Lower;
            nudSat2L.Value = flags.configs.saturation2Lower;
            nudValueL.Value = flags.configs.valueLower;
            nudAreaL.Value = flags.configs.areaLower;
            checkBox_DebugMode.Checked = game.DebugMode;
        }

        private void nudHue1L_ValueChanged(object sender, EventArgs e)
        {
            _flags.configs.hue1Lower = (int)nudHue1L.Value;
        }

        private void nudHue1H_ValueChanged(object sender, EventArgs e)
        {
            _flags.configs.hue1Upper = (int)nudHue1H.Value;
        }

        private void nudHue2L_ValueChanged(object sender, EventArgs e)
        {
            _flags.configs.hue2Lower = (int)nudHue2L.Value;
        }

        private void nudHue2H_ValueChanged(object sender, EventArgs e)
        {
            _flags.configs.hue2Upper = (int)nudHue2H.Value;
        }

        private void nudSat1L_ValueChanged(object sender, EventArgs e)
        {
            _flags.configs.saturation1Lower = (int)nudSat1L.Value;
        }

        private void nudSat2L_ValueChanged(object sender, EventArgs e)
        {
            _flags.configs.saturation2Lower = (int)nudSat2L.Value;
        }

        private void nudValueL_ValueChanged(object sender, EventArgs e)
        {
            _flags.configs.valueLower = (int)nudValueL.Value;
        }

        private void nudAreaL_ValueChanged(object sender, EventArgs e)
        {
            _flags.configs.areaLower = (int)nudAreaL.Value;
        }

        private void checkBox_DebugMode_CheckedChanged(object sender, EventArgs e)
        {
            _game.DebugMode = checkBox_DebugMode.Checked;
        }

        private void button_ConfigSave_Click(object sender, EventArgs e)
        {
            string arrStr = String.Format("{0} {1} {2} {3} {4} {5} {6} {7}", _flags.configs.hue1Lower, _flags.configs.hue1Upper, _flags.configs.hue2Lower
                                        , _flags.configs.hue2Upper, _flags.configs.saturation1Lower, _flags.configs.saturation2Lower
                                        , _flags.configs.valueLower, _flags.configs.areaLower);
            File.WriteAllText("data.txt", arrStr);
        }

        private void button_ConfigLoad_Click(object sender, EventArgs e)
        {
            if (File.Exists("data.txt"))
            {
                FileStream fsRead = new FileStream("data.txt", FileMode.Open);
                int fsLen = (int)fsRead.Length;
                byte[] heByte = new byte[fsLen];
                int r = fsRead.Read(heByte, 0, heByte.Length);
                string myStr = System.Text.Encoding.UTF8.GetString(heByte);
                string[] str = myStr.Split(' ');
                nudHue1L.Value = (_flags.configs.hue1Lower = Convert.ToInt32(str[0]));
                nudHue1H.Value = (_flags.configs.hue1Upper = Convert.ToInt32(str[1]));
                nudHue2L.Value = (_flags.configs.hue2Lower = Convert.ToInt32(str[2]));
                nudHue2H.Value = (_flags.configs.hue2Upper = Convert.ToInt32(str[3]));
                nudSat1L.Value = (_flags.configs.saturation1Lower = Convert.ToInt32(str[4]));
                nudSat2L.Value = (_flags.configs.saturation2Lower = Convert.ToInt32(str[5]));
                nudValueL.Value = (_flags.configs.valueLower = Convert.ToInt32(str[6]));
                nudAreaL.Value = (_flags.configs.areaLower = Convert.ToInt32(str[7]));
                fsRead.Close();
            }
        }
    }
}
