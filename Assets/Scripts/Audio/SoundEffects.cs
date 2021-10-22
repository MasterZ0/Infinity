using FMOD.Studio;
using FMODUnity;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Infinity.Audio {

    public enum SFX {
        DropEnergy,
        DropWithoutEnergy,
        LightOn,
        LightOff,
        Negative,
        Drag,
        Win
    }

    /// <summary>
    /// Play Sounds
    /// </summary>
    public class SoundEffects : MonoBehaviour {

        [Title("SoundEffects")]
        [SerializeField, EventRef] private string dropEnergy;
        [SerializeField, EventRef] private string dropWithoutEnergy;
        [SerializeField, EventRef] private string negative;
        [SerializeField, EventRef] private string drag;
        [SerializeField, EventRef] private string lightOn;
        [SerializeField, EventRef] private string lightOff;
        [SerializeField, EventRef] private string win;

        private static Dictionary<SFX, string> soundEffects;

        private void Awake() {
            soundEffects = new Dictionary<SFX, string>() {
                [SFX.DropEnergy] = dropEnergy,
                [SFX.DropWithoutEnergy] = dropWithoutEnergy,
                [SFX.LightOn] = lightOn,
                [SFX.LightOff] = lightOff,
                [SFX.Negative] = negative,
                [SFX.Drag] = drag,
                [SFX.Win] = win
            };
        }

        public static void PlaySFX(SFX sfx) {
            EventInstance instance = RuntimeManager.CreateInstance(soundEffects[sfx]);
            instance.start();
        }
    }
}