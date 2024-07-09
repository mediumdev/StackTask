namespace Game.Gameplay
{
    public interface IConfig
    {
        float stackTransferDistance { get; }
        float resourceTransferSpeed { get; }
        string animationRunParamName { get; }
    }
}
