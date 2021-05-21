namespace MarineTovar_Assign3
{
    partial class WOCForm
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
            this.queryListBox = new System.Windows.Forms.ListBox();
            this.queryLabel = new System.Windows.Forms.Label();
            this.classTypeLabel = new System.Windows.Forms.Label();
            this.classTypeClassComboBox = new System.Windows.Forms.ComboBox();
            this.classTypeClassLabel = new System.Windows.Forms.Label();
            this.classTypeServerLabel = new System.Windows.Forms.Label();
            this.classTypeServerComboBox = new System.Windows.Forms.ComboBox();
            this.percentRaceLabel = new System.Windows.Forms.Label();
            this.percentRaceServerComboBox = new System.Windows.Forms.ComboBox();
            this.percentRaceServerLabel = new System.Windows.Forms.Label();
            this.classTypeButton = new System.Windows.Forms.Button();
            this.percentRaceButton = new System.Windows.Forms.Button();
            this.roleTypeButton = new System.Windows.Forms.Button();
            this.roleTypeServerComboBox = new System.Windows.Forms.ComboBox();
            this.roleTypeServerLabel = new System.Windows.Forms.Label();
            this.roleTypeRollLabel = new System.Windows.Forms.Label();
            this.roleTypeRoleComboBox = new System.Windows.Forms.ComboBox();
            this.roleTypeLabel = new System.Windows.Forms.Label();
            this.roleTypeMinLabel = new System.Windows.Forms.Label();
            this.roleTypeMinNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.roleTypeMaxNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.roleTypeMaxLabel = new System.Windows.Forms.Label();
            this.guildTypeButton = new System.Windows.Forms.Button();
            this.guildTypeComboBox = new System.Windows.Forms.ComboBox();
            this.guildTypeLabel = new System.Windows.Forms.Label();
            this.guildLabel = new System.Windows.Forms.Label();
            this.playerFillButon = new System.Windows.Forms.Button();
            this.playerFillLabel = new System.Windows.Forms.Label();
            this.playerFIllTankRadioButton = new System.Windows.Forms.RadioButton();
            this.playerFillHealerRadioButton = new System.Windows.Forms.RadioButton();
            this.playerFIllDamageRadioButton = new System.Windows.Forms.RadioButton();
            this.playerFillGroupBox = new System.Windows.Forms.GroupBox();
            this.percentLevelButton = new System.Windows.Forms.Button();
            this.percentLevelLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.roleTypeMinNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleTypeMaxNumericUpDown)).BeginInit();
            this.playerFillGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // queryListBox
            // 
            this.queryListBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.queryListBox.FormattingEnabled = true;
            this.queryListBox.ItemHeight = 17;
            this.queryListBox.Location = new System.Drawing.Point(637, 57);
            this.queryListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.queryListBox.Name = "queryListBox";
            this.queryListBox.Size = new System.Drawing.Size(863, 599);
            this.queryListBox.TabIndex = 0;
            // 
            // queryLabel
            // 
            this.queryLabel.AutoSize = true;
            this.queryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.queryLabel.ForeColor = System.Drawing.Color.White;
            this.queryLabel.Location = new System.Drawing.Point(631, 9);
            this.queryLabel.Name = "queryLabel";
            this.queryLabel.Size = new System.Drawing.Size(97, 32);
            this.queryLabel.TabIndex = 1;
            this.queryLabel.Text = "Query";
            // 
            // classTypeLabel
            // 
            this.classTypeLabel.AutoSize = true;
            this.classTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classTypeLabel.ForeColor = System.Drawing.Color.White;
            this.classTypeLabel.Location = new System.Drawing.Point(12, 57);
            this.classTypeLabel.Name = "classTypeLabel";
            this.classTypeLabel.Size = new System.Drawing.Size(356, 25);
            this.classTypeLabel.TabIndex = 2;
            this.classTypeLabel.Text = "All Class Type from a Single Server";
            // 
            // classTypeClassComboBox
            // 
            this.classTypeClassComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classTypeClassComboBox.FormattingEnabled = true;
            this.classTypeClassComboBox.Location = new System.Drawing.Point(17, 110);
            this.classTypeClassComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.classTypeClassComboBox.Name = "classTypeClassComboBox";
            this.classTypeClassComboBox.Size = new System.Drawing.Size(145, 28);
            this.classTypeClassComboBox.TabIndex = 3;
            this.classTypeClassComboBox.DropDown += new System.EventHandler(this.classTypeClassComboBox_DropDown);
            // 
            // classTypeClassLabel
            // 
            this.classTypeClassLabel.AutoSize = true;
            this.classTypeClassLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classTypeClassLabel.ForeColor = System.Drawing.Color.White;
            this.classTypeClassLabel.Location = new System.Drawing.Point(21, 81);
            this.classTypeClassLabel.Name = "classTypeClassLabel";
            this.classTypeClassLabel.Size = new System.Drawing.Size(62, 25);
            this.classTypeClassLabel.TabIndex = 4;
            this.classTypeClassLabel.Text = "Class";
            // 
            // classTypeServerLabel
            // 
            this.classTypeServerLabel.AutoSize = true;
            this.classTypeServerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classTypeServerLabel.ForeColor = System.Drawing.Color.White;
            this.classTypeServerLabel.Location = new System.Drawing.Point(183, 81);
            this.classTypeServerLabel.Name = "classTypeServerLabel";
            this.classTypeServerLabel.Size = new System.Drawing.Size(70, 25);
            this.classTypeServerLabel.TabIndex = 5;
            this.classTypeServerLabel.Text = "Server";
            // 
            // classTypeServerComboBox
            // 
            this.classTypeServerComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classTypeServerComboBox.FormattingEnabled = true;
            this.classTypeServerComboBox.Location = new System.Drawing.Point(179, 110);
            this.classTypeServerComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.classTypeServerComboBox.Name = "classTypeServerComboBox";
            this.classTypeServerComboBox.Size = new System.Drawing.Size(145, 28);
            this.classTypeServerComboBox.TabIndex = 6;
            this.classTypeServerComboBox.DropDown += new System.EventHandler(this.classTypeServerComboBox_DropDown);
            // 
            // percentRaceLabel
            // 
            this.percentRaceLabel.AutoSize = true;
            this.percentRaceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentRaceLabel.ForeColor = System.Drawing.Color.White;
            this.percentRaceLabel.Location = new System.Drawing.Point(12, 151);
            this.percentRaceLabel.Name = "percentRaceLabel";
            this.percentRaceLabel.Size = new System.Drawing.Size(459, 25);
            this.percentRaceLabel.TabIndex = 7;
            this.percentRaceLabel.Text = "Percentage of Each Race from a Single Server";
            // 
            // percentRaceServerComboBox
            // 
            this.percentRaceServerComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentRaceServerComboBox.FormattingEnabled = true;
            this.percentRaceServerComboBox.Location = new System.Drawing.Point(179, 204);
            this.percentRaceServerComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.percentRaceServerComboBox.Name = "percentRaceServerComboBox";
            this.percentRaceServerComboBox.Size = new System.Drawing.Size(145, 28);
            this.percentRaceServerComboBox.TabIndex = 9;
            this.percentRaceServerComboBox.DropDown += new System.EventHandler(this.percentRaceServerComboBox_DropDown);
            // 
            // percentRaceServerLabel
            // 
            this.percentRaceServerLabel.AutoSize = true;
            this.percentRaceServerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentRaceServerLabel.ForeColor = System.Drawing.Color.White;
            this.percentRaceServerLabel.Location = new System.Drawing.Point(183, 176);
            this.percentRaceServerLabel.Name = "percentRaceServerLabel";
            this.percentRaceServerLabel.Size = new System.Drawing.Size(70, 25);
            this.percentRaceServerLabel.TabIndex = 8;
            this.percentRaceServerLabel.Text = "Server";
            // 
            // classTypeButton
            // 
            this.classTypeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classTypeButton.Location = new System.Drawing.Point(445, 105);
            this.classTypeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.classTypeButton.Name = "classTypeButton";
            this.classTypeButton.Size = new System.Drawing.Size(155, 30);
            this.classTypeButton.TabIndex = 10;
            this.classTypeButton.Text = "Show Results";
            this.classTypeButton.UseVisualStyleBackColor = true;
            this.classTypeButton.Click += new System.EventHandler(this.classTypeButton_Click);
            // 
            // percentRaceButton
            // 
            this.percentRaceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentRaceButton.Location = new System.Drawing.Point(445, 199);
            this.percentRaceButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.percentRaceButton.Name = "percentRaceButton";
            this.percentRaceButton.Size = new System.Drawing.Size(155, 30);
            this.percentRaceButton.TabIndex = 11;
            this.percentRaceButton.Text = "Show Results";
            this.percentRaceButton.UseVisualStyleBackColor = true;
            this.percentRaceButton.Click += new System.EventHandler(this.percentRaceButton_Click);
            // 
            // roleTypeButton
            // 
            this.roleTypeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roleTypeButton.Location = new System.Drawing.Point(445, 289);
            this.roleTypeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.roleTypeButton.Name = "roleTypeButton";
            this.roleTypeButton.Size = new System.Drawing.Size(155, 30);
            this.roleTypeButton.TabIndex = 17;
            this.roleTypeButton.Text = "Show Results";
            this.roleTypeButton.UseVisualStyleBackColor = true;
            this.roleTypeButton.Click += new System.EventHandler(this.roleTypeButton_Click);
            // 
            // roleTypeServerComboBox
            // 
            this.roleTypeServerComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roleTypeServerComboBox.FormattingEnabled = true;
            this.roleTypeServerComboBox.Location = new System.Drawing.Point(179, 293);
            this.roleTypeServerComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.roleTypeServerComboBox.Name = "roleTypeServerComboBox";
            this.roleTypeServerComboBox.Size = new System.Drawing.Size(145, 28);
            this.roleTypeServerComboBox.TabIndex = 16;
            this.roleTypeServerComboBox.DropDown += new System.EventHandler(this.roleTypeServerComboBox_DropDown);
            // 
            // roleTypeServerLabel
            // 
            this.roleTypeServerLabel.AutoSize = true;
            this.roleTypeServerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roleTypeServerLabel.ForeColor = System.Drawing.Color.White;
            this.roleTypeServerLabel.Location = new System.Drawing.Point(183, 265);
            this.roleTypeServerLabel.Name = "roleTypeServerLabel";
            this.roleTypeServerLabel.Size = new System.Drawing.Size(70, 25);
            this.roleTypeServerLabel.TabIndex = 15;
            this.roleTypeServerLabel.Text = "Server";
            // 
            // roleTypeRollLabel
            // 
            this.roleTypeRollLabel.AutoSize = true;
            this.roleTypeRollLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roleTypeRollLabel.ForeColor = System.Drawing.Color.White;
            this.roleTypeRollLabel.Location = new System.Drawing.Point(21, 265);
            this.roleTypeRollLabel.Name = "roleTypeRollLabel";
            this.roleTypeRollLabel.Size = new System.Drawing.Size(51, 25);
            this.roleTypeRollLabel.TabIndex = 14;
            this.roleTypeRollLabel.Text = "Role";
            // 
            // roleTypeRoleComboBox
            // 
            this.roleTypeRoleComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roleTypeRoleComboBox.FormattingEnabled = true;
            this.roleTypeRoleComboBox.Location = new System.Drawing.Point(17, 293);
            this.roleTypeRoleComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.roleTypeRoleComboBox.Name = "roleTypeRoleComboBox";
            this.roleTypeRoleComboBox.Size = new System.Drawing.Size(145, 28);
            this.roleTypeRoleComboBox.TabIndex = 13;
            this.roleTypeRoleComboBox.DropDown += new System.EventHandler(this.roleTypeRoleComboBox_DropDown);
            // 
            // roleTypeLabel
            // 
            this.roleTypeLabel.AutoSize = true;
            this.roleTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roleTypeLabel.ForeColor = System.Drawing.Color.White;
            this.roleTypeLabel.Location = new System.Drawing.Point(12, 240);
            this.roleTypeLabel.Name = "roleTypeLabel";
            this.roleTypeLabel.Size = new System.Drawing.Size(566, 25);
            this.roleTypeLabel.TabIndex = 12;
            this.roleTypeLabel.Text = "All Role Types from a Single Server Within a Level Range";
            // 
            // roleTypeMinLabel
            // 
            this.roleTypeMinLabel.AutoSize = true;
            this.roleTypeMinLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roleTypeMinLabel.ForeColor = System.Drawing.Color.White;
            this.roleTypeMinLabel.Location = new System.Drawing.Point(19, 331);
            this.roleTypeMinLabel.Name = "roleTypeMinLabel";
            this.roleTypeMinLabel.Size = new System.Drawing.Size(44, 25);
            this.roleTypeMinLabel.TabIndex = 18;
            this.roleTypeMinLabel.Text = "Min";
            // 
            // roleTypeMinNumericUpDown
            // 
            this.roleTypeMinNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roleTypeMinNumericUpDown.Location = new System.Drawing.Point(17, 359);
            this.roleTypeMinNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.roleTypeMinNumericUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.roleTypeMinNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.roleTypeMinNumericUpDown.Name = "roleTypeMinNumericUpDown";
            this.roleTypeMinNumericUpDown.Size = new System.Drawing.Size(48, 27);
            this.roleTypeMinNumericUpDown.TabIndex = 19;
            this.roleTypeMinNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.roleTypeMinNumericUpDown.ValueChanged += new System.EventHandler(this.roleTypeMinNumericUpDown_ValueChanged);
            // 
            // roleTypeMaxNumericUpDown
            // 
            this.roleTypeMaxNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roleTypeMaxNumericUpDown.Location = new System.Drawing.Point(97, 359);
            this.roleTypeMaxNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.roleTypeMaxNumericUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.roleTypeMaxNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.roleTypeMaxNumericUpDown.Name = "roleTypeMaxNumericUpDown";
            this.roleTypeMaxNumericUpDown.Size = new System.Drawing.Size(48, 27);
            this.roleTypeMaxNumericUpDown.TabIndex = 21;
            this.roleTypeMaxNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.roleTypeMaxNumericUpDown.ValueChanged += new System.EventHandler(this.roleTypeMaxNumericUpDown_ValueChanged);
            // 
            // roleTypeMaxLabel
            // 
            this.roleTypeMaxLabel.AutoSize = true;
            this.roleTypeMaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roleTypeMaxLabel.ForeColor = System.Drawing.Color.White;
            this.roleTypeMaxLabel.Location = new System.Drawing.Point(92, 331);
            this.roleTypeMaxLabel.Name = "roleTypeMaxLabel";
            this.roleTypeMaxLabel.Size = new System.Drawing.Size(50, 25);
            this.roleTypeMaxLabel.TabIndex = 20;
            this.roleTypeMaxLabel.Text = "Max";
            // 
            // guildTypeButton
            // 
            this.guildTypeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guildTypeButton.Location = new System.Drawing.Point(445, 453);
            this.guildTypeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guildTypeButton.Name = "guildTypeButton";
            this.guildTypeButton.Size = new System.Drawing.Size(155, 30);
            this.guildTypeButton.TabIndex = 25;
            this.guildTypeButton.Text = "Show Results";
            this.guildTypeButton.UseVisualStyleBackColor = true;
            this.guildTypeButton.Click += new System.EventHandler(this.guildTypeButton_Click);
            // 
            // guildTypeComboBox
            // 
            this.guildTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guildTypeComboBox.FormattingEnabled = true;
            this.guildTypeComboBox.Location = new System.Drawing.Point(17, 454);
            this.guildTypeComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guildTypeComboBox.Name = "guildTypeComboBox";
            this.guildTypeComboBox.Size = new System.Drawing.Size(145, 28);
            this.guildTypeComboBox.TabIndex = 24;
            this.guildTypeComboBox.DropDown += new System.EventHandler(this.guildTypeComboBox_DropDown);
            // 
            // guildTypeLabel
            // 
            this.guildTypeLabel.AutoSize = true;
            this.guildTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guildTypeLabel.ForeColor = System.Drawing.Color.White;
            this.guildTypeLabel.Location = new System.Drawing.Point(21, 426);
            this.guildTypeLabel.Name = "guildTypeLabel";
            this.guildTypeLabel.Size = new System.Drawing.Size(57, 25);
            this.guildTypeLabel.TabIndex = 23;
            this.guildTypeLabel.Text = "Type";
            // 
            // guildLabel
            // 
            this.guildLabel.AutoSize = true;
            this.guildLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guildLabel.ForeColor = System.Drawing.Color.White;
            this.guildLabel.Location = new System.Drawing.Point(12, 401);
            this.guildLabel.Name = "guildLabel";
            this.guildLabel.Size = new System.Drawing.Size(268, 25);
            this.guildLabel.TabIndex = 22;
            this.guildLabel.Text = "All Guilds of a Single Type";
            // 
            // playerFillButon
            // 
            this.playerFillButon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerFillButon.Location = new System.Drawing.Point(445, 551);
            this.playerFillButon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.playerFillButon.Name = "playerFillButon";
            this.playerFillButon.Size = new System.Drawing.Size(155, 30);
            this.playerFillButon.TabIndex = 29;
            this.playerFillButon.Text = "Show Results";
            this.playerFillButon.UseVisualStyleBackColor = true;
            this.playerFillButon.Click += new System.EventHandler(this.playerFillButton_Click);
            // 
            // playerFillLabel
            // 
            this.playerFillLabel.AutoSize = true;
            this.playerFillLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerFillLabel.ForeColor = System.Drawing.Color.White;
            this.playerFillLabel.Location = new System.Drawing.Point(12, 494);
            this.playerFillLabel.Name = "playerFillLabel";
            this.playerFillLabel.Size = new System.Drawing.Size(527, 25);
            this.playerFillLabel.TabIndex = 26;
            this.playerFillLabel.Text = "All Players Who Could Fill a Role But Presently Aren\'t";
            // 
            // playerFIllTankRadioButton
            // 
            this.playerFIllTankRadioButton.AutoSize = true;
            this.playerFIllTankRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerFIllTankRadioButton.ForeColor = System.Drawing.Color.White;
            this.playerFIllTankRadioButton.Location = new System.Drawing.Point(5, 21);
            this.playerFIllTankRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.playerFIllTankRadioButton.Name = "playerFIllTankRadioButton";
            this.playerFIllTankRadioButton.Size = new System.Drawing.Size(66, 24);
            this.playerFIllTankRadioButton.TabIndex = 30;
            this.playerFIllTankRadioButton.TabStop = true;
            this.playerFIllTankRadioButton.Text = "Tank";
            this.playerFIllTankRadioButton.UseVisualStyleBackColor = true;
            // 
            // playerFillHealerRadioButton
            // 
            this.playerFillHealerRadioButton.AutoSize = true;
            this.playerFillHealerRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerFillHealerRadioButton.ForeColor = System.Drawing.Color.White;
            this.playerFillHealerRadioButton.Location = new System.Drawing.Point(96, 21);
            this.playerFillHealerRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.playerFillHealerRadioButton.Name = "playerFillHealerRadioButton";
            this.playerFillHealerRadioButton.Size = new System.Drawing.Size(80, 24);
            this.playerFillHealerRadioButton.TabIndex = 31;
            this.playerFillHealerRadioButton.TabStop = true;
            this.playerFillHealerRadioButton.Text = "Healer";
            this.playerFillHealerRadioButton.UseVisualStyleBackColor = true;
            // 
            // playerFIllDamageRadioButton
            // 
            this.playerFIllDamageRadioButton.AutoSize = true;
            this.playerFIllDamageRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerFIllDamageRadioButton.ForeColor = System.Drawing.Color.White;
            this.playerFIllDamageRadioButton.Location = new System.Drawing.Point(196, 21);
            this.playerFIllDamageRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.playerFIllDamageRadioButton.Name = "playerFIllDamageRadioButton";
            this.playerFIllDamageRadioButton.Size = new System.Drawing.Size(93, 24);
            this.playerFIllDamageRadioButton.TabIndex = 32;
            this.playerFIllDamageRadioButton.TabStop = true;
            this.playerFIllDamageRadioButton.Text = "Damage";
            this.playerFIllDamageRadioButton.UseVisualStyleBackColor = true;
            // 
            // playerFillGroupBox
            // 
            this.playerFillGroupBox.Controls.Add(this.playerFIllTankRadioButton);
            this.playerFillGroupBox.Controls.Add(this.playerFIllDamageRadioButton);
            this.playerFillGroupBox.Controls.Add(this.playerFillHealerRadioButton);
            this.playerFillGroupBox.ForeColor = System.Drawing.Color.White;
            this.playerFillGroupBox.Location = new System.Drawing.Point(17, 533);
            this.playerFillGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.playerFillGroupBox.Name = "playerFillGroupBox";
            this.playerFillGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.playerFillGroupBox.Size = new System.Drawing.Size(308, 59);
            this.playerFillGroupBox.TabIndex = 33;
            this.playerFillGroupBox.TabStop = false;
            this.playerFillGroupBox.Text = "Role";
            // 
            // percentLevelButton
            // 
            this.percentLevelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentLevelButton.Location = new System.Drawing.Point(445, 651);
            this.percentLevelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.percentLevelButton.Name = "percentLevelButton";
            this.percentLevelButton.Size = new System.Drawing.Size(133, 30);
            this.percentLevelButton.TabIndex = 37;
            this.percentLevelButton.Text = "Show Results";
            this.percentLevelButton.UseVisualStyleBackColor = true;
            this.percentLevelButton.Click += new System.EventHandler(this.percentLevelButton_Click);
            // 
            // percentLevelLabel
            // 
            this.percentLevelLabel.AutoSize = true;
            this.percentLevelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentLevelLabel.ForeColor = System.Drawing.Color.White;
            this.percentLevelLabel.Location = new System.Drawing.Point(12, 610);
            this.percentLevelLabel.Name = "percentLevelLabel";
            this.percentLevelLabel.Size = new System.Drawing.Size(450, 25);
            this.percentLevelLabel.TabIndex = 34;
            this.percentLevelLabel.Text = "Percentage of Max Level Players in All Guilds";
            // 
            // WOCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1511, 699);
            this.Controls.Add(this.percentLevelButton);
            this.Controls.Add(this.percentLevelLabel);
            this.Controls.Add(this.playerFillGroupBox);
            this.Controls.Add(this.playerFillButon);
            this.Controls.Add(this.playerFillLabel);
            this.Controls.Add(this.guildTypeButton);
            this.Controls.Add(this.guildTypeComboBox);
            this.Controls.Add(this.guildTypeLabel);
            this.Controls.Add(this.guildLabel);
            this.Controls.Add(this.roleTypeMaxNumericUpDown);
            this.Controls.Add(this.roleTypeMaxLabel);
            this.Controls.Add(this.roleTypeMinNumericUpDown);
            this.Controls.Add(this.roleTypeMinLabel);
            this.Controls.Add(this.roleTypeButton);
            this.Controls.Add(this.roleTypeServerComboBox);
            this.Controls.Add(this.roleTypeServerLabel);
            this.Controls.Add(this.roleTypeRollLabel);
            this.Controls.Add(this.roleTypeRoleComboBox);
            this.Controls.Add(this.roleTypeLabel);
            this.Controls.Add(this.percentRaceButton);
            this.Controls.Add(this.classTypeButton);
            this.Controls.Add(this.percentRaceServerComboBox);
            this.Controls.Add(this.percentRaceServerLabel);
            this.Controls.Add(this.percentRaceLabel);
            this.Controls.Add(this.classTypeServerComboBox);
            this.Controls.Add(this.classTypeServerLabel);
            this.Controls.Add(this.classTypeClassLabel);
            this.Controls.Add(this.classTypeClassComboBox);
            this.Controls.Add(this.classTypeLabel);
            this.Controls.Add(this.queryLabel);
            this.Controls.Add(this.queryListBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "WOCForm";
            this.Text = "World of ConflictCraft: Querying System";
            ((System.ComponentModel.ISupportInitialize)(this.roleTypeMinNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleTypeMaxNumericUpDown)).EndInit();
            this.playerFillGroupBox.ResumeLayout(false);
            this.playerFillGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox queryListBox;
        private System.Windows.Forms.Label queryLabel;
        private System.Windows.Forms.Label classTypeLabel;
        private System.Windows.Forms.ComboBox classTypeClassComboBox;
        private System.Windows.Forms.Label classTypeClassLabel;
        private System.Windows.Forms.Label classTypeServerLabel;
        private System.Windows.Forms.ComboBox classTypeServerComboBox;
        private System.Windows.Forms.Label percentRaceLabel;
        private System.Windows.Forms.ComboBox percentRaceServerComboBox;
        private System.Windows.Forms.Label percentRaceServerLabel;
        private System.Windows.Forms.Button classTypeButton;
        private System.Windows.Forms.Button percentRaceButton;
        private System.Windows.Forms.Button roleTypeButton;
        private System.Windows.Forms.ComboBox roleTypeServerComboBox;
        private System.Windows.Forms.Label roleTypeServerLabel;
        private System.Windows.Forms.Label roleTypeRollLabel;
        private System.Windows.Forms.ComboBox roleTypeRoleComboBox;
        private System.Windows.Forms.Label roleTypeLabel;
        private System.Windows.Forms.Label roleTypeMinLabel;
        private System.Windows.Forms.NumericUpDown roleTypeMinNumericUpDown;
        private System.Windows.Forms.NumericUpDown roleTypeMaxNumericUpDown;
        private System.Windows.Forms.Label roleTypeMaxLabel;
        private System.Windows.Forms.Button guildTypeButton;
        private System.Windows.Forms.ComboBox guildTypeComboBox;
        private System.Windows.Forms.Label guildTypeLabel;
        private System.Windows.Forms.Label guildLabel;
        private System.Windows.Forms.Button playerFillButon;
        private System.Windows.Forms.Label playerFillLabel;
        private System.Windows.Forms.RadioButton playerFIllTankRadioButton;
        private System.Windows.Forms.RadioButton playerFillHealerRadioButton;
        private System.Windows.Forms.RadioButton playerFIllDamageRadioButton;
        private System.Windows.Forms.GroupBox playerFillGroupBox;
        private System.Windows.Forms.Button percentLevelButton;
        private System.Windows.Forms.Label percentLevelLabel;
    }
}

