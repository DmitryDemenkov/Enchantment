using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup _tableLayoutGroup;
    [SerializeField] private Text _nameTextPrefab;
    [SerializeField] private Text _valueTextPrefab;

    private int _level;
    private string _type;
    private IReadOnlyDictionary<string, int> _currentData;
    private List<Text> _currentTexts = new List<Text>();

    public void UpdateInformation(int level, string type, IReadOnlyDictionary<string, int> newData)
    {
        _currentData = newData;
        _level = level;
        _type = type;
        ClearTable();
        CreateTable();
    }

    public void ClearTable()
    {
        foreach (Text textElement in _currentTexts)
        {
            if (textElement != null) Destroy(textElement.gameObject);
        }
        _currentTexts.Clear();
    }

    private void CreateTable()
    {
        CreateTableRow("Тип", _type);
        CreateTableRow("Уровень", _level.ToString());

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
