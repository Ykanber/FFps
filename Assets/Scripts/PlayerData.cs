[System.Serializable]
public class PlayerData
{

    public int hpLevel;
    public int pistolMastery;
    public int rifleMastery;
    public int upgradeMaterial;
    public int deathCount;

    public PlayerData(Player player)
    {
        upgradeMaterial = player.upgradeMaterial;
        hpLevel = player.hpLevel;
        pistolMastery = player.pistolMastery;
        rifleMastery = player.rifleMastery;
        deathCount = player.deathCount;
    }

}
