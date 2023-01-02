using System;
namespace SpaceShooter9000;
public static class Constants
{
    public const float ScreenWidth = 800;
    public static class CssClasses
    {
        public const string IdleRightWolf = "idle-right-wolf";
        public const string IdleLeftWolf = "idle-left-wolf";
        public const string WalkingRightWolf = "walking-right-wolf";
        public const string WalkingLeftWolf = "walking-left-wolf";
        public const string RunningRightWolf = "running-right-wolf";
        public const string RunningLefttWolf = "running-left-wolf";
    }

    public static class Velocity
    {
        public const float Right = 10;
        public const float Left = -10;
        public const float Down = 10;
        public const float Up = -10;

        public const float TurboRight = 25;
        public const float TurboLeft = -25;
        public const float TurboDown = 25;
        public const float TurboUp = -25;
    }
}

