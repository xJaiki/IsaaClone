using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Shooting.Sprites;

namespace Shooting;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private List<Sprite> _sprites;

    private SpriteFont _font;

    

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        
        _font = Content.Load<SpriteFont>("Font");

        // TODO: use this.Content to load your game content here

        var playerTexture = Content.Load<Texture2D>("Jaiki");
        var enemyTexture = Content.Load<Texture2D>("Enemy");

        _sprites = new List<Sprite>(){
            new Enemy(enemyTexture){
                Position = new Vector2(300, 300)
            },
            new Player(playerTexture){
                Position = new Vector2(100, 100),
                Bullet = new Bullet(Content.Load<Texture2D>("Bullet"))
            }
        };
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        

        foreach (var sprite in _sprites.ToArray())
        {
            sprite.Update(gameTime, _sprites);
        }

        for(int i=0; i<_sprites.Count; i++)
        {
            if (_sprites[i].IsRemoved)
            {
                _sprites.RemoveAt(i);
                i--;
            }
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        _spriteBatch.Begin();

        foreach (var sprite in _sprites)
        {
            sprite.Draw(_spriteBatch);
        }
        //write timer 
        _spriteBatch.DrawString(_font, "Timer: " + _sprites[0].timer, new Vector2(10, 10), Color.White);

    
        _spriteBatch.End();


        base.Draw(gameTime);
    }
}
