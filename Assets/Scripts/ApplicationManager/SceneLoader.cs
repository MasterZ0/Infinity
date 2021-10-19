using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Infinity.Shared;

namespace Infinity.ApplicationManager {

    /// <summary>
    /// Load and unload scenes
    /// </summary>
    public class SceneLoader : MonoBehaviour {

        private GameScene currentScene;

        /// <summary>
        /// Check if there is any scene loaded, if is not, load the MainMenu
        /// </summary>
        public void LoadApplication(Action onFinish) {
            Scene activeScene = SceneManager.GetActiveScene();
            currentScene = (GameScene)activeScene.buildIndex;

            if (activeScene == SceneManager.GetSceneByBuildIndex(0) && SceneManager.sceneCount == 1) {

                currentScene = GameScene.MainMenu;
                StartCoroutine(LoadCurrentScene(onFinish));
                return;
            }

            onFinish();
        }

        public void LoadScene(GameScene gameScene, Action onFinish) {
            StartCoroutine(LoadNextScene(gameScene, onFinish));
        }

        #region Private Methods
        private IEnumerator LoadCurrentScene(Action onFinish) {

            AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync((int)currentScene, LoadSceneMode.Additive);
            yield return new WaitUntil(() => loadSceneAsync.isDone);

            Scene loadedScene = SceneManager.GetSceneByBuildIndex((int)currentScene);
            SceneManager.SetActiveScene(loadedScene);

            onFinish();
        }
        private IEnumerator LoadNextScene(GameScene gameScene, Action onFinish) {

            // Unload current
            AsyncOperation loadSceneAsync = SceneManager.UnloadSceneAsync((int)currentScene);
            yield return new WaitUntil(() => loadSceneAsync.isDone);

            currentScene = gameScene;
            GC.Collect();

            // Load next
            StartCoroutine(LoadCurrentScene(onFinish));
        }
        #endregion
    }
}
