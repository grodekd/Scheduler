namespace Scheduler
{
    partial class ChildrenControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.emptyLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.roomsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 51);
            this.dataGridView1.MaximumSize = new System.Drawing.Size(1352, 402);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.Size = new System.Drawing.Size(1352, 402);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.MouseEnter += new System.EventHandler(this.DataGrid_MouseEnter);
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
            this.roomsBox.Location = new System.Drawing.Point(51, 5);
            this.roomsBox.Name = "roomsBox";
            this.roomsBox.Size = new System.Drawing.Size(1264, 40);
            this.roomsBox.TabIndex = 3;
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
            // emptyLabel
            // 
            this.emptyLabel.AutoSize = true;
            this.emptyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emptyLabel.Location = new System.Drawing.Point(546, 270);
            this.emptyLabel.Name = "emptyLabel";
            this.emptyLabel.Size = new System.Drawing.Size(174, 20);
            this.emptyLabel.TabIndex = 4;
            this.emptyLabel.Text = "No Child Data Available";
            this.emptyLabel.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(550, 459);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 32);
            this.button1.TabIndex = 5;
            this.button1.Text = "View Daily Breakdown";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChildrenControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.emptyLabel);
            this.Controls.Add(this.roomsBox);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ChildrenControl";
            this.Size = new System.Drawing.Size(1352, 494);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.roomsBox.ResumeLayout(false);
            this.roomsBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
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
        private System.Windows.Forms.Label emptyLabel;
        private System.Windows.Forms.Button button1;
    }
}
