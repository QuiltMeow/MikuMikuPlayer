using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Threading;
using Un4seen.Bass;
using Un4seen.BassWasapi;

namespace MikuMikuPlayer
{
    public class Analyzer
    {
        private const int spectrumLine = 32;

        private bool status, hasInit;
        private readonly DispatcherTimer timerDisplay;
        public readonly float[] fftData;
        private readonly ProgressBar barLeft, barRight;
        private readonly WASAPIPROC apiProcess;
        private int lastLevel, levelCount, deviceIndex;
        public readonly List<byte> spectrumData;
        private readonly Spectrum spectrum;
        private readonly ComboBox cbDeviceList;

        public Analyzer(ProgressBar barLeft, ProgressBar barRight, Spectrum spectrum, ComboBox cbDeviceList)
        {
            fftData = new float[8192];

            timerDisplay = new DispatcherTimer();
            timerDisplay.Tick += timerDisplayTick;
            timerDisplay.Interval = TimeSpan.FromMilliseconds(25);

            this.barLeft = barLeft;
            this.barRight = barRight;
            barRight.Maximum = (ushort.MaxValue) / 2;
            barLeft.Maximum = (ushort.MaxValue) / 2;
            apiProcess = new WASAPIPROC(process);
            spectrumData = new List<byte>();

            this.spectrum = spectrum;
            this.cbDeviceList = cbDeviceList;

            init();
        }

        public bool displayEnable
        {
            get;
            set;
        }

        public bool enable
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                if (value)
                {
                    if (!hasInit)
                    {
                        string[] array = (cbDeviceList.Items[cbDeviceList.SelectedIndex] as string).Split(' ');
                        deviceIndex = Convert.ToInt32(array[0]);
                        bool result = BassWasapi.BASS_WASAPI_Init(deviceIndex, 0, 0, BASSWASAPIInit.BASS_WASAPI_BUFFER, 1, 0.05F, apiProcess, IntPtr.Zero);
                        if (!result)
                        {
                            BASSError error = Bass.BASS_ErrorGetCode();
                            MessageBox.Show("發生錯誤 : " + error.ToString(), "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            hasInit = true;
                            cbDeviceList.Enabled = false;
                        }
                    }
                    BassWasapi.BASS_WASAPI_Start();
                }
                else
                {
                    BassWasapi.BASS_WASAPI_Stop(true);
                }
                timerDisplay.IsEnabled = value;
            }
        }

        private void init()
        {
            for (int i = 0; i < BassWasapi.BASS_WASAPI_GetDeviceCount(); ++i)
            {
                BASS_WASAPI_DEVICEINFO device = BassWasapi.BASS_WASAPI_GetDeviceInfo(i);
                if (device.IsEnabled && device.IsLoopback)
                {
                    string name = device.name.Split('(')[1].Split(')')[0];
                    cbDeviceList.Items.Add(string.Format("{0} - {1}", i, name));
                }
            }
            cbDeviceList.SelectedIndex = 0;
            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_UPDATETHREADS, false);
            bool result = Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            if (!result)
            {
                throw new EWException("初始化失敗");
            }
        }

        private void timerDisplayTick(object sender, EventArgs e)
        {
            int ret = BassWasapi.BASS_WASAPI_GetData(fftData, (int)BASSData.BASS_DATA_FFT8192);
            if (ret < -1)
            {
                return;
            }
            for (int x = 0, b0 = 0; x < spectrumLine; ++x)
            {
                float peak = 0;
                int b1 = (int)Math.Pow(2, x * 10.0 / (spectrumLine - 1));
                if (b1 > 1023)
                {
                    b1 = 1023;
                }
                if (b1 <= b0)
                {
                    b1 = b0 + 1;
                }
                for (; b0 < b1; ++b0)
                {
                    if (peak < fftData[1 + b0])
                    {
                        peak = fftData[1 + b0];
                    }
                }
                int y = (int)(Math.Sqrt(peak) * 3 * 255 - 4);
                if (y > 255)
                {
                    y = 255;
                }
                else if (y < 0)
                {
                    y = 0;
                }
                spectrumData.Add((byte)y);
            }

            if (displayEnable)
            {
                spectrum.set(spectrumData);
            }
            spectrumData.Clear();

            int level = BassWasapi.BASS_WASAPI_GetLevel();
            barLeft.Value = Utils.LowWord32(level);
            barRight.Value = Utils.HighWord32(level);
            if (level == lastLevel && level != 0)
            {
                ++levelCount;
            }
            lastLevel = level;

            if (levelCount > 3)
            {
                levelCount = 0;
                barLeft.Value = 0;
                barRight.Value = 0;
                free();
                Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
                hasInit = false;
                enable = true;
            }
        }

        private int process(IntPtr buffer, int length, IntPtr user)
        {
            return length;
        }

        public void free()
        {
            BassWasapi.BASS_WASAPI_Free();
            Bass.BASS_Free();
        }
    }
}