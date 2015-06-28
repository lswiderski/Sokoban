using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SokobanPC.ScreenManager
{
    public class Screen
    {
        protected GraphicsDevice device = null;
        protected ContentManager content = null;
        protected SpriteBatch spriteBatch;
        protected Camera2D camera;

        /// <summary>
        /// Screen Constructor
        /// </summary>
        /// <param name="name">Must be unique since when you use ScreenManager is per name</param>
        public Screen(GraphicsDevice _device, ContentManager _content, string name)
        {

            Name = name;
            this.device = _device;
            content = _content;

        }

        ~Screen()
        {
        }

        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Virtual Function that's called when entering a Screen
        /// override it and add your own initialization code
        /// </summary>
        /// <returns></returns>
        public virtual bool Init()
        {
            spriteBatch = new SpriteBatch(device);
            camera = new Camera2D();
            return true;
        }

        /// <summary>
        /// Virtual Function that's called when exiting a Screen
        /// override it and add your own shutdown code
        /// </summary>
        /// <returns></returns>
        public virtual void Shutdown()
        {
        }

        /// <summary>
        /// Override it to have access to elapsed time
        /// </summary>
        /// <param name="elapsed">GameTime</param>
        public virtual void Update(GameTime gameTime)
        {


        }

        public virtual void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.End();
        }

    }
}