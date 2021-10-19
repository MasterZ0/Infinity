using System;
using UnityEngine;

namespace Infinity.Shared {

    /// <summary>
    /// Used to send and receive events from different namespaces
    /// </summary>
    [CreateAssetMenu(fileName = "NewGameEvent", menuName = "Scriptable Objects/Events/Game Event")]
    public class GameEvent : ScriptableObject {

        private Action listeners;

        public void Invoke() {
            listeners?.Invoke();
        }

        public static GameEvent operator +(GameEvent gameEvent, Action action) {
            gameEvent.listeners += action;
            return gameEvent;
        }

        public static GameEvent operator -(GameEvent gameEvent, Action action) {
            gameEvent.listeners -= action;
            return gameEvent;
        }
    }
}
