namespace Scheduler
{
    partial class WeeklySchedulesForm
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
            this.roomsBox = new System.Windows.Forms.GroupBox();
            this.saRadio = new System.Windows.Forms.RadioButton();
            this.mindsRadio = new System.Windows.Forms.RadioButton();
            this.horizonsRadio = new System.Windows.Forms.RadioButton();
            this.firefly2Radio = new System.Windows.Forms.RadioButton();
            this.firefly1Radio = new System.Windows.Forms.RadioButton();
            this.forest2Radio = new System.Windows.Forms.RadioButton();
            this.forest1Radio = new System.Windows.Forms.RadioButton();
            this.turtleRadio = new System.Windows.Forms.RadioButton();
            this.lambRadio = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.mondayTextBox = new System.Windows.Forms.TextBox();
            this.tuesdayTextBox = new System.Windows.Forms.TextBox();
            this.wednesdayTextBox = new System.Windows.Forms.TextBox();
            this.thursdayTextBox = new System.Windows.Forms.TextBox();
            this.fridayTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.roomsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // roomsBox
            // 
            this.roomsBox.Controls.Add(this.saRadio);
            this.roomsBox.Controls.Add(this.mindsRadio);
            this.roomsBox.Controls.Add(this.horizonsRadio);
            this.roomsBox.Controls.Add(this.firefly2Radio);
            this.roomsBox.Controls.Add(this.firefly1Radio);
            this.roomsBox.Controls.Add(this.forest2Radio);
            this.roomsBox.Controls.Add(this.forest1Radio);
            this.roomsBox.Controls.Add(this.turtleRadio);
            this.roomsBox.Controls.Add(this.lambRadio);
            this.roomsBox.Location = new System.Drawing.Point(63, 36);
            this.roomsBox.Name = "roomsBox";
            this.roomsBox.Size = new System.Drawing.Size(1264, 40);
            this.roomsBox.TabIndex = 4;
            this.roomsBox.TabStop = false;
            this.roomsBox.Text = "Rooms:";
            // 
            // saRadio
            // 
            this.saRadio.AutoSize = true;
            this.saRadio.Location = new System.Drawing.Point(1178, 17);
            this.saRadio.Name = "saRadio";
            this.saRadio.Size = new System.Drawing.Size(80, 17);
            this.saRadio.TabIndex = 8;
            this.saRadio.Text = "School Age";
            this.saRadio.UseVisualStyleBackColor = true;
            this.saRadio.CheckedChanged += new System.EventHandler(this.saRadio_CheckedChanged);
            // 
            // mindsRadio
            // 
            this.mindsRadio.AutoSize = true;
            this.mindsRadio.Location = new System.Drawing.Point(1032, 17);
            this.mindsRadio.Name = "mindsRadio";
            this.mindsRadio.Size = new System.Drawing.Size(83, 17);
            this.mindsRadio.TabIndex = 7;
            this.mindsRadio.Text = "Bright Minds";
            this.mindsRadio.UseVisualStyleBackColor = true;
            this.mindsRadio.CheckedChanged += new System.EventHandler(this.mindsRadio_CheckedChanged);
            // 
            // horizonsRadio
            // 
            this.horizonsRadio.AutoSize = true;
            this.horizonsRadio.Location = new System.Drawing.Point(879, 17);
            this.horizonsRadio.Name = "horizonsRadio";
            this.horizonsRadio.Size = new System.Drawing.Size(96, 17);
            this.horizonsRadio.TabIndex = 6;
            this.horizonsRadio.Text = "Bright Horizons";
            this.horizonsRadio.UseVisualStyleBackColor = true;
            this.horizonsRadio.CheckedChanged += new System.EventHandler(this.horizonsRadio_CheckedChanged);
            // 
            // firefly2Radio
            // 
            this.firefly2Radio.AutoSize = true;
            this.firefly2Radio.Location = new System.Drawing.Point(753, 17);
            this.firefly2Radio.Name = "firefly2Radio";
            this.firefly2Radio.Size = new System.Drawing.Size(69, 17);
            this.firefly2Radio.TabIndex = 5;
            this.firefly2Radio.Text = "Fireflies 2";
            this.firefly2Radio.UseVisualStyleBackColor = true;
            this.firefly2Radio.CheckedChanged += new System.EventHandler(this.firefly2Radio_CheckedChanged);
            // 
            // firefly1Radio
            // 
            this.firefly1Radio.AutoSize = true;
            this.firefly1Radio.Location = new System.Drawing.Point(627, 17);
            this.firefly1Radio.Name = "firefly1Radio";
            this.firefly1Radio.Size = new System.Drawing.Size(69, 17);
            this.firefly1Radio.TabIndex = 4;
            this.firefly1Radio.Text = "Fireflies 1";
            this.firefly1Radio.UseVisualStyleBackColor = true;
            this.firefly1Radio.CheckedChanged += new System.EventHandler(this.firefly1Radio_CheckedChanged);
            // 
            // forest2Radio
            // 
            this.forest2Radio.AutoSize = true;
            this.forest2Radio.Location = new System.Drawing.Point(451, 17);
            this.forest2Radio.Name = "forest2Radio";
            this.forest2Radio.Size = new System.Drawing.Size(119, 17);
            this.forest2Radio.TabIndex = 3;
            this.forest2Radio.Text = "Bumblebee Forest 2";
            this.forest2Radio.UseVisualStyleBackColor = true;
            this.forest2Radio.CheckedChanged += new System.EventHandler(this.forest2Radio_CheckedChanged);
            // 
            // forest1Radio
            // 
            this.forest1Radio.AutoSize = true;
            this.forest1Radio.Location = new System.Drawing.Point(275, 17);
            this.forest1Radio.Name = "forest1Radio";
            this.forest1Radio.Size = new System.Drawing.Size(119, 17);
            this.forest1Radio.TabIndex = 2;
            this.forest1Radio.Text = "Bumblebee Forest 1";
            this.forest1Radio.UseVisualStyleBackColor = true;
            this.forest1Radio.CheckedChanged += new System.EventHandler(this.forest1Radio_CheckedChanged);
            // 
            // turtleRadio
            // 
            this.turtleRadio.AutoSize = true;
            this.turtleRadio.Location = new System.Drawing.Point(138, 17);
            this.turtleRadio.Name = "turtleRadio";
            this.turtleRadio.Size = new System.Drawing.Size(80, 17);
            this.turtleRadio.TabIndex = 1;
            this.turtleRadio.Text = "Tiny Turtles";
            this.turtleRadio.UseVisualStyleBackColor = true;
            this.turtleRadio.CheckedChanged += new System.EventHandler(this.turtleRadio_CheckedChanged);
            // 
            // lambRadio
            // 
            this.lambRadio.AutoSize = true;
            this.lambRadio.Checked = true;
            this.lambRadio.Location = new System.Drawing.Point(7, 17);
            this.lambRadio.Name = "lambRadio";
            this.lambRadio.Size = new System.Drawing.Size(81, 17);
            this.lambRadio.TabIndex = 0;
            this.lambRadio.TabStop = true;
            this.lambRadio.Text = "Little Lambs";
            this.lambRadio.UseVisualStyleBackColor = true;
            this.lambRadio.CheckedChanged += new System.EventHandler(this.lambRadio_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(575, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Weekly Schedules";
            // 
            // mondayTextBox
            // 
            this.mondayTextBox.Location = new System.Drawing.Point(63, 138);
            this.mondayTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.mondayTextBox.Multiline = true;
            this.mondayTextBox.Name = "mondayTextBox";
            this.mondayTextBox.ReadOnly = true;
            this.mondayTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mondayTextBox.Size = new System.Drawing.Size(235, 387);
            this.mondayTextBox.TabIndex = 6;
            this.mondayTextBox.Text = "No Employee Shifts";
            // 
            // tuesdayTextBox
            // 
            this.tuesdayTextBox.Location = new System.Drawing.Point(321, 138);
            this.tuesdayTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.tuesdayTextBox.Multiline = true;
            this.tuesdayTextBox.Name = "tuesdayTextBox";
            this.tuesdayTextBox.ReadOnly = true;
            this.tuesdayTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tuesdayTextBox.Size = new System.Drawing.Size(235, 387);
            this.tuesdayTextBox.TabIndex = 7;
            this.tuesdayTextBox.Text = "No Employee Shifts";
            // 
            // wednesdayTextBox
            // 
            this.wednesdayTextBox.Location = new System.Drawing.Point(579, 138);
            this.wednesdayTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.wednesdayTextBox.Multiline = true;
            this.wednesdayTextBox.Name = "wednesdayTextBox";
            this.wednesdayTextBox.ReadOnly = true;
            this.wednesdayTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.wednesdayTextBox.Size = new System.Drawing.Size(235, 387);
            this.wednesdayTextBox.TabIndex = 8;
            this.wednesdayTextBox.Text = "No Employee Shifts";
            // 
            // thursdayTextBox
            // 
            this.thursdayTextBox.Location = new System.Drawing.Point(835, 138);
            this.thursdayTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.thursdayTextBox.Multiline = true;
            this.thursdayTextBox.Name = "thursdayTextBox";
            this.thursdayTextBox.ReadOnly = true;
            this.thursdayTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.thursdayTextBox.Size = new System.Drawing.Size(235, 387);
            this.thursdayTextBox.TabIndex = 9;
            this.thursdayTextBox.Text = "No Employee Shifts";
            // 
            // fridayTextBox
            // 
            this.fridayTextBox.Location = new System.Drawing.Point(1092, 138);
            this.fridayTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.fridayTextBox.Multiline = true;
            this.fridayTextBox.Name = "fridayTextBox";
            this.fridayTextBox.ReadOnly = true;
            this.fridayTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.fridayTextBox.Size = new System.Drawing.Size(235, 387);
            this.fridayTextBox.TabIndex = 10;
            this.fridayTextBox.Text = "No Employee Shifts";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(152, 111);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Monday";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(407, 111);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tuesday";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(653, 111);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Wednesday";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(913, 111);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Thursday";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1180, 111);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Friday";
            // 
            // WeeklySchedulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1399, 562);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fridayTextBox);
            this.Controls.Add(this.thursdayTextBox);
            this.Controls.Add(this.wednesdayTextBox);
            this.Controls.Add(this.tuesdayTextBox);
            this.Controls.Add(this.mondayTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.roomsBox);
            this.Name = "WeeklySchedulesForm";
            this.Text = "WeeklySchedulesForm";
            this.roomsBox.ResumeLayout(false);
            this.roomsBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox roomsBox;
        private System.Windows.Forms.RadioButton saRadio;
        private System.Windows.Forms.RadioButton mindsRadio;
        private System.Windows.Forms.RadioButton horizonsRadio;
        private System.Windows.Forms.RadioButton firefly2Radio;
        private System.Windows.Forms.RadioButton firefly1Radio;
        private System.Windows.Forms.RadioButton forest2Radio;
        private System.Windows.Forms.RadioButton forest1Radio;
        private System.Windows.Forms.RadioButton turtleRadio;
        private System.Windows.Forms.RadioButton lambRadio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox mondayTextBox;
        private System.Windows.Forms.TextBox tuesdayTextBox;
        private System.Windows.Forms.TextBox wednesdayTextBox;
        private System.Windows.Forms.TextBox thursdayTextBox;
        private System.Windows.Forms.TextBox fridayTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}