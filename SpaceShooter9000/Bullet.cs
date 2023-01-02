namespace SpaceShooter9000;

public abstract class Bullet : Entity
{
    public bool Fired { get; set; }
    public async Task FireAsync(Ship ship)
    {
        Fired = true;
        while (X <= Constants.ScreenWidth)
        {
            X += VelocityX;
            await Task.Delay(20);
        }

        if (X >= Constants.ScreenWidth)
        {
            X = ship.X + ship.Width + 10;
        }
        Fired = false;
    }
}
