using UnityEditor;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private EnchantmentTableView _enchantmentTableView;
    [SerializeField] private ItemСreationView _itemСreationView;

    private EnchantmentTablePresenter _enchantmentTablePresenter;
    private ItemСreationPresenter _itemСreationPresenter;
    private PlayerSaveStep _saveStep;
    private AddressableIconProvider _addressableIconProvider;

    private void Start()
    {
        Descriptions descriptions = new Descriptions();
        PlayerModel playerModel = new PlayerModel();

        IStep[] loadSteps =
        {
            new DescriptionLoadStep(descriptions),
            new PlayerLoadStep(playerModel, descriptions)
        };

        foreach (var loadStep in loadSteps)
        {
            loadStep.Execute();
        }

        _addressableIconProvider = new AddressableIconProvider();
        _enchantmentTablePresenter = new EnchantmentTablePresenter(playerModel.CurrentItem, _enchantmentTableView, _addressableIconProvider);
        _itemСreationPresenter = new ItemСreationPresenter(_itemСreationView, playerModel.CurrentItem);
        _saveStep = new PlayerSaveStep(playerModel);

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

    private void Dispose()
    {
#if UNITY_EDITOR
        EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
#endif
        Application.quitting -= OnQuit;

        _saveStep.Execute();

        _itemСreationPresenter.Disable();
        _enchantmentTablePresenter.Disable();
    }
}
