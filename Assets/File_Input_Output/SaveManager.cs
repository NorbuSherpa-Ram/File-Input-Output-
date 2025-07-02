using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine.Rendering;

namespace File_Input_Output
{
    public class SaveManager : MonoBehaviour
    {
        private FileHandler fileHandler;

        public GameData gameData;

        [ShowInInspector]
        [SerializeField] private List<ISaveable> saveables = new List<ISaveable>();

        private void Start()
        {
            fileHandler = new FileHandler(Application.dataPath);
            RefreshSaveables();
        }

        private void RefreshSaveables()
        {
            saveables.Clear();
            saveables. AddRange(FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<ISaveable>());
        }

        [Button] // get all data of current scene as data tat are already in dictionty into json
        public void SaveGame()
        {
            RefreshSaveables();
            foreach (var saveable in saveables)
            {
                saveable.Save(ref gameData);
            }

            fileHandler.Save(gameData);
        }
    }

    [Serializable]
    public class GameData
    {
        public SerializedDictionary<int, string> saveData = new SerializedDictionary<int, string>();

        public void UpdateData(int id, string data)
        {
            if (saveData.ContainsKey(id))
            {
                saveData[id] = data;
            }
            else
            {
                saveData.Add(id, data);
            }
        }
    }
}