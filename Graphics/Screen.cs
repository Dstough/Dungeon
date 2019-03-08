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
        brush = new SolidBrush(Color.White);
        thread = new Thread(draw);
        thread.IsBackground = true;
        thread.Start();
    }

    protected override void OnResizeEnd(EventArgs e)
    {
        cellSize = ClientSize.Width / Config.screenWidth;
        image = new Bitmap(ClientSize.Width, ClientSize.Height);
        font = new Font("DungeonFont", cellSize, FontStyle.Regular);
        buffer = Graphics.FromImage(image);
        screen = CreateGraphics();
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

    public static void drawMessage()
    {
    }

    void drawRoom()
    {
        for (var y = 0; y < Config.roomHeight; y++)
        {
            for (var x = 0; x < Config.screenWidth; x++)
            {
                var item = Program.dungeon.levels[Program.dungeon.currentLevel].objects.Where(obj => obj.position.x == x && obj.position.y == y).FirstOrDefault();
                var actor = Program.dungeon.levels[Program.dungeon.currentLevel].actors.Where(obj => obj.position.x == x && obj.position.y == y).FirstOrDefault();
                var charToDraw = "☺";

                //TODO: draw a rectangle at the position if there is a background color set;
                if (actor != null)
                {
                    charToDraw = actor.sprite.ToString();
                    brush.Color = actor.forgroundColor;
                }
                else if (item != null)
                {
                    charToDraw = item.sprite.ToString();
                    brush.Color = item.forgroundColor;
                }

                buffer.DrawString(charToDraw, font, brush, x * cellSize, y * cellSize);
            }
        }
    }

    public void drawHud()
    {
        var hudText = "Player HUD";
        buffer.DrawString(hudText.trim(Config.screenWidth), font, brush, 0, Config.roomHeight);
    }
}