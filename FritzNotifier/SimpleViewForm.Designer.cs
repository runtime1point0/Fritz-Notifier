namespace FritzNotifier
{
    partial class SimpleViewForm
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
            this.detailedViewButton = new System.Windows.Forms.Button();
            this.simpleViewControl = new FritzNotifier.SimpleViewControl();
            this.SuspendLayout();
            // 
            // detailedViewButton
            // 
            this.detailedViewButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.detailedViewButton.Location = new System.Drawing.Point(93, 6);
            this.detailedViewButton.Name = "detailedViewButton";
            this.detailedViewButton.Size = new System.Drawing.Size(111, 23);
            this.detailedViewButton.TabIndex = 3;
            this.detailedViewButton.Text = "Detailed Overview";
            this.detailedViewButton.UseVisualStyleBackColor = true;
            this.detailedViewButton.Click += new System.EventHandler(this.detailedViewButton_Click);
            // 
            // simpleViewControl
            // 
            this.simpleViewControl.Location = new System.Drawing.Point(0, 34);
            this.simpleViewControl.Name = "simpleViewControl";
            this.simpleViewControl.Size = new System.Drawing.Size(219, 150);
            this.simpleViewControl.TabIndex = 4;
            // 
            // SimpleViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 186);
            this.Controls.Add(this.detailedViewButton);
            this.Controls.Add(this.simpleViewControl);
            this.Name = "SimpleViewForm";
            this.Text = "Fritz Notifier";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button detailedViewButton;
        private SimpleViewControl simpleViewControl;
    }
}