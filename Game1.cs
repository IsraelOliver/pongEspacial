using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace pongEspacial;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;

    Paddle paddle;
    Paddle paddle2;
    Ball ball;
    SpriteFont font;

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
        paddle = new Paddle(false); 
        paddle2 = new Paddle(true);
        ball = new Ball();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        Globals.spriteBatch = new SpriteBatch(GraphicsDevice);

        Globals.background = Content.Load<Texture2D>("Background_Space");
        Globals.shiled = Content.Load<Texture2D>("escudo");
        Globals.ball = Content.Load<Texture2D>("meteoro");
        font = Content.Load<SpriteFont>("Score");
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        paddle.update(gameTime);
        paddle2.update(gameTime);
        ball.update(gameTime, paddle, paddle2);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        Globals.spriteBatch.Begin();
        
        Globals.spriteBatch.Draw(Globals.background, new Rectangle(0, 0, 1280, 720),Color.White);
        paddle.Draw();
        paddle2.Draw();
        ball.Draw();

        Globals.spriteBatch.DrawString(font, Globals.player1_score.ToString(), new Vector2(300, 100), Color.White);
        Globals.spriteBatch.DrawString(font, Globals.player2_score.ToString(), new Vector2(Globals.WIDTH - 300, 100), Color.White);

        Globals.spriteBatch.End();  

        base.Draw(gameTime);
    }
}
