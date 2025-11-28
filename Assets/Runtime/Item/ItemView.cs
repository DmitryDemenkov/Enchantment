using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup _tableLayoutGroup;
    [SerializeField] private StatView _statViewPrefab;
    [SerializeField] private Text _typeTextPrefab;
    [SerializeField] private Text _levelTextPrefab;

    public void UpdateInformation(int level, string type)
    {
        UpdateLevel(level);
        _typeTextPrefab.text = type;
    }

    public void UpdateLevel(int level)
    {
        _levelTextPrefab.text = level.ToString();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public StatView CreateStatView()
    {
        StatView statView = Instantiate(_statViewPrefab, _tableLayoutGroup.transform);
        return statView;
    }
}
