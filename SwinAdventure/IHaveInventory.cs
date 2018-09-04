using System;

namespace SwinAdventure
{
    interface IHaveInventory
    {
        GameObject Locate(string id);

        string Name { get; }
    }
}