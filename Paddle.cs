using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace pongEspacial;

public class Paddle
{
    public Rectangle Shield;

    float paddleSpeed = 400f;
    bool isSecondPlayer;

    public Paddle(bool isSecondPlayer)
    {
        this.isSecondPlayer = isSecondPlayer;
        Shield = new Rectangle((this.isSecondPlayer ? Globals.WIDTH - 210 : 140), 280, 70, 200);
    }

    public void moviment(GameTime gameTime)
    {
        KeyboardState state = Keyboard.GetState();
        float updateSpeed = paddleSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if ((this.isSecondPlayer ? state.IsKeyDown(Keys.Up) : state.IsKeyDown(Keys.W) && Shield.Y > 0))
        {
            Shield.Y -= (int)updateSpeed;
        }

        if ((this.isSecondPlayer ? state.IsKeyDown(Keys.Down) : state.IsKeyDown(Keys.S) && Shield.Y < Globals.HEIGHT - Shield.Height))
        {
            Shield.Y += (int)updateSpeed;
        }
    }

    public void Update(GameTime gameTime)
    {
        moviment(gameTime);
    }
    public void Draw(){
        Globals.spriteBatch.Draw(Globals.shiled, Shield, Color.White);
    }
}
