using Microsoft.AspNetCore.Components.Web;

namespace SpaceShooter9000.Entites;

public abstract class Entity : IEntityMovement
{
    public abstract float Width { get; init; }
    public abstract float Height { get; init; }
    public abstract string? SpriteImage { get; }
    public abstract string[] SpriteSheet { get; }
    public abstract int SpriteIndex { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public float VelocityX { get; set; }
    public float VelocityY { get; set; }

    public virtual void TriggerKeyDown(KeyboardEventArgs e) { }
    public virtual void TriggerKeyUp(KeyboardEventArgs e) { }

    public override string ToString() => System.Text.Json.JsonSerializer.Serialize(this);

    public virtual void UpdatePositions()
    {
        X += VelocityX;
        Y += VelocityY;
    }
}
