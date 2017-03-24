namespace Scheduler
{
    partial class ConfirmImportForm
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
            this.yesButton = new System.Windows.Forms.Button();
            this.noButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.importLabel = new System.Windows.Forms.Label();
            this.exportLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // yesButton
            // 
            this.yesButton.Location = new System.Drawing.Point(12, 198);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(117, 52);
            this.yesButton.TabIndex = 3;
            this.yesButton.Text = "Continue";
            this.yesButton.UseVisualStyleBackColor = true;
            this.yesButton.Click += new System.EventHandler(this.yesButton_Click);
            // 
            // noButton
            // 
            this.noButton.Location = new System.Drawing.Point(369, 198);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(117, 52);
            this.noButton.TabIndex = 4;
            this.noButton.Text = "Cancel";
            this.noButton.UseVisualStyleBackColor = true;
            this.noButton.Click += new System.EventHandler(this.noButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(189, 198);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(117, 52);
            this.exportButton.TabIndex = 5;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // importLabel
            // 
            this.importLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importLabel.Location = new System.Drawing.Point(25, 36);
            this.importLabel.Name = "importLabel";
            this.importLabel.Size = new System.Drawing.Size(461, 64);
            this.importLabel.TabIndex = 7;
            this.importLabel.Text = "Importing new [0] will completely replace the current ones.  If it is okay to ove" +
    "rwrite the current [1] data, click Continue.  Otherwise, click Cancel. ";
            // 
            // exportLabel
            // 
            this.exportLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportLabel.Location = new System.Drawing.Point(25, 119);
            this.exportLabel.Name = "exportLabel";
            this.exportLabel.Size = new System.Drawing.Size(461, 51);
            this.exportLabel.TabIndex = 8;
            this.exportLabel.Text = " If you would like to export the [1] data first, click Export.";
            // 
            // ConfirmImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 262);
            this.Controls.Add(this.exportLabel);
            this.Controls.Add(this.importLabel);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.yesButton);
            this.Name = "ConfirmImportForm";
            this.Text = "Confirm Import";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button yesButton;
        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Label importLabel;
        private System.Windows.Forms.Label exportLabel;

    }
}