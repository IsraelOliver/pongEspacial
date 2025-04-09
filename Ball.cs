using Microsoft.Xna.Framework;

namespace pongEspacial;

public class Ball
{
    Rectangle ball;
    int right = 1, top = 1, moveSpeed = 200;

    public Ball()
    {
        ball = new Rectangle(Globals.WIDTH / 2 - 20, Globals.HEIGHT / 2 - 20, 40, 40);
    }

    public void resetGame()
    {
        ball.X = Globals.WIDTH / 2 - 20;
        ball.Y = Globals.HEIGHT / 2 - 20;
    }

    public void update(GameTime gameTime, Paddle player1, Paddle player2)
    {
        int deltaSpeed = (int)(moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
        ball.X += right * deltaSpeed;
        ball.Y += top * deltaSpeed;

        if (ball.Right >= player1.Shield.Left && ball.Left < player1.Shield.Right && ball.Top < player1.Shield.Bottom && ball.Bottom > player1.Shield.Top)
        {
            right = 1;
        }

        if (ball.Left <= player2.Shield.Right && ball.Right > player2.Shield.Left && ball.Top < player2.Shield.Bottom && ball.Bottom > player2.Shield.Top)
        {
            right = -1;
        }

        if (ball.Y < 0) {
            top *= -1;
        }

        if (ball.Y > Globals.HEIGHT - ball.Height) {
            top *= -1;
        }

        if (ball.X < 0)
        {
            Globals.player2_score += 1;
            resetGame();
        }

        if (ball.X > Globals.WIDTH - ball.Width)
        {
            Globals.player1_score += 1;
            resetGame();
        }
    }
    public void Draw()
    {
        Globals.spriteBatch.Draw(Globals.ball, ball, Color.White);
    }

}
