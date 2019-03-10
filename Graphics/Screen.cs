using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

public partial class Screen : Form
{
    int cellSize;
    Thread thread;
    Bitmap image;
    Font font;
    SolidBrush brush;
    Graphics buffer;
    Graphics screen;

    public Screen()
    {
        InitializeComponent();
    }

    private void onLoad(object sender, EventArgs e)
    {
        OnResizeEnd(e);
        brush = new SolidBrush(Color.Gray);
        thread = new Thread(draw);
        thread.IsBackground = true;
        thread.Start();
    }

    protected override void OnResizeEnd(EventArgs e)
    {
        cellSize = ClientSize.Width / Config.screenWidth;
        image = new Bitmap(ClientSize.Width, ClientSize.Height);
        font = new Font(FontFamily.GenericMonospace, cellSize, FontStyle.Regular);
        buffer = Graphics.FromImage(image);
        screen = CreateGraphics();
    }

    protected override void OnResize(EventArgs e)
    {
        if (WindowState == FormWindowState.Maximized)
            OnResizeEnd(e);
    }

    public void draw()
    {
        while (!Program.quit)
        {
            buffer.Clear(Color.Black);
            drawMessage();
            drawRoom();
            drawHud();
            screen.DrawImage(image, 0, 0);
        }
    }

    public void drawMessage()
    {
        var hudText = "Welcome To Dungeon.";
        buffer.DrawString(hudText.trim(Config.screenWidth), font, brush, 0, 1 * cellSize);
    }

    void drawRoom()
    {
        for (var y = 0; y < Config.roomHeight; y++)
        {
            for (var x = 0; x < Config.screenWidth; x++)
            {
                var item = Program.dungeon.levels[Program.dungeon.currentLevel].objects.Where(obj => obj.position.x == x && obj.position.y == y).FirstOrDefault();
                var actor = Program.dungeon.levels[Program.dungeon.currentLevel].actors.Where(obj => obj.position.x == x && obj.position.y == y).FirstOrDefault();
                Random rnd = new Random();
                var charToDraw = "•";

                if (actor != null)
                {
                    if (actor.backgroundColor != Color.Empty)
                    {
                        brush.Color = actor.backgroundColor;
                        buffer.FillRectangle(brush, x * cellSize,y * cellSize + Config.messageHeight * cellSize, cellSize, cellSize);
                    }
                    brush.Color = actor.forgroundColor;
                    charToDraw = actor.sprite.ToString();
                }
                else if (item != null)
                {
                    if (item.backgroundColor != Color.Empty)
                    {
                        brush.Color = item.backgroundColor;
                        buffer.FillRectangle(brush, x * cellSize, y * cellSize + Config.messageHeight * cellSize, cellSize, cellSize);
                    }
                    brush.Color = item.forgroundColor;
                    charToDraw = item.sprite.ToString();
                }

                buffer.DrawString(charToDraw, font, brush, x * cellSize, y * cellSize + Config.messageHeight * cellSize);
                brush.Color = Color.White;
            }
        }
    }

    public void drawHud()
    {

    }
}