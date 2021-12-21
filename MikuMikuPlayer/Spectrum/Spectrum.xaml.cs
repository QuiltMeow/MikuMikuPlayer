using System.Collections.Generic;
using System.Windows.Controls;

namespace MikuMikuPlayer
{
    public partial class Spectrum : UserControl
    {
        public Spectrum()
        {
            InitializeComponent();
        }

        public void set(List<byte> data)
        {
            if (data.Count < 32)
            {
                return;
            }
            bar1.Value = data[0];
            bar2.Value = data[1];
            bar3.Value = data[2];
            bar4.Value = data[3];
            bar5.Value = data[4];
            bar6.Value = data[5];
            bar7.Value = data[6];
            bar8.Value = data[7];
            bar9.Value = data[8];
            bar10.Value = data[9];
            bar11.Value = data[10];
            bar12.Value = data[11];
            bar13.Value = data[12];
            bar14.Value = data[13];
            bar15.Value = data[14];
            bar16.Value = data[15];
            bar17.Value = data[16];
            bar18.Value = data[17];
            bar19.Value = data[18];
            bar20.Value = data[19];
            bar21.Value = data[20];
            bar22.Value = data[21];
            bar23.Value = data[22];
            bar24.Value = data[23];
            bar25.Value = data[24];
            bar26.Value = data[25];
            bar27.Value = data[26];
            bar28.Value = data[27];
            bar29.Value = data[28];
            bar30.Value = data[29];
            bar31.Value = data[30];
            bar32.Value = data[31];
        }
    }
}