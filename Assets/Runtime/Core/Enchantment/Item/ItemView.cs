using Enchantment.Stat;
using UnityEngine;
using UnityEngine.UI;

namespace Enchantment.Item
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField] private GridLayoutGroup _tableLayoutGroup;
        [SerializeField] private Image _icon;
        [SerializeField] private StatView _statViewPrefab;
        [SerializeField] private Text _typeText;
        [SerializeField] private Text _levelText;


        public void UpdateInformation(int level, string type)
        {
            UpdateLevel(level);
            _typeText.text = type;
        }

        public void UpdateLevel(int level)
        {
            _levelText.text = level.ToString();
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public void SetIcon(Sprite icon)
        {
            _icon.sprite = icon;
        }

        public StatView CreateStatView()
        {
            StatView statView = Instantiate(_statViewPrefab, _tableLayoutGroup.transform);
            return statView;
        }
    }
}
