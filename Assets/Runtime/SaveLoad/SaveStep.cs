public class SaveStep
{
    private PlayerModel _player;

    public SaveStep(PlayerModel player)
    {
        _player = player;
    }

    public void SavePlayerData()
    {
        DataLoader.SavePlayerData(_player);
    }
}
