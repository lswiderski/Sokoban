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
        private AIPlayer aiplayer;
        private List<Box> boxes;
        private LastAction lastAction;
        private LevelList levels;
        private int currentLevel;
        private KeyboardState oldKeyboardState;
        private KeyboardState newKeyboardState;

        private Vector2 oldPlayerPosition;

        public LevelScreen(GraphicsDevice device, ContentManager content)
            : base(device, content, "level")
        {
            text = content.Load<Texture2D>("sb_texture");
            boxes = new List<Box>();
            player = new Player(text);
            aiplayer = new AIPlayer(ref player);
            levels = new LevelList();
            level = new Level(text, player, ref boxes);
            oldKeyboardState = Keyboard.GetState();
            lastAction = new LastAction();

            currentLevel = 0;
            level.LoadLevel(levels.GetLEvel(currentLevel));

        }

        public override void Update(GameTime gameTime)
        {
            oldPlayerPosition = player.Position;
            InputPC();
            aiplayer.Update(gameTime);
            if (oldPlayerPosition != player.Position)
            {
                PlayerPropablyChangedHisPosition();
            }

            foreach (Box box in boxes)
            {
                box.IsActive = level.getType(box.Position) == BLOCK_TYPE.Goal ? true : false;

            }

        }

        private void PlayerPropablyChangedHisPosition()
        {
            bool flagAnyBoxWasMoved = false;

            if (level.isWall(player.Position))
            {
                player.Position = oldPlayerPosition;
            }
            else if (!level.isEmpty(player.Position))
            {
                //box on place
                Vector2 NextToBox = player.Position + player.MoveVector;

                if (!level.isEmpty(NextToBox) || level.isWall(NextToBox))
                {
                    player.Position = oldPlayerPosition;
                }
                else
                {
                    //new box place
                    foreach (Box box in boxes)
                    {
                        if (box.Position == player.Position)
                        {
                            flagAnyBoxWasMoved = MoveBox(box, NextToBox, flagAnyBoxWasMoved);
                        }
                    }
                }
            }
            if (oldPlayerPosition != player.Position)
            {
                SetLastActionOnAvailable(flagAnyBoxWasMoved);
            }
        }

        private void SetLastActionOnAvailable(bool flagAnyBoxWasMoved)
        {
            if (!flagAnyBoxWasMoved)
            {
                lastAction.IsBoxMoved = false;
            }
            lastAction.IsAvailable = true;
            lastAction.MoveVector = player.MoveVector;
        }

        private bool MoveBox(Box box, Vector2 NextToBox, bool flagAnyBoxWasMoved)
        {
            box.Position = NextToBox;
            level.SetEmpty(NextToBox, false);
            level.SetEmpty(player.Position);

            flagAnyBoxWasMoved = SetBoxMovedFlag(box);
            return flagAnyBoxWasMoved;
        }

        private bool SetBoxMovedFlag(Box box)
        {
            bool flagAnyBoxWasMoved;
            lastAction.IsBoxMoved = true;
            lastAction.BoxID = box.ID;
            flagAnyBoxWasMoved = true;
            return flagAnyBoxWasMoved;
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

            else if (newKeyboardState.IsKeyDown(Keys.B) && !oldKeyboardState.IsKeyDown(Keys.B))
            {

                BackInTime();
            }
            else if (newKeyboardState.IsKeyDown(Keys.Q) && !oldKeyboardState.IsKeyDown(Keys.Q))
            {

                aiplayer.Run(level.SolvePath, new TimeSpan(0, 0, 0, 0, 100));
            }
            else if (newKeyboardState.IsKeyDown(Keys.E) && !oldKeyboardState.IsKeyDown(Keys.E))
            {
                LoadNextLevel();
            }
            oldKeyboardState = newKeyboardState;
        }

        private void LoadNextLevel()
        {
            currentLevel = currentLevel < levels.Amount() -1 ? ++currentLevel : 0;
            level.LoadLevel(levels.GetLEvel(currentLevel));
        }
        private void BackInTime()
        {
            if (lastAction.IsAvailable)
            {
                UndoPlayer();
                if (lastAction.IsBoxMoved)
                {
                    FindBoxAndTurnItBack();
                }
                ResetLastActionAndPlayerPosition();
            }
        }

        private void UndoPlayer()
        {
            player.Position -= lastAction.MoveVector;
        }

        private void ResetLastActionAndPlayerPosition()
        {
            lastAction = new LastAction();
            oldPlayerPosition = player.Position;
        }

        private void FindBoxAndTurnItBack()
        {
            foreach (Box box in boxes)
            {
                if (box.ID == lastAction.BoxID)
                {
                    BackBox(box);
                    break;
                }
            }
        }

        private void BackBox(Box box)
        {
            level.SetEmpty(box.Position);
            box.Position -= lastAction.MoveVector;
            level.SetEmpty(box.Position, false);
        }


        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            spriteBatch.Begin();
            level.Draw(gameTime, spriteBatch);
            player.Draw(gameTime, spriteBatch);
            foreach (Box box in boxes)
            {
                box.Draw(gameTime, spriteBatch, text);
            }
            spriteBatch.End();
        }

    }
}
