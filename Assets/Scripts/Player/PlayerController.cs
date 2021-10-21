using Infinity.Puzzle;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Infinity.Player {

    /// <summary>
    /// Note to developers: Please describe what this MonoBehaviour does.
    /// </summary>
    public class PlayerController : MonoBehaviour {

        [Title("Player Inputs")]
        [SerializeField] private LayerMask draggableMask;

        private IDraggable draggable;
        private MobileInputs mobileInputs;

        private void Start() {
            mobileInputs = new MobileInputs();
            mobileInputs.OnStartTouch += OnDrag;
            mobileInputs.OnEndTouch += OnDrop;
            mobileInputs.OnMove += OnMove;
        }

        private void OnDestroy() {
            mobileInputs.Dispose();
        }

        private void OnDrag(Vector2 position) {

            Collider2D col = Physics2D.OverlapPoint(position, draggableMask);

            // If find some object
            if (col) {
                IDraggable piece = col.GetComponent<IDraggable>();

                // If can successful, set variable
                if (piece.Drag()) {
                    draggable = piece;
                }
            }
        }

        private void OnMove(Vector2 position) {
            if (draggable != null) {
                draggable.Move(position);
            }
        }

        private void OnDrop(Vector2 position) {
            if (draggable != null) {
                draggable.Drop(position);
                draggable = null;
            }
        }
    }
}