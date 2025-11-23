using System.Collections.Generic;
using System.IO;
using TinyJSON;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private WeaponView _weaponView;
    [SerializeField] private EnchancerTableView _enchancerTableView;
    [SerializeField] private WeaponCreationView _weaponCreationView;

    private EnchanceTablePresenter _enchanceTablePresenter;
    private WeaponCreationPresenter _weaponCreationPresenter;
    private SaveLoadPresenter _saveLoadPresenter;

    private void Start()
    {
        References references = DataLoader.LoadReferences();

        ItemFactory itemFactory = new ItemFactory(references.GetDefaultStats());
        EnchanceTableModel enchanceTableModel = new EnchanceTableModel();
        enchanceTableModel.SetChances(references.GetChances());
        enchanceTableModel.SetItems(references.GetIncreaseStats());

        _enchanceTablePresenter = new EnchanceTablePresenter(enchanceTableModel, _enchancerTableView, _weaponView);
        _weaponCreationPresenter = new WeaponCreationPresenter(itemFactory, _weaponCreationView, enchanceTableModel);
        _saveLoadPresenter = new SaveLoadPresenter(enchanceTableModel, itemFactory);

        _enchanceTablePresenter.Enable();
        _weaponCreationPresenter.Enable();
        _saveLoadPresenter.Enable();
    }

    private void OnDestroy()
    {
        _saveLoadPresenter.Disable();
        _weaponCreationPresenter.Disable();
        _enchanceTablePresenter.Disable();
    }
}
