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
    private SaveLoadPresenter _saveLoadPresenter;

    private void Start()
    {
        References references = DataLoader.LoadReferences();

        ItemFactory itemFactory = new ItemFactory(references.GetDefaultStats());
        EnchantmentTableModel enchantmentTableModel = new EnchantmentTableModel();
        enchantmentTableModel.SetChances(references.GetChances());
        enchantmentTableModel.SetItems(references.GetIncreaseStats());

        _enchantmentTablePresenter = new EnchantmentTablePresenter(enchantmentTableModel, _enchantmentTableView, _itemView);
        _itemСreationPresenter = new ItemСreationPresenter(itemFactory, _itemСreationView, enchantmentTableModel);
        _saveLoadPresenter = new SaveLoadPresenter(enchantmentTableModel, itemFactory);

        _enchantmentTablePresenter.Enable();
        _itemСreationPresenter.Enable();
        _saveLoadPresenter.Enable();
    }

    private void OnDestroy()
    {
        _saveLoadPresenter.Disable();
        _itemСreationPresenter.Disable();
        _enchantmentTablePresenter.Disable();
    }
}
