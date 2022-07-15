
namespace WinformAppConsole_
{
    partial class Form1
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
            this.imagePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tstxb_imgSource = new System.Windows.Forms.ToolStripTextBox();
            this.rowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txbRow = new System.Windows.Forms.ToolStripTextBox();
            this.columnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txbCol = new System.Windows.Forms.ToolStripTextBox();
            this.mns_newGame = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlChessBoard = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imagePathToolStripMenuItem,
            this.tstxb_imgSource,
            this.rowToolStripMenuItem,
            this.txbRow,
            this.columnToolStripMenuItem,
            this.txbCol,
            this.mns_newGame});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(881, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // imagePathToolStripMenuItem
            // 
            this.imagePathToolStripMenuItem.Enabled = false;
            this.imagePathToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.imagePathToolStripMenuItem.Name = "imagePathToolStripMenuItem";
            this.imagePathToolStripMenuItem.Size = new System.Drawing.Size(85, 23);
            this.imagePathToolStripMenuItem.Text = "Image path:";
            // 
            // tstxb_imgSource
            // 
            this.tstxb_imgSource.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tstxb_imgSource.Name = "tstxb_imgSource";
            this.tstxb_imgSource.Size = new System.Drawing.Size(300, 23);
            this.tstxb_imgSource.Text = "D:\\Ảnh\\icon-pokemon-go.jpg";
            this.tstxb_imgSource.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tstxb_imgSource_KeyDown);
            // 
            // rowToolStripMenuItem
            // 
            this.rowToolStripMenuItem.Enabled = false;
            this.rowToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.rowToolStripMenuItem.Name = "rowToolStripMenuItem";
            this.rowToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
            this.rowToolStripMenuItem.Text = "Row";
            // 
            // txbRow
            // 
            this.txbRow.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txbRow.Name = "txbRow";
            this.txbRow.Size = new System.Drawing.Size(50, 23);
            this.txbRow.Text = "3";
            this.txbRow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tstxb_imgSource_KeyDown);
            // 
            // columnToolStripMenuItem
            // 
            this.columnToolStripMenuItem.Enabled = false;
            this.columnToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.columnToolStripMenuItem.Name = "columnToolStripMenuItem";
            this.columnToolStripMenuItem.Size = new System.Drawing.Size(61, 23);
            this.columnToolStripMenuItem.Text = "Column";
            // 
            // txbCol
            // 
            this.txbCol.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txbCol.Name = "txbCol";
            this.txbCol.Size = new System.Drawing.Size(50, 23);
            this.txbCol.Text = "3";
            this.txbCol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tstxb_imgSource_KeyDown);
            // 
            // mns_newGame
            // 
            this.mns_newGame.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mns_newGame.Name = "mns_newGame";
            this.mns_newGame.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mns_newGame.Size = new System.Drawing.Size(79, 23);
            this.mns_newGame.Text = "New game";
            this.mns_newGame.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // pnlChessBoard
            // 
            this.pnlChessBoard.Location = new System.Drawing.Point(12, 27);
            this.pnlChessBoard.Name = "pnlChessBoard";
            this.pnlChessBoard.Size = new System.Drawing.Size(857, 372);
            this.pnlChessBoard.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 411);
            this.Controls.Add(this.pnlChessBoard);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mns_newGame;
        private System.Windows.Forms.Panel pnlChessBoard;
        private System.Windows.Forms.ToolStripTextBox tstxb_imgSource;
        private System.Windows.Forms.ToolStripMenuItem imagePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rowToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox txbRow;
        private System.Windows.Forms.ToolStripMenuItem columnToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox txbCol;
    }
}

