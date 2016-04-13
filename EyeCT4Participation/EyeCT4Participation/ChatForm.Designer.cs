namespace EyeCT4Participation
{
    partial class ChatForm
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
            this.lbActiveConversations = new System.Windows.Forms.ListBox();
            this.lbConversation = new System.Windows.Forms.ListBox();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblActiveConversation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbActiveConversations
            // 
            this.lbActiveConversations.FormattingEnabled = true;
            this.lbActiveConversations.Location = new System.Drawing.Point(12, 25);
            this.lbActiveConversations.Name = "lbActiveConversations";
            this.lbActiveConversations.Size = new System.Drawing.Size(148, 524);
            this.lbActiveConversations.TabIndex = 0;
            // 
            // lbConversation
            // 
            this.lbConversation.FormattingEnabled = true;
            this.lbConversation.Location = new System.Drawing.Point(166, 25);
            this.lbConversation.Name = "lbConversation";
            this.lbConversation.Size = new System.Drawing.Size(546, 381);
            this.lbConversation.TabIndex = 1;
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(166, 428);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(546, 92);
            this.tbMessage.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(637, 526);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Verstuur";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 412);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Bericht";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Gesprek";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Actieve gesprekken";
            // 
            // lblActiveConversation
            // 
            this.lblActiveConversation.AutoSize = true;
            this.lblActiveConversation.Location = new System.Drawing.Point(216, 9);
            this.lblActiveConversation.Name = "lblActiveConversation";
            this.lblActiveConversation.Size = new System.Drawing.Size(83, 13);
            this.lblActiveConversation.TabIndex = 7;
            this.lblActiveConversation.Text = "[HuidigGesprek]";
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 561);
            this.Controls.Add(this.lblActiveConversation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.lbConversation);
            this.Controls.Add(this.lbActiveConversations);
            this.Name = "ChatForm";
            this.Text = "ChatForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbActiveConversations;
        private System.Windows.Forms.ListBox lbConversation;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblActiveConversation;
    }
}