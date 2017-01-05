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
    class SplicerTwo
    {

        private  Vector2 spPosition2;
        private Texture2D splicerEnemyTwo;
        static Random rndGen2 = new Random();

       public void LoadContent(ContentManager theContentManager, string splicer)

        {
                 splicerEnemyTwo = theContentManager.Load<Texture2D>("meelesplicer");


      }


        public void Update(GameTime gameTime, Rectangle playerPosition)
        {
            randomizeMovement(playerPosition);
        }

        private void randomizeMovement(Rectangle littleSisterPosition)

        {
            if (spPosition2.X < littleSisterPosition.X)
            {
                spPosition2.X += 2;
            }
            if (spPosition2.Y > littleSisterPosition.Y)
            {
                spPosition2.Y -= 2;
            }
            if (spPosition2.X > littleSisterPosition.X)
            {
                spPosition2.X -= 2;
            }
            if (spPosition2.Y < littleSisterPosition.Y)
            {
                spPosition2.Y += 2;
            }

        }
        //where uI return the needed positions and directions 
        public void Draw(SpriteBatch theSpriteBatch)
        {

            theSpriteBatch.Draw(splicerEnemyTwo, spPosition2, Color.White);

        }
        public Vector2 Position
        {
            get
            {
                return spPosition2;
            }
            set
            {
                spPosition2 = value;
            }

        }
        public Texture2D Texture
        {
            get
            {
                return splicerEnemyTwo;
            }
        }
    }
}
