using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace File_Input_Output
{
    public class FileHandler
    {
        private string fileName = "TryFile";
        private string fullPath;
        private string fullBackupFilePath;

        public FileHandler(string path, string fileName = "SaveFile")
        {
            this.fullPath = Path.Combine(path, fileName);
        }

        public void Save(GameData gameData)
        {
            try
            {
                string dataToSave = JsonUtility.ToJson(gameData, true);

                using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                {
                    using (StreamWriter reader = new StreamWriter(stream))
                        // using (StreamWriter reader = new StreamWriter(fullPath))
                    {
                        reader.Write(dataToSave);
                        Debug.Log("Write " + dataToSave);
                        //TODO SAVE BACK FILE
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("Exception : " + e);
            }
        }

        public string LoadGame()
        {
            if (File.Exists(fullPath))
            {
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            //TODO check for backup file then do load if no failed to load file 


            return "";
        }
    }
}