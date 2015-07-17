namespace FolderKaitai {
    partial class Form2 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.bwRun = new System.ComponentModel.BackgroundWorker();
            this.lWip = new System.Windows.Forms.Label();
            this.lDone = new System.Windows.Forms.Label();
            this.lErr = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bwRun
            // 
            this.bwRun.WorkerSupportsCancellation = true;
            this.bwRun.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwRun_DoWork);
            this.bwRun.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwRun_RunWorkerCompleted);
            // 
            // lWip
            // 
            this.lWip.AutoSize = true;
            this.lWip.Location = new System.Drawing.Point(12, 9);
            this.lWip.Name = "lWip";
            this.lWip.Size = new System.Drawing.Size(233, 12);
            this.lWip.TabIndex = 0;
            this.lWip.Text = "フォルダを解体しています。しばらくお待ちください。";
            // 
            // lDone
            // 
            this.lDone.AutoSize = true;
            this.lDone.Location = new System.Drawing.Point(12, 21);
            this.lDone.Name = "lDone";
            this.lDone.Size = new System.Drawing.Size(152, 12);
            this.lDone.TabIndex = 1;
            this.lDone.Text = "フォルダの解体が完了しました。";
            this.lDone.Visible = false;
            // 
            // lErr
            // 
            this.lErr.AutoSize = true;
            this.lErr.Location = new System.Drawing.Point(12, 33);
            this.lErr.Name = "lErr";
            this.lErr.Size = new System.Drawing.Size(198, 12);
            this.lErr.TabIndex = 2;
            this.lErr.Text = "フォルダの解体中にエラーが発生しました：";
            this.lErr.Visible = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 161);
            this.Controls.Add(this.lErr);
            this.Controls.Add(this.lDone);
            this.Controls.Add(this.lWip);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "フォルダ解体 実行";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bwRun;
        private System.Windows.Forms.Label lWip;
        private System.Windows.Forms.Label lDone;
        private System.Windows.Forms.Label lErr;
    }
}