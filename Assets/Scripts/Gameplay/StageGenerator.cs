using Infinity.Data;
using Infinity.Shared;
using Infinity.System;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Infinity.Gameplay
{

    /// <summary>
    /// Note to developers: Please describe what this MonoBehaviour does.
    /// </summary>
    public class StageGenerator : MonoBehaviour {

        [Title("Initial Pieces")]
        [SerializeField] private Transform circle;
        [SerializeField] private Transform square;
        [SerializeField] private Transform hexagonFlat;
        [SerializeField] private Transform hexagonPointed;

        [Title("Stage Slots")]
        [SerializeField] private Transform lamp;
        [SerializeField] private Transform energy;
        [SerializeField] private Transform circleSlot;
        [SerializeField] private Transform squareSlot;
        [SerializeField] private Transform hexagonFlatSlot;
        [SerializeField] private Transform hexagonPointedSlot;

        public int X => StageSO.GridX;
        public int Y => StageSO.GridY;

        private Dictionary<PieceType, Transform> pieces;
        private void Awake() {
            pieces = new Dictionary<PieceType, Transform>() {
                [PieceType.Circle] = circleSlot,
                [PieceType.Square] = square,
                [PieceType.HexagonFlat] = hexagonFlat,
                [PieceType.HexagonPointed] = hexagonPointed,
            };
        }
        public void GenerateStage(StageSO stageSO) {


            for (int x = 0; x < X; x++) {
                for (int y = 0; y < Y; y++) {
                    SpawnSlot(new Vector2(X - x, Y - y), stageSO.ItemsGrid[x, y]);
                }
            }

            Vector2 piecePosition = Vector2.zero;
            foreach (PieceType pieceType in stageSO.InitialPieces) {
                piecePosition.x += 1;
                ObjectPool.SpawnPoolObject(pieces[pieceType], piecePosition);
            }
        }

        private void SpawnSlot(Vector2 position, int type) {
            switch (type) {
                case 0:
                    return;
                case 1:
                    ObjectPool.SpawnPoolObject(lamp, position);
                    return;
                case 2:
                    ObjectPool.SpawnPoolObject(energy, position);
                    return;
                case 3:
                    ObjectPool.SpawnPoolObject(circleSlot, position);
                    return;
                case 4:
                    ObjectPool.SpawnPoolObject(squareSlot, position);
                    return;
                case 5:
                    ObjectPool.SpawnPoolObject(hexagonFlatSlot, position);
                    return;
                case 6:
                    ObjectPool.SpawnPoolObject(hexagonPointed, position);
                    return;
                default:
                    throw new NotImplementedException();
            }
        }

        private void OnDrawGizmosSelected() {
            Vector2 center = new Vector2(X / 2f, Y / 2f);
            Vector2 size = new Vector2(X, Y);
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(center, size);
        }
    }
}