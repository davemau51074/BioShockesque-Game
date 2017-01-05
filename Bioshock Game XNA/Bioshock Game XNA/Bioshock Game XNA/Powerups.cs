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
    class Powerups
    {



        private  Texture2D eve;
        private Texture2D winter;
        private Texture2D electro;

        public Vector2 evePosition = new Vector2 (250,250);
        public Vector2 wintPosition = new Vector2(340, 440);
        public Vector2 elecPosition = new Vector2(390, 440);

       // public pickups [] pickupssArray = new pickups[5];

        public void LoadContent(ContentManager theContentManager, string eveTexture, string winterTexture, string electroTexture)
        {


            eve = theContentManager.Load<Texture2D>(eveTexture);
            winter = theContentManager.Load<Texture2D>(winterTexture) ;
            electro = theContentManager.Load<Texture2D>(electroTexture);
    
        }


        public void Update()
        {

            //for (int i = 0; i < length; i++)
            //{
                
            //}


        
        }
        public Vector2 Position
        {
            get
            {
                return evePosition;
            }
            set
            {
                evePosition = value;
            }
        }
        public Texture2D Texture
        {
            get
            {
                return eve;
            }
        }

        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(eve, evePosition, Color.White);
            theSpriteBatch.Draw(winter, wintPosition, Color.White);
            theSpriteBatch.Draw(electro, elecPosition, Color.White);

        }










    }
}
