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
            var player = Player.Instance;
            
            Console.WriteLine($"Ruleset: {player.Ruleset.BaseAddress}");
            Console.WriteLine($"\nHitObjectManager: {player.HitObjectManager.BaseAddress.ToString("x8")}");
            Console.WriteLine($"HitObjects: {player.HitObjectManager.HitObjects.BaseAddress.ToString("x8")}");
            Console.WriteLine($"HitObjectsList: {player.HitObjectManager.HitObjects.HitObjectsList.BaseAddress.ToString("x8")}");
            
            Console.WriteLine(player.HitObjectManager.HitObjects.HitObjectsList.ListItems.Count);
            
            // Vector2 mousePosition = default;
            //
            // while (true)
            // {
            //     var mPosition = Player.Instance.Ruleset.MousePosition.GetRelativePosition();
            //
            //     if (!mPosition.Equals(mousePosition))
            //     {
            //         mousePosition = mPosition;
            //         
            //         Console.ForegroundColor = ConsoleColor.White;
            //
            //         Console.WriteLine($"x: {mousePosition.X} y: {mousePosition.Y}");
            //         
            //         Console.ResetColor();
            //     }
            //
            //     Thread.Sleep(1);
            // }
        }
    }
}