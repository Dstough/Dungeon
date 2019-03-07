using System.Drawing;
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

    private void InitializeComponent()
    {
        this.SuspendLayout();
        this.Name = "Dungeon";
        this.Text = "Dungeon";
        this.ClientSize = new System.Drawing.Size(800, 600);
        this.Load += new System.EventHandler(onLoad);
        this.ResumeLayout(false);
    }
}