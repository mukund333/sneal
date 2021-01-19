using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/PlayerInventory", fileName = "PlayerInventoryData")]
public class PlayerInventoryDetails : ScriptableObject
{
    public List<Item> playerInventoryItems;
    public int CopperCoins;
    [Range(5,50)]
    public int totalBagsSlots;
    
    public int[] GetCoinCurrency()
    {
        int[] currency = new int[] { 0, 0, 0 };

        currency[0] = CopperCoins % 100;
        currency[1] = (CopperCoins / 100) % 100;
        currency[2] = (CopperCoins / 100) / 100;


        return currency;
    }
}
