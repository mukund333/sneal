using UnityEngine;
using System.Collections;


[CreateAssetMenu(menuName = "Item/Individual/Armor", fileName = "Armor Name")]
public class ArmorItem : Item
{

    public Types ItemType;
    public enum Types
    {
        Head,
        Shoulders,
        Chest,
        Belt,
        Legs,
        Feet,
        Wrist,
        Hands
    }
}
