using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnchancerTableView : MonoBehaviour
{
    [SerializeField] private Button _enchanceButton;
    [SerializeField] private Text _enchantmentResultText;

    public void AddEnchanceClickedListener(UnityAction enchanceClicked)
    {
        _enchanceButton.onClick.AddListener(enchanceClicked);
    }

    public void RemoveEnchanceClickedListener(UnityAction enchanceClicked)
    {
        _enchanceButton.onClick.RemoveListener(enchanceClicked);
    }

    public void ShowEnchanceResult(bool result)
    {
        if (result)
        {
            _enchantmentResultText.text = "Success";
        }
        else
        {
            _enchantmentResultText.text = "Failure";
        }
    }
}
