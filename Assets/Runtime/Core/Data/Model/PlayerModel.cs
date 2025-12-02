using Data.Model.Item;
using Data.Model.Random;
using Data.References;
using TinyJSON;

namespace Data.Model
{
    public class PlayerModel
    {
        public SeedModelCollection Seeds { get; private set; }
        public CurrentItemModel CurrentItem { get; private set; }

        public PlayerModel()
        {
            CurrentItem = null;
        }

        public void SetData(Descriptions descriptions)
        {
            Seeds = new SeedModelCollection();
            CurrentItem = new CurrentItemModel(descriptions, Seeds);
        }

        public void SetData(Variant variant, Descriptions descriptions)
        {
            Seeds = new SeedModelCollection(variant["seeds"]);
            CurrentItem = new CurrentItemModel(variant["current_item"], descriptions, Seeds);
        }

        public string Serialize()
        {
            return $"{{\"current_item\":{CurrentItem.Serialize()},\"seeds\":{Seeds.Serialize()}}}";
        }
    }
}
