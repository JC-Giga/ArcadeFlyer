using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ArcadeFlyer2D
{

    class Enemy
    {

        private ArcadeFlyerGame root;
        private Vector2 position;
        private Texture2D spriteImage;
        private float spriteWidth;

        private Vector2 velocity;

        public float SpriteHeight
        {
            get
            {
                float scale = spriteWidth / spriteImage.Width;
                return spriteImage.Height * scale;
            }
        }
        public Rectangle PositionRectangle
        {
            get
            {
                Rectangle rec = new Rectangle((int)position.X, (int)position.Y, (int)spriteWidth, (int)SpriteHeight);
                return rec;
            }

        }

        // Initialize an enemy
        public Enemy(ArcadeFlyerGame root, Vector2 position)
        {
            // Initialize values
            this.root = root;
            this.position = position;
            this.spriteWidth = 128.0f;
            this.velocity = new Vector2(-1.0f, 5.0f);

            // Load the content for this enemy
            LoadContent();
        }

        // Loads all the assets for this enemy
        public void LoadContent()
        {
            // Get the Enemy image
            this.spriteImage = root.Content.Load<Texture2D>("Enemy");
        }

        // Called each frame
        public void Update(GameTime gameTime)
        {
            // Handle movement
            position += velocity;

            // Bounce on top and bottom
            if (position.Y < 0 || position.Y > (root.ScreenHeight - SpriteHeight))
            {
                velocity.Y *= -1;
            }
        }

        // Draw this enemy
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Use the Sprite Batch to draw
            spriteBatch.Draw(spriteImage, PositionRectangle, Color.White);
        }



    }




}