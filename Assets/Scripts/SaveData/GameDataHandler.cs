using System.IO;
using Data;
using UnityEngine;

namespace SaveData
{
    public class GameDataHandler
    {
        private readonly string _filePath;

        public GameDataHandler()
        {
            _filePath = Path.Combine(Application.persistentDataPath, "GameResults.json");
        }
        
        public void SaveResults(GameResults results)
        {
            var json = JsonUtility.ToJson(results, true);
            File.WriteAllText(_filePath, json);
        }

        public GameResults LoadResult()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);

                if (string.IsNullOrEmpty(json))
                {
                    Debug.LogWarning("GameResults.json is empty. Returning new GameResults.");
                    return new GameResults();
                }
                
                return JsonUtility.FromJson<GameResults>(json);
            }

            return new GameResults();
        }
    }
}
