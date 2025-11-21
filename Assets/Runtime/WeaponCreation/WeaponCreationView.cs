using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponCreationView : MonoBehaviour
{
    [SerializeField] private Button _createButton;

    public void AddCreateClickedListener(UnityAction createClicked)
    {
        _createButton.onClick.AddListener(createClicked);
    }

    public void RemoveCreateClickedListener(UnityAction createClicked)
    {
        _createButton.onClick.RemoveListener(createClicked);
    }
}
