namespace TMS
{
    partial class SoftwareSetting
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.lblname = new Infragistics.Win.Misc.UltraLabel();
            this.txtname = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lbladdress = new Infragistics.Win.Misc.UltraLabel();
            this.txtaddress = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.btnsaveupdate = new Infragistics.Win.Misc.UltraButton();
            this.lblcontact = new Infragistics.Win.Misc.UltraLabel();
            this.lblemail = new Infragistics.Win.Misc.UltraLabel();
            this.txtcontact = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtemail = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.btnopen = new Infragistics.Win.Misc.UltraButton();
            this.txtpath = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lbllocation = new Infragistics.Win.Misc.UltraLabel();
            this.ultraFormManager1 = new Infragistics.Win.UltraWinForm.UltraFormManager(this.components);
            this.SoftwareSetting_Fill_Panel = new Infragistics.Win.Misc.UltraPanel();
            this._SoftwareSetting_UltraFormManager_Dock_Area_Left = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._SoftwareSetting_UltraFormManager_Dock_Area_Right = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._SoftwareSetting_UltraFormManager_Dock_Area_Top = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._SoftwareSetting_UltraFormManager_Dock_Area_Bottom = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.txtname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtaddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcontact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtemail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).BeginInit();
            this.SoftwareSetting_Fill_Panel.ClientArea.SuspendLayout();
            this.SoftwareSetting_Fill_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblname
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.lblname.Appearance = appearance1;
            this.lblname.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblname.Location = new System.Drawing.Point(0, 24);
            this.lblname.Name = "lblname";
            this.lblname.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblname.Size = new System.Drawing.Size(100, 23);
            this.lblname.TabIndex = 2;
            this.lblname.Text = ": Name";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(106, 21);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(508, 21);
            this.txtname.TabIndex = 0;
            this.txtname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtname_KeyDown);
            // 
            // lbladdress
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.lbladdress.Appearance = appearance2;
            this.lbladdress.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lbladdress.Location = new System.Drawing.Point(0, 58);
            this.lbladdress.Name = "lbladdress";
            this.lbladdress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbladdress.Size = new System.Drawing.Size(100, 23);
            this.lbladdress.TabIndex = 2;
            this.lbladdress.Text = ": Address";
            // 
            // txtaddress
            // 
            this.txtaddress.Location = new System.Drawing.Point(106, 56);
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(508, 21);
            this.txtaddress.TabIndex = 1;
            this.txtaddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtaddress_KeyDown);
            // 
            // btnsaveupdate
            // 
            this.btnsaveupdate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnsaveupdate.Location = new System.Drawing.Point(268, 147);
            this.btnsaveupdate.Name = "btnsaveupdate";
            this.btnsaveupdate.Size = new System.Drawing.Size(82, 30);
            this.btnsaveupdate.TabIndex = 4;
            this.btnsaveupdate.Text = "Save";
            this.btnsaveupdate.Click += new System.EventHandler(this.btnsaveupdate_Click);
            // 
            // lblcontact
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.lblcontact.Appearance = appearance3;
            this.lblcontact.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblcontact.Location = new System.Drawing.Point(0, 88);
            this.lblcontact.Name = "lblcontact";
            this.lblcontact.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblcontact.Size = new System.Drawing.Size(100, 23);
            this.lblcontact.TabIndex = 2;
            this.lblcontact.Text = ": Contact";
            // 
            // lblemail
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.lblemail.Appearance = appearance4;
            this.lblemail.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblemail.Location = new System.Drawing.Point(0, 122);
            this.lblemail.Name = "lblemail";
            this.lblemail.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblemail.Size = new System.Drawing.Size(100, 23);
            this.lblemail.TabIndex = 2;
            this.lblemail.Text = ": Email";
            // 
            // txtcontact
            // 
            this.txtcontact.Location = new System.Drawing.Point(106, 85);
            this.txtcontact.Name = "txtcontact";
            this.txtcontact.Size = new System.Drawing.Size(508, 21);
            this.txtcontact.TabIndex = 2;
            this.txtcontact.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcontact_KeyDown);
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(106, 120);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(508, 21);
            this.txtemail.TabIndex = 3;
            this.txtemail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtemail_KeyDown);
            // 
            // btnopen
            // 
            this.btnopen.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnopen.Location = new System.Drawing.Point(509, 183);
            this.btnopen.Name = "btnopen";
            this.btnopen.Size = new System.Drawing.Size(105, 29);
            this.btnopen.TabIndex = 10;
            this.btnopen.Text = "Open";
            this.btnopen.Click += new System.EventHandler(this.btnopen_Click);
            // 
            // txtpath
            // 
            this.txtpath.Location = new System.Drawing.Point(106, 187);
            this.txtpath.Name = "txtpath";
            this.txtpath.Size = new System.Drawing.Size(397, 21);
            this.txtpath.TabIndex = 8;
            // 
            // lbllocation
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            this.lbllocation.Appearance = appearance5;
            this.lbllocation.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lbllocation.Location = new System.Drawing.Point(0, 190);
            this.lbllocation.Name = "lbllocation";
            this.lbllocation.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbllocation.Size = new System.Drawing.Size(100, 23);
            this.lbllocation.TabIndex = 11;
            this.lbllocation.Text = ": BackUp Path";
            // 
            // ultraFormManager1
            // 
            this.ultraFormManager1.Form = this;
            // 
            // SoftwareSetting_Fill_Panel
            // 
            // 
            // SoftwareSetting_Fill_Panel.ClientArea
            // 
            this.SoftwareSetting_Fill_Panel.ClientArea.Controls.Add(this.lbllocation);
            this.SoftwareSetting_Fill_Panel.ClientArea.Controls.Add(this.btnopen);
            this.SoftwareSetting_Fill_Panel.ClientArea.Controls.Add(this.txtpath);
            this.SoftwareSetting_Fill_Panel.ClientArea.Controls.Add(this.btnsaveupdate);
            this.SoftwareSetting_Fill_Panel.ClientArea.Controls.Add(this.txtemail);
            this.SoftwareSetting_Fill_Panel.ClientArea.Controls.Add(this.txtcontact);
            this.SoftwareSetting_Fill_Panel.ClientArea.Controls.Add(this.txtaddress);
            this.SoftwareSetting_Fill_Panel.ClientArea.Controls.Add(this.lblemail);
            this.SoftwareSetting_Fill_Panel.ClientArea.Controls.Add(this.txtname);
            this.SoftwareSetting_Fill_Panel.ClientArea.Controls.Add(this.lblcontact);
            this.SoftwareSetting_Fill_Panel.ClientArea.Controls.Add(this.lbladdress);
            this.SoftwareSetting_Fill_Panel.ClientArea.Controls.Add(this.lblname);
            this.SoftwareSetting_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.SoftwareSetting_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SoftwareSetting_Fill_Panel.Location = new System.Drawing.Point(8, 32);
            this.SoftwareSetting_Fill_Panel.Name = "SoftwareSetting_Fill_Panel";
            this.SoftwareSetting_Fill_Panel.Size = new System.Drawing.Size(648, 235);
            this.SoftwareSetting_Fill_Panel.TabIndex = 0;
            this.SoftwareSetting_Fill_Panel.PaintClient += new System.Windows.Forms.PaintEventHandler(this.SoftwareSetting_Fill_Panel_PaintClient);
            // 
            // _SoftwareSetting_UltraFormManager_Dock_Area_Left
            // 
            this._SoftwareSetting_UltraFormManager_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SoftwareSetting_UltraFormManager_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._SoftwareSetting_UltraFormManager_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Left;
            this._SoftwareSetting_UltraFormManager_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SoftwareSetting_UltraFormManager_Dock_Area_Left.FormManager = this.ultraFormManager1;
            this._SoftwareSetting_UltraFormManager_Dock_Area_Left.InitialResizeAreaExtent = 8;
            this._SoftwareSetting_UltraFormManager_Dock_Area_Left.Location = new System.Drawing.Point(0, 32);
            this._SoftwareSetting_UltraFormManager_Dock_Area_Left.Name = "_SoftwareSetting_UltraFormManager_Dock_Area_Left";
            this._SoftwareSetting_UltraFormManager_Dock_Area_Left.Size = new System.Drawing.Size(8, 235);
            // 
            // _SoftwareSetting_UltraFormManager_Dock_Area_Right
            // 
            this._SoftwareSetting_UltraFormManager_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SoftwareSetting_UltraFormManager_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._SoftwareSetting_UltraFormManager_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Right;
            this._SoftwareSetting_UltraFormManager_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SoftwareSetting_UltraFormManager_Dock_Area_Right.FormManager = this.ultraFormManager1;
            this._SoftwareSetting_UltraFormManager_Dock_Area_Right.InitialResizeAreaExtent = 8;
            this._SoftwareSetting_UltraFormManager_Dock_Area_Right.Location = new System.Drawing.Point(656, 32);
            this._SoftwareSetting_UltraFormManager_Dock_Area_Right.Name = "_SoftwareSetting_UltraFormManager_Dock_Area_Right";
            this._SoftwareSetting_UltraFormManager_Dock_Area_Right.Size = new System.Drawing.Size(8, 235);
            // 
            // _SoftwareSetting_UltraFormManager_Dock_Area_Top
            // 
            this._SoftwareSetting_UltraFormManager_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SoftwareSetting_UltraFormManager_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._SoftwareSetting_UltraFormManager_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Top;
            this._SoftwareSetting_UltraFormManager_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SoftwareSetting_UltraFormManager_Dock_Area_Top.FormManager = this.ultraFormManager1;
            this._SoftwareSetting_UltraFormManager_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._SoftwareSetting_UltraFormManager_Dock_Area_Top.Name = "_SoftwareSetting_UltraFormManager_Dock_Area_Top";
            this._SoftwareSetting_UltraFormManager_Dock_Area_Top.Size = new System.Drawing.Size(664, 32);
            // 
            // _SoftwareSetting_UltraFormManager_Dock_Area_Bottom
            // 
            this._SoftwareSetting_UltraFormManager_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SoftwareSetting_UltraFormManager_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._SoftwareSetting_UltraFormManager_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Bottom;
            this._SoftwareSetting_UltraFormManager_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SoftwareSetting_UltraFormManager_Dock_Area_Bottom.FormManager = this.ultraFormManager1;
            this._SoftwareSetting_UltraFormManager_Dock_Area_Bottom.InitialResizeAreaExtent = 8;
            this._SoftwareSetting_UltraFormManager_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 267);
            this._SoftwareSetting_UltraFormManager_Dock_Area_Bottom.Name = "_SoftwareSetting_UltraFormManager_Dock_Area_Bottom";
            this._SoftwareSetting_UltraFormManager_Dock_Area_Bottom.Size = new System.Drawing.Size(664, 8);
            // 
            // SoftwareSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 275);
            this.Controls.Add(this.SoftwareSetting_Fill_Panel);
            this.Controls.Add(this._SoftwareSetting_UltraFormManager_Dock_Area_Left);
            this.Controls.Add(this._SoftwareSetting_UltraFormManager_Dock_Area_Right);
            this.Controls.Add(this._SoftwareSetting_UltraFormManager_Dock_Area_Top);
            this.Controls.Add(this._SoftwareSetting_UltraFormManager_Dock_Area_Bottom);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SoftwareSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Software Setting";
            this.Load += new System.EventHandler(this.SoftwareSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtaddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcontact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtemail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).EndInit();
            this.SoftwareSetting_Fill_Panel.ClientArea.ResumeLayout(false);
            this.SoftwareSetting_Fill_Panel.ClientArea.PerformLayout();
            this.SoftwareSetting_Fill_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel lblname;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtname;
        private Infragistics.Win.Misc.UltraLabel lbladdress;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtaddress;
        private Infragistics.Win.Misc.UltraButton btnsaveupdate;
        private Infragistics.Win.Misc.UltraLabel lblcontact;
        private Infragistics.Win.Misc.UltraLabel lblemail;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtcontact;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtemail;
        private Infragistics.Win.Misc.UltraButton btnopen;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtpath;
        private Infragistics.Win.Misc.UltraLabel lbllocation;
        private Infragistics.Win.UltraWinForm.UltraFormManager ultraFormManager1;
        private Infragistics.Win.Misc.UltraPanel SoftwareSetting_Fill_Panel;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _SoftwareSetting_UltraFormManager_Dock_Area_Left;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _SoftwareSetting_UltraFormManager_Dock_Area_Right;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _SoftwareSetting_UltraFormManager_Dock_Area_Top;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _SoftwareSetting_UltraFormManager_Dock_Area_Bottom;
    }
}