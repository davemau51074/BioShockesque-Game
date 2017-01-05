using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Bioshock_Game_XNA
{
    class DeadBody
    {
        const int deadBody_Position_X = 100;
        const int deadBody_Position_Y = 200;
        public Vector2 dBPosition;
        public Texture2D deadBodyTexture;
        //Vector2 deadBody;
      //  Texture2D deadBodyTexture;



        public DeadBody()
        {
            dBPosition = new Vector2(deadBody_Position_X, deadBody_Position_Y);
        }

        public void LoadContent(ContentManager theContentManager, string deadBody)
        {

            deadBodyTexture = theContentManager.Load<Texture2D>("deadBody");

        }


        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(deadBodyTexture, dBPosition, Color.White);

        }

    }
}
