using Sirenix.OdinInspector;
using UnityEngine;

namespace Infinity.Data {
    [System.Serializable, InlineProperty]
    public class Background {
        public override string ToString() => background.name;
        [SerializeField] private Sprite background;

        public static implicit operator Sprite(Background bg) => bg.background;
    }

}
