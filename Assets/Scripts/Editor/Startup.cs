using Infinity.Data;
using Infinity.Shared;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace Infinity.InfinityEditor {

    /// <summary>
    /// Initialize the GameValuesSO and Load the GameManagerScene
    /// </summary>
    [InitializeOnLoad]
    public static class Startup {

        static Startup() {
            EditorSceneManager.sceneOpened += LoadGameManager;
            EditorApplication.delayCall += GameValuesValidation;
        }

        private static void GameValuesValidation() {
            AssetDatabase.LoadAssetAtPath<GameValuesSO>(ProjectPath.GameValuesPath);
        }

        private static void LoadGameManager(Scene scene, OpenSceneMode mode) {
            if (mode == OpenSceneMode.Single && scene.buildIndex > 0) {
                EditorSceneManager.OpenScene(ProjectPath.ApplicationManagerScene, OpenSceneMode.Additive);
            }
        }
    }
}