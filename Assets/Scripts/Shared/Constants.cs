namespace Infinity.Shared
{
    public static class Animations {
        // Buttons
        public const string Normal = "Normal";
        public const string Highlighted = "Highlighted";
        public const string Pressed = "Pressed";
        public const string Selected = "Selected";
        public const string Disabled = "Disabled";

        // Transitions
        public const string FadeIn = "FadeIn";
        public const string FadeOut = "FadeOut";
    }

    public static class AudioMixers {
        public const string Master = "bus:/Master";
        public const string Music = "bus:/Master/Music";
        public const string SFX = "bus:/Master/SFX";
    }

    public static class ProjectPath {
        // Scenes
        public const string ApplicationManagerScene = "Assets/Scenes/ApplicationManager.unity";

        // Assets
        public const string GameValuesPath = "Assets/Data/Settings/GameValues.asset";

        // Many Assets
        public const string Stages = "Assets/Data/Stages";
    }
}