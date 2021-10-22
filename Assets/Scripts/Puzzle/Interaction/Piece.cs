using Infinity.Audio;
using Infinity.Data;
using Infinity.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Infinity.Puzzle {

    /// <summary>
    /// Move and fit the piece
    /// </summary>
    public class Piece : MonoBehaviour, IDraggable {

        [Title("Piece")]
        [SerializeField] private PieceType pieceType;

        [Title("Config")]
        [SerializeField] private LayerMask placeHolderMask;
        [SerializeField] private Connector connector;
        [SerializeField] private GameEvent onPlayerMove;

        private Vector2 startPosition;
        private ISlot currentSlot;
        private bool returning;

        private const float Threshold = 0.02f;
        public PieceType PieceType => pieceType;
        private float ReturningSpeed => GameValuesSO.PuzzleSettings.PieceReturningSpeed;

        public void Init(Interactable empty, LineDirection lineDirection) {

            // Fill slot
            currentSlot = empty as ISlot;
            currentSlot.Drop(transform.position, pieceType);


            connector.Init(lineDirection);
        }

        public bool Drag() {
            if (returning) {
                return false;
            }

            SoundEffects.PlaySFX(SFX.Drag);
            startPosition = transform.position;
            connector.Drag();
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
                    currentSlot.RemovePiece();
                    currentSlot = slot;
                    FitIn(slot.Position, true);
                    return;
                }
            }

            SoundEffects.PlaySFX(SFX.Negative);
            connector.Moving();
            returning = true;
        }

        public void Move(Vector2 position) {
            transform.position = position;
        }

        private void FitIn(Vector2 position, bool drop) {
            transform.position = position;
            connector.FitIn(drop);
            onPlayerMove.Invoke();
        }

        private void FixedUpdate() {
            if (returning) {
                transform.position = Vector2.Lerp(transform.position, startPosition, Time.fixedDeltaTime * ReturningSpeed);

                if (Vector2.Distance(transform.position, startPosition) <= Threshold) {
                    FitIn(startPosition, false);
                    returning = false;
                }
            }
        }
    }
}