public interface IHumans
{

    /// <summary>
    /// Lorsque appelé, permet de retourner le type d'humain que le personnage incarne
    /// </summary>
    /// <returns></returns>
    public HumansType GetHumansType();
}
public enum HumansType {
    Healer,
    Trainer,
}
