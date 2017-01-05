using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bioshock_Game_XNA
{
    class DeadBodies
    {
        const int deadBody_Position_X = 515;
        const int deadBody_Position_Y = 489;
        public Vector2 dBPosition;
        public Texture2D deadBodyTexture;

        public DeadBodies()
        {
            dBPosition = new Vector2(deadBody_Position_X, deadBody_Position_Y);
        }

        public void LoadContent(ContentManager theContentManager, string deadBody)
        {

            deadBodyTexture = theContentManager.Load<Texture2D>("deadBody");

        }

        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(deadBodyTexture, new Rectangle((int)dBPosition.X, (int)dBPosition.Y, (int)deadBodyTexture.Width, (int)deadBodyTexture.Height), Color.White);

        }
    }
}
