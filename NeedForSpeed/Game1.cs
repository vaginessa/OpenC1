using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using PlatformEngine;
using NFSEngine;

namespace Carmageddon
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 768;
            _graphics.PreferMultiSampling = true;
            //_graphics.IsFullScreen = true;


            _graphics.MinimumVertexShaderProfile = ShaderProfile.VS_2_0;
            _graphics.MinimumPixelShaderProfile = ShaderProfile.PS_2_0;

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            Engine.Initialize(this, _graphics);

            //enable per-pixel transparency
            Engine.Instance.Device.RenderState.AlphaTestEnable = true;
            Engine.Instance.Device.RenderState.ReferenceAlpha = 50;
            Engine.Instance.Device.RenderState.AlphaFunction = CompareFunction.Greater;

            //IsFixedTimeStep = false;
            //ChaseCamera cam = new ChaseCamera();
            //cam.DesiredPositionOffset = new Vector3(0.0f, 10.0f, 50.0f);
            ////cam.LookAtOffset = new Vector3(0.0f, 150.0f, 0.0f);
            //cam.Reset();

            //JiggleGame.JigCamera jigCam = new JiggleGame.JigCamera(this);
            //jigCam.Position = Vector3.Down * 7 + Vector3.Backward * 30.0f;
            Engine.Instance.Mode = new PlayGameMode();
            
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            Engine.Instance.ContentManager.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //check for exit
            if (Engine.Instance.Input.WasPressed(Keys.Escape))
            {
                Exit();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            _graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}