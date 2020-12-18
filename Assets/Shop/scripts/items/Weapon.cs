using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "new item", menuName = "Item/Individual/weapon")]
public class Weapon : Item
{
    
    public Types ItemType;
   
    public int Hands;

    public enum Types
    {
        Staff,
        Sword,
        Dagger
    }

}
