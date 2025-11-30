using UnityEngine;
using UnityEngine.UI;

public class StatView : MonoBehaviour
{
    [SerializeField] private Image _icon;
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

    public void SetIcon(Sprite icon)
    {
        _icon.sprite = icon;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
