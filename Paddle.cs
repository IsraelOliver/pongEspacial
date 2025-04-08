using System.Net;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace pongEspacial;

public class Paddle
{
    public Rectangle Shield;

    float paddleSpeed = 400f;

    public Paddle()
    {
        Shield = new Rectangle(150, 280, 70, 200);
    }
    public void update(GameTime gameTime)
    {
        KeyboardState state = Keyboard.GetState();
        float updateSpeed = paddleSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (state.IsKeyDown(Keys.W) && Shield.Y > 0)
        {
            Shield.Y -= (int)updateSpeed;
        }

        if (state.IsKeyDown(Keys.S) && Shield.Y < Globals.HEIGHT - Shield.Height)
        {
            Shield.Y += (int)updateSpeed;
        }
    }
    public void Draw(){
        Globals.spriteBatch.Draw(Globals.shiled, Shield, Color.White);
    }
}
