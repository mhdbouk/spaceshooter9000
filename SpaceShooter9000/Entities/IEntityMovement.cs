namespace SpaceShooter9000.Entites;

public interface IEntityMovement
{
    float Width { get; }
    float Height { get; }
    float X { get; set; }
    float Y { get; set; }
    float VelocityX { get; set; }
    float VelocityY { get; set; }
    string? SpriteImage { get; }
    string[] SpriteSheet { get; }
    int SpriteIndex { get; }
    void UpdatePositions();
}