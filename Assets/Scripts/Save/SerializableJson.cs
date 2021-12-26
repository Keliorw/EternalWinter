[System.Serializable]
public class PlayerData
{
    public PlayerProgress[] Player;
}

[System.Serializable]
public class PlayerProgress
{
    public string Money;
    public string Gifts;
    public string MusicVolume;
    public string SoundVolume;
}

[System.Serializable]
public class UnitsData
{
    public UnitStats[] Units;
}

[System.Serializable]
public class UnitStats
{
    public string Name;
    public string Level;
    public string Cards;
    public string Damage;
    public string AttackSpeed;
    public string Health;
    public string Generator;
    public string Price;
}