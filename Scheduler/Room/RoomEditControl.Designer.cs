namespace Scheduler
{
    partial class RoomEditControl
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
            this.nameBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.descBox = new System.Windows.Forms.TextBox();
            this.descLabel = new System.Windows.Forms.Label();
            this.ratioBox = new System.Windows.Forms.TextBox();
            this.ratioLabel = new System.Windows.Forms.Label();
            this.capacityBox = new System.Windows.Forms.TextBox();
            this.capacityLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(91, 23);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(144, 20);
            this.nameBox.TabIndex = 53;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(16, 26);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(69, 13);
            this.nameLabel.TabIndex = 52;
            this.nameLabel.Text = "Room Name:";
            // 
            // descBox
            // 
            this.descBox.Location = new System.Drawing.Point(91, 84);
            this.descBox.Name = "descBox";
            this.descBox.Size = new System.Drawing.Size(144, 20);
            this.descBox.TabIndex = 55;
            // 
            // descLabel
            // 
            this.descLabel.AutoSize = true;
            this.descLabel.Location = new System.Drawing.Point(16, 87);
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(63, 13);
            this.descLabel.TabIndex = 54;
            this.descLabel.Text = "Description:";
            // 
            // ratioBox
            // 
            this.ratioBox.Location = new System.Drawing.Point(352, 23);
            this.ratioBox.Name = "ratioBox";
            this.ratioBox.Size = new System.Drawing.Size(30, 20);
            this.ratioBox.TabIndex = 57;
            // 
            // ratioLabel
            // 
            this.ratioLabel.AutoSize = true;
            this.ratioLabel.Location = new System.Drawing.Point(286, 26);
            this.ratioLabel.Name = "ratioLabel";
            this.ratioLabel.Size = new System.Drawing.Size(35, 13);
            this.ratioLabel.TabIndex = 56;
            this.ratioLabel.Text = "Ratio:";
            // 
            // capacityBox
            // 
            this.capacityBox.Location = new System.Drawing.Point(352, 84);
            this.capacityBox.Name = "capacityBox";
            this.capacityBox.Size = new System.Drawing.Size(30, 20);
            this.capacityBox.TabIndex = 61;
            // 
            // capacityLabel
            // 
            this.capacityLabel.AutoSize = true;
            this.capacityLabel.Location = new System.Drawing.Point(286, 87);
            this.capacityLabel.Name = "capacityLabel";
            this.capacityLabel.Size = new System.Drawing.Size(51, 13);
            this.capacityLabel.TabIndex = 60;
            this.capacityLabel.Text = "Capacity:";
            // 
            // RoomEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.capacityBox);
            this.Controls.Add(this.capacityLabel);
            this.Controls.Add(this.ratioBox);
            this.Controls.Add(this.ratioLabel);
            this.Controls.Add(this.descBox);
            this.Controls.Add(this.descLabel);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.nameLabel);
            this.Name = "RoomEditControl";
            this.Size = new System.Drawing.Size(1352, 494);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox descBox;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.TextBox ratioBox;
        private System.Windows.Forms.Label ratioLabel;
        private System.Windows.Forms.TextBox capacityBox;
        private System.Windows.Forms.Label capacityLabel;
    }
}
