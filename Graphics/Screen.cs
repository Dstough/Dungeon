using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;

namespace Dungeon.Graphics
{
    internal class Screen : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private TileSet tileSet;
        private int gridWidth, gridHeight, cellWidth, cellHeight;

        public Screen()
        {
            graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += Resize;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var fileStream = new FileStream("Graphics/Runeset_24x24.png", FileMode.Open);
            tileSet = new TileSet(Texture2D.FromStream(GraphicsDevice, fileStream));

            fileStream.Close();
            fileStream.Dispose();

            gridWidth = Program.dungeon.levels[Program.dungeon.currentLevel].width;
            gridHeight = Program.dungeon.levels[Program.dungeon.currentLevel].height;
            cellWidth = GraphicsDevice.Viewport.Bounds.Width / gridWidth;
            cellHeight = GraphicsDevice.Viewport.Bounds.Height / gridHeight;

            base.LoadContent();
        }

        protected void Resize(object sender, EventArgs e)
        {
            gridWidth = Program.dungeon.levels[Program.dungeon.currentLevel].width;
            gridHeight = Program.dungeon.levels[Program.dungeon.currentLevel].height;
            cellWidth = GraphicsDevice.Viewport.Bounds.Width / gridWidth;
            cellHeight = GraphicsDevice.Viewport.Bounds.Height / gridHeight;
        }

        protected override void Update(GameTime gameTime)
        {
            var state = Keyboard.GetState();

            if (((state.IsKeyDown(Keys.LeftAlt) || state.IsKeyDown(Keys.RightAlt)) && state.IsKeyDown(Keys.Enter)) || state.IsKeyDown(Keys.F11))
            {
                graphics.IsFullScreen = !graphics.IsFullScreen;
                graphics.ApplyChanges();
            }

            if (state.IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();

            Program.quit = true;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            // TODO: Add your drawing code here


            spriteBatch.Begin();

            for (int i = 0, x = 0, y = 0; i < tileSet.Glyphs.Length; i++, x += cellWidth)
            {
                if (i != 0 && i % 16 == 0)
                {
                    x = 0;
                    y += cellHeight;
                }

                spriteBatch.Draw(tileSet.Source,
                    new Rectangle(x, y, cellWidth, cellHeight),
                    tileSet.Glyphs[i],
                    Color.White
                );
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
