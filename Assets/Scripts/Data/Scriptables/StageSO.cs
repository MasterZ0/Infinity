using Sirenix.OdinInspector;
using UnityEngine;

namespace Infinity.Data {

    /// <summary>
    /// Create a playable stage
    /// </summary>
    [CreateAssetMenu(fileName = "Stage", menuName = "Scriptable Objects/Stage")]
    public class StageSO : ScriptableObject {
        [Title("Stage")]
        public GameObject rememberToUseTheTitle;
    }
}
