using Infinity.Data;
using Infinity.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Infinity.Puzzle
{

    /// <summary>
    /// Note to developers: Please describe what this MonoBehaviour does.
    /// </summary>
    public class Piece : MonoBehaviour, IDraggable {

        [Title("Piece")]
        [SerializeField] private PieceType pieceType;

        [Title("Config")]
        [SerializeField] private LayerMask placeHolderMask;
        [SerializeField] private Connector connector;
        [SerializeField] private GameEvent onPlayerMove;

        public PieceType PieceType => pieceType;
        private Vector2 startPosition;
        private bool returning;
        private const float Threshold = 0.02f;
        private ISlot currentSlot;
        private float ReturningSpeed => GameValuesSO.PuzzleSettings.PieceReturningSpeed;

        public void Init(Interactable empty, LineDirection lineDirection) {
            currentSlot = empty as ISlot;
            connector.Init(lineDirection);
        }

        public bool Drag() {
            if (returning) {
                return false;
            }

            startPosition = transform.position;
            connector.Drag();
            currentSlot.RemovePiece();
            onPlayerMove.Invoke();
            return true;
        }

        public void Drop(Vector2 position) {
            Collider2D col = Physics2D.OverlapPoint(position, placeHolderMask);

            // If find some object
            if (col) {
                ISlot slot = col.GetComponent<ISlot>();

                // If can't drop, return to the start position
                bool successful = slot.Drop(position, pieceType);
                if (successful) {
                    currentSlot = slot;
                    FitIn(slot.Position);
                    return;
                }
            }

            returning = true;
        }

        public void Move(Vector2 position) {
            transform.position = position;
        }

        private void FitIn(Vector2 position) {
            transform.position = position;
            connector.FitIn();
            onPlayerMove.Invoke();
        }

        private void FixedUpdate() {
            if (returning) {
                transform.position = Vector2.Lerp(transform.position, startPosition, Time.fixedDeltaTime * ReturningSpeed);

                if (Vector2.Distance(transform.position, startPosition) <= Threshold) {
                    FitIn(startPosition);
                    returning = false;
                }
            }
        }
    }
}