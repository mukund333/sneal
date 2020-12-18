using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


[CreateAssetMenu(menuName = "Item/Individual/Generic", fileName = "Generic Item Name")]
public class Item : ScriptableObject
{
   
    public string itemName = "New Item";
	
	public int itemIdentityNumber;
	
    public string Description = "Item Description";

   
    public int MinimumLevel;

    
    public Sprite sprite;

   
    public List<CurrencyDefinition> PurchasePrice;

   
   // public float SellPriceReduction = 0.10f;

    public int PurchasePriceInCopper()
    {
        int copperCoins = 0;
        copperCoins += PurchasePrice.Where(x => x.Currency.Name.Equals("Copper")).Select(s => s.Amount).DefaultIfEmpty(0).Single();
        copperCoins += PurchasePrice.Where(x => x.Currency.Name.Equals("Silver")).Select(s => s.Amount).DefaultIfEmpty(0).Single() * 100;
        copperCoins += (PurchasePrice.Where(x => x.Currency.Name.Equals("Gold")).Select(s => s.Amount).DefaultIfEmpty(0).Single()*100)*100;

        return copperCoins;
    }


}
