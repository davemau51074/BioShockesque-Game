using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Bioshock_Game_XNA
{       //David O Gorman
        //Bioshock XNA game 
        //if firing before moving bullet will not move.
        // this project tokk me 10-12 hours. 
        
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //this is all the the variables,vectors,rectangles and everything needed for my game 

        const int personSpeed = 5;
        const int personDirection = 0;
        int Health = 100;
        int score;
        int viewPortWidth;
        int viewPortHeight;
        int noKill = 0;
        int limit = 6;
        int weaponChooser;
        int bulletSpeed = 5;
        float currentTime = 0f;
     


        //all my bools used for firing
        bool fire = false;
        bool fire2 = false;
        bool fire3 = false;
        bool fire4 = false;
        bool menu = true;
        bool bulletAlive = false;
        bool adamAlive = false;
        bool eve = false;
        bool firstAidALive = false;
        bool gameOver = false;
        Random rnd = new Random();
        Random rndweapon = new Random();
    

        //all my rectangles 
        Rectangle playerRect;
        Rectangle littleSisterRect;
        Rectangle bulletRect;
        Rectangle firstAidRect;
        Rectangle adamRect;
        Rectangle powerUps;
        Rectangle mainFrame;
        //these are my two different arrays 
        Rectangle[] enemyARect;
        Rectangle[] powerArect;


        public Vector2 bigDaddyCentre;
        Vector2 bigDaddyPosition;
        Vector2 FontPos;
        Vector2 Fontpos2;
        Vector2 FontPos3;
        Vector2 firstAidPosition;
        Vector2 bulletPosition;
        Vector2 adamPosition = new Vector2(226, 324);

        Texture2D menuT;
        Texture2D backGroundImage;
        Texture2D fireBall;
        Texture2D bullet;
        Texture2D defaultBullet;
        Texture2D firstAid;
        Texture2D adam;
        Texture2D winter;
        Texture2D electro;
       
        //giving my classes names and making them objects
        Big_Daddy bigDaddyOne;
        DeadBody deadBodyOne;
        Little_Sister littleSisterOne;
        Powerups pickups;
        Splicer splicerEnemyOne;
        SplicerTwo splicerEnemyTwo;
        Splicer[] enemyArray = new Splicer[6];
        Powerups[] powerArray = new Powerups[3];

        SoundEffect backgroundSong;
        SoundEffectInstance mainSong;
        SpriteFont Font1;
      
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
         
            //initializing my classes here 
            bigDaddyOne = new Big_Daddy();
            pickups = new Powerups();
            littleSisterOne = new Little_Sister();
            splicerEnemyOne = new Splicer();
            splicerEnemyTwo = new SplicerTwo();
            deadBodyOne = new DeadBody();
            enemyARect = new Rectangle[6];
            powerArect = new Rectangle[3];

           weaponChooser = rndweapon.Next(0,1);
           firstAidPosition = new Vector2 (310, 400);

           for (int i = 0; i < enemyArray.Length; i++)
           {
               enemyArray[i] = new Splicer();
           }
           for (int i = 0; i < enemyARect.Length; i++)
           {
               enemyARect[i] = new Rectangle();
           }

           for (int i = 0; i < powerArray.Length; i++)
           {
               powerArray[i] = new Powerups();
           }

           for (int i = 0; i < powerArect.Length; i++)
           {
               powerArect[i] = new Rectangle();
           }
          bulletPosition.X = bigDaddyOne.mPosition.X;
          bulletPosition.Y = bigDaddyOne.mPosition.Y;

          viewPortWidth = graphics.GraphicsDevice.Viewport.Width;
          viewPortHeight = graphics.GraphicsDevice.Viewport.Height;
         // graphics.IsFullScreen = true;

       //  graphics.ApplyChanges();
        
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            bigDaddyOne.LoadContent(this.Content, "bigDaddyForward", "BigDaddyRight" , "bigDaddy-1", "bigDaddyUp1");    
            mainFrame= new Rectangle(0,0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height );
            

            //this is where im loading in the the textures 
            backGroundImage = Content.Load<Texture2D>("Floor1");
            menuT = Content.Load<Texture2D>("menuScreen");
            fireBall = Content.Load<Texture2D>("Fireball");
            littleSisterOne.LoadContent(this.Content, "LittleSisterStanding");
            pickups.LoadContent(this.Content, "eve", "winterShock", "electroShock");
            electro = Content.Load<Texture2D>("electricBolt");
            winter = Content.Load<Texture2D>("frostBullet");
      
            for (int i = 0; i < enemyArray.Length; i++)
            {
                enemyArray[i].LoadContent(this.Content, "meelesplicer");
            }

            deadBodyOne.LoadContent(this.Content, "deadBody");

            firstAid = Content.Load<Texture2D>("First_Aid_Kit");

            adam = Content.Load<Texture2D>("Adam");


            //these are where i load the textures for my arrays 
            for (int i = 0; i < enemyArray.Length; i++)
            {
                enemyArray[i].LoadContent(this.Content, "meelesplicer");
            }

            for (int i = 0; i < powerArray.Length; i++)
            {
                powerArray[i].LoadContent(this.Content, "eve", "winterShock", "electroShock");
            }

            spriteBatch = new SpriteBatch(GraphicsDevice);
            Font1 = Content.Load<SpriteFont>("SpriteFont1");
            FontPos = new Vector2(150,30);
            Fontpos2 = new Vector2(650, 30);
            FontPos3 = new Vector2(100, 450);

            bullet = Content.Load<Texture2D>("LeftBullet");
            defaultBullet = bullet;


            //this is where i loud in the background music for my level
          backgroundSong = Content.Load<SoundEffect>("PianoBackGround");
          mainSong = backgroundSong.CreateInstance();

            ///the song is then looped because of this
          mainSong.IsLooped = true;

            // TODO: use this.Content to load your game content here
            //mainSong.Play();
        }
       // graphics.GraphicsDevice.Viewport.Width / 3, graphics.GraphicsDevice.Viewport.Height / 2
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        bool increaseTimer = false;

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {


            //this is wheree im creating the rectangles for my objects 
            playerRect = new Rectangle((int)bigDaddyOne.Position.X, (int)bigDaddyOne.Position.Y, bigDaddyOne.Texture.Width, bigDaddyOne.Texture.Height);
            littleSisterRect = new Rectangle((int)littleSisterOne.Position.X, (int)littleSisterOne.Position.Y, littleSisterOne.Texture.Width, littleSisterOne.Texture.Height);
            bulletRect = new Rectangle((int)bulletPosition.X, (int)bulletPosition.Y, bullet.Width, bullet.Height);
            adamRect = new Rectangle((int)adamPosition.X, (int)adamPosition.Y, adam.Width, adam.Height);
            powerUps = new Rectangle ((int) pickups.Position.X, (int)pickups.Position.Y, pickups.Texture.Width, pickups.Texture.Height);
            firstAidRect = new Rectangle((int)firstAidPosition.X, (int)firstAidPosition.Y, firstAid.Width, firstAid.Height);

            //these are where the rectangles are made for the  objects in my arrays 
            for (int i = 0; i < enemyARect.Length; i++ )
            {
                enemyARect[i] = new Rectangle((int)enemyArray[i].Position.X, (int)enemyArray[i].Position.Y, (int)enemyArray[i].Texture.Width, (int)enemyArray[i].Texture.Height);
            }
              
            for (int i = 0; i < powerArect.Length; i++)
            {
                powerArect[i] = new Rectangle((int)powerArray[i].Position.X, (int)powerArray[i].Position.Y, (int)powerArray[i].Texture.Width, (int)powerArray[i].Texture.Height);
            }
            GamePadState gamePad = GamePad.GetState(PlayerIndex.One);

            bigDaddyPosition = bigDaddyOne.Position;
       
          
            // Allows the game to exit

            KeyboardState aCurrentkeyBoardState = Keyboard.GetState();
            GamePadState padState1 = GamePad.GetState(PlayerIndex.One);
            GamePadState currentState = GamePad.GetState(PlayerIndex.One);

            for (int i = 0; i < enemyARect.Length; i++)
            {
                if (enemyARect[i].Intersects(playerRect))
                {
                    Health -= 10;
                    enemyArray[i].splicerEnemyOne = enemyArray[i].splicerEnemyOneAtacking;
                    enemyArray[i].Position = new Vector2(615, 189);
                   noKill = 0;
                }
            }
            
            //Creating the health bar for the player
            if (Health <= 0)
            {
               gameOver = true;
            }
            //the code used to move the player
            if (aCurrentkeyBoardState.IsKeyDown(Keys.Left) ||
              gamePad.DPad.Left == ButtonState.Pressed == true)
            {
                bigDaddyOne.MoveLeft();
              //bulletDirection = west;
            }

            else if (aCurrentkeyBoardState.IsKeyDown(Keys.Right) ||
              gamePad.DPad.Right == ButtonState.Pressed == true)
            {
                bigDaddyOne.MoveRight();
            }

            else if (aCurrentkeyBoardState.IsKeyDown(Keys.Down) ||
              gamePad.DPad.Down == ButtonState.Pressed == true)
            {
                bigDaddyOne.MoveDown();
            }

            if (aCurrentkeyBoardState.IsKeyDown(Keys.Up) ||
              gamePad.DPad.Up == ButtonState.Pressed == true)
            {
                bigDaddyOne.MoveUp();
             //   bulletDirection = north;
            }

            if (!bulletAlive && (aCurrentkeyBoardState.IsKeyDown(Keys.Space) ||
              gamePad.Buttons.A == ButtonState.Pressed))
            {

                //bulletAlive = true;
                if (bulletAlive == false)
                {
                    bulletSpeed = 10;
                    bulletPosition.X = bigDaddyOne.mPosition.X;
                    bulletPosition.Y = bigDaddyOne.mPosition.Y;
                    //bulletPosition.X = bulletDirection;

                    bulletAlive = true;
                }
                //this is the code used to make the bullet fire in the direction that the player is facing. 
                if (bulletAlive && bigDaddyOne.direction == 1)
                {
                    fire = true;
                }
                else if (bulletAlive && bigDaddyOne.direction == 2)
                {
                    fire2 = true;
                }
                else if (bulletAlive && bigDaddyOne.direction == 3)
                {
                    fire3 = true;
                }
                else if (bulletAlive && bigDaddyOne.direction == 4)
                {
                    fire4 = true;
                }

                if (menu == true)
                {
                menu = false;
                }

            }

            //the code used to fire the actual bullet. Its done using Bools that when equalling true fires the bullet 
            if (fire == true )
            {
                bulletPosition.Y -= bulletSpeed;
            }
            else if (fire2 == true)
            {
                bulletPosition.Y += bulletSpeed;
            }
            else if (fire3 == true)
            {
                bulletPosition.X -= bulletSpeed;
            }
            else if (fire4 == true)
            {
                bulletPosition.X += bulletSpeed;
            }       

     
      //ths allows for the enemy Array to folllow the player 
            for (int i = 0; i < enemyArray.Length; i++)
            {
                enemyArray[i].Update(gameTime, bigDaddyPosition);
            }
            littleSisterOne.Update(gameTime, bigDaddyOne.mPosition);

            //yes... i used alot of bools for my bullets and the collison with the viewports. I know there were 
            //plenty of easier ways but unfortunatly with game jam i didnt have time.
            if (bulletPosition.X < 0)
            {
                fire = false;
                fire2 = false;
                fire3 = false;
                fire4 = false;
                bulletAlive = false;
            }
            if (bulletPosition.X > viewPortWidth)
            {

                fire = false;
                fire2 = false;
                fire3 = false;
                fire4 = false;
                bulletAlive = false;
            }
            if (bulletPosition.Y < 0)

            {

                fire = false;
                fire2 = false;
                fire3 = false;
                fire4 = false;
                bulletAlive = false;
            }
            if (bulletPosition.Y > viewPortHeight)
            {

                fire = false;
                fire2 = false;
                fire3 = false;
                fire4 = false;
                bulletAlive = false;
            }

            //this is the code used to set the bullet to false with eacjh individual enemy 
            for (int i = 0; i < enemyArray.Length; i++)
            {
                if (bulletRect.Intersects(enemyARect[i]))
                {
                    bulletAlive = false;

                    int side = rnd.Next(1, 5);
                    if (side == 1)
                    {
                        enemyArray[i].Position = new Vector2(-20, rnd.Next(0, viewPortHeight));
                    }
                    else if (side == 2)
                    {
                        enemyArray[i].Position = new Vector2(rnd.Next(0,viewPortWidth), -20);
                    }
                    else if (side == 3)
                    {
                        enemyArray[i].Position = new Vector2(rnd.Next(0, viewPortWidth), viewPortHeight-20);
                    }
                    else if (side == 4)
                    {
                        enemyArray[i].Position = new Vector2(viewPortWidth-20, rnd.Next(0, viewPortHeight));
                    }


                    score += 1;
                    noKill += 1;
                }
            }
       
            if (bulletAlive == false)
            {
                bulletPosition = new Vector2(-1000, -1000);
            }
        
            if (aCurrentkeyBoardState.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }
            if (firstAidALive)
            {
                if (playerRect.Intersects(firstAidRect))
                {
                    firstAidALive = false;
                    Health += 20;
                    firstAidPosition = new Vector2(-1000, -1000);
                    //firstAidALive = false;
                    noKill = 0;
                }
            }
           
            if (adamAlive)
            {
                if (playerRect.Intersects(adamRect))
                {
                    adamAlive = false;
                    increaseTimer = true;
                    // personSpeed = 10; 
                  
                    defaultBullet = fireBall;
                    noKill = 0;
                }
            }

           
        


            if (eve == true)
            {
                if (playerRect.Intersects(powerUps))
                {
                     // gameOver = true;
                    //     defaultBullet = electro;
                    weaponChooser = rndweapon.Next(0, 2); 
                    if (weaponChooser == 0)
                    {
                        defaultBullet = electro;
                    }
                    if (weaponChooser == 1)
                    {
                        defaultBullet = winter;
                    }
                    eve = false;
                    increaseTimer = true;
                    noKill = 0;
                 


                }
               
                if (increaseTimer)
                {
                    currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }




                if (currentTime >= limit)
                {
                    // counter = 0;
                    defaultBullet = bullet;
                }
            }

           // bigDaddyOne.mPosition.X = MathHelper.Clamp(bigDaddyOne.mPosition.X, 50, Window.ClientBounds.Width- 50);
           // bigDaddyOne.mPosition.X = MathHelper.Clamp(bigDaddyOne.mPosition.Y, 50, Window.ClientBounds.Height-50);




                base.Update(gameTime);
        }
              
       

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);

       
          //  if (menu == false)
           // {
                spriteBatch.Begin();

                if (menu == true)
                {
                    spriteBatch.Draw(menuT ,mainFrame, Color.Black);
                }


            //a bool used to make the game end 
                if (gameOver == false)
                {
                    spriteBatch.Draw(backGroundImage, mainFrame, Color.White);

                    string output = "Health:" + Health;
                    string output2 = "score:" + score;
                    string output3 = "Kill streak: " + noKill;

                    // Find the center of the string
                    Vector2 FontOrigin = Font1.MeasureString(output) / 2;
                    // Draw the string
                    spriteBatch.DrawString(Font1, output, FontPos, Color.Yellow,
                        0, FontOrigin, 2.0f, SpriteEffects.None, 0.5f);

                    spriteBatch.DrawString(Font1, output2, Fontpos2, Color.Red,
                     0, FontOrigin, 2.0f, SpriteEffects.None, 0.5f);

                    spriteBatch.DrawString(Font1, output3, FontPos3, Color.Blue, 
                        0, FontOrigin, 1.0f, SpriteEffects.None, 1f);

                    //this is where i draw the sprites 
                    bigDaddyOne.Draw(this.spriteBatch);
                    littleSisterOne.Draw(this.spriteBatch);
                  //  pickups.Draw(this.spriteBatch);
                    for (int i = 0; i < enemyArray.Length; i++)
                    {
                        enemyArray[i].Draw(this.spriteBatch);
                    }



                    if (noKill >=4)
                    {
                        eve = true;
                        for (int i = 0; i < powerArray.Length; i++)
                        {
                            powerArray[i].Draw(this.spriteBatch);
                        }
                    }

                    deadBodyOne.Draw(this.spriteBatch);

                    if (adamAlive == true)
                    {
                        spriteBatch.Draw(adam, adamPosition, Color.White);
                    }

                    if (firstAidALive == true)
                    {
                        firstAidPosition = new Vector2(400, 400);
                    }
                    if (bulletAlive == true)
                    {
                        spriteBatch.Draw(defaultBullet, bulletPosition, Color.White);
                        //bulletPosition.X = mPosition.X;
                        //bulletPosition.Y = mPosition.Y;
                    }

                    if (noKill >= 5 )
                    {
                        firstAidALive = true;
                        spriteBatch.Draw(firstAid, firstAidPosition, Color.White);
                        
                    }
                    else
                        firstAidALive = false;


                    
                    if (noKill >= 15)
                    {
                            adamAlive = true;
                            spriteBatch.Draw(adam, adamPosition, Color.White);
                            
                   }
                    else
                        adamAlive = false;

                }

                else
                {
                    GraphicsDevice.Clear(Color.Black);
                    spriteBatch.DrawString(Font1, "Game Over", new Vector2(325, 200), Color.Red);
                    spriteBatch.DrawString(Font1, "Your score is: " + score.ToString(), new Vector2(275, 250), Color.White);

                }

           // }
        
                spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
