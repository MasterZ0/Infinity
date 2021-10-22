using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Infinity.SaveSystem {

    /// <summary>
    /// Save and Load the game
    /// </summary>
    public static class SaveManager {

        private const string Path = "/PlayerData.inf";

        private static PlayerData data;
        public static PlayerData Data {
            get {
                if (data == null) {
                    LoadGame();
                }
                return data;
            }
        }

        public static void SaveGame(int levelComplete) {

            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + Path;
            FileStream stream = new FileStream(path, FileMode.Create);

            data = new PlayerData() { completedLevels = levelComplete };
            formatter.Serialize(stream, data);
            stream.Close();
        }

        private static void LoadGame() {

            string path = Application.persistentDataPath + Path;
            if (!File.Exists(path)) {
                SaveGame(0);
                return;
            }

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            data = formatter.Deserialize(stream) as PlayerData;
        }
    }
}
