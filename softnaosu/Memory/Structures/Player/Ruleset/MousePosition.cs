using System;
using System.Numerics;
using softnaosu.Memory.Serialization;

namespace softnaosu.Memory.Structures.Player.Ruleset
{
    public static class Resolution
    {
        public static float Width = 1280.0f;
        public static float Height = 720.0f;
    }
    
    public class MousePosition : IMemoryDeserializable
    {
        // Offset 0x80
        public Vector2 Position;
        
        public Vector2 GetRelativePosition()
        {
            if ((Position.X >= 0 && Position.X <= 1280) && (Position.Y >= 0 && Position.Y <= 720))
                return Position;

            FixCoordinate(Position.X, Resolution.Width, out var x);
            FixCoordinate(Position.Y, Resolution.Height, out var y);
                
            return new Vector2(x, y);
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

        public int MemoryBlockSize { get; set; } = 0x80 + sizeof(float) * 2;

        public void ReadFromStream(SerializationReader reader)
        {
            reader.ReadBytes(0x80);

            Position = reader.ReadVector2();
        }
    }
}