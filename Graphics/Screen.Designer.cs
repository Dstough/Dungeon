using System;
using System.Drawing;
using System.Windows.Forms;
partial class Screen
{
    private System.ComponentModel.IContainer components = null;
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        
        base.Dispose(disposing);
    }
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        Program.quit = true;
    }
    
    private void InitializeComponent()
    {
        SuspendLayout();
        Name = "Dungeon";
        Text = "Dungeon";
        ClientSize = new Size(810, 600);
        BackColor = Color.Black;
        Load += new EventHandler(onLoad);
        KeyDown += new KeyEventHandler(onKeyPress);
        FormClosed += new FormClosedEventHandler(onFormClose);
        ResumeLayout(false);
    }
}