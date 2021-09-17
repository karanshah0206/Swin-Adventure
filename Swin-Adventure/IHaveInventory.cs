namespace Swin_Adventure
{
    interface IHaveInventory
    {
        void Locate(string id);
        string Name { get; }
    }
}
