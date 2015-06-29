using SokobanPC.ScreenManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SokobanPC
{
    public class LevelScreen : Screen
    {
        private Texture2D text;
        private Level level;
        private Player player;

        private KeyboardState oldKeyboardState;
        private KeyboardState newKeyboardState;

        public LevelScreen(GraphicsDevice device, ContentManager content)
            : base(device, content, "level")
        {
            text = content.Load<Texture2D>("sb_texture");
            player = new Player(text);
            level = new Level(text,player);
            oldKeyboardState = Keyboard.GetState();
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 oldPlayerPosition = player.Position;
            InputPC();
            if (level.isWall(player.Position ))
            {
                player.Position = oldPlayerPosition;
            }
            else if (!level.isEmpty(player.Position))
            {
                //box on place
                Vector2 NextToBox = new Vector2(player.Position.X,player.Position.Y) + player.MoveVector;

                if (!level.isEmpty(NextToBox) || level.isWall(NextToBox))
                {
                    player.Position = oldPlayerPosition;
                }
                else
                {
                    //new box place
                    // Box.position  = NextToBox
                }

            }

        }

        private void InputPC()
        {
            newKeyboardState = Keyboard.GetState();
            
            if (newKeyboardState.IsKeyDown(Keys.W) && !oldKeyboardState.IsKeyDown(Keys.W))
            {
                player.moveUp();
            }
            else if (newKeyboardState.IsKeyDown(Keys.A) && !oldKeyboardState.IsKeyDown(Keys.A))
            {
                player.moveLeft();
            }
            else if (newKeyboardState.IsKeyDown(Keys.S) && !oldKeyboardState.IsKeyDown(Keys.S))
            {
                player.moveDown();
            }
            else if (newKeyboardState.IsKeyDown(Keys.D) && !oldKeyboardState.IsKeyDown(Keys.D))
            {
                player.moveRight();
            }
            oldKeyboardState = newKeyboardState;
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
