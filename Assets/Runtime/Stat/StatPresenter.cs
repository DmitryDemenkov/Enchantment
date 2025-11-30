public class StatPresenter
{
    private readonly StatModel _statModel;
    private readonly StatView _statView;
    private AddressableIconProvider _addressableIconProvider;

    private IconHandle _iconHandle;
    private int _iconLoadVersion;

    public StatPresenter(StatModel statModel, StatView statView, AddressableIconProvider addressableIconProvider)
    {
        _statModel = statModel;
        _statView = statView;
        _addressableIconProvider = addressableIconProvider;
    }

    public void Enable()
    {
        _statModel.Changed += OnStatChanged;

        _statView.SetName(_statModel.Id);
        _statView.SetValue(_statModel.Value);

        _iconLoadVersion++;
        int currentVersion = _iconLoadVersion;
        LoadIconAsync(currentVersion);
    }

    public void Disable()
    {
        _statModel.Changed -= OnStatChanged;

        _iconLoadVersion++;

        if (_iconHandle != null)
        {
            _addressableIconProvider.ReleaseIcon(_iconHandle);
            _iconHandle = null;
        }

        _statView.Destroy();
    }

    private async void LoadIconAsync(int version)
    {
        IconHandle handle = await _addressableIconProvider.LoadIconAsync(_statModel.Id);
        
        if (version == _iconLoadVersion)
        {
            _iconHandle = handle;

            if (_iconHandle != null && _iconHandle.Sprite != null)
            {
                _statView.SetIcon(_iconHandle.Sprite);
            }
        }
        else
        {
            if (handle != null)
            {
                _addressableIconProvider.ReleaseIcon(handle);
            }
        }
    }

    private void OnStatChanged(int value)
    {
        _statView.SetValue(value);
    }
}
