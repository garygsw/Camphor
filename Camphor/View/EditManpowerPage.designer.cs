namespace Camphor.View {
    partial class EditManpowerPage {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditManpowerPage));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.organiserListView = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.markAsUnpaidButton = new System.Windows.Forms.Button();
            this.markAsPaidButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.addStudentButton = new System.Windows.Forms.Button();
            this.deleteStudentButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.organiserTab = new System.Windows.Forms.TabPage();
            this.facilitatorTab = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.facilitatorListView = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.participantTab = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.participantListView = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.organiserTab.SuspendLayout();
            this.facilitatorTab.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.participantTab.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.organiserListView);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 292);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Student List";
            // 
            // organiserListView
            // 
            this.organiserListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.Description,
            this.columnHeader1});
            this.organiserListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.organiserListView.FullRowSelect = true;
            this.organiserListView.GridLines = true;
            this.organiserListView.Location = new System.Drawing.Point(6, 20);
            this.organiserListView.Name = "organiserListView";
            this.organiserListView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.organiserListView.Size = new System.Drawing.Size(330, 265);
            this.organiserListView.TabIndex = 17;
            this.organiserListView.UseCompatibleStateImageBehavior = false;
            this.organiserListView.View = System.Windows.Forms.View.Details;
            this.organiserListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.organiserListView_ColumnClick);
            this.organiserListView.SelectedIndexChanged += new System.EventHandler(this.organiserListView_SelectedIndexChanged);
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 141;
            // 
            // Description
            // 
            this.Description.Text = "Matric Number";
            this.Description.Width = 108;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Paid";
            this.columnHeader1.Width = 76;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 328);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(490, 22);
            this.statusStrip1.TabIndex = 32;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(211, 17);
            this.toolStripStatusLabel1.Text = "Welcome to the Edit Manpower Menu.";
            // 
            // markAsUnpaidButton
            // 
            this.markAsUnpaidButton.Enabled = false;
            this.markAsUnpaidButton.Location = new System.Drawing.Point(6, 110);
            this.markAsUnpaidButton.Name = "markAsUnpaidButton";
            this.markAsUnpaidButton.Size = new System.Drawing.Size(107, 23);
            this.markAsUnpaidButton.TabIndex = 31;
            this.markAsUnpaidButton.Text = "Mark as &Unpaid";
            this.markAsUnpaidButton.UseVisualStyleBackColor = true;
            this.markAsUnpaidButton.Click += new System.EventHandler(this.markAsUnpaidButton_Click);
            // 
            // markAsPaidButton
            // 
            this.markAsPaidButton.Enabled = false;
            this.markAsPaidButton.Location = new System.Drawing.Point(6, 81);
            this.markAsPaidButton.Name = "markAsPaidButton";
            this.markAsPaidButton.Size = new System.Drawing.Size(107, 23);
            this.markAsPaidButton.TabIndex = 30;
            this.markAsPaidButton.Text = "Mark as &Paid";
            this.markAsPaidButton.UseVisualStyleBackColor = true;
            this.markAsPaidButton.Click += new System.EventHandler(this.markAsPaidButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(6, 272);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(107, 23);
            this.closeButton.TabIndex = 27;
            this.closeButton.Text = "&Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // addStudentButton
            // 
            this.addStudentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addStudentButton.Location = new System.Drawing.Point(6, 23);
            this.addStudentButton.Name = "addStudentButton";
            this.addStudentButton.Size = new System.Drawing.Size(107, 23);
            this.addStudentButton.TabIndex = 22;
            this.addStudentButton.Text = "&Add Student";
            this.addStudentButton.UseVisualStyleBackColor = true;
            this.addStudentButton.Click += new System.EventHandler(this.addStudentButton_Click);
            // 
            // deleteStudentButton
            // 
            this.deleteStudentButton.Enabled = false;
            this.deleteStudentButton.Location = new System.Drawing.Point(6, 52);
            this.deleteStudentButton.Name = "deleteStudentButton";
            this.deleteStudentButton.Size = new System.Drawing.Size(107, 23);
            this.deleteStudentButton.TabIndex = 24;
            this.deleteStudentButton.Text = "D&elete";
            this.deleteStudentButton.UseVisualStyleBackColor = true;
            this.deleteStudentButton.Click += new System.EventHandler(this.deleteStudentButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.organiserTab);
            this.tabControl.Controls.Add(this.facilitatorTab);
            this.tabControl.Controls.Add(this.participantTab);
            this.tabControl.Location = new System.Drawing.Point(3, 1);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(359, 325);
            this.tabControl.TabIndex = 1;
            // 
            // organiserTab
            // 
            this.organiserTab.Controls.Add(this.groupBox1);
            this.organiserTab.Location = new System.Drawing.Point(4, 22);
            this.organiserTab.Name = "organiserTab";
            this.organiserTab.Padding = new System.Windows.Forms.Padding(3);
            this.organiserTab.Size = new System.Drawing.Size(351, 299);
            this.organiserTab.TabIndex = 0;
            this.organiserTab.Text = "Organiser List";
            this.organiserTab.UseVisualStyleBackColor = true;
            // 
            // facilitatorTab
            // 
            this.facilitatorTab.Controls.Add(this.groupBox3);
            this.facilitatorTab.Location = new System.Drawing.Point(4, 22);
            this.facilitatorTab.Name = "facilitatorTab";
            this.facilitatorTab.Padding = new System.Windows.Forms.Padding(3);
            this.facilitatorTab.Size = new System.Drawing.Size(351, 299);
            this.facilitatorTab.TabIndex = 1;
            this.facilitatorTab.Text = "Facilitator List";
            this.facilitatorTab.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.facilitatorListView);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(342, 292);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Student List";
            // 
            // facilitatorListView
            // 
            this.facilitatorListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.facilitatorListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.facilitatorListView.FullRowSelect = true;
            this.facilitatorListView.GridLines = true;
            this.facilitatorListView.Location = new System.Drawing.Point(6, 20);
            this.facilitatorListView.Name = "facilitatorListView";
            this.facilitatorListView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.facilitatorListView.Size = new System.Drawing.Size(330, 265);
            this.facilitatorListView.TabIndex = 17;
            this.facilitatorListView.UseCompatibleStateImageBehavior = false;
            this.facilitatorListView.View = System.Windows.Forms.View.Details;
            this.facilitatorListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.facilitatorListView_ColumnClick);
            this.facilitatorListView.SelectedIndexChanged += new System.EventHandler(this.facilitatorListView_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 141;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Matric Number";
            this.columnHeader3.Width = 108;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Paid";
            this.columnHeader4.Width = 76;
            // 
            // participantTab
            // 
            this.participantTab.Controls.Add(this.groupBox4);
            this.participantTab.Location = new System.Drawing.Point(4, 22);
            this.participantTab.Name = "participantTab";
            this.participantTab.Padding = new System.Windows.Forms.Padding(3);
            this.participantTab.Size = new System.Drawing.Size(351, 299);
            this.participantTab.TabIndex = 2;
            this.participantTab.Text = "Participant List";
            this.participantTab.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.participantListView);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(342, 292);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Student List";
            // 
            // participantListView
            // 
            this.participantListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.participantListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.participantListView.FullRowSelect = true;
            this.participantListView.GridLines = true;
            this.participantListView.Location = new System.Drawing.Point(6, 20);
            this.participantListView.Name = "participantListView";
            this.participantListView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.participantListView.Size = new System.Drawing.Size(330, 265);
            this.participantListView.TabIndex = 17;
            this.participantListView.UseCompatibleStateImageBehavior = false;
            this.participantListView.View = System.Windows.Forms.View.Details;
            this.participantListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.participantListView_ColumnClick);
            this.participantListView.SelectedIndexChanged += new System.EventHandler(this.participantListView_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Name";
            this.columnHeader5.Width = 141;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Matric Number";
            this.columnHeader6.Width = 108;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Paid";
            this.columnHeader7.Width = 76;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.deleteStudentButton);
            this.groupBox2.Controls.Add(this.markAsUnpaidButton);
            this.groupBox2.Controls.Add(this.addStudentButton);
            this.groupBox2.Controls.Add(this.closeButton);
            this.groupBox2.Controls.Add(this.markAsPaidButton);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(364, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(120, 303);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Management";
            // 
            // EditManpowerPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 350);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditManpowerPage";
            this.Text = "Edit Manpower";
            this.groupBox1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.organiserTab.ResumeLayout(false);
            this.facilitatorTab.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.participantTab.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView organiserListView;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.Button addStudentButton;
        private System.Windows.Forms.Button deleteStudentButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button markAsUnpaidButton;
        private System.Windows.Forms.Button markAsPaidButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage organiserTab;
        private System.Windows.Forms.TabPage facilitatorTab;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView facilitatorListView;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TabPage participantTab;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView participantListView;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}