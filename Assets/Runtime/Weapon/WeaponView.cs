using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup _tableLayoutGroup;
    [SerializeField] private Text _nameTextPrefab;
    [SerializeField] private Text _valueTextPrefab;

    private int _weaponlevel;
    private string _weaponType;
    private Dictionary<string, int> _currentData;
    private List<Text> _currentTexts = new List<Text>();

    public void UpdateInformation(int level, string weaponType, Dictionary<string, int> newData)
    {
        _currentData = newData;
        _weaponlevel = level;
        _weaponType = weaponType;
        ClearTable();
        CreateTable();
    }

    private void ClearTable()
    {
        foreach (Text textElement in _currentTexts)
        {
            if (textElement != null) Destroy(textElement.gameObject);
        }
        _currentTexts.Clear();
    }

    private void CreateTable()
    {
        CreateTableRow("Тип", _weaponType);
        CreateTableRow("Уровень", _weaponlevel.ToString());

        foreach (KeyValuePair<string, int> item in _currentData)
        {
            CreateTableRow(item.Key, item.Value.ToString());            
        }
    }

    private void CreateTableRow(string name, string value)
    {
        Text nameText = Instantiate(_nameTextPrefab, _tableLayoutGroup.transform);
        nameText.text = name;
        _currentTexts.Add(nameText);

        Text valueText = Instantiate(_valueTextPrefab, _tableLayoutGroup.transform);
        valueText.text = value;
        _currentTexts.Add(valueText);
    }
}
