using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Infinity.SaveSystem {

    /// <summary>
    /// Save and Load the game
    /// </summary>
    public static class SaveManager {

        private const string Path = "/PlayerData.inf";

        public static PlayerData Data { get; private set; }
        public static void SaveGame(int levelComplete) {

            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + Path;
            FileStream stream = new FileStream(path, FileMode.Create);

            Data = new PlayerData() { completedLevels = levelComplete };
            formatter.Serialize(stream, Data);
            stream.Close();
        }

        public static PlayerData LoadGame() {

            string path = Application.persistentDataPath + Path;
            if (!File.Exists(path)) {
                SaveGame(0);
                return null;
            }

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Data = formatter.Deserialize(stream) as PlayerData;
            return Data;
        }
    }
}
