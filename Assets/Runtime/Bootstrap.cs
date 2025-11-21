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
        EnchanceTableModel enchanceTableModel = new EnchanceTableModel();
        enchanceTableModel.SetChances(GetChances());
        enchanceTableModel.SetScroll(new ScrollModel(GetScrollProperties()));

        WeaponCreationModel weaponCreationModel = new WeaponCreationModel(GetDefualtProperties(), new WeaponFactory());

        _enchanceTablePresenter = new EnchanceTablePresenter(enchanceTableModel, _enchancerTableView, _weaponView);
        _weaponCreationPresenter = new WeaponCreationPresenter(weaponCreationModel, _weaponCreationView, enchanceTableModel);

        _enchanceTablePresenter.Enable();
        _weaponCreationPresenter.Enable();
    }

    private Dictionary<WeaponType, Dictionary<string, int>> GetDefualtProperties()
    {
        string json = File.ReadAllText(Application.dataPath + "/Content/Default.json");
        return JSON.Load(json).Make<Dictionary<WeaponType, Dictionary<string, int>>>();
    }

    private Dictionary<string, int> GetScrollProperties()
    {
        string json = File.ReadAllText(Application.dataPath + "/Content/Scroll.json");
        return JSON.Load(json).Make<Dictionary<string, int>>();
    }

    private Dictionary<int, float> GetChances()
    {
        string json = File.ReadAllText(Application.dataPath + "/Content/Chances.json");
        return JSON.Load(json).Make<Dictionary<int, float>>();
    }

    private void OnDestroy()
    {
        _weaponCreationPresenter.Disable();
        _enchanceTablePresenter.Disable();
    }
}
