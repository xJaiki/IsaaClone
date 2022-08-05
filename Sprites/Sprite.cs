using System.Collections.Generic;
using System.Security.AccessControl;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shooting.Sprites {
    public class Sprite {
        protected Texture2D _texture;
        protected KeyboardState _currentKey;
        protected KeyboardState _previousKey;

        public Vector2 Position;
        public Vector2 Origin;
        public float LinearVelocity = 3f;
        public Vector2 Direction;

        public Sprite Parent;
        public float LifeSpan = 4f;
        public bool IsRemoved = false;
        public int timer = 25;

        public Sprite(Texture2D texture) {
            _texture = texture;
            Origin = new Vector2(_texture.Width / 2, _texture.Height / 2);
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites) {

        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(_texture, Position, null, Color.White, 0f, Origin, 1f, SpriteEffects.None, 0f);
        }

        public object Clone() {
            return this.MemberwiseClone();
        }
    }
}