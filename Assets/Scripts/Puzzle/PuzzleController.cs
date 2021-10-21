using Infinity.Shared;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infinity.Puzzle
{

    /// <summary>
    /// Note to developers: Please describe what this MonoBehaviour does.
    /// </summary>
    public class PuzzleController : MonoBehaviour {
        [Title("PuzzleController")]
        [SerializeField] private GameEvent onPlayerMove;

        public static event Action OnDesativePower = delegate { };
        public static event Action OnActivePower = delegate { };
        public static event Action OnUpdateAnimations = delegate { };

        private static List<Lamp> lamps = new List<Lamp>();
        private void Awake() {
            onPlayerMove += OnPlayerMove;
        }

        private void OnDestroy() {
            onPlayerMove -= OnPlayerMove;
        }

        private void OnPlayerMove() {
            StartCoroutine(Cor());
        }

        private IEnumerator Cor() {
            yield return new WaitForEndOfFrame();
            OnDesativePower();
            OnActivePower();
            OnUpdateAnimations();
        }

        public static void AddLamp(Lamp newLamps) {
            lamps.Add(newLamps);
        }

        public static void LampTurnOn(Lamp lamp) {
            lamps.Remove(lamp);

            if (lamps.Count == 0) {
                Debug.LogError("Win");
            }
        }

        public static void LampTurnOff(Lamp lamp) {
            lamps.Add(lamp);
        }
    }
}