using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup _tableLayoutGroup;
    [SerializeField] private StatView _statViewPrefab;

    private StatView _levelRow;

    public void UpdateInformation(int level, string type)
    {
        ClearTable();

        StatView typeRow = CreateStatView();
        typeRow.SetName("type");
        typeRow.SetValue(type);

        _levelRow = CreateStatView();
        _levelRow.SetName("level");
        _levelRow.SetValue(level);
    }

    public void ClearTable()
    {
        foreach (Transform child in _tableLayoutGroup.transform)
        {
            Destroy(child.gameObject);
        }
        _levelRow = null;
    }

    public void UpdateLevel(int level)
    {
        _levelRow.SetValue(level);
    }

    public StatView CreateStatView()
    {
        StatView statView = Instantiate(_statViewPrefab, _tableLayoutGroup.transform);
        return statView;
    }
}
