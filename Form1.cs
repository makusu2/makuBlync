using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Blynclight;
using System.Threading;
using System.Diagnostics;

namespace BlyncLightTest
{
    public partial class Form1
    {
        private BlynclightController makuController = new BlynclightController();
        public Form1()
        {
            //SearchAndListBlyncDevices();
            makuController.InitBlyncDevices();
            this.InfLoop();
        }
    
    public void InfLoop()
    {
        Random rnd = new Random();
        int[] steps = { 0, 0, 0 };
        byte[] vals = { 120, 120, 120 };
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                steps[i] = steps[i] + 1;
                vals[i] = (byte)(255 * Math.Pow((Math.Abs(Math.Sin(i + steps[i] * (i + 1) * Math.PI / 1800))), 2));
                //vals[i] = (byte)((vals[i]+(byte)(rnd.Next(5)-2))%256);
            }
            makuController.TurnOnRGBLights(0, vals[0], vals[1], vals[2]);
        }

    }
    private bool blankTicket = false;
    public bool BlankTicket
        {
            get
            {
                return this.blankTicket;
            }
            set
            {
                this.blankTicket = value;
                if (value)
                {
                    this.GoRed();
                }
                else
                {
                    this.GoGreen();
                }
            }
        }
    public void GoRed()
    {
        bool bResult = false;
        bResult = makuController.TurnOnRedLight(0);
    }
    public void GoGreen()
    {
        makuController.TurnOnGreenLight(0);
    }
    }
}
/*namespace BlyncLightTest
{
    public partial class Form1 : Form
    {
        private BlynclightController makuController = new BlynclightController();


        // Create object for the base class BlynclightController
        private BlynclightController makuController = new BlynclightController();

        private int nNumberOfBlyncDevices = 0;
        private int nSelectedDeviceIndex = 0;

        internal const byte DEVICETYPE_NODEVICE_INVALIDDEVICE_TYPE = 0x00;
        internal const byte DEVICETYPE_BLYNC_CHIPSET_TENX_10 = 0x01;
        internal const byte DEVICETYPE_BLYNC_CHIPSET_TENX_20 = 0x02;
        internal const byte DEVICETYPE_BLYNC_CHIPSET_V30 = 0x03;
        internal const byte DEVICETYPE_BLYNC_CHIPSET_V30S = 0x04;
        internal const byte DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA110 = 0x05;
        internal const byte DEVICETYPE_BLYNC_WIRELESS_CHIPSET_V30S = 0x06;
        internal const byte DEVICETYPE_BLYNC_MINI_CHIPSET_V30S = 0x07;
        internal const byte DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA120 = 0x08;

        private byte bySelectedMusic = 1;
        private byte bySelectedFlashSpeed = 1;
        private byte byVolumeLevel = 5;

        private string[] arrMusicListForBlyncUSB30S = { 
                                                          "Music 1", "Music 2", "Music 3", "Music 4", "Music 5", 
                                                          "Music 6", "Music 7", "Music 8", "Music 9", "Music 10"
                                                      };
        
        private string[] arrMusicListForBlyncMiniWireless = { 
                                                                "Music 1", "Music 2", "Music 3", "Music 4", "Music 5", 
                                                                "Music 6", "Music 7", "Music 8", "Music 9", "Music 10", 
                                                                "Music 11", "Music 12", "Music 13", "Music 14"
                                                            };
                                                            
        public Form1()
        {
            InitializeComponent();

            // Form_Closing event while exiting the application
            this.Closing += Form1_Closing;

            Byte bySelectedFlashSpeed = 0x04;
            Byte byLightControl = 0x00;
            
            byLightControl |= (Byte)((bySelectedFlashSpeed & 0x0F) << 3);

            DisableUIComponentsForBlyncUsb1020Devices();
            DisableUIComponentsForBlyncUsb30Devices();

            SearchAndListBlyncDevices();

            //comboBoxMusicList.SelectedIndex = 0;
            comboBoxFlashSpeedList.SelectedIndex = 0;
            Debug.Print("Hey");
            makuController.SetLightDim(nSelectedDeviceIndex);
            this.InfLoop();
            //Thread oThread = new Thread(new ThreadStart(this.InfLoop));
        }
        public void InfLoop()
        {
            Random rnd = new Random();
            int[] steps = { 0, 0, 0 };
            byte[] vals = { 120, 120, 120 };
            while (true)
            {
                for (int i = 0; i < 3; i++)
                {
                    steps[i] = steps[i] + 1;
                    vals[i] = (byte)(255 * Math.Pow((Math.Abs(Math.Sin(i+steps[i] * (i + 1) * Math.PI / 1800))), 2));
                    //vals[i] = (byte)((vals[i]+(byte)(rnd.Next(5)-2))%256);
                }
                makuController.TurnOnRGBLights(nSelectedDeviceIndex, vals[0], vals[1], vals[2]);
            }
            
        }
        private bool blankTicket = false;
        public bool BlankTicket
        {
            get
            {
                return this.blankTicket;
            }
            set
            {
                this.blankTicket = value;
                if (value)
                {
                    this.GoRed();
                }
                else
                {
                    this.GoGreen();
                }
            }
        }

        public void GoRed()
        {
            bool bResult = false;
            bResult = makuController.TurnOnRedLight(nSelectedDeviceIndex);
        }
        public void GoGreen()
        {
            makuController.TurnOnGreenLight(nSelectedDeviceIndex);
        }
        
        private void SearchAndListBlyncDevices()
        {
            // If there is already a list of devices, free the list of device and resources allocated
            comboBoxDeviceList.Items.Clear();

            // Look for the Blync devices connected to the System
            // the nNumberOfBlyncDevices will be equal to the number 
            // of Blync devices connected to the System USB Ports
            nNumberOfBlyncDevices = makuController.InitBlyncDevices();

            if (nNumberOfBlyncDevices > 0)
            {
                // Add the Blync devices detected to the combobox
                for (int i = 0; i < nNumberOfBlyncDevices; i++)
                {
                    comboBoxDeviceList.Items.Insert(i, makuController.aoDevInfo[i].szDeviceName);

                    if (makuController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_TENX_10 ||
                        makuController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_TENX_20)
                    {
                        EnableUIComponentsForBlyncUsb1020Devices();
                        DisableUIComponentsForBlyncUsb30Devices();
                    }
                    else if (makuController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30S ||
                        makuController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30 ||
                        makuController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA110 ||
                        makuController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA120 ||
                        makuController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_WIRELESS_CHIPSET_V30S ||
                        makuController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_MINI_CHIPSET_V30S)
                    {
                        EnableUIComponentsForBlyncUsb30Devices();
                        DisableUIComponentsForBlyncUsb1020Devices();
                    }
                }

                comboBoxDeviceList.SelectedIndex = 0;
                nSelectedDeviceIndex = 0;
            }
            else
            {
                MessageBox.Show("No Blync Devices Detected", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                // If device is not present disable all UI components
                DisableUIComponentsForBlyncUsb1020Devices();
                DisableUIComponentsForBlyncUsb30Devices();
            }
        }

        private void EnableUIComponentsForBlyncUsb1020Devices()
        {
            groupBoxOldDeviceControls.Enabled = true;
        }

        private void DisableUIComponentsForBlyncUsb1020Devices()
        {
            groupBoxOldDeviceControls.Enabled = false;
        }

        private void EnableUIComponentsForBlyncUsb30Devices()
        {
            if (makuController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30S ||
                makuController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_WIRELESS_CHIPSET_V30S ||
                makuController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_MINI_CHIPSET_V30S)
            {
                groupBoxLightControls.Enabled = true;
                groupBoxMusicControls.Enabled = true;
            }
            else if (makuController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30 ||
                makuController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA110 ||
                makuController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA120)
            {
                groupBoxLightControls.Enabled = true;
                groupBoxMusicControls.Enabled = false;
            }
        }

        private void DisableUIComponentsForBlyncUsb30Devices()
        {
            groupBoxLightControls.Enabled = false;
            groupBoxMusicControls.Enabled = false;
        } 

        private void comboBoxDeviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            nSelectedDeviceIndex = comboBoxDeviceList.SelectedIndex;

            if (nSelectedDeviceIndex >= 0)
            {
                if (makuController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_TENX_10 ||
                    makuController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_TENX_20)
                {
                    EnableUIComponentsForBlyncUsb1020Devices();
                    DisableUIComponentsForBlyncUsb30Devices();
                }
                else if (makuController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30S ||
                    makuController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30 ||
                    makuController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA110 ||
                    makuController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA120 ||
                    makuController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_MINI_CHIPSET_V30S ||
                    makuController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_WIRELESS_CHIPSET_V30S)
                {
                    EnableUIComponentsForBlyncUsb30Devices();
                    DisableUIComponentsForBlyncUsb1020Devices();

                    if (makuController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30S)
                    {
                        if (comboBoxMusicList.Items.Count > 0)
                        {
                            comboBoxMusicList.Items.Clear();                            
                        }

                        for (int j = 0; j < arrMusicListForBlyncUSB30S.Length; j++)
                        {
                            comboBoxMusicList.Items.Insert(j, arrMusicListForBlyncUSB30S[j]);
                        }

                        comboBoxMusicList.SelectedIndex = 0;
                    }
                    else if (makuController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_MINI_CHIPSET_V30S ||
                    makuController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_WIRELESS_CHIPSET_V30S)
                    {
                        if (comboBoxMusicList.Items.Count > 0)
                        {
                            comboBoxMusicList.Items.Clear();
                        }

                        for (int j = 0; j < arrMusicListForBlyncMiniWireless.Length; j++)
                        {
                            comboBoxMusicList.Items.Insert(j, arrMusicListForBlyncMiniWireless[j]);
                        }

                        comboBoxMusicList.SelectedIndex = 0;
                    }
                }
            }
        }

        private void buttonRed_Click(object sender, EventArgs e)
        {
            // Call TurnOnRedLight and pass the nSelectedDeviceIndex.
            // nSelectedDeviceIndex value will be updated on device selection in the Combo box

            bool bResult = false;
            bResult = makuController.TurnOnRedLight(nSelectedDeviceIndex);
        }

        private void buttonBlue_Click(object sender, EventArgs e)
        {
            makuController.TurnOnBlueLight(nSelectedDeviceIndex);
        }

        private void buttonMagenta_Click(object sender, EventArgs e)
        {
            makuController.TurnOnMagentaLight(nSelectedDeviceIndex);
        }

        private void buttonCyan_Click(object sender, EventArgs e)
        {
            makuController.TurnOnCyanLight(nSelectedDeviceIndex);
        }

        private void buttonGreen_Click(object sender, EventArgs e)
        {
            makuController.TurnOnGreenLight(nSelectedDeviceIndex);
        }

        private void buttonYellow_Click(object sender, EventArgs e)
        {
            makuController.TurnOnYellowLight(nSelectedDeviceIndex);
        }

        private void buttonWhite_Click(object sender, EventArgs e)
        {
            makuController.TurnOnWhiteLight(nSelectedDeviceIndex);
        }

        private void buttonResetEffects_Click(object sender, EventArgs e)
        {
            makuController.ResetLight(nSelectedDeviceIndex);
        }

        private void buttonUpdateDevList_Click(object sender, EventArgs e)
        {
            SearchAndListBlyncDevices();
        }

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            if (nNumberOfBlyncDevices > 0)
            {
                makuController.CloseDevices(nNumberOfBlyncDevices);
            }
        }

        private void checkBoxDisplayLight_CheckedChanged(object sender, EventArgs e)
        {
            bool bDisplayLight = checkBoxDisplayLight.Checked;
            bool bResult = false;

            // Select turn on or off light based on check box value
            if (bDisplayLight == true)
            {
                // Send the RGB color values
                SetRgbValues();
            }
            else
            {
                bResult = makuController.ResetLight(nSelectedDeviceIndex);
                if (bResult == false)
                {
                    MessageBox.Show("TurnOffLight failed", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void checkBoxPlayMusic_CheckedChanged(object sender, EventArgs e)
        {
            bool bPlayMusic = checkBoxPlayMusic.Checked;
            bool bResult = false;

            if (bPlayMusic == true)
            {
                bResult = makuController.StartMusicPlay(nSelectedDeviceIndex);
                if (bResult == false)
                {
                    MessageBox.Show("StartMusicPlay failed", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                bResult = makuController.StopMusicPlay(nSelectedDeviceIndex);
                if (bResult == false)
                {
                    MessageBox.Show("StopMusicPlay failed", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }

            bResult = makuController.SelectMusicToPlay(nSelectedDeviceIndex, bySelectedMusic);
            if (bResult == false)
            {
                MessageBox.Show("SelectMusicToPlay failed", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

            bResult = makuController.SetMusicVolume(nSelectedDeviceIndex, byVolumeLevel);
            if (bResult == false)
            {
                MessageBox.Show("SetMusicVolume failed", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void checkBoxDimLight_CheckedChanged(object sender, EventArgs e)
        {
            bool bDimLight = checkBoxDimLight.Checked;
            bool bResult = false;

            if (bDimLight == true)
            {
                bResult = makuController.SetLightDim(nSelectedDeviceIndex);
                if (bResult == false)
                {
                    MessageBox.Show("SetLightDim failed", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                bResult = makuController.ClearLightDim(nSelectedDeviceIndex);
                if (bResult == false)
                {
                    MessageBox.Show("ClearLightDim failed", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void buttonSetRgbValues_Click(object sender, EventArgs e)
        {
            SetRgbValues();
        }

        private void SetRgbValues()
        {
            Boolean bResult = false;

            Byte byRedLevel = 255;
            Byte byGreenLevel = 255;
            Byte byBlueLevel = 255;

            try
            {
                byRedLevel = Byte.Parse(textBoxRed.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease check Red color value. It should be a value from 0 to 255.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                return;
            }

            try
            {
                byGreenLevel = Byte.Parse(textBoxGreen.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease check Green color value. It should be a value from 0 to 255.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                return;
            }

            try
            {
                byBlueLevel = Byte.Parse(textBoxBlue.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease check Blue color value. It should be a value from 0 to 255.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                return;
            }

            bResult = makuController.TurnOnRGBLights(nSelectedDeviceIndex, byRedLevel, byGreenLevel, 
                byBlueLevel);

            if (!bResult)
            {
                MessageBox.Show("TurnOnRGBColors failed.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }           
        }
    }
}*/
