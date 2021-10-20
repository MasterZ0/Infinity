using UnityEngine;

namespace Infinity.Interactable {

    /// <summary>
    /// Objects the player can drag and drop
    /// </summary>
    public interface IDraggable {
        public bool Drag();
        public void Drop(Vector2 position);
        public void Move(Vector2 position);
    }
}
