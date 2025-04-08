using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace pongEspacial;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;

    Paddle paddle;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = Globals.WIDTH;
        _graphics.PreferredBackBufferHeight = Globals.HEIGHT;
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        paddle = new Paddle(); 

        base.Initialize();
    }

    protected override void LoadContent()
    {
        Globals.spriteBatch = new SpriteBatch(GraphicsDevice);

        Globals.background = Content.Load<Texture2D>("Background_Space");
        Globals.shiled = Content.Load<Texture2D>("escudo");
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        paddle.update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        Globals.spriteBatch.Begin();
        
        Globals.spriteBatch.Draw(Globals.background, new Rectangle(0, 0, 1280, 720),Color.White);
        paddle.Draw();

        Globals.spriteBatch.End();  

        base.Draw(gameTime);
    }
}
