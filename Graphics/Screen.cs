using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

public partial class Screen : Form
{
    Size cellSize;
    Thread thread;
    Graphics buffer;
    Graphics screen;
    Bitmap image;

    public Screen()
    {
        InitializeComponent();
    }
    private void onLoad(object sender, EventArgs e)
    {
        cellSize = new Size(this.ClientSize.Width / Config.screenWidth, this.ClientSize.Height / Config.roomHeight);
        image = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
        buffer = Graphics.FromImage(image);
        screen = CreateGraphics();
        thread = new Thread(draw);
        thread.IsBackground = true;
        thread.Start();
    }
    protected override void OnResizeEnd(EventArgs e)
    {
        image = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
        buffer = Graphics.FromImage(image);
    }
    public void draw()
    {
        while (!Program.quit)
        {

        }
    }

    void drawRoom()
    {

    }
}