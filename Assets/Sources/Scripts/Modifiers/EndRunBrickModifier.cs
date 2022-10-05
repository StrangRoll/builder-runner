public class EndRunBrickModifier: IModifier
{
    private float _increaseStep = 0.1f;
    private float _PriceMultiplier = 1.1f;

    public float BrickCountModifier { get; private set; } = 1.0f;

    public void BuyNextLevel()
    {

    }
}
