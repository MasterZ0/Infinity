using UnityEngine;

namespace Infinity.Puzzle {

    /// <summary>
    /// Sends power to nearby IEnergyConnection
    /// </summary>
    public class Power : Interactable {

        [SerializeField] private float pieceRadius = .5f;
        [SerializeField] private LayerMask connectionsMask;

        private void OnEnable() {
            PuzzleController.OnActivePower += OnUpdateEnergy;
        }

        private void OnDisable() {
            PuzzleController.OnActivePower -= OnUpdateEnergy;
        }

        private void OnUpdateEnergy() {
            Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, pieceRadius, connectionsMask);
            if (cols != null) {

                foreach (Collider2D c in cols) {
                    c.GetComponent<IEnergyConnection>().SendEnergy();
                }
            }
        }

        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, pieceRadius);
        }
    }
}