using Infinity.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Infinity.Puzzle {
    public class Line : MonoBehaviour, IEnergyConnection {

        #region Variables and Properties
        [EnumPaging]
        [SerializeField] private LineDirection lineDirection;
        [SerializeField] private BoxCollider2D boxCollider;

        private bool isEnergized;
        private Connector connector;
        private IEnergyConnection connectionPoint;

        public LineDirection LineDirection => lineDirection;
        #endregion

        public void SetConnector(Connector parent) => connector = parent;        
        public void ActiveLine(bool enable) => boxCollider.enabled = enable;

        // Check all connections
        public void SendEnergy() {
            if (isEnergized) {
                return;
            }

            isEnergized = true;
            connector.SendEnergy();
            connectionPoint?.SendEnergy();
        }

        public void StopEnergy() {
            isEnergized = false;
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            connectionPoint = collision.GetComponent<IEnergyConnection>();
        }

        private void OnTriggerExit2D(Collider2D collision) {
            connectionPoint = null;
        }
    }
}