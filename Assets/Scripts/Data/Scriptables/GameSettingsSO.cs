using Sirenix.OdinInspector;
using UnityEngine;

namespace Infinity.Data
{

    /// <summary>
    /// Note to developers: Please describe what this class does.
    /// </summary>
    [CreateAssetMenu(fileName = "GameSettingsSO", menuName = "Scriptable Objects/Data/Game Settings")]
    public class GameSettingsSO : ScriptableObject {
        [Title("GameSettings")]
        public GameObject rememberToUseTheTitle;
    }
}
