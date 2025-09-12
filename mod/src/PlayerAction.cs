// PlayerAction.cs
// Defines player actions and the action queue for Heel-Kawn Multiplayer Mod.

namespace HeelKawnPlugin
{
    public enum PlayerActionType
    {
        None,
        Move,
        Pray,
        Farm,
        // Add more actions as needed (e.g., Build, Gather, Attack)
    }

    public class PlayerAction
    {
        public PlayerActionType Type;
        public string Arg; // e.g., direction (for Move), or prayer type, etc.
    }
}
