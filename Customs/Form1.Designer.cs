namespace Customs
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            dataGridViewMain = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            toolStrip1 = new ToolStrip();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            stateToolStripMenuItem = new ToolStripMenuItem();
            batchToolStripMenuItem = new ToolStripMenuItem();
            batchTypeToolStripMenuItem = new ToolStripMenuItem();
            processToolStripMenuItem = new ToolStripMenuItem();
            scheduleToolStripMenuItem = new ToolStripMenuItem();
            shipmentToolStripMenuItem = new ToolStripMenuItem();
            customsToolStripMenuItem = new ToolStripMenuItem();
            toolStripButton1 = new ToolStripButton();
            contextMenuStrip2 = new ContextMenuStrip(components);
            ((System.ComponentModel.ISupportInitialize)dataGridViewMain).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewMain
            // 
            dataGridViewMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMain.Dock = DockStyle.Fill;
            dataGridViewMain.Location = new Point(0, 0);
            dataGridViewMain.Name = "dataGridViewMain";
            dataGridViewMain.RowHeadersWidth = 51;
            dataGridViewMain.RowTemplate.Height = 29;
            dataGridViewMain.Size = new Size(570, 421);
            dataGridViewMain.TabIndex = 4;
            dataGridViewMain.CellContentClick += dataGridViewMain_CellContentClick;
            dataGridViewMain.CellValueChanged += dataGridViewMain_CellValueChanged;
            dataGridViewMain.EditingControlShowing += dataGridViewMain_EditingControlShowing;
            dataGridViewMain.UserAddedRow += dataGridViewMain_UserAddedRow;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Bottom;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1, toolStripButton1 });
            toolStrip1.Location = new Point(0, 394);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(570, 27);
            toolStrip1.TabIndex = 5;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { stateToolStripMenuItem, batchToolStripMenuItem, batchTypeToolStripMenuItem, processToolStripMenuItem, scheduleToolStripMenuItem, shipmentToolStripMenuItem, customsToolStripMenuItem });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(85, 24);
            toolStripDropDownButton1.Text = "Таблицы";
            toolStripDropDownButton1.Click += toolStripDropDownButton1_Click;
            // 
            // stateToolStripMenuItem
            // 
            stateToolStripMenuItem.Name = "stateToolStripMenuItem";
            stateToolStripMenuItem.Size = new Size(160, 26);
            stateToolStripMenuItem.Text = "State";
            stateToolStripMenuItem.Click += stateToolStripMenuItem_Click;
            // 
            // batchToolStripMenuItem
            // 
            batchToolStripMenuItem.Name = "batchToolStripMenuItem";
            batchToolStripMenuItem.Size = new Size(160, 26);
            batchToolStripMenuItem.Text = "Batch";
            batchToolStripMenuItem.Click += batchToolStripMenuItem_Click;
            // 
            // batchTypeToolStripMenuItem
            // 
            batchTypeToolStripMenuItem.Name = "batchTypeToolStripMenuItem";
            batchTypeToolStripMenuItem.Size = new Size(160, 26);
            batchTypeToolStripMenuItem.Text = "BatchType";
            batchTypeToolStripMenuItem.Click += batchTypeToolStripMenuItem_Click;
            // 
            // processToolStripMenuItem
            // 
            processToolStripMenuItem.Name = "processToolStripMenuItem";
            processToolStripMenuItem.Size = new Size(160, 26);
            processToolStripMenuItem.Text = "Process";
            processToolStripMenuItem.Click += processToolStripMenuItem_Click;
            // 
            // scheduleToolStripMenuItem
            // 
            scheduleToolStripMenuItem.Name = "scheduleToolStripMenuItem";
            scheduleToolStripMenuItem.Size = new Size(160, 26);
            scheduleToolStripMenuItem.Text = "Schedule";
            scheduleToolStripMenuItem.Click += scheduleToolStripMenuItem_Click;
            // 
            // shipmentToolStripMenuItem
            // 
            shipmentToolStripMenuItem.Name = "shipmentToolStripMenuItem";
            shipmentToolStripMenuItem.Size = new Size(160, 26);
            shipmentToolStripMenuItem.Text = "Shipment";
            shipmentToolStripMenuItem.Click += shipmentToolStripMenuItem_Click;
            // 
            // customsToolStripMenuItem
            // 
            customsToolStripMenuItem.Name = "customsToolStripMenuItem";
            customsToolStripMenuItem.Size = new Size(160, 26);
            customsToolStripMenuItem.Text = "Customs";
            customsToolStripMenuItem.Click += customsToolStripMenuItem_Click;
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(208, 24);
            toolStripButton1.Text = "Вычислить время проверки";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.ImageScalingSize = new Size(20, 20);
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(61, 4);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(570, 421);
            Controls.Add(toolStrip1);
            Controls.Add(dataGridViewMain);
            Name = "Form1";
            Text = "Экспорт товаров";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewMain).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridViewMain;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem stateToolStripMenuItem;
        private ToolStripMenuItem batchToolStripMenuItem;
        private ToolStripMenuItem batchTypeToolStripMenuItem;
        private ToolStripMenuItem processToolStripMenuItem;
        private ToolStripMenuItem scheduleToolStripMenuItem;
        private ToolStripMenuItem shipmentToolStripMenuItem;
        private ToolStripMenuItem customsToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripButton toolStripButton1;
    }
}