using Infinity.Data;
using Infinity.Puzzle;
using Infinity.Shared;
using Infinity.System;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Infinity.Gameplay
{

    /// <summary>
    /// Generate the slots and pieces
    /// </summary>
    public class StageGenerator : MonoBehaviour {

        [Title("Stage Generator")]
        [SerializeField] private SpriteRenderer background;

        [Title("Slots")]
        [SerializeField] private Interactable emptySlot;
        [SerializeField] private List<Interactable> interactables;

        [Title("Pieces")]
        [SerializeField] private List<Piece> pieces;

        public int X => StageSO.GridX;
        public int Y => StageSO.GridY;

        public Vector2 start;
        public Vector2 spacement;
        public float max;
        public void GenerateStage(StageSO stageSO) {
            ObjectPool.ReturnAllToPool();
            background.sprite = stageSO.Background;

            // Spawn Place Holders
            for (int x = 0; x < X; x++) {
                for (int y = 0; y < Y; y++) {

                    SpawnPlaceHolder(new Vector2(x, Y - y), stageSO.ItemsGrid[x, y]);
                }
            }

            // Spawn possible items
            Vector2 piecePosition = start;
            foreach (PieceData pieceData in stageSO.InitialPieces) {

                SpawnPiece(piecePosition, pieceData.PieceType, pieceData.LineDirection);
                piecePosition.x += spacement.x;
                if (piecePosition.x > max) {
                    piecePosition.x = start.x;
                    piecePosition.y -= spacement.y;
                }
            }
        }
        
        private void SpawnPlaceHolder(Vector2 position, int index) {
            if (index == 0)
                return;

            PuzzleType slotType = (PuzzleType)index - 1;
            Interactable prefab = interactables.Where(p => p.PuzzleType == slotType).First();
            ObjectPool.SpawnPoolObject(prefab, position);

            if (prefab is Lamp) {
                PuzzleController.AddLamp(prefab as Lamp);
            }
        }

        private void SpawnPiece(Vector2 piecePosition, PieceType pieceType, LineDirection lineDirection) {
            Interactable placeHolder = ObjectPool.SpawnPoolObject(emptySlot, piecePosition);

            Piece prefab = pieces.Where(p => p.PieceType == pieceType).First();
            ObjectPool.SpawnPoolObject(prefab, piecePosition).Init(placeHolder, lineDirection);
        }

        private void OnDrawGizmosSelected() {
            Vector2 center = new Vector2(X / 2f, Y / 2f);
            Vector2 size = new Vector2(X, Y);
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(center, size);
        }

        #region Dev Tool
        [Title("Dev Tool")]
        [SerializeField] private int stageIndex;

        [Button]
        private void TestSpawn() {
            GenerateStage(GameValuesSO.GameSettings.Stages[stageIndex]);
        }

        #endregion
    }
}