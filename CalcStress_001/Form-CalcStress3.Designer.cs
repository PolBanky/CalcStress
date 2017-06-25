namespace CalcStress_003
{
    partial class Form_CalcStress
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CalcStress));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.расчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.параметрыПрофиляToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.напряжениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.максУсилиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.расчетToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(820, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // расчетToolStripMenuItem
            // 
            this.расчетToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.параметрыПрофиляToolStripMenuItem,
            this.напряжениеToolStripMenuItem,
            this.максУсилиеToolStripMenuItem});
            this.расчетToolStripMenuItem.Name = "расчетToolStripMenuItem";
            this.расчетToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.расчетToolStripMenuItem.Text = "Расчет";
            // 
            // параметрыПрофиляToolStripMenuItem
            // 
            this.параметрыПрофиляToolStripMenuItem.Name = "параметрыПрофиляToolStripMenuItem";
            this.параметрыПрофиляToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.параметрыПрофиляToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.параметрыПрофиляToolStripMenuItem.Text = "Параметры профиля";
            this.параметрыПрофиляToolStripMenuItem.Click += new System.EventHandler(this.параметрыПрофиляToolStripMenuItem_Click);
            // 
            // напряжениеToolStripMenuItem
            // 
            this.напряжениеToolStripMenuItem.Name = "напряжениеToolStripMenuItem";
            this.напряжениеToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.напряжениеToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.напряжениеToolStripMenuItem.Text = "Напряжение";
            this.напряжениеToolStripMenuItem.Click += new System.EventHandler(this.напряжениеToolStripMenuItem_Click);
            // 
            // максУсилиеToolStripMenuItem
            // 
            this.максУсилиеToolStripMenuItem.Name = "максУсилиеToolStripMenuItem";
            this.максУсилиеToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.максУсилиеToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.максУсилиеToolStripMenuItem.Text = "Макс. усилие";
            this.максУсилиеToolStripMenuItem.Click += new System.EventHandler(this.максУсилиеToolStripMenuItem_Click);
            // 
            // Form_CalcStress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(820, 808);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_CalcStress";
            this.Text = "Calculation Stress";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem расчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem параметрыПрофиляToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem напряжениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem максУсилиеToolStripMenuItem;
    }
}

