using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnchantmentTableView : MonoBehaviour
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

    public void ShowEnchanceResult(EnchantmentResult result)
    {
        string resultText = Enum.GetName(typeof(EnchantmentResult), result);
        _enchantmentResultText.text = resultText;
    }

    public void ClearResult()
    {
        _enchantmentResultText.text = "";
    }
}
