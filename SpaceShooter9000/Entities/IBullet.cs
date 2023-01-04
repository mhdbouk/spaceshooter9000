namespace SpaceShooter9000.Entites;

public interface IBullet : IEntityMovement
{
    bool Fired { get; set; }
    Task FireAsync(Ship ship);
}
