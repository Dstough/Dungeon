using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

public partial class Screen : Form
{
    Size cellSize;
    Thread thread;
    Bitmap image;
    Font font;
    Graphics buffer;
    Graphics screen;

    public Screen()
    {
        InitializeComponent();
    }

    private void onLoad(object sender, EventArgs e)
    {
        OnResizeEnd(e);
        thread = new Thread(draw);
        thread.IsBackground = true;
        thread.Start();
    }

    protected override void OnResizeEnd(EventArgs e)
    {
        cellSize = new Size(ClientSize.Width / Config.screenWidth, ClientSize.Height / Config.roomHeight);
        image = new Bitmap(ClientSize.Width, ClientSize.Height);
        font = new Font("DungeonFont", cellSize.Width, FontStyle.Regular);
        buffer = Graphics.FromImage(image);
        screen = CreateGraphics();
    }

    public void draw()
    {
        while (!Program.quit)
        {
            buffer.Clear(Color.Blue);
            drawRoom();
            screen.DrawImage(image,0,0);
        }
    }

    void drawRoom()
    {
        
    }
}