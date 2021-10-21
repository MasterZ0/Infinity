using Sirenix.OdinInspector;
using UnityEngine;

namespace Infinity.Puzzle {

    /// <summary>
    /// Control the Orthographic Size
    /// </summary>
    public class CameraController : MonoBehaviour {

        [Title("Camera Controller")]
        [SerializeField] private Camera mainCamera;
        [Range(1f, 100f)]
        [SerializeField] private float width = 35f;

        public static Camera MainCamera { get; private set; }

        void Awake() {
            MainCamera = mainCamera;
            RescaleCamera();
        }

        private void OnValidate() {
            RescaleCamera();
        }

        private void RescaleCamera() {
            float orthoSize = width * Screen.height / Screen.width * .5f;
            mainCamera.orthographicSize = orthoSize;
        }
    }
}
