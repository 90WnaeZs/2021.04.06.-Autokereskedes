
namespace Autokereskedes
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.márkaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tulajdonosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autóToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listázásToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.márkaToolStripMenuItem,
            this.tulajdonosToolStripMenuItem,
            this.autóToolStripMenuItem,
            this.listázásToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // márkaToolStripMenuItem
            // 
            this.márkaToolStripMenuItem.Name = "márkaToolStripMenuItem";
            this.márkaToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.márkaToolStripMenuItem.Text = "Márka";
            this.márkaToolStripMenuItem.Click += new System.EventHandler(this.márkaToolStripMenuItem_Click);
            // 
            // tulajdonosToolStripMenuItem
            // 
            this.tulajdonosToolStripMenuItem.Name = "tulajdonosToolStripMenuItem";
            this.tulajdonosToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.tulajdonosToolStripMenuItem.Text = "Tulajdonos";
            this.tulajdonosToolStripMenuItem.Click += new System.EventHandler(this.tulajdonosToolStripMenuItem_Click);
            // 
            // autóToolStripMenuItem
            // 
            this.autóToolStripMenuItem.Name = "autóToolStripMenuItem";
            this.autóToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.autóToolStripMenuItem.Text = "Autó";
            this.autóToolStripMenuItem.Click += new System.EventHandler(this.autóToolStripMenuItem_Click);
            // 
            // listázásToolStripMenuItem
            // 
            this.listázásToolStripMenuItem.Name = "listázásToolStripMenuItem";
            this.listázásToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.listázásToolStripMenuItem.Text = "Listázás";
            this.listázásToolStripMenuItem.Click += new System.EventHandler(this.listázásToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem márkaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tulajdonosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autóToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listázásToolStripMenuItem;
    }
}

