using Infinity.Data;
using Infinity.Shared;
using Infinity.System;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Infinity.Puzzle {

    /// <summary>
    /// Generate the slots and pieces
    /// </summary>
    public class StageGenerator : MonoBehaviour {

        [Title("Stage Generator")]
        [SerializeField] private Vector2 start;
        [SerializeField] private Vector2 spacement;
        [SerializeField] private float max;
        [Space]
        [SerializeField] private SpriteRenderer background;

        [Title("Slots")]
        [SerializeField] private Interactable emptySlot;
        [SerializeField] private List<Interactable> interactables;

        [Title("Pieces")]
        [SerializeField] private List<Piece> pieces;

        private List<Component> activeInteractables = new List<Component>();
        #region Public methods
        public void ClearStage() {
            foreach (var item in activeInteractables) {
                ObjectPool.ReturnToPool(item);
            }
            activeInteractables.Clear();
        }

        public List<Lamp> GenerateStage(StageSO stageSO) {

            background.sprite = stageSO.Background;

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

            // Spawn Place Holders
            List<Lamp> lamps = new List<Lamp>();

            int lengthX = stageSO.ItemsGrid.GetLength(0);
            int lengthY = stageSO.ItemsGrid.GetLength(1);
            for (int x = 0; x < lengthX; x++) {
                for (int y = 0; y < lengthY; y++) {

                    Interactable item = SpawnPlaceHolder(new Vector2(x, lengthY - y), stageSO.ItemsGrid[x, y]);
                    if (item is Lamp) {
                        lamps.Add(item as Lamp);
                    }
                }
            }
            return lamps;
        }
        #endregion

        #region Spawn
        private Interactable SpawnPlaceHolder(Vector2 position, int index) {
            if (index == 0)
                return null;

            PuzzleType slotType = (PuzzleType)index - 1;
            Interactable prefab = interactables.Where(p => p.PuzzleType == slotType).First();
            Interactable obj = ObjectPool.SpawnPoolObject(prefab, position);
            activeInteractables.Add(obj);
            return obj;
        }

        private void SpawnPiece(Vector2 piecePosition, PieceType pieceType, LineDirection lineDirection) {
            Interactable placeHolder = ObjectPool.SpawnPoolObject(emptySlot, piecePosition);

            Piece prefab = pieces.Where(p => p.PieceType == pieceType).First();
            Piece obj = ObjectPool.SpawnPoolObject(prefab, piecePosition);
            obj.Init(placeHolder, lineDirection);
            activeInteractables.Add(obj);
            
        }
        #endregion

        private void OnDrawGizmosSelected() {
            int X = StageSO.GridX;
            int Y = StageSO.GridY;
            Vector2 center = new Vector2(X / 2f, Y / 2f);
            Vector2 size = new Vector2(X, Y);
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(center, size);
        }

        #region Dev Tool
#if UNITY_EDITOR
        [Title("Dev Tool")]
        [DropdownData(nameof(Stages))]
        [SerializeField] private int stageIndex;

        private static List<StageSO> Stages => GameValuesSO.GameSettings.Stages;
        [Button]
        private void TestSpawn() {
            ClearStage();
            GenerateStage(Stages[stageIndex]);
        }
#endif
        #endregion
    }
}