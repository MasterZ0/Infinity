using Infinity.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Infinity.ApplicationManager {

    /// <summary>
    /// Collect the UI button event
    /// </summary>
    public class SceneChanger : MonoBehaviour {

        [Title("Scene Changer")]
        [SerializeField] private GameScene scene;

        public void OnChanceScene() {
            GameManager.LoadNewScene(scene);
        }
    }
}