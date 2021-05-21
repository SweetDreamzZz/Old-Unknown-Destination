using System;
using System.Numerics;

namespace softnaosu.Memory.Structures.Player
{
    public static class Resolution
    {
        public static float Width = 1280.0f;
        public static float Height = 720.0f;
    }
    
    public class MousePosition
    {
        [Offset(0x80)] public float X;
        
        [Offset(0x84)] public float Y;

        public Vector2 RelativePosition
        {
            get
            {
                if ((X >= 0 && X <= 1280) && (Y >= 0 && Y <= 720))
                    return new Vector2(X, Y);

                FixCoordinate(X, Resolution.Width, out var x);
                FixCoordinate(Y, Resolution.Height, out var y);
                
                return new Vector2(x, y);
            }
        }

        private void FixCoordinate(float coordValue, float maxCoord, out float fixedCoord)
        {
            fixedCoord = coordValue;
            
            if (coordValue < 0)
                fixedCoord = coordValue + Math.Abs(coordValue);
            
            // TODO: Find current resolution 
            if (coordValue > maxCoord)
                fixedCoord = coordValue - (coordValue - maxCoord);
        }
    }
}