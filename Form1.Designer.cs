namespace BlyncLightTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonUpdateDevList = new System.Windows.Forms.Button();
            this.comboBoxDeviceList = new System.Windows.Forms.ComboBox();
            this.groupBoxOldDeviceControls = new System.Windows.Forms.GroupBox();
            this.buttonCyan = new System.Windows.Forms.Button();
            this.buttonRed = new System.Windows.Forms.Button();
            this.buttonGreen = new System.Windows.Forms.Button();
            this.buttonResetEffects = new System.Windows.Forms.Button();
            this.buttonYellow = new System.Windows.Forms.Button();
            this.buttonBlue = new System.Windows.Forms.Button();
            this.buttonMagenta = new System.Windows.Forms.Button();
            this.buttonWhite = new System.Windows.Forms.Button();
            this.groupBoxLightControls = new System.Windows.Forms.GroupBox();
            this.buttonSetRgbValues = new System.Windows.Forms.Button();
            this.comboBoxFlashSpeedList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxFlashLight = new System.Windows.Forms.CheckBox();
            this.checkBoxDimLight = new System.Windows.Forms.CheckBox();
            this.labelBlue = new System.Windows.Forms.Label();
            this.labelGreen = new System.Windows.Forms.Label();
            this.labelRed = new System.Windows.Forms.Label();
            this.textBoxBlue = new System.Windows.Forms.TextBox();
            this.vScrollBarBlue = new System.Windows.Forms.VScrollBar();
            this.textBoxGreen = new System.Windows.Forms.TextBox();
            this.vScrollBarGreen = new System.Windows.Forms.VScrollBar();
            this.checkBoxDisplayLight = new System.Windows.Forms.CheckBox();
            this.textBoxRed = new System.Windows.Forms.TextBox();
            this.vScrollBarRed = new System.Windows.Forms.VScrollBar();
            this.checkBoxRepeatMusic = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxMusicList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxPlayMusic = new System.Windows.Forms.CheckBox();
            this.groupBoxNewDeviceControls = new System.Windows.Forms.GroupBox();
            this.groupBoxMusicControls = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBoxOldDeviceControls.SuspendLayout();
            this.groupBoxLightControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBoxNewDeviceControls.SuspendLayout();
            this.groupBoxMusicControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonUpdateDevList);
            this.groupBox2.Controls.Add(this.comboBoxDeviceList);
            this.groupBox2.Location = new System.Drawing.Point(16, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(635, 59);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Device";
            // 
            // buttonUpdateDevList
            // 
            this.buttonUpdateDevList.Location = new System.Drawing.Point(507, 18);
            this.buttonUpdateDevList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonUpdateDevList.Name = "buttonUpdateDevList";
            this.buttonUpdateDevList.Size = new System.Drawing.Size(113, 28);
            this.buttonUpdateDevList.TabIndex = 1;
            this.buttonUpdateDevList.Text = "Update";
            this.buttonUpdateDevList.UseVisualStyleBackColor = true;
            this.buttonUpdateDevList.Click += new System.EventHandler(this.buttonUpdateDevList_Click);
            // 
            // comboBoxDeviceList
            // 
            this.comboBoxDeviceList.AllowDrop = true;
            this.comboBoxDeviceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDeviceList.FormattingEnabled = true;
            this.comboBoxDeviceList.Location = new System.Drawing.Point(8, 21);
            this.comboBoxDeviceList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxDeviceList.Name = "comboBoxDeviceList";
            this.comboBoxDeviceList.Size = new System.Drawing.Size(477, 24);
            this.comboBoxDeviceList.TabIndex = 0;
            this.comboBoxDeviceList.SelectedIndexChanged += new System.EventHandler(this.comboBoxDeviceList_SelectedIndexChanged);
            // 
            // groupBoxOldDeviceControls
            // 
            this.groupBoxOldDeviceControls.Controls.Add(this.buttonCyan);
            this.groupBoxOldDeviceControls.Controls.Add(this.buttonRed);
            this.groupBoxOldDeviceControls.Controls.Add(this.buttonGreen);
            this.groupBoxOldDeviceControls.Controls.Add(this.buttonResetEffects);
            this.groupBoxOldDeviceControls.Controls.Add(this.buttonYellow);
            this.groupBoxOldDeviceControls.Controls.Add(this.buttonBlue);
            this.groupBoxOldDeviceControls.Controls.Add(this.buttonMagenta);
            this.groupBoxOldDeviceControls.Controls.Add(this.buttonWhite);
            this.groupBoxOldDeviceControls.Location = new System.Drawing.Point(16, 81);
            this.groupBoxOldDeviceControls.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxOldDeviceControls.Name = "groupBoxOldDeviceControls";
            this.groupBoxOldDeviceControls.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxOldDeviceControls.Size = new System.Drawing.Size(200, 346);
            this.groupBoxOldDeviceControls.TabIndex = 20;
            this.groupBoxOldDeviceControls.TabStop = false;
            this.groupBoxOldDeviceControls.Text = "BlyncUSB10/20 Devices";
            // 
            // buttonCyan
            // 
            this.buttonCyan.Location = new System.Drawing.Point(8, 146);
            this.buttonCyan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCyan.Name = "buttonCyan";
            this.buttonCyan.Size = new System.Drawing.Size(183, 28);
            this.buttonCyan.TabIndex = 12;
            this.buttonCyan.Text = "Cyan";
            this.buttonCyan.UseVisualStyleBackColor = true;
            this.buttonCyan.Click += new System.EventHandler(this.buttonCyan_Click);
            // 
            // buttonRed
            // 
            this.buttonRed.Location = new System.Drawing.Point(8, 38);
            this.buttonRed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRed.Name = "buttonRed";
            this.buttonRed.Size = new System.Drawing.Size(183, 28);
            this.buttonRed.TabIndex = 0;
            this.buttonRed.Text = "Red";
            this.buttonRed.UseVisualStyleBackColor = true;
            this.buttonRed.Click += new System.EventHandler(this.buttonRed_Click);
            // 
            // buttonGreen
            // 
            this.buttonGreen.Location = new System.Drawing.Point(8, 182);
            this.buttonGreen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonGreen.Name = "buttonGreen";
            this.buttonGreen.Size = new System.Drawing.Size(183, 28);
            this.buttonGreen.TabIndex = 1;
            this.buttonGreen.Text = "Green";
            this.buttonGreen.UseVisualStyleBackColor = true;
            this.buttonGreen.Click += new System.EventHandler(this.buttonGreen_Click);
            // 
            // buttonResetEffects
            // 
            this.buttonResetEffects.Location = new System.Drawing.Point(8, 290);
            this.buttonResetEffects.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonResetEffects.Name = "buttonResetEffects";
            this.buttonResetEffects.Size = new System.Drawing.Size(183, 28);
            this.buttonResetEffects.TabIndex = 4;
            this.buttonResetEffects.Text = "Reset";
            this.buttonResetEffects.UseVisualStyleBackColor = true;
            this.buttonResetEffects.Click += new System.EventHandler(this.buttonResetEffects_Click);
            // 
            // buttonYellow
            // 
            this.buttonYellow.Location = new System.Drawing.Point(8, 219);
            this.buttonYellow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonYellow.Name = "buttonYellow";
            this.buttonYellow.Size = new System.Drawing.Size(183, 28);
            this.buttonYellow.TabIndex = 5;
            this.buttonYellow.Text = "Yellow";
            this.buttonYellow.UseVisualStyleBackColor = true;
            this.buttonYellow.Click += new System.EventHandler(this.buttonYellow_Click);
            // 
            // buttonBlue
            // 
            this.buttonBlue.Location = new System.Drawing.Point(8, 75);
            this.buttonBlue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonBlue.Name = "buttonBlue";
            this.buttonBlue.Size = new System.Drawing.Size(183, 28);
            this.buttonBlue.TabIndex = 6;
            this.buttonBlue.Text = "Blue";
            this.buttonBlue.UseVisualStyleBackColor = true;
            this.buttonBlue.Click += new System.EventHandler(this.buttonBlue_Click);
            // 
            // buttonMagenta
            // 
            this.buttonMagenta.Location = new System.Drawing.Point(8, 111);
            this.buttonMagenta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonMagenta.Name = "buttonMagenta";
            this.buttonMagenta.Size = new System.Drawing.Size(183, 28);
            this.buttonMagenta.TabIndex = 9;
            this.buttonMagenta.Text = "Magenta";
            this.buttonMagenta.UseVisualStyleBackColor = true;
            this.buttonMagenta.Click += new System.EventHandler(this.buttonMagenta_Click);
            // 
            // buttonWhite
            // 
            this.buttonWhite.Location = new System.Drawing.Point(8, 255);
            this.buttonWhite.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonWhite.Name = "buttonWhite";
            this.buttonWhite.Size = new System.Drawing.Size(183, 28);
            this.buttonWhite.TabIndex = 11;
            this.buttonWhite.Text = "White";
            this.buttonWhite.UseVisualStyleBackColor = true;
            this.buttonWhite.Click += new System.EventHandler(this.buttonWhite_Click);
            // 
            // groupBoxLightControls
            // 
            this.groupBoxLightControls.Controls.Add(this.buttonSetRgbValues);
            this.groupBoxLightControls.Controls.Add(this.comboBoxFlashSpeedList);
            this.groupBoxLightControls.Controls.Add(this.label2);
            this.groupBoxLightControls.Controls.Add(this.checkBoxFlashLight);
            this.groupBoxLightControls.Controls.Add(this.checkBoxDimLight);
            this.groupBoxLightControls.Controls.Add(this.labelBlue);
            this.groupBoxLightControls.Controls.Add(this.labelGreen);
            this.groupBoxLightControls.Controls.Add(this.labelRed);
            this.groupBoxLightControls.Controls.Add(this.textBoxBlue);
            this.groupBoxLightControls.Controls.Add(this.vScrollBarBlue);
            this.groupBoxLightControls.Controls.Add(this.textBoxGreen);
            this.groupBoxLightControls.Controls.Add(this.vScrollBarGreen);
            this.groupBoxLightControls.Controls.Add(this.checkBoxDisplayLight);
            this.groupBoxLightControls.Controls.Add(this.textBoxRed);
            this.groupBoxLightControls.Controls.Add(this.vScrollBarRed);
            this.groupBoxLightControls.Location = new System.Drawing.Point(12, 17);
            this.groupBoxLightControls.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxLightControls.Name = "groupBoxLightControls";
            this.groupBoxLightControls.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxLightControls.Size = new System.Drawing.Size(400, 169);
            this.groupBoxLightControls.TabIndex = 22;
            this.groupBoxLightControls.TabStop = false;
            // 
            // buttonSetRgbValues
            // 
            this.buttonSetRgbValues.Location = new System.Drawing.Point(287, 66);
            this.buttonSetRgbValues.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSetRgbValues.Name = "buttonSetRgbValues";
            this.buttonSetRgbValues.Size = new System.Drawing.Size(103, 28);
            this.buttonSetRgbValues.TabIndex = 32;
            this.buttonSetRgbValues.Text = "Set";
            this.buttonSetRgbValues.UseVisualStyleBackColor = true;
            this.buttonSetRgbValues.Click += new System.EventHandler(this.buttonSetRgbValues_Click);
            // 
            // comboBoxFlashSpeedList
            // 
            this.comboBoxFlashSpeedList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFlashSpeedList.FormattingEnabled = true;
            this.comboBoxFlashSpeedList.Items.AddRange(new object[] {
            "Slow",
            "Med",
            "Fast"});
            this.comboBoxFlashSpeedList.Location = new System.Drawing.Point(287, 128);
            this.comboBoxFlashSpeedList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxFlashSpeedList.Name = "comboBoxFlashSpeedList";
            this.comboBoxFlashSpeedList.Size = new System.Drawing.Size(101, 24);
            this.comboBoxFlashSpeedList.TabIndex = 28;
            this.comboBoxFlashSpeedList.SelectedIndexChanged += new System.EventHandler(this.comboBoxFlashSpeedList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 130);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "Speed";
            // 
            // checkBoxFlashLight
            // 
            this.checkBoxFlashLight.AutoSize = true;
            this.checkBoxFlashLight.Location = new System.Drawing.Point(105, 130);
            this.checkBoxFlashLight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxFlashLight.Name = "checkBoxFlashLight";
            this.checkBoxFlashLight.Size = new System.Drawing.Size(99, 21);
            this.checkBoxFlashLight.TabIndex = 23;
            this.checkBoxFlashLight.Text = "Flash Light";
            this.checkBoxFlashLight.UseVisualStyleBackColor = true;
            this.checkBoxFlashLight.CheckedChanged += new System.EventHandler(this.checkBoxFlashLight_CheckedChanged);
            // 
            // checkBoxDimLight
            // 
            this.checkBoxDimLight.AutoSize = true;
            this.checkBoxDimLight.Location = new System.Drawing.Point(11, 130);
            this.checkBoxDimLight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxDimLight.Name = "checkBoxDimLight";
            this.checkBoxDimLight.Size = new System.Drawing.Size(89, 21);
            this.checkBoxDimLight.TabIndex = 10;
            this.checkBoxDimLight.Text = "Dim Light";
            this.checkBoxDimLight.UseVisualStyleBackColor = true;
            this.checkBoxDimLight.CheckedChanged += new System.EventHandler(this.checkBoxDimLight_CheckedChanged);
            // 
            // labelBlue
            // 
            this.labelBlue.AutoSize = true;
            this.labelBlue.Location = new System.Drawing.Point(200, 47);
            this.labelBlue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBlue.Name = "labelBlue";
            this.labelBlue.Size = new System.Drawing.Size(36, 17);
            this.labelBlue.TabIndex = 9;
            this.labelBlue.Text = "Blue";
            // 
            // labelGreen
            // 
            this.labelGreen.AutoSize = true;
            this.labelGreen.Location = new System.Drawing.Point(101, 47);
            this.labelGreen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGreen.Name = "labelGreen";
            this.labelGreen.Size = new System.Drawing.Size(48, 17);
            this.labelGreen.TabIndex = 8;
            this.labelGreen.Text = "Green";
            // 
            // labelRed
            // 
            this.labelRed.AutoSize = true;
            this.labelRed.Location = new System.Drawing.Point(7, 47);
            this.labelRed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new System.Drawing.Size(34, 17);
            this.labelRed.TabIndex = 7;
            this.labelRed.Text = "Red";
            // 
            // textBoxBlue
            // 
            this.textBoxBlue.Location = new System.Drawing.Point(204, 68);
            this.textBoxBlue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxBlue.Name = "textBoxBlue";
            this.textBoxBlue.Size = new System.Drawing.Size(52, 22);
            this.textBoxBlue.TabIndex = 6;
            this.textBoxBlue.Text = "255";
            // 
            // vScrollBarBlue
            // 
            this.vScrollBarBlue.Location = new System.Drawing.Point(261, 64);
            this.vScrollBarBlue.Maximum = 264;
            this.vScrollBarBlue.Name = "vScrollBarBlue";
            this.vScrollBarBlue.Size = new System.Drawing.Size(17, 30);
            this.vScrollBarBlue.TabIndex = 5;
            this.vScrollBarBlue.Value = 255;
            this.vScrollBarBlue.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBarBlue_Scroll);
            // 
            // textBoxGreen
            // 
            this.textBoxGreen.Location = new System.Drawing.Point(105, 66);
            this.textBoxGreen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxGreen.Name = "textBoxGreen";
            this.textBoxGreen.Size = new System.Drawing.Size(52, 22);
            this.textBoxGreen.TabIndex = 4;
            this.textBoxGreen.Text = "255";
            // 
            // vScrollBarGreen
            // 
            this.vScrollBarGreen.Location = new System.Drawing.Point(163, 64);
            this.vScrollBarGreen.Maximum = 264;
            this.vScrollBarGreen.Name = "vScrollBarGreen";
            this.vScrollBarGreen.Size = new System.Drawing.Size(17, 30);
            this.vScrollBarGreen.TabIndex = 3;
            this.vScrollBarGreen.Value = 255;
            this.vScrollBarGreen.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBarGreen_Scroll);
            // 
            // checkBoxDisplayLight
            // 
            this.checkBoxDisplayLight.AutoSize = true;
            this.checkBoxDisplayLight.Location = new System.Drawing.Point(11, 17);
            this.checkBoxDisplayLight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxDisplayLight.Name = "checkBoxDisplayLight";
            this.checkBoxDisplayLight.Size = new System.Drawing.Size(111, 21);
            this.checkBoxDisplayLight.TabIndex = 2;
            this.checkBoxDisplayLight.Text = "Display Light";
            this.checkBoxDisplayLight.UseVisualStyleBackColor = true;
            this.checkBoxDisplayLight.CheckedChanged += new System.EventHandler(this.checkBoxDisplayLight_CheckedChanged);
            // 
            // textBoxRed
            // 
            this.textBoxRed.Location = new System.Drawing.Point(11, 66);
            this.textBoxRed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxRed.Name = "textBoxRed";
            this.textBoxRed.Size = new System.Drawing.Size(51, 22);
            this.textBoxRed.TabIndex = 1;
            this.textBoxRed.Text = "255";
            // 
            // vScrollBarRed
            // 
            this.vScrollBarRed.Location = new System.Drawing.Point(64, 63);
            this.vScrollBarRed.Maximum = 264;
            this.vScrollBarRed.Name = "vScrollBarRed";
            this.vScrollBarRed.Size = new System.Drawing.Size(17, 30);
            this.vScrollBarRed.TabIndex = 0;
            this.vScrollBarRed.Value = 255;
            this.vScrollBarRed.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBarRed_Scroll);
            // 
            // checkBoxRepeatMusic
            // 
            this.checkBoxRepeatMusic.AutoSize = true;
            this.checkBoxRepeatMusic.Location = new System.Drawing.Point(11, 114);
            this.checkBoxRepeatMusic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxRepeatMusic.Name = "checkBoxRepeatMusic";
            this.checkBoxRepeatMusic.Size = new System.Drawing.Size(116, 21);
            this.checkBoxRepeatMusic.TabIndex = 31;
            this.checkBoxRepeatMusic.Text = "Repeat Music";
            this.checkBoxRepeatMusic.UseVisualStyleBackColor = true;
            this.checkBoxRepeatMusic.CheckedChanged += new System.EventHandler(this.checkBoxRepeatMusic_CheckedChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 3;
            this.trackBar1.Location = new System.Drawing.Point(215, 69);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(175, 56);
            this.trackBar1.TabIndex = 30;
            this.trackBar1.Value = 5;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 29;
            this.label3.Text = "Volume";
            // 
            // comboBoxMusicList
            // 
            this.comboBoxMusicList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMusicList.FormattingEnabled = true;
            this.comboBoxMusicList.Location = new System.Drawing.Point(11, 69);
            this.comboBoxMusicList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxMusicList.Name = "comboBoxMusicList";
            this.comboBoxMusicList.Size = new System.Drawing.Size(173, 24);
            this.comboBoxMusicList.TabIndex = 27;
            this.comboBoxMusicList.SelectedIndexChanged += new System.EventHandler(this.comboBoxMusicList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Music";
            // 
            // checkBoxPlayMusic
            // 
            this.checkBoxPlayMusic.AutoSize = true;
            this.checkBoxPlayMusic.Location = new System.Drawing.Point(11, 17);
            this.checkBoxPlayMusic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxPlayMusic.Name = "checkBoxPlayMusic";
            this.checkBoxPlayMusic.Size = new System.Drawing.Size(97, 21);
            this.checkBoxPlayMusic.TabIndex = 24;
            this.checkBoxPlayMusic.Text = "Play Music";
            this.checkBoxPlayMusic.UseVisualStyleBackColor = true;
            this.checkBoxPlayMusic.CheckedChanged += new System.EventHandler(this.checkBoxPlayMusic_CheckedChanged);
            // 
            // groupBoxNewDeviceControls
            // 
            this.groupBoxNewDeviceControls.Controls.Add(this.groupBoxMusicControls);
            this.groupBoxNewDeviceControls.Controls.Add(this.groupBoxLightControls);
            this.groupBoxNewDeviceControls.Location = new System.Drawing.Point(224, 81);
            this.groupBoxNewDeviceControls.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxNewDeviceControls.Name = "groupBoxNewDeviceControls";
            this.groupBoxNewDeviceControls.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxNewDeviceControls.Size = new System.Drawing.Size(427, 346);
            this.groupBoxNewDeviceControls.TabIndex = 32;
            this.groupBoxNewDeviceControls.TabStop = false;
            this.groupBoxNewDeviceControls.Text = "BlyncUSB30/30S/Mini/Headset Devices";
            // 
            // groupBoxMusicControls
            // 
            this.groupBoxMusicControls.Controls.Add(this.checkBoxPlayMusic);
            this.groupBoxMusicControls.Controls.Add(this.checkBoxRepeatMusic);
            this.groupBoxMusicControls.Controls.Add(this.trackBar1);
            this.groupBoxMusicControls.Controls.Add(this.comboBoxMusicList);
            this.groupBoxMusicControls.Controls.Add(this.label1);
            this.groupBoxMusicControls.Controls.Add(this.label3);
            this.groupBoxMusicControls.Location = new System.Drawing.Point(12, 187);
            this.groupBoxMusicControls.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxMusicControls.Name = "groupBoxMusicControls";
            this.groupBoxMusicControls.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxMusicControls.Size = new System.Drawing.Size(400, 145);
            this.groupBoxMusicControls.TabIndex = 33;
            this.groupBoxMusicControls.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 438);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxOldDeviceControls);
            this.Controls.Add(this.groupBoxNewDeviceControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Blync Light Test Software";
            this.groupBox2.ResumeLayout(false);
            this.groupBoxOldDeviceControls.ResumeLayout(false);
            this.groupBoxLightControls.ResumeLayout(false);
            this.groupBoxLightControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBoxNewDeviceControls.ResumeLayout(false);
            this.groupBoxMusicControls.ResumeLayout(false);
            this.groupBoxMusicControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonUpdateDevList;
        private System.Windows.Forms.ComboBox comboBoxDeviceList;
        private System.Windows.Forms.GroupBox groupBoxOldDeviceControls;
        private System.Windows.Forms.Button buttonCyan;
        private System.Windows.Forms.Button buttonRed;
        private System.Windows.Forms.Button buttonGreen;
        private System.Windows.Forms.Button buttonResetEffects;
        private System.Windows.Forms.Button buttonYellow;
        private System.Windows.Forms.Button buttonBlue;
        private System.Windows.Forms.Button buttonMagenta;
        private System.Windows.Forms.Button buttonWhite;
        private System.Windows.Forms.GroupBox groupBoxLightControls;
        private System.Windows.Forms.VScrollBar vScrollBarRed;
        private System.Windows.Forms.TextBox textBoxRed;
        private System.Windows.Forms.CheckBox checkBoxDisplayLight;
        private System.Windows.Forms.TextBox textBoxBlue;
        private System.Windows.Forms.VScrollBar vScrollBarBlue;
        private System.Windows.Forms.TextBox textBoxGreen;
        private System.Windows.Forms.VScrollBar vScrollBarGreen;
        private System.Windows.Forms.Label labelGreen;
        private System.Windows.Forms.Label labelRed;
        private System.Windows.Forms.Label labelBlue;
        private System.Windows.Forms.CheckBox checkBoxFlashLight;
        private System.Windows.Forms.CheckBox checkBoxDimLight;
        private System.Windows.Forms.CheckBox checkBoxPlayMusic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxMusicList;
        private System.Windows.Forms.ComboBox comboBoxFlashSpeedList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.CheckBox checkBoxRepeatMusic;
        private System.Windows.Forms.Button buttonSetRgbValues;
        private System.Windows.Forms.GroupBox groupBoxNewDeviceControls;
        private System.Windows.Forms.GroupBox groupBoxMusicControls;
    }
}

