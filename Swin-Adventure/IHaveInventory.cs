namespace Swin_Adventure
{
    interface IHaveInventory
    {
        Game Locate(string id);
        string Name { get; }
    }
}
