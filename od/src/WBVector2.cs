// WBVector2.cs
// Simple 2D vector struct for Heel-Kawn Multiplayer Mod.

namespace HeelKawnPlugin
{
    public struct WBVector2
    {
        public int x;
        public int y;

        public WBVector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"({x}, {y})";
        }
    }
}
