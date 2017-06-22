﻿using System;
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
    public partial class Form1 : Form
    {
        // Create object for the base class BlynclightController
        private BlynclightController oBlynclightController = new BlynclightController();

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
            Debug.Print("YO");
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
            oBlynclightController.SetLightDim(nSelectedDeviceIndex);
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
                oBlynclightController.TurnOnRGBLights(nSelectedDeviceIndex, vals[0], vals[1], vals[2]);
            }

            /*while (true)
            {
                Debug.Print(""+this.BlankTicket);
                this.BlankTicket = !this.BlankTicket;
            }*/
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
            bResult = oBlynclightController.TurnOnRedLight(nSelectedDeviceIndex);
        }
        public void GoGreen()
        {
            oBlynclightController.TurnOnGreenLight(nSelectedDeviceIndex);
        }
        
        private void SearchAndListBlyncDevices()
        {
            // If there is already a list of devices, free the list of device and resources allocated
            comboBoxDeviceList.Items.Clear();

            // Look for the Blync devices connected to the System
            // the nNumberOfBlyncDevices will be equal to the number 
            // of Blync devices connected to the System USB Ports
            nNumberOfBlyncDevices = oBlynclightController.InitBlyncDevices();

            if (nNumberOfBlyncDevices > 0)
            {
                // Add the Blync devices detected to the combobox
                for (int i = 0; i < nNumberOfBlyncDevices; i++)
                {
                    comboBoxDeviceList.Items.Insert(i, oBlynclightController.aoDevInfo[i].szDeviceName);

                    if (oBlynclightController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_TENX_10 ||
                        oBlynclightController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_TENX_20)
                    {
                        EnableUIComponentsForBlyncUsb1020Devices();
                        DisableUIComponentsForBlyncUsb30Devices();
                    }
                    else if (oBlynclightController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30S ||
                        oBlynclightController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30 ||
                        oBlynclightController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA110 ||
                        oBlynclightController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA120 ||
                        oBlynclightController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_WIRELESS_CHIPSET_V30S ||
                        oBlynclightController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_MINI_CHIPSET_V30S)
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
            if (oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30S ||
                oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_WIRELESS_CHIPSET_V30S ||
                oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_MINI_CHIPSET_V30S)
            {
                groupBoxLightControls.Enabled = true;
                groupBoxMusicControls.Enabled = true;
            }
            else if (oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30 ||
                oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA110 ||
                oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA120)
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
                if (oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_TENX_10 ||
                    oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_TENX_20)
                {
                    EnableUIComponentsForBlyncUsb1020Devices();
                    DisableUIComponentsForBlyncUsb30Devices();
                }
                else if (oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30S ||
                    oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30 ||
                    oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA110 ||
                    oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA120 ||
                    oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_MINI_CHIPSET_V30S ||
                    oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_WIRELESS_CHIPSET_V30S)
                {
                    EnableUIComponentsForBlyncUsb30Devices();
                    DisableUIComponentsForBlyncUsb1020Devices();

                    if (oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30S)
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
                    else if (oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_MINI_CHIPSET_V30S ||
                    oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_WIRELESS_CHIPSET_V30S)
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
            bResult = oBlynclightController.TurnOnRedLight(nSelectedDeviceIndex);
        }

        private void buttonBlue_Click(object sender, EventArgs e)
        {
            oBlynclightController.TurnOnBlueLight(nSelectedDeviceIndex);
        }

        private void buttonMagenta_Click(object sender, EventArgs e)
        {
            oBlynclightController.TurnOnMagentaLight(nSelectedDeviceIndex);
        }

        private void buttonCyan_Click(object sender, EventArgs e)
        {
            oBlynclightController.TurnOnCyanLight(nSelectedDeviceIndex);
        }

        private void buttonGreen_Click(object sender, EventArgs e)
        {
            oBlynclightController.TurnOnGreenLight(nSelectedDeviceIndex);
        }

        private void buttonYellow_Click(object sender, EventArgs e)
        {
            oBlynclightController.TurnOnYellowLight(nSelectedDeviceIndex);
        }

        private void buttonWhite_Click(object sender, EventArgs e)
        {
            oBlynclightController.TurnOnWhiteLight(nSelectedDeviceIndex);
        }

        private void buttonResetEffects_Click(object sender, EventArgs e)
        {
            oBlynclightController.ResetLight(nSelectedDeviceIndex);
        }

        private void buttonUpdateDevList_Click(object sender, EventArgs e)
        {
            SearchAndListBlyncDevices();
        }

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            if (nNumberOfBlyncDevices > 0)
            {
                oBlynclightController.CloseDevices(nNumberOfBlyncDevices);
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
                bResult = oBlynclightController.ResetLight(nSelectedDeviceIndex);
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
                bResult = oBlynclightController.StartMusicPlay(nSelectedDeviceIndex);
                if (bResult == false)
                {
                    MessageBox.Show("StartMusicPlay failed", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                bResult = oBlynclightController.StopMusicPlay(nSelectedDeviceIndex);
                if (bResult == false)
                {
                    MessageBox.Show("StopMusicPlay failed", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }

            bResult = oBlynclightController.SelectMusicToPlay(nSelectedDeviceIndex, bySelectedMusic);
            if (bResult == false)
            {
                MessageBox.Show("SelectMusicToPlay failed", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

            bResult = oBlynclightController.SetMusicVolume(nSelectedDeviceIndex, byVolumeLevel);
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
                bResult = oBlynclightController.SetLightDim(nSelectedDeviceIndex);
                if (bResult == false)
                {
                    MessageBox.Show("SetLightDim failed", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                bResult = oBlynclightController.ClearLightDim(nSelectedDeviceIndex);
                if (bResult == false)
                {
                    MessageBox.Show("ClearLightDim failed", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void checkBoxFlashLight_CheckedChanged(object sender, EventArgs e)
        {
            bool bFlashLight = checkBoxFlashLight.Checked;
            bool bResult = false;

            if (bFlashLight == true)
            {
                bResult = oBlynclightController.StartLightFlash(nSelectedDeviceIndex);
                if (bResult == false)
                {
                    MessageBox.Show("StartLightFlash failed", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                bResult = oBlynclightController.StopLightFlash(nSelectedDeviceIndex);
                if (bResult == false)
                {
                    MessageBox.Show("StopLightFlash failed", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }

            // Select light flash speed
            bResult = oBlynclightController.SelectLightFlashSpeed(nSelectedDeviceIndex, bySelectedFlashSpeed);
            if (bResult == false)
            {
                MessageBox.Show("SelectLightFlashSpeed failed", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void checkBoxRepeatMusic_CheckedChanged(object sender, EventArgs e)
        {
            bool bRepeatMusic = checkBoxRepeatMusic.Checked;
            bool bResult = false;

            if (bRepeatMusic == true)
            {

                bResult = oBlynclightController.SetMusicRepeat(nSelectedDeviceIndex);
                if (bResult == false)
                {
                    MessageBox.Show("SetMusicRepeat failed", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                bResult = oBlynclightController.ClearMusicRepeat(nSelectedDeviceIndex);
                if (bResult == false)
                {
                    MessageBox.Show("ClearMusicRepeat failed", "Information",
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

            bResult = oBlynclightController.TurnOnRGBLights(nSelectedDeviceIndex, byRedLevel, byGreenLevel, 
                byBlueLevel);

            if (!bResult)
            {
                MessageBox.Show("TurnOnRGBColors failed.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }           
        }

        private void comboBoxMusicList_SelectedIndexChanged(object sender, EventArgs e)
        {
            bySelectedMusic = (Byte)(comboBoxMusicList.SelectedIndex + 1);

            if (oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30S ||
                oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_WIRELESS_CHIPSET_V30S ||
                oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_MINI_CHIPSET_V30S)
            {
                bool bResult = oBlynclightController.SelectMusicToPlay(nSelectedDeviceIndex, bySelectedMusic);
                if (bResult == false)
                {
                    MessageBox.Show("SelectMusicToPlay failed", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }

            /*if (comboBoxMusicList.Enabled == false)
            {
                return;
            }

            bool bResult = oBlynclightController.SelectMusicToPlay(nSelectedDeviceIndex, bySelectedMusic);
            if (bResult == false)
            {
                MessageBox.Show("SelectMusicToPlay failed", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }*/
        }

        private void comboBoxFlashSpeedList_SelectedIndexChanged(object sender, EventArgs e)
        {
            bySelectedFlashSpeed = (Byte)(comboBoxFlashSpeedList.SelectedIndex + 1);

            if (oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30S ||
                oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30 ||
                oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA110 ||
                oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA120 || 
                oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_MINI_CHIPSET_V30S ||
                oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_WIRELESS_CHIPSET_V30S)
            {
                // Select light flash speed
                bool bResult = oBlynclightController.SelectLightFlashSpeed(nSelectedDeviceIndex, bySelectedFlashSpeed);
                if (bResult == false)
                {
                    MessageBox.Show("SelectLightFlashSpeed failed", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            byVolumeLevel = (Byte)trackBar1.Value;
            bool bResult = false;

            bResult = oBlynclightController.SetMusicVolume(nSelectedDeviceIndex, byVolumeLevel);
            if (bResult == false)
            {
                MessageBox.Show("SetMusicVolume failed", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

        }

        private void vScrollBarRed_Scroll(object sender, ScrollEventArgs e)
        {
            textBoxRed.Text = vScrollBarRed.Value.ToString();
        }

        private void vScrollBarGreen_Scroll(object sender, ScrollEventArgs e)
        {
            textBoxGreen.Text = vScrollBarGreen.Value.ToString();
        }

        private void vScrollBarBlue_Scroll(object sender, ScrollEventArgs e)
        {
            textBoxBlue.Text = vScrollBarBlue.Value.ToString();
        }
    }
}