using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ArcadeFlyer2D
{
    // The player, controlled by the keyboard
    class Player : Sprite
    {
        // A reference to the game that will contain the player
        private ArcadeFlyerGame root;
        
        // The speed at which the player can move
        private float movementSpeed = 4.0f;

        // Min time between shots
        private float projectileCoolDownTime = 0.5f;

        private float projectileTimer = 0.0f;

        private bool projectileTimerActive = false;
        //current time since shot


        // Initialize a player                          _calls base class sprite below_
        public Player(ArcadeFlyerGame root, Vector2 position) : base(position)
        // call base class sprite
        {
            // Initialize values
            this.root = root;
            this.Position = position;
            this.SpriteWidth = 128.0f;

            // Load the content for the player
            LoadContent();
        }

        // Loads all the assets for the player
        public void LoadContent()
        {
            // Get the MainChar image
            this.SpriteImage = root.Content.Load<Texture2D>("MainChar");
        }

        // Update position based on input
        private void HandleInput(KeyboardState currentKeyboardState)
        {
            // Get all the key states
            bool upKeyPressed = currentKeyboardState.IsKeyDown(Keys.W);
            bool downKeyPressed = currentKeyboardState.IsKeyDown(Keys.S);
            bool leftKeyPressed = currentKeyboardState.IsKeyDown(Keys.A);
            bool rightKeyPressed = currentKeyboardState.IsKeyDown(Keys.D);
            bool spaceKeyPressed = currentKeyboardState.IsKeyDown(Keys.Space);

            // If Up is pressed, decrease position Y
            if (upKeyPressed)
            {
                position.Y -= movementSpeed;
            }
            
            // If Down is pressed, increase position Y
            if (downKeyPressed)
            {
                position.Y += movementSpeed;
            }
            
            // If Left is pressed, decrease position X
            if (leftKeyPressed)
            {
                position.X -= movementSpeed;
            }
            
            // If Right is pressed, increase position X
            if (rightKeyPressed)
            {
                position.X += movementSpeed;
            }
            // If Spapce is pressed, shoot a projectile
            if (spaceKeyPressed && !projectileTimerActive)
            {
                Vector2 projectilePosition;
                Vector2 projectileVelocity;

                projectilePosition = new Vector2(position.X + (SpriteWidth/ 2), position.Y + (SpriteHeight / 2));
                projectileVelocity = new Vector2(10.0f, 0.0f);
                root.FireProjectile(projectilePosition, projectileVelocity);
                projectileTimerActive = true;
                projectileTimer = 0f;

            }
        }

        // Called each frame
        public void Update(GameTime gameTime)
        {   
            // Get current keyboard state
            KeyboardState currentKeyboardState = Keyboard.GetState();

            // Handle any movement input
            HandleInput(currentKeyboardState);

            if (projectileTimerActive)
            {
                projectileTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (projectileTimer > projectileCoolDownTime)
                {
                    projectileTimerActive = false;
                }
            }
        }
    }
}
