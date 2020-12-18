using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "new item", menuName = "Item/Individual/consumable")]
public class Consumable : Item
{
    public Types ItemType;
    public float Amount;
    public enum Types
    {
        ManaPotion,
        HealingPotion,
        Poision
    }

}
