namespace SpaceShooter9000.Entites;

public interface IEntityMovement
{
    float X { get; set; }
    float Y { get; set; }
    float VelocityX { get; set; }
    float VelocityY { get; set; }
    void UpdatePositions();
}