using Infinity.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Infinity.Puzzle {

    /// <summary>
    /// Responsible for distributing energy between the connector and other line
    /// </summary>
    public class Line : MonoBehaviour, IEnergyConnection {

        #region Variables and Properties
        [EnumPaging]
        [SerializeField] private LineDirection lineDirection;
        [SerializeField] private LayerMask connectionsMask;
        [SerializeField] private BoxCollider2D boxCollider;
        [SerializeField] private SpriteRenderer spriteRenderer;

        private bool isEnergized;
        private Connector connector;

        public LineDirection LineDirection => lineDirection;
        #endregion

        private void OnEnable() => spriteRenderer.enabled = true; 
        private void OnDisable() => spriteRenderer.enabled = false;        
        public void SetConnector(Connector parent) => connector = parent;        
        public void ActiveLine(bool enable) => boxCollider.enabled = enable;

        // Check all connections
        public void SendEnergy() {
            if (isEnergized) {
                return;
            }
             
            isEnergized = true;
            connector.SendEnergy();

            Collider2D[] cols = Physics2D.OverlapPointAll(transform.position, connectionsMask);
            foreach (var c in cols) {
                if (c.transform != transform) {
                    c.GetComponent<IEnergyConnection>().SendEnergy();
                    break;
                }
            }
        }

        public void StopEnergy() {
            isEnergized = false;
        }
    }
}