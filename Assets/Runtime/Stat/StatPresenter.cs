public class StatPresenter
{
    private readonly StatModel _statModel;
    private readonly StatView _statView;

    public StatPresenter(StatModel statModel, StatView statView)
    {
        _statModel = statModel;
        _statView = statView;
    }

    public void Enable()
    {
        _statModel.Changed += OnStatChanged;

        _statView.SetName(_statModel.Id);
        _statView.SetValue(_statModel.Value);
    }

    public void Disable()
    {
        _statModel.Changed -= OnStatChanged;
        _statView.Destroy();
    }

    private void OnStatChanged(int value)
    {
        _statView.SetValue(value);
    }
}
