namespace PushNotification
{
    partial class Push
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
            this.MessageLabel = new System.Windows.Forms.Label();
            this.MessageTexBox = new System.Windows.Forms.TextBox();
            this.RoleLabel = new System.Windows.Forms.Label();
            this.RoleListBox = new System.Windows.Forms.ListBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Location = new System.Drawing.Point(201, 27);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(50, 13);
            this.MessageLabel.TabIndex = 0;
            this.MessageLabel.Text = "Message";
            // 
            // MessageTexBox
            // 
            this.MessageTexBox.Location = new System.Drawing.Point(257, 21);
            this.MessageTexBox.Multiline = true;
            this.MessageTexBox.Name = "MessageTexBox";
            this.MessageTexBox.Size = new System.Drawing.Size(373, 95);
            this.MessageTexBox.TabIndex = 1;
            // 
            // RoleLabel
            // 
            this.RoleLabel.AutoSize = true;
            this.RoleLabel.Location = new System.Drawing.Point(12, 27);
            this.RoleLabel.Name = "RoleLabel";
            this.RoleLabel.Size = new System.Drawing.Size(34, 13);
            this.RoleLabel.TabIndex = 2;
            this.RoleLabel.Text = "Roles";
            // 
            // RoleListBox
            // 
            this.RoleListBox.FormattingEnabled = true;
            this.RoleListBox.Items.AddRange(new object[] {
            "All",
            "Food",
            "Logistics",
            "Seva Comittee",
            "Finance"});
            this.RoleListBox.Location = new System.Drawing.Point(52, 21);
            this.RoleListBox.Name = "RoleListBox";
            this.RoleListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.RoleListBox.Size = new System.Drawing.Size(92, 95);
            this.RoleListBox.TabIndex = 3;
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(554, 123);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(75, 23);
            this.SendButton.TabIndex = 4;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(473, 123);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 5;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // Push
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 171);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.RoleListBox);
            this.Controls.Add(this.RoleLabel);
            this.Controls.Add(this.MessageTexBox);
            this.Controls.Add(this.MessageLabel);
            this.MaximizeBox = false;
            this.Name = "Push";
            this.Text = "Push";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.TextBox MessageTexBox;
        private System.Windows.Forms.Label RoleLabel;
        private System.Windows.Forms.ListBox RoleListBox;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Button ResetButton;
    }
}