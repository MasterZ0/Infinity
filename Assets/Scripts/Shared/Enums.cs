namespace Infinity.Shared
{
    public enum GameScene {
        ApplicationManager,
        MainMenu,
        Gameplay
    }

    public enum PuzzleType {
        Lamp,
        Power,
        Circle,
        Square,
        HorizontalHexagon,
        VerticalHexagon,
        Empty,
    }

    public enum PieceType {
        Circle,
        Square,
        HorizontalHexagon,
        VerticalHexagon,
    }

    [System.Flags]
    public enum LineDirection {
        Up = 1,
        Down = 2,
        Left = 4,
        Right = 8,
    }
}
