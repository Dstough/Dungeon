using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        thread = new Thread(draw)
        {
            IsBackground = true
        };
        thread.Start();
    }

    private void onFormClose(object sender, FormClosedEventArgs e)
    {
        Program.quit = true;
    }

    private void onKeyPress(object sender, KeyEventArgs e)
    {
        if (e.Alt && e.KeyCode == Keys.Enter)
        {
            if (TopMost)
            {
                TopMost = false;
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
            }
            else
            {
                TopMost = true;
                FormBorderStyle = FormBorderStyle.Sizable;
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
            OnResizeEnd(e);
        }
        else
        {
            Program.hero.input = e;
        }
    }

    protected override void OnResizeEnd(EventArgs e)
    {
        cellSize = ClientSize.Width / Config.screenWidth;
        image = new Bitmap(ClientSize.Width, ClientSize.Height);
        font = new Font("Courier New", cellSize * 2, GraphicsUnit.Pixel);
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
            //drawMessage();
            //drawRoom();
            //drawHud();

            for (int i = 0, x = 0, y = 0; i < Program.tileSet.Glyphs.Length; i++)
            {
                if (i != 0 && i % 16 == 0)
                {
                    x = 0;
                    y += cellSize;
                }
                buffer.DrawImage(Resize(Program.tileSet.Glyphs[i],cellSize,cellSize), x, y);
                x += cellSize;
            }

            screen.DrawImage(image, 0, 0);
        }
    }

    public Image Resize(Image image, int newWidth, int maxHeight, bool onlyResizeIfWider = true)
    {
        if (onlyResizeIfWider && image.Width <= newWidth) newWidth = image.Width;

        var newHeight = image.Height * newWidth / image.Width;
        if (newHeight > maxHeight)
        {
            // Resize with height instead  
            newWidth = image.Width * maxHeight / image.Height;
            newHeight = maxHeight;
        }

        var res = new Bitmap(newWidth, newHeight);

        using (var graphic = Graphics.FromImage(res))
        {
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = CompositingQuality.HighQuality;
            graphic.DrawImage(image, 0, 0, newWidth, newHeight);
        }

        return res;
    }

    public void drawMessage()
    {
        var messageText = "X:" + Program.hero.position.x + ", Y:" + Program.hero.position.y;
        buffer.DrawString(messageText.trim(Config.screenWidth), font, brush, 0, cellSize);
    }

    void drawRoom()
    {
        for (var y = 0; y < Config.roomHeight; y++)
            for (var x = 0; x < Config.screenWidth; x++)
            {
                if (Program.hero.position.DistanceTo(new Position(x, y)) > 15.5)
                    continue;

                var item = Program.dungeon.levels[Program.dungeon.currentLevel].objects.Where(obj => obj.position.x == x && obj.position.y == y).FirstOrDefault();
                var actor = Program.dungeon.levels[Program.dungeon.currentLevel].actors.Where(obj => obj.position.x == x && obj.position.y == y).FirstOrDefault();
                var charToDraw = "·";
                brush.Color = Color.Gray;

                if (actor != null)
                {
                    if (actor.backgroundColor != Color.Empty)
                    {
                        brush.Color = actor.backgroundColor;
                        buffer.DrawString("█", font, brush, x * cellSize, y * (cellSize + cellSize / 2) + Config.messageHeight * cellSize);
                    }
                    brush.Color = actor.forgroundColor;
                    charToDraw = actor.sprite.ToString();
                }
                else if (item != null)
                {
                    if (item.backgroundColor != Color.Empty)
                    {
                        brush.Color = item.backgroundColor;
                        buffer.DrawString("█", font, brush, x * cellSize, y * (cellSize + cellSize / 2) + Config.messageHeight * cellSize);
                    }
                    brush.Color = item.forgroundColor;
                    charToDraw = item.sprite.ToString();
                }

                buffer.DrawString(charToDraw, font, brush, x * cellSize, y * (cellSize + cellSize / 2) + Config.messageHeight * cellSize);
                brush.Color = Color.Gray;
            }
    }

    public void drawHud()
    {

    }
}