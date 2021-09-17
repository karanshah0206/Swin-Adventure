namespace Swin_Adventure
{
    public interface IHaveInventory
    {
        Game Locate(string id);
        string Name { get; }
    }
}
