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

    private void Start()
    {
        References references = LoadReferences();

        ItemFactory itemFactory = new ItemFactory(references.GetDefaultStats());
        EnchanceTableModel enchanceTableModel = new EnchanceTableModel();
        enchanceTableModel.SetChances(references.GetChances());
        enchanceTableModel.SetItems(references.GetIncreaseStats());

        _enchanceTablePresenter = new EnchanceTablePresenter(enchanceTableModel, _enchancerTableView, _weaponView);
        _weaponCreationPresenter = new WeaponCreationPresenter(itemFactory, _weaponCreationView, enchanceTableModel);

        _enchanceTablePresenter.Enable();
        _weaponCreationPresenter.Enable();
    }

    private References LoadReferences()
    {
        string json = File.ReadAllText(Application.dataPath + "\\Content\\Data\\references.json");
        return JSON.Load(json).Make<References>();
    }

    private void OnDestroy()
    {
        _weaponCreationPresenter.Disable();
        _enchanceTablePresenter.Disable();
    }
}
