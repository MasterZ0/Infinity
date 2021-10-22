using Sirenix.OdinInspector;
using UnityEngine;

namespace Infinity.Data {

    /// <summary>
    /// Store background image, this class is used in combination with the DropdownDataAttribute 
    /// </summary>
    [System.Serializable, InlineProperty]
    public class Background {
        public override string ToString() => background.name;
        [SerializeField] private Sprite background;

        public static implicit operator Sprite(Background bg) => bg.background;
    }

}
