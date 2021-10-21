using Infinity.Data;
using Infinity.Shared;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace Infinity.UnityEditor {

    /// <summary>
    /// Create the Game Design screen
    /// </summary>
    public class GameDesignEditorWindow : OdinMenuEditorWindow {
        private ScriptableObject memoryObject;

        private CreateNewAsset<StageSO> newStage;

        private const string ApplicationName = "Infinity";
        [MenuItem("Infinity/Game Design")]
        private static void OpenMenu() {
            GetWindow<GameDesignEditorWindow>($"{ApplicationName} Settings").Show();
        }

        private void RebuildTree() {
            GameValuesSO.OnChangeEnvironment -= RebuildTree;
            ForceMenuTreeRebuild();
        }

        protected override OdinMenuTree BuildMenuTree() {
            OdinMenuTree tree = new OdinMenuTree();
            GameValuesSO.OnChangeEnvironment += RebuildTree;

            DrawEnvironment(tree);
            DrawTree(tree);
            SetMenuTreeColor(tree);
            return tree;
        }

        private void DrawEnvironment(OdinMenuTree menuTree) {
            GameValuesSO simulatorValues = AssetDatabase.LoadAssetAtPath<GameValuesSO>(ProjectPath.GameValuesPath);

            EditorIcon gameSettingsIcon = GameValuesSO.Environment switch {
                EnvironmentState.Develop => EditorIcons.Char2,
                EnvironmentState.Staging => EditorIcons.Char3,
                EnvironmentState.Release => EditorIcons.Char1,
                _ => throw new System.ArgumentOutOfRangeException()
            };

            GameDesign gameDesign = new GameDesign(simulatorValues);
            menuTree.Add($"{ApplicationName} Settings", gameDesign, gameSettingsIcon);
        }

        private void DrawTree(OdinMenuTree tree) {

            tree.Add($"{ApplicationName} Settings/Main", GameValuesSO.GameSettings, EditorIcons.SettingsCog);
            tree.Add($"{ApplicationName} Settings/Puzzle", GameValuesSO.PuzzleSettings, EditorIcons.Next);

            newStage = new CreateNewAsset<StageSO>();

            tree.Add("Stages", newStage, EditorIcons.GridBlocks);
            tree.AddAllAssetsAtPath("Stages", ProjectPath.Stages, typeof(StageSO));
        }

        private void SetMenuTreeColor(OdinMenuTree menuTree) {
            Color color = GameValuesSO.Environment switch {
                EnvironmentState.Develop => new Color(1f, 0.239f, 0.407f),
                EnvironmentState.Staging => new Color(1f, 0.403f, 0.403f),
                EnvironmentState.Release => new Color(0.654f, 0.203f, 0.537f),
                _ => throw new System.ArgumentOutOfRangeException()
            };

            OdinMenuTreeDrawingConfig config = new OdinMenuTreeDrawingConfig {
                DefaultMenuStyle =
                {
                    SelectedColorDarkSkin = color,
                    SelectedColorLightSkin = color
                }
            };

            menuTree.Config = config;
        }

        protected override void OnBeginDrawEditors() {
            ScriptableObject asset = MenuTree?.Selection.SelectedValue as ScriptableObject;

            if (asset == null)
                return;

            SirenixEditorGUI.BeginHorizontalToolbar();
            {
                if (asset is StageSO) {
                    if (SirenixEditorGUI.ToolbarButton("Delete")) {
                        string path = AssetDatabase.GetAssetPath(asset);
                        AssetDatabase.DeleteAsset(path);
                    }
                }

                GUILayout.FlexibleSpace();

                if (SirenixEditorGUI.ToolbarButton("Copy values")) {
                    memoryObject = asset;
                }

                GUI.enabled = memoryObject != null && memoryObject.GetType() == asset.GetType();

                if (SirenixEditorGUI.ToolbarButton("Paste values")) {
                    EditorUtility.CopySerialized(memoryObject, asset);
                    AssetDatabase.SaveAssets();
                }

                GUI.enabled = true;
            }

            SirenixEditorGUI.EndHorizontalToolbar();
        }

        public class GameDesign {
            [Title("Simulator Values"), InlineEditor(objectFieldMode: InlineEditorObjectFieldModes.Hidden), HideLabel]
            [SerializeField] private GameValuesSO SimulatorValues;
            [Title("Environment Assets"), InlineEditor(objectFieldMode: InlineEditorObjectFieldModes.Hidden), HideLabel]
            [SerializeField] private EnvironmentSettingsSO EnvironmentSettingsSO;

            public GameDesign(GameValuesSO simulatorValues) {
                SimulatorValues = simulatorValues;
                EnvironmentSettingsSO = GameValuesSO.EnvironmentSettings;
            }
        }

        public class CreateNewAsset<T> where T : ScriptableObject {
            [TitleGroup("File Settings"), HorizontalGroup("File Settings/Main")]
            [SerializeField] private string fileName;

            [HorizontalGroup("File Settings/Main"), Button]
            private void Create() {
                AssetDatabase.CreateAsset(asset, $"{ProjectPath.Stages}/{fileName}.asset");
                AssetDatabase.SaveAssets();
            }

            public CreateNewAsset() {
                asset = CreateInstance<T>();
            }

            [Space]
            [InlineEditor(objectFieldMode: InlineEditorObjectFieldModes.Hidden)]
            [SerializeField] private T asset;
        }
    }
}