using System;
using System.Numerics;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.VisualBasic;

namespace SpaceShooter9000.Entites;

public class Ship : Entity
{
    public override string? SpriteImage => "img/Spritesheet_64x29.png";

    public override string[] SpriteSheet => new[] { "0px 29px" , "0px 58px" , "0px 87px" , "0px 116px" };

    public override int SpriteIndex { get; set; } = 0;
    public override float Width { get; init; }
    public override float Height { get; init; }

    public float Health { get; set; }
    public IBullet Bullet { get; set; }

    public Ship()
    {
        X = 30;
        Y = 300;
        VelocityX = 0;
        VelocityY = 0;
        Health = 100;
        Width = 64;
        Height = 29;

        Bullet = new NoobBullet(this);
    }

    public override void TriggerKeyDown(KeyboardEventArgs e)
    {
        switch (e.Key)
        {
            case "ArrowLeft":
                VelocityX = e.ShiftKey ? Constants.Velocity.TurboLeft : Constants.Velocity.Left;
                break;
            case "ArrowRight":
                VelocityX = e.ShiftKey ? Constants.Velocity.TurboRight : Constants.Velocity.Right;
                break;
            case "ArrowUp":
                VelocityY = e.ShiftKey ? Constants.Velocity.TurboUp : Constants.Velocity.Up;
                break;
            case "ArrowDown":
                VelocityY = e.ShiftKey ? Constants.Velocity.TurboDown : Constants.Velocity.Down;
                break;
            case " ":
                Bullet.FireAsync(this).ConfigureAwait(false);
                break;
        }
    }

    public override void TriggerKeyUp(KeyboardEventArgs e)
    {
        switch (e.Key)
        {
            case "ArrowLeft":
            case "ArrowRight":
                VelocityX = 0;
                break;
            case "ArrowUp":
            case "ArrowDown":
                VelocityY = 0;
                break;
        }
    }

    public override void UpdatePositions()
    {
        base.UpdatePositions();
        if (!Bullet.Fired)
        {
            Bullet.UpdatePositions();
        }
    }
}
