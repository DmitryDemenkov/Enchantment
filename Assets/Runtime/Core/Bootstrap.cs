using Data.Model;
using Data.Provider;
using Data.References;
using Enchantment.EnchanceTable;
using Enchantment.ItemCreation;
using SaveLoad;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private EnchantmentTableView _enchantmentTableView;
    [SerializeField] private ItemСreationView _itemСreationView;

    private EnchantmentTablePresenter _enchantmentTablePresenter;
    private ItemСreationPresenter _itemСreationPresenter;
    private PlayerSaveStep _saveStep;

    private AddressablePresenter _addressablePresenter;
    private AddressableModel _addressableModel;

    private async void Start()
    {
        Descriptions descriptions = new Descriptions();
        PlayerModel playerModel = new PlayerModel();

        IStep[] loadSteps =
        {
            new DescriptionsLoadStep(descriptions),
            new PlayerLoadStep(playerModel, descriptions)
        };

        foreach (var loadStep in loadSteps)
        {
            await loadStep.Execute();
        }

        _addressableModel = new AddressableModel();
        _addressablePresenter = new AddressablePresenter(_addressableModel);

        _enchantmentTablePresenter = new EnchantmentTablePresenter(playerModel.CurrentItem, _enchantmentTableView, _addressableModel, descriptions.ViewDescriptions);
        _itemСreationPresenter = new ItemСreationPresenter(_itemСreationView, playerModel.CurrentItem);
        _saveStep = new PlayerSaveStep(playerModel);

        _addressablePresenter.Enable();
        _enchantmentTablePresenter.Enable();
        _itemСreationPresenter.Enable();

        

        Application.quitting += OnQuit;

#if UNITY_EDITOR
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
#endif
    }

#if UNITY_EDITOR
    private void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingPlayMode)
        {
            Dispose();
        }
    }
#endif

    private void OnQuit()
    {
        Dispose();
    }

    private async void Dispose()
    {
#if UNITY_EDITOR
        EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
#endif
        Application.quitting -= OnQuit;

        Task saveTask = _saveStep.Execute();        

        _itemСreationPresenter.Disable();
        _enchantmentTablePresenter.Disable();
        _addressablePresenter.Disable();

        await saveTask;
    }
}
