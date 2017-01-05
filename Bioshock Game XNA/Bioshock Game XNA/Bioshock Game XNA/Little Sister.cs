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
    class Little_Sister
    {
        const int Start_Position_X = 55;
        const int Start_Position_Y = 177;
        private Vector2 littlesisterPosition ;
        private Texture2D littleSisterTexture;
        public Vector2 littleSisterCentre;
        const int direction = 10;
        const int velocity = 10;

        public void Update(GameTime gameTime, Vector2 playerPosition)
        {

            RandomizeMovement(playerPosition);

            littlesisterPosition = playerPosition ;
            
            KeyboardState aCurrentKeyboardState = Keyboard.GetState();

         //   UpdateMovement(aCurrentKeyboardState);


            KeyboardState keyboard = Keyboard.GetState();
            GamePadState gamePad = GamePad.GetState(PlayerIndex.One);


           //   base.Update(gameTime);
           // iSPosition.X = mPosition.X;
           // iSPosition.Y = mPosition.Y;
 
            
        }
    
             public Little_Sister()
        {
            littlesisterPosition = new Vector2(Start_Position_X, Start_Position_Y);
        }    
        

        public void LoadContent(ContentManager theContentManager, string littleSister)
        {
            // Position = new Vector2(Start_Position_X, Start_Position_Y);
            //base.LoadContent(theContentManager,);

            littleSisterTexture = theContentManager.Load<Texture2D>(littleSister);
        }

        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(littleSisterTexture, littlesisterPosition, Color.White);
        }

        public void RandomizeMovement( Vector2 playerPosition)
        {
            //  v2motion.X = rndGen.Next(-50, 50);
            //v2motion.Y = rndGen.Next(-50, 50);
            //v2motion.Normalize();
            //fSpeed = (float)(rndGen.Next(3, 6));

            if (littlesisterPosition.X < playerPosition.X)
            {
                littlesisterPosition.X += 1;
            }
            if (littlesisterPosition.Y > playerPosition.Y)
            {
                littlesisterPosition.Y -= 1;
            }
            if (littlesisterPosition.X > playerPosition.X)
            {
                littlesisterPosition.X -= 1;
            }
            if (littlesisterPosition.Y < playerPosition.Y)
            {
                littlesisterPosition.Y += 1;
            }

        }
        //this is where im returning the posituins and textures and directions
        public Vector2 Position
        {
            get
            {
                return littlesisterPosition;
            }
            set
            {
                littlesisterPosition = value;
            }

        }
        public Texture2D Texture
        {
            get
            {
                return littleSisterTexture;
            }
        }

    }
}
