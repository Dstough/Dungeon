using System.Drawing;
using System.Windows.Forms;
partial class Screen
{
    private System.ComponentModel.IContainer components = null;
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        Program.quit = true;
    }
    
    private void InitializeComponent()
    {
        this.SuspendLayout();
        this.Name = "Dungeon";
        this.Text = "Dungeon";
        this.ClientSize = new Size(800, 600);
        this.BackColor = Color.Black;
        this.Load += new System.EventHandler(onLoad);
        this.ResumeLayout(false);
    }
}