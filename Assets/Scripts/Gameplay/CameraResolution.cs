using UnityEngine;

namespace TheLongSnow {

    /// <summary>
    /// Control the Orthographic Size and the Camera Position
    /// </summary>
    public class CameraResolution : MonoBehaviour {
        [SerializeField] private Camera mainCamera;
        [Range(1f, 100f)]
        [SerializeField] private float width = 35f;

        void Awake() {
            RescaleCamera();
        }

        private void OnValidate() {
            RescaleCamera();
        }

        void Update() {
            RescaleCamera();
        }
        private void RescaleCamera() {
            float orthoSize = width * Screen.height / Screen.width * .5f;
            mainCamera.orthographicSize = orthoSize;

        }
    }
}
