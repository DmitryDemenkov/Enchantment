using Data.Model;
using System.IO;
using UnityEngine;

namespace SaveLoad
{
    public class PlayerSaveStep : IStep
    {
        private PlayerModel _player;

        public PlayerSaveStep(PlayerModel player)
        {
            _player = player;
        }

        public void Execute()
        {
            string path = DataPath() + "\\player.json";
            string json = _player.Serialize();
            File.WriteAllText(path, json);
        }

        private string DataPath()
        {
            return Application.dataPath + "\\Content\\Data";
        }
    }
}
