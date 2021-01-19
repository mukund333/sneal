using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Inventory",fileName ="Inventory Data" )]
public class MerchantInvetoryDetails : ScriptableObject
{
    public List<Item> InventoryItems = new List<Item>();
}
