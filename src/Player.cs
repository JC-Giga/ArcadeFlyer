using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ArcadeFlyer2D
{
    class Player
    {   //defined data we want to contain in data class. private fields.
        private float spriteWidth;
        private ArcadeFlyerGame root;
        private Vector2 position;
        private Texture2D spriteImage;

        public float SpriteHeight
        {   //to get property and not let it change original variable use get. Game player need this though. caapitalized for reason.
            get{
                float scale = spriteWidth / spriteImage.Width; //hard coded width is not the the pixels of the original
                return spriteImage.Height * scale;
            }//set would change it for game

        }
            //properties should always be public
        public Rectangle PostionRectangle
        {
            get{
                Rectangle rec = new Rectangle((int)position.X, (int)position.Y, (int)spriteWidth, (int)SpriteHeight);
                return rec;
            }

        }

        public Player(ArcadeFlyerGame root, Vector2 position) //construction doesn't return. should be same name as class
        {   //need game for the players and need postion for player to be displayed. This dot is way to tell compilier to use this root in Arcade
            this.root = root;//or Root just above equals root.
            this.position = position;
            this.spriteWidth = 128.0f;

            LoadContent();

        }
        public void LoadContent()//use this method to have objects use their own graphics
        {
            this.spriteImage = root.Content.Load<Texture2D>("MainChar");
        }

        public void Update(GameTime gameTime)//to do define this
        {

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteImage, PostionRectangle, Color.White);
        }



    }


}