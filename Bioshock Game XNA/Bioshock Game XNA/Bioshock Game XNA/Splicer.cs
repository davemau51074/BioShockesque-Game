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
    class Splicer
    {

        //diffeent variablew for the enemy 
        const int Splicer_Position_X = 615;
        const int Splicer_Position_Y = 189;
        public Vector2 spPosition;
        public Texture2D splicerEnemyOne;
        const int direction = 10;
        const int velocity = 10;
        public Texture2D splicerEnemyOneAtacking;
        static Random rndGen = new Random();
        



        public void Update(GameTime gameTime,Vector2 playerPosition)
        {


            RandomizeMovement(playerPosition);
          //  littleSister= iSPositon;
            
            KeyboardState aCurrentKeyboardState = Keyboard.GetState();

         //   UpdateMovement(aCurrentKeyboardState);


            KeyboardState keyboard = Keyboard.GetState();
            GamePadState gamePad = GamePad.GetState(PlayerIndex.One);


            //  base.Update(gameTime);
          //  spPosition.X = mPosition.X;
           // spPosition.Y = mPosition.Y;

            

            
        }
    
             public Splicer()
        {
            spPosition = new Vector2(Splicer_Position_X, Splicer_Position_Y);
        }


             public void LoadContent(ContentManager theContentManager, string splicer)
             {
                 // Position = new Vector2(Start_Position_X, Start_Position_Y);
                 //base.LoadContent(theContentManager,);

                 splicerEnemyOne = theContentManager.Load<Texture2D>("meelesplicer");
                 splicerEnemyOneAtacking = theContentManager.Load<Texture2D>("meleeplicerAttacking");
                // splicerEnemyOneAtacking = theContentManager.Load<Texture2D>("meleesplicerAttacking");
             }
        

        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(splicerEnemyOne, spPosition, Color.White);

        }

        //creating random movement for my enemy class
        public void RandomizeMovement(Vector2 playerPosition )
        {
          
            //to allow the the splicer to follow the player
            if(spPosition.X < playerPosition.X)
            {
                spPosition.X += 1;
            }
            if (spPosition.Y > playerPosition.Y)
            {
                spPosition.Y -= 1;
            }
            if (spPosition.X > playerPosition.X)
            {
                spPosition.X -= 1;
            }
            if (spPosition.Y < playerPosition.Y)
            {
                spPosition.Y += 1;
            }

        }

        public void update()
        {

            


        }
        //this is where im returning the posituins and textures and directions
        public Vector2 Position
        {
            get
            {
                return spPosition;
            }
            set
            {
                spPosition = value;
            }

        }
        public Texture2D Texture
        {
            get
            {
                return splicerEnemyOne;
            }
        }
    }
}
