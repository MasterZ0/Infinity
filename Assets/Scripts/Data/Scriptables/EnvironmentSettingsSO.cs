using UnityEngine;

namespace Infinity.Data {

    /// <summary>
    /// Storage all development environment data
    /// </summary>
    [CreateAssetMenu(fileName = "EnvironmentSettings", menuName = "Scriptable Objects/Data/Environment Settings")]
    public class EnvironmentSettingsSO : ScriptableObject {

        public GameSettingsSO GameSettings => gameSettings;

        [SerializeField] private GameSettingsSO gameSettings;
    }
}
