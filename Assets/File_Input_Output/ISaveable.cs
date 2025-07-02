using Sirenix.OdinInspector;

namespace File_Input_Output
{
    public interface ISaveable
    {
       
        [Button]
        void Save(ref GameData gameData);

        [Button]
        void Load(GameData gameData);
    }
}