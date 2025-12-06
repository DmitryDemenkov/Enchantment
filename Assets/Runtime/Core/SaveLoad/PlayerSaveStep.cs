using Data.Model;
using System.IO;
using System.Threading.Tasks;
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

        public async Task Execute()
        {
            string path = DataPath() + "\\player.json";
            string json = _player.Serialize();
            await File.WriteAllTextAsync(path, json);
            await Task.Delay(2000);
        }

        private string DataPath()
        {
            return Application.dataPath + "\\Content\\Data";
        }
    }
}
