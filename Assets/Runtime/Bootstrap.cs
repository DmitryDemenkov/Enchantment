using System.Collections.Generic;
using System.IO;
using TinyJSON;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private ItemView _itemView;
    [SerializeField] private EnchantmentTableView _enchantmentTableView;
    [SerializeField] private ItemСreationView _itemСreationView;

    private EnchantmentTablePresenter _enchantmentTablePresenter;
    private ItemСreationPresenter _itemСreationPresenter;
    private SaveStep _saveStep;
    private LoadStep _loadStep;

    private void Start()
    {
        _loadStep = new LoadStep();
        PlayerModel playerModel = _loadStep.LoadPlayerData();

        _enchantmentTablePresenter = new EnchantmentTablePresenter(playerModel.CurrentItem, _enchantmentTableView, _itemView);
        _itemСreationPresenter = new ItemСreationPresenter(_itemСreationView, playerModel.CurrentItem);
        _saveStep = new SaveStep(playerModel);

        _enchantmentTablePresenter.Enable();
        _itemСreationPresenter.Enable();
    }

    private void OnDestroy()
    {
        //_saveStep.SavePlayerData();

        _itemСreationPresenter.Disable();
        _enchantmentTablePresenter.Disable();
    }
}
