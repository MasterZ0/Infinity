using UnityEngine;

namespace Infinity.System {

    /// <summary>
    /// Set Scene Container
    /// </summary>
    public class ObjectContainer : MonoBehaviour {

        private void Awake() {
            ObjectPool.SetContainer(this);
        }

        private void OnDestroy() {
            ObjectPool.ReturnAllToPool();
        }
    }
}