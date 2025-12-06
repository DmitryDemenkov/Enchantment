using Data.References;
using System.IO;
using System.Threading.Tasks;
using TinyJSON;
using UnityEngine;

namespace SaveLoad
{
    public class DescriptionsLoadStep : IStep
    {
        private Descriptions _descriptions;

        public DescriptionsLoadStep(Descriptions descriptions)
        {
            _descriptions = descriptions;
        }

        public async Task Execute()
        {
            string descriptionsPath = DataPath() + "\\references.json";
            string descriptionsJson = await File.ReadAllTextAsync(descriptionsPath);

            var descriptionsJsonData = JSON.Load(descriptionsJson);
            _descriptions.SetData(descriptionsJsonData);
        }

        private static string DataPath()
        {
            return Application.dataPath + "\\Content\\Data";
        }
    }
}
