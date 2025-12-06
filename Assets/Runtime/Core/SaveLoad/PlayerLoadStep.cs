using Data.Model;
using Data.References;
using System.IO;
using System.Threading.Tasks;
using TinyJSON;
using UnityEngine;

namespace SaveLoad
{
    public class PlayerLoadStep : IStep
    {
        private PlayerModel _player;
        private Descriptions _descriptions;

        public PlayerLoadStep(PlayerModel player, Descriptions descriptions)
        {
            _player = player;
            _descriptions = descriptions;
        }

        public async Task Execute()
        {
            string playerPath = DataPath() + "\\player.json";
            if (File.Exists(playerPath))
            {
                string playerJson = await File.ReadAllTextAsync(playerPath);
                _player.SetData(JSON.Load(playerJson), _descriptions);
            }
            else
            {
                _player.SetData(_descriptions);
            }
        }

        private string DataPath()
        {
            return Application.dataPath + "\\Content\\Data";
        }
    }
}
