using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using SpaceShooter9000.Entites;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SpaceShooter9000.Components;

public partial class GameComponent : ComponentBase
{
    private Ship _ship =  new();
    private bool _running = false;
    private ShipComponent _shipComponent;
    private int _backgroundPosition = 0;
    private System.Timers.Timer _timer;
    [Inject] private IJSRuntime _jsRuntime { get; set; }
    protected ElementReference gameDiv;

    private void OnKeyDown(KeyboardEventArgs e)
    {
        _ship.TriggerKeyDown(e);
    }

    private void OnKeyUp(KeyboardEventArgs e)
    {
        _ship.TriggerKeyUp(e);
    }
            
    private async Task StartAsync()
    {
        _shipComponent.GameRunning += _shipComponent_GameRunning;
        _running = !_running;
        _shipComponent.Running = _running;
        if (_running)
        {
            await _jsRuntime.InvokeVoidAsync("SetFocusToElement", gameDiv);
            _shipComponent.Start();
            _timer = new System.Timers.Timer();
            _timer.Elapsed += (_, _) => UpdateBackgroundPosition();
            _timer.Start();
        }
        else
        {
            _shipComponent.Stop();
            _timer.Stop();
            UpdateBackgroundPosition(0);
        }
    }

    private void _shipComponent_GameRunning(object? sender, EventArgs e)
    {
        _shipComponent.RunAsync().ConfigureAwait(false);
    }

    private void UpdateBackgroundPosition(int? position = null)
    {
        if (position is not null)
        {
            _backgroundPosition = position.Value;
            StateHasChanged();
            return;
        }
        
        _backgroundPosition--;
        if (_backgroundPosition < -1782)
        {
            _backgroundPosition = 0;
        }
        StateHasChanged();
    }
}
