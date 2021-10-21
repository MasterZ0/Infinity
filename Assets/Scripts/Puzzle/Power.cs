using System.Collections.Generic;
using UnityEngine;

namespace Infinity.Puzzle {

    public class Power : Interactable {

        private List<IEnergyConnection> connections = new List<IEnergyConnection>();

        private void OnEnable() {
            PuzzleController.OnActivePower += OnUpdateEnergy;
        }

        private void OnDisable() {
            PuzzleController.OnActivePower -= OnUpdateEnergy;
        }

        public void OnUpdateEnergy() {
            foreach (var e in connections) {
                e.SendEnergy();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            IEnergyConnection newConnection = collision.GetComponent<IEnergyConnection>();
            connections.Add(newConnection);
        }

        private void OnTriggerExit2D(Collider2D collision) {
            IEnergyConnection removedConnection = collision.GetComponent<IEnergyConnection>();
            connections.Remove(removedConnection);
        }
    }
}