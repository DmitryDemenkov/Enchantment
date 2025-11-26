using UnityEngine;
using UnityEngine.UI;

public class StatView : MonoBehaviour
{
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _valueText;

    public void SetName(string name)
    {
        _nameText.text = name;
    }

    public void SetValue(int value)
    {
        _valueText.text = value.ToString();
    }

    public void SetValue(string value)
    {
        _valueText.text = value;
    }
}
