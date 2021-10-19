using Infinity.Shared;
using Infinity.Shared.ExtensionMethods;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using UnityEngine;

namespace Infinity.ApplicationManager {

    /// <summary>
    /// Control the GameManager Scene
    /// </summary>
    public class GameManager : MonoBehaviour {

        #region Variables and Properties
        [Title("GameManager")]
        [SerializeField] private Animator transitionAnimator;
        [SerializeField] private SceneLoader sceneLoader;

        [Title("Events")]
        [SerializeField] private GameEvent onLoadSceneFinish;

        private static Action<GameScene> onLoadScene;
        #endregion

        #region Initialization
        private void Awake() {
            onLoadScene = (scene) => StartCoroutine(LoadScene(scene));
            sceneLoader.LoadApplication(OnLoadFinish);
        }
        #endregion

        #region Public Request
        public static void LoadNewScene(GameScene scene) => onLoadScene.Invoke(scene);
        #endregion

        #region Private Methods

        private IEnumerator LoadScene(GameScene scene) {
            yield return transitionAnimator.PlayAnimationAndWait(Animations.FadeIn);
            sceneLoader.LoadScene(scene, OnLoadFinish);
        }
        private void OnLoadFinish() {
            transitionAnimator.Play(Animations.FadeOut);
        }
        #endregion

        #region Events
        /// <summary> Init Scene </summary>
        public void OnFadeOutEnd() {
            onLoadSceneFinish.Invoke();
        }
        #endregion
    }
}
