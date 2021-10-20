using Infinity.Data;
using Infinity.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Infinity.Interactable
{

    /// <summary>
    /// Note to developers: Please describe what this MonoBehaviour does.
    /// </summary>
    public class Piece : MonoBehaviour, IDraggable {

        [Title("Piece")]
        [SerializeField] private PieceType pieceType;
        [SerializeField] private Animator animator;
        [SerializeField] private LayerMask slotMask;

        private const string Highlight = "Highlight";
        private const string Connected = "Connected";
        private const string Disconnected = "Disconnected";

        private Vector2 startPosition;
        private bool returning;
        private const float Threshold = 0.02f;
        private ISlot currentSlot;
        private float ReturningSpeed => GameValuesSO.GameSettings.PieceReturningSpeed;
        public bool Drag() {
            if (returning) {
                return false;
            }

            startPosition = transform.position;
            animator.Play(Highlight);
            return true;
        }

        public void Drop(Vector2 position) {
            Collider2D col = Physics2D.OverlapPoint(position, slotMask);

            // If find some object
            if (col) {
                ISlot slot = col.GetComponent<ISlot>();

                // If can't drop, return to the start position
                bool successful = slot.Drop(position, pieceType);
                if (successful) {
                    transform.position = slot.Position;
                    currentSlot = slot;
                    CheckConnections();
                    return;
                }
            }

            returning = true;
            animator.Play(Disconnected);
        }

        public void Move(Vector2 position) {
            transform.position = position;
        }

        private void FixedUpdate() {
            if (returning) {
                transform.position = Vector2.Lerp(transform.position, startPosition, Time.fixedDeltaTime * ReturningSpeed);

                if (Vector2.Distance(transform.position, startPosition) <= Threshold) {
                    transform.position = startPosition;
                    returning = false;
                    CheckConnections();
                }
            }
        }

        private void CheckConnections() {

            if (currentSlot.InitialSlot) {
                animator.Play(Disconnected);
            }
            else {
                animator.Play(Connected);
            }
        }
    }
}