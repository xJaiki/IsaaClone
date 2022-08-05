using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shooting.Sprites {
    public class Player : Sprite {
        public Bullet Bullet;

        public Player(Texture2D texture) : base(texture) {
            
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _previousKey = _currentKey;
            _currentKey = Keyboard.GetState();

            timer++;

            if (_currentKey.IsKeyDown(Keys.A))
            {
                Position.X -= LinearVelocity;
            }
            if (_currentKey.IsKeyDown(Keys.D))
            {
                Position.X += LinearVelocity;
            }
            if (_currentKey.IsKeyDown(Keys.W))
            {
                Position.Y -= LinearVelocity;
            }
            if (_currentKey.IsKeyDown(Keys.S))
            {
                Position.Y += LinearVelocity;
            }


            if (_currentKey.IsKeyDown(Keys.Up)){
                AddBullet(sprites, 0, -1);
            } else if (_currentKey.IsKeyDown(Keys.Down))
            {
                AddBullet(sprites, 0, 1);
            } else if (_currentKey.IsKeyDown(Keys.Left))
            {
                AddBullet(sprites, -1, 0);
            } else if (_currentKey.IsKeyDown(Keys.Right))
            {
                AddBullet(sprites, 1, 0);
            }

            


        }

        private void AddBullet(List<Sprite> sprites, int x, int y)
        {
            if(timer > 25 ){
                var bullet = Bullet.Clone() as Bullet;
                bullet.Direction = new Vector2(x, y);
                bullet.Position = this.Position;
                bullet.LinearVelocity = this.LinearVelocity * 1.5f;
                bullet.LifeSpan = 1.2f;
                bullet.Parent = this;

                sprites.Add(bullet);

                timer=0;
            }
            
        }
    }
}