using Microsoft.AspNetCore.Components.Web;

namespace SpaceShooter9000.Entites;

public class NoobBullet : Bullet
{
    public override string? SpriteImage => "img/spr_bullet_strip.png";

    public override string[] SpriteSheet => new[] { "110px -8px", "71px -8px", "33px -8px" } ;

    public override int SpriteIndex { get; set; } = 0;

    public override float Width { get; init; } = 24;
    public override float Height { get; init; } = 24;
    private Ship _ship;
    public NoobBullet(Ship ship)
    {
        _ship = ship;
        InitCoordinates();
        VelocityX = 15;
        VelocityY = 0;
    }

    public void InitCoordinates()
    {
        X = _ship.X + _ship.Width + (Width / 2);
        Y = _ship.Y + (_ship.Height / 2) - Height + (Height / 2);
    }

    public override void UpdatePositions()
    {
        InitCoordinates();
    }
}
