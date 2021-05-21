using System;
using System.Numerics;
using System.Threading;
using softnaosu.Memory.Structures.Player;

namespace softnaosu.Game
{
    public class PlayerTest
    {
        public static void Start()
        {
            Vector2 mousePos = default;
            
            while (true)
            {
                var pos = PlayerStructure.Instance.Ruleset.MousePosition.RelativePosition;

                if (!pos.Equals(mousePos))
                {
                    mousePos = pos;
                    Console.WriteLine($"x: {pos.X} y: {pos.Y}");
                }

                Thread.Sleep(1);
            }
        }
    }
}