namespace AlienDecryptor {
    partial class MainForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            splitContainer = new SplitContainer();
            dataGridView = new DataGridView();
            Index = new DataGridViewTextBoxColumn();
            Symbol = new DataGridViewImageColumn();
            Anzahl = new DataGridViewTextBoxColumn();
            Translate = new DataGridViewImageColumn();
            Letter = new DataGridViewTextBoxColumn();
            pictureBox = new PictureBox();
            menuStrip1 = new MenuStrip();
            dateiToolStripMenuItem = new ToolStripMenuItem();
            beendenToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            hilfeAnzeigenToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 24);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(dataGridView);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.AutoScroll = true;
            splitContainer.Panel2.BackColor = SystemColors.ActiveCaption;
            splitContainer.Panel2.Controls.Add(pictureBox);
            splitContainer.Size = new Size(800, 426);
            splitContainer.SplitterDistance = 309;
            splitContainer.TabIndex = 2;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { Index, Symbol, Anzahl, Translate, Letter });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(0, 0);
            dataGridView.Name = "dataGridView";
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(309, 426);
            dataGridView.TabIndex = 0;
            dataGridView.KeyPress += dataGridView_KeyPress;
            // 
            // Index
            // 
            Index.HeaderText = "Index";
            Index.Name = "Index";
            Index.ReadOnly = true;
            Index.Width = 50;
            // 
            // Symbol
            // 
            Symbol.HeaderText = "Symbol";
            Symbol.Name = "Symbol";
            Symbol.Width = 50;
            // 
            // Anzahl
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            Anzahl.DefaultCellStyle = dataGridViewCellStyle1;
            Anzahl.HeaderText = "Anzahl";
            Anzahl.Name = "Anzahl";
            Anzahl.ReadOnly = true;
            Anzahl.Width = 50;
            // 
            // Translate
            // 
            Translate.HeaderText = "Translate";
            Translate.Name = "Translate";
            Translate.ReadOnly = true;
            Translate.Width = 55;
            // 
            // Letter
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Letter.DefaultCellStyle = dataGridViewCellStyle2;
            Letter.HeaderText = "Letter";
            Letter.Name = "Letter";
            Letter.ReadOnly = true;
            Letter.Width = 50;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(0, 0);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(309, 255);
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.MouseDown += pictureBox_MouseDown;
            pictureBox.MouseUp += pictureBox_MouseUp;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { dateiToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            dateiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { beendenToolStripMenuItem });
            dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            dateiToolStripMenuItem.Size = new Size(46, 20);
            dateiToolStripMenuItem.Text = "Datei";
            // 
            // beendenToolStripMenuItem
            // 
            beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            beendenToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            beendenToolStripMenuItem.Size = new Size(162, 22);
            beendenToolStripMenuItem.Text = "Beenden";
            beendenToolStripMenuItem.Click += beendenToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { hilfeAnzeigenToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // hilfeAnzeigenToolStripMenuItem
            // 
            hilfeAnzeigenToolStripMenuItem.Name = "hilfeAnzeigenToolStripMenuItem";
            hilfeAnzeigenToolStripMenuItem.ShortcutKeys = Keys.F1;
            hilfeAnzeigenToolStripMenuItem.Size = new Size(168, 22);
            hilfeAnzeigenToolStripMenuItem.Text = "Hilfe anzeigen";
            hilfeAnzeigenToolStripMenuItem.Click += hilfeAnzeigenToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer);
            Controls.Add(menuStrip1);
            Name = "MainForm";
            Text = "Alien-Decryptor";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer splitContainer;
        private PictureBox pictureBox;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn Index;
        private DataGridViewImageColumn Symbol;
        private DataGridViewTextBoxColumn Anzahl;
        private DataGridViewImageColumn Translate;
        private DataGridViewTextBoxColumn Letter;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem hilfeAnzeigenToolStripMenuItem;
        private ToolStripMenuItem dateiToolStripMenuItem;
        private ToolStripMenuItem beendenToolStripMenuItem;
    }
}