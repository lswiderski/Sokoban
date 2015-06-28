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
        public LevelScreen(GraphicsDevice device, ContentManager content)
            : base(device, content, "level")
        {
            
        }

        public override void Update(GameTime gameTime)
        {
        }


        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            spriteBatch.Begin();
            spriteBatch.End();
        }

    }
}
