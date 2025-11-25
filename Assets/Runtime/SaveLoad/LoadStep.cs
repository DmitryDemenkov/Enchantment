public class LoadStep
{
    private PlayerModel _player;

    public PlayerModel LoadPlayerData()
    {
        _player = DataLoader.LoadPlayerData();
        return _player;
    }
}

