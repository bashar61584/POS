namespace TMS.SettingBR
{
    partial class BackupForm
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
            this.components = new System.ComponentModel.Container();
            this.txtpath = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lbllocation = new Infragistics.Win.Misc.UltraLabel();
            this.btnopen = new Infragistics.Win.Misc.UltraButton();
            this.btnbackup = new Infragistics.Win.Misc.UltraButton();
            this.ultraFormManager1 = new Infragistics.Win.UltraWinForm.UltraFormManager(this.components);
            this.BackupForm_Fill_Panel = new Infragistics.Win.Misc.UltraPanel();
            this._BackupForm_UltraFormManager_Dock_Area_Left = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._BackupForm_UltraFormManager_Dock_Area_Right = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._BackupForm_UltraFormManager_Dock_Area_Top = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._BackupForm_UltraFormManager_Dock_Area_Bottom = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.txtpath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).BeginInit();
            this.BackupForm_Fill_Panel.ClientArea.SuspendLayout();
            this.BackupForm_Fill_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtpath
            // 
            this.txtpath.Location = new System.Drawing.Point(71, 17);
            this.txtpath.Name = "txtpath";
            this.txtpath.Size = new System.Drawing.Size(258, 21);
            this.txtpath.TabIndex = 3;
            // 
            // lbllocation
            // 
            this.lbllocation.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lbllocation.Location = new System.Drawing.Point(12, 20);
            this.lbllocation.Name = "lbllocation";
            this.lbllocation.Size = new System.Drawing.Size(68, 23);
            this.lbllocation.TabIndex = 4;
            this.lbllocation.Text = "Location";
            // 
            // btnopen
            // 
            this.btnopen.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnopen.Location = new System.Drawing.Point(335, 13);
            this.btnopen.Name = "btnopen";
            this.btnopen.Size = new System.Drawing.Size(111, 30);
            this.btnopen.TabIndex = 7;
            this.btnopen.Text = "Open";
            this.btnopen.Click += new System.EventHandler(this.btnopen_Click);
            // 
            // btnbackup
            // 
            this.btnbackup.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnbackup.Location = new System.Drawing.Point(452, 13);
            this.btnbackup.Name = "btnbackup";
            this.btnbackup.Size = new System.Drawing.Size(111, 30);
            this.btnbackup.TabIndex = 8;
            this.btnbackup.Text = "Back Up";
            this.btnbackup.Click += new System.EventHandler(this.btnbackup_Click);
            // 
            // ultraFormManager1
            // 
            this.ultraFormManager1.Form = this;
            // 
            // BackupForm_Fill_Panel
            // 
            // 
            // BackupForm_Fill_Panel.ClientArea
            // 
            this.BackupForm_Fill_Panel.ClientArea.Controls.Add(this.btnbackup);
            this.BackupForm_Fill_Panel.ClientArea.Controls.Add(this.btnopen);
            this.BackupForm_Fill_Panel.ClientArea.Controls.Add(this.txtpath);
            this.BackupForm_Fill_Panel.ClientArea.Controls.Add(this.lbllocation);
            this.BackupForm_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.BackupForm_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackupForm_Fill_Panel.Location = new System.Drawing.Point(8, 32);
            this.BackupForm_Fill_Panel.Name = "BackupForm_Fill_Panel";
            this.BackupForm_Fill_Panel.Size = new System.Drawing.Size(575, 55);
            this.BackupForm_Fill_Panel.TabIndex = 0;
            // 
            // _BackupForm_UltraFormManager_Dock_Area_Left
            // 
            this._BackupForm_UltraFormManager_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._BackupForm_UltraFormManager_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._BackupForm_UltraFormManager_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Left;
            this._BackupForm_UltraFormManager_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._BackupForm_UltraFormManager_Dock_Area_Left.FormManager = this.ultraFormManager1;
            this._BackupForm_UltraFormManager_Dock_Area_Left.InitialResizeAreaExtent = 8;
            this._BackupForm_UltraFormManager_Dock_Area_Left.Location = new System.Drawing.Point(0, 32);
            this._BackupForm_UltraFormManager_Dock_Area_Left.Name = "_BackupForm_UltraFormManager_Dock_Area_Left";
            this._BackupForm_UltraFormManager_Dock_Area_Left.Size = new System.Drawing.Size(8, 55);
            // 
            // _BackupForm_UltraFormManager_Dock_Area_Right
            // 
            this._BackupForm_UltraFormManager_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._BackupForm_UltraFormManager_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._BackupForm_UltraFormManager_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Right;
            this._BackupForm_UltraFormManager_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._BackupForm_UltraFormManager_Dock_Area_Right.FormManager = this.ultraFormManager1;
            this._BackupForm_UltraFormManager_Dock_Area_Right.InitialResizeAreaExtent = 8;
            this._BackupForm_UltraFormManager_Dock_Area_Right.Location = new System.Drawing.Point(583, 32);
            this._BackupForm_UltraFormManager_Dock_Area_Right.Name = "_BackupForm_UltraFormManager_Dock_Area_Right";
            this._BackupForm_UltraFormManager_Dock_Area_Right.Size = new System.Drawing.Size(8, 55);
            // 
            // _BackupForm_UltraFormManager_Dock_Area_Top
            // 
            this._BackupForm_UltraFormManager_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._BackupForm_UltraFormManager_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._BackupForm_UltraFormManager_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Top;
            this._BackupForm_UltraFormManager_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._BackupForm_UltraFormManager_Dock_Area_Top.FormManager = this.ultraFormManager1;
            this._BackupForm_UltraFormManager_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._BackupForm_UltraFormManager_Dock_Area_Top.Name = "_BackupForm_UltraFormManager_Dock_Area_Top";
            this._BackupForm_UltraFormManager_Dock_Area_Top.Size = new System.Drawing.Size(591, 32);
            // 
            // _BackupForm_UltraFormManager_Dock_Area_Bottom
            // 
            this._BackupForm_UltraFormManager_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._BackupForm_UltraFormManager_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._BackupForm_UltraFormManager_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Bottom;
            this._BackupForm_UltraFormManager_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._BackupForm_UltraFormManager_Dock_Area_Bottom.FormManager = this.ultraFormManager1;
            this._BackupForm_UltraFormManager_Dock_Area_Bottom.InitialResizeAreaExtent = 8;
            this._BackupForm_UltraFormManager_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 87);
            this._BackupForm_UltraFormManager_Dock_Area_Bottom.Name = "_BackupForm_UltraFormManager_Dock_Area_Bottom";
            this._BackupForm_UltraFormManager_Dock_Area_Bottom.Size = new System.Drawing.Size(591, 8);
            // 
            // BackupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 95);
            this.Controls.Add(this.BackupForm_Fill_Panel);
            this.Controls.Add(this._BackupForm_UltraFormManager_Dock_Area_Left);
            this.Controls.Add(this._BackupForm_UltraFormManager_Dock_Area_Right);
            this.Controls.Add(this._BackupForm_UltraFormManager_Dock_Area_Top);
            this.Controls.Add(this._BackupForm_UltraFormManager_Dock_Area_Bottom);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BackupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup";
            this.Load += new System.EventHandler(this.BackupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtpath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).EndInit();
            this.BackupForm_Fill_Panel.ClientArea.ResumeLayout(false);
            this.BackupForm_Fill_Panel.ClientArea.PerformLayout();
            this.BackupForm_Fill_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtpath;
        private Infragistics.Win.Misc.UltraLabel lbllocation;
        private Infragistics.Win.Misc.UltraButton btnopen;
        private Infragistics.Win.Misc.UltraButton btnbackup;
        private Infragistics.Win.UltraWinForm.UltraFormManager ultraFormManager1;
        private Infragistics.Win.Misc.UltraPanel BackupForm_Fill_Panel;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _BackupForm_UltraFormManager_Dock_Area_Left;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _BackupForm_UltraFormManager_Dock_Area_Right;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _BackupForm_UltraFormManager_Dock_Area_Top;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _BackupForm_UltraFormManager_Dock_Area_Bottom;
    }
}