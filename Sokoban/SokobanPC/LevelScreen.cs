using SokobanPC.ScreenManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SokobanPC
{
    public class LevelScreen : Screen
    {
        private Texture2D text;
        private Level level;
        private Player player;
        public LevelScreen(GraphicsDevice device, ContentManager content)
            : base(device, content, "level")
        {
            text = content.Load<Texture2D>("sb_texture");
            player = new Player(text);
            level = new Level(text,player);
        }

        public override void Update(GameTime gameTime)
        {
        }


        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            spriteBatch.Begin();
            level.Draw(gameTime,spriteBatch);
            player.Draw(gameTime,spriteBatch);
            spriteBatch.End();
        }

    }
}
