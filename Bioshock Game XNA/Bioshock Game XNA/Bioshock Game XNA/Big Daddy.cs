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
    class Big_Daddy
    {
        const int Start_Position_X = 125;
        const int Start_Position_Y = 245;
        const int Move_Up = -2;
        const int Move_Down = 2;
        const int Move_Left = -2;
        const int Move_Right = 2;
        const int speedtho = 160;


        const int UP = 1;
        const int Down = 2;
        const int Left = 3;
        const int Right = 4;
        public int direction = 0;
       
        public Vector2 mPosition;
      
        // public string bigDaddy;
        //all the textures used for my big Daddy class
        Texture2D bigDaddyOne;
        Texture2D bigDaddyTemp;
        Texture2D bigDaddyRight;
        Texture2D bigDaddyForward;
        Texture2D bigDaddyUp1;
  
      

        //direction and vectors for speed

        Vector2 mDirection = Vector2.Zero;
        Vector2 mSpeed = Vector2.Zero;

        public Vector2 Mposition
        { 
        get
            {
            return mPosition;
             }
        
        }


        public void Update (GameTime gameTime)
        {

            KeyboardState aCurrentKeyboardState = Keyboard.GetState();

            UpdateMovement(aCurrentKeyboardState);


            KeyboardState keyboard = Keyboard.GetState();
            GamePadState gamePad = GamePad.GetState(PlayerIndex.One);

           bigDaddyOne = bigDaddyForward;

           
            
           //  base.Update(gameTime);

        }

        public void LoadContent (ContentManager theContentManager, string imageForward, string imageRight, string imageLeft, string imageUp)
        {
           // Position = new Vector2(Start_Position_X, Start_Position_Y);
           //base.LoadContent(theContentManager,);


            //loading in all the textures for when my big dadddy is facing different positions 
            bigDaddyOne = theContentManager.Load<Texture2D>(imageForward);
            bigDaddyRight = theContentManager.Load<Texture2D>(imageRight);
            bigDaddyForward = theContentManager.Load<Texture2D>(imageLeft);
            bigDaddyTemp = theContentManager.Load<Texture2D>(imageForward);
            bigDaddyUp1 = theContentManager.Load<Texture2D>(imageUp);

        }

        
        //code used to make the big dadddy face different posoitions and load the different directions in the right places 
          public Big_Daddy()
        {
            mPosition = new Vector2(Start_Position_X, Start_Position_Y);
        }


        public void MoveLeft()
        {

         //   mPosition.X = MathHelper.Clamp(mPosition.X, 0, viewport.Width - bigDaddyOne.Width);
           // mPosition.Y = MathHelper.Clamp(mPosition.Y, 0, viewport.Height - bigDaddyOne.Height);
            mPosition.X = mPosition.X + Move_Left;
            direction = Left;
            bigDaddyOne = bigDaddyForward;
        
        }
        public void MoveRight()
        {
            mPosition.X = mPosition.X + Move_Right;
            bigDaddyOne = bigDaddyRight;


         
            direction = Right;
            
        }
        public void MoveUp()
        {
            mPosition.Y = mPosition.Y + Move_Up;
            direction = UP;
            bigDaddyOne = bigDaddyUp1;
        }
        public void MoveDown()
        {
            mPosition.Y = mPosition.Y + Move_Down;
            direction = Down;
            bigDaddyOne = bigDaddyTemp;

        
        }
     
        
       /* public void LoadContent(ContentManager theContentManager, string bigDaddyOne)
        {

           bigDaddyOne = theContentManager.Load<Texture2D>("BigDaddy-1");
        }*/

        private void UpdateMovement(KeyboardState aCurrentKeyboardState)
        {

        }
          
        
          
            

        

        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(bigDaddyOne, mPosition, Color.White);
        }
        
        /// <summary>
        
     //this is where im returning the posituins and textures and directions
        public Vector2 Position
        {
            get
            {
                return mPosition;
            }
        }
        public Texture2D Texture
        {
            get
            {
                return bigDaddyOne;
            }
        }
        public int Direction
        {
            get
            {
                return direction;
            }
            
        }
        
    }
}
