using Microsoft.Xna.Framework;//work on enemy class, don't touch draw n update
using Microsoft.Xna.Framework.Graphics;

namespace ArcadeFlyer2D
{
    // The Game itself
    class ArcadeFlyerGame : Game
    {//arcade inherits from game. it can add too
        // Graphics Manager
        private GraphicsDeviceManager graphics;

        // Sprite Drawer
        private SpriteBatch spriteBatch;
        
        // Player Character Graphic
        private Texture2D playerImage;

        private Player player;//brings in Player.cs class and creates object player

        private int screenWidth = 1600;
        public int ScreenWidth
        {
            get { return ScreenWidth; }
            set { screenWidth = value; }
        }

        private int screenHeight = 900;
        public int ScreenHeight
        {
            get { return ScreenHeight; }
            set { screenHeight = value; }
        }

        // Initalized the game
        public ArcadeFlyerGame() //instance to make arcade flyer game
        {
            // Get the graphics
            graphics = new GraphicsDeviceManager(this);

            // Set the height and width
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.ApplyChanges();

            // Set up the directory containing the assets
            Content.RootDirectory = "Content";

            // Make mouse visible
            IsMouseVisible = true;

            
            Vector2 position = new Vector2(0.0f, 0.0f);
            player = new Player(this,position);
        }

        // Initialize
        protected override void Initialize()
        {
            base.Initialize();
        }

        // Load the content for the game, called automatically on start
        protected override void LoadContent()
        {
            //loads content onto the screen, references
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // Create the sprite batch
        }

        // Called every frame
        protected override void Update(GameTime gameTime)
        {   
            player.Update(gameTime);
            // Update base game
            base.Update(gameTime);
        }

        // Draw everything in the game
        protected override void Draw(GameTime gameTime)
        {
            // First clear the screen
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();
            // //Drawing will happen here! need to set how big character is
            // Rectangle playerDestinationRect = new Rectangle(0,0, playerImage.Width, playerImage.Height);
            // spriteBatch.Draw(playerImage, playerDestinationRect, Color.White);

            player.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }
    }
}
