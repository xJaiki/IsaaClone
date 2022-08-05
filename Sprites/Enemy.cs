using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shooting.Sprites {
    public class Enemy : Sprite {
        public Bullet Bullet;

        public Enemy(Texture2D texture) : base(texture) {
            
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            
            
        }

        
    }
}