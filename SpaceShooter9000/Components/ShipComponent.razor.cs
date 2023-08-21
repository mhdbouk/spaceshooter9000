using System;
using System.Numerics;
using Microsoft.AspNetCore.Components;
using SpaceShooter9000.Entites;

namespace SpaceShooter9000.Components;

public partial class ShipComponent : ComponentBase
{
    [Parameter] public Ship Ship { get; set; } = new();

    public bool Running { get; set; }

    public event EventHandler? GameRunning;

    public async Task RunAsync()
    {
        Console.WriteLine("Run");
        Console.WriteLine(Running);
        while (Running)
        {
            UpdatePosition();
            UpdateSpriteImages();
            StateHasChanged();

            await Task.Delay(50);
        }
    }

    public void Start()
    {
        Console.WriteLine("Start");
        GameRunning?.Invoke(this, EventArgs.Empty);
    }
    public void Stop() { }

    private void UpdateSpriteImages()
    {
        if (Ship.SpriteIndex < Ship.SpriteSheet.Length - 1)
        {
            Ship.SpriteIndex++;
        }
        else
        {
            Ship.SpriteIndex = 0;
        }
    }

    private void UpdatePosition()
    {
        Ship.UpdatePositions();
    }
}

