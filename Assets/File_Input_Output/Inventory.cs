using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace File_Input_Output
{
    public class Inventory : MonoBehaviour, ISaveable
    {
      
        public void Save(ref GameData gameData)
        {
            gameData.UpdateData(id, data);
        }

 [Button]

        public void Load(GameData gameData)
        {
        }

        [SerializeField] private int id = 0;

        private string data = "Inventory Data";
    }
}