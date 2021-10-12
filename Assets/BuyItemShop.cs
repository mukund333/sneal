using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BuyItemShop : MonoBehaviour
{
	public int coins;
      public GameObject AdPanel;

  [SerializeField] PowerUpUnlockData powerUpUnlockData;
  [SerializeField] GunPowerupUnlockData gunPowerupUnlockData;
  [SerializeField] int currentLevel;
  [SerializeField] int maxLevel;
  
   public Slider slider;
   
   
   public GameObject ItemUIPrefab;
   public Transform itemsHolder;
   public GameObject g;
   Button buyBtn;
   public List<ItemTemplate> powerupItems;
   
	
   
   
    private void Start(){
		
		powerUpUnlockData.LoadUnlockData();
		
		for(int i= 0; i<powerupItems.Count;i++)
		{
			
			g = Instantiate(ItemUIPrefab,itemsHolder);
			g.transform.Find("ItemImage").GetComponent<Image>().sprite = powerupItems[i].image;
			g.transform.Find("descriptionText").GetComponent<Text>().text= powerupItems[i].itemDescription;
			g.transform.Find("valueText").GetComponent<Text>().text= powerupItems[i].price[powerupItems[i].itemLevel].ToString();
			slider = g.transform.Find("UpgradeSlider").GetComponent<Slider>();
			slider.maxValue = powerupItems[i].price.Length;
			slider.value = powerupItems[i].itemLevel;
			buyBtn = g.transform.Find("BuyButton").GetComponent<Button>();
			
			
			buyBtn.AddEventListener(i,BuyItem);
			
			
			
		}
		
	   
   }
   
	public void BuyItem(int itemIndex){
	   	    currentLevel = powerupItems[itemIndex].itemLevel;
			maxLevel = powerupItems[itemIndex].price.Length;		
			
	   if(currentLevel<maxLevel && powerupItems[itemIndex].itemLevel!=maxLevel){
	   
	   
			if(powerupItems[itemIndex].price[currentLevel]<= coins)
			{
				coins -=powerupItems[itemIndex].price[currentLevel];
				
				
				
				
				buyBtn = itemsHolder.GetChild(itemIndex).Find("BuyButton").GetComponent<Button>();
				
				if(powerupItems[itemIndex].isUpgradable==true)
				{
					powerUpUnlockData.SetBuyCount(itemIndex,powerupItems[itemIndex].itemId);			
				}else{
					gunPowerupUnlockData.SetBuyCount(itemIndex,powerupItems[itemIndex].itemId);			
				}
				
				
				
				powerupItems[itemIndex].itemLevel++;
				
				if(powerupItems[itemIndex].itemLevel < powerupItems[itemIndex].price.Length){
					itemsHolder.GetChild(itemIndex).Find("valueText").GetComponent<Text>().text= powerupItems[itemIndex].price[powerupItems[itemIndex].itemLevel].ToString();
					slider =  itemsHolder.GetChild(itemIndex).Find("UpgradeSlider").GetComponent<Slider>();
					 
					slider.value = powerupItems[itemIndex].itemLevel;
				}
				

				
				Debug.Log("Powerup:"+powerupItems[itemIndex].itemName+powerupItems[itemIndex].itemValue[currentLevel]);
		   
			}else 
			{
				Debug.Log("not enough coins");
				OpenAdPanel();
			}
	   }
	   
	   if(powerupItems[itemIndex].itemLevel==maxLevel){
	
			itemsHolder.GetChild(itemIndex).Find("valueText").GetComponent<Text>().text="MAX";
		   
		   	buyBtn = itemsHolder.GetChild(itemIndex).Find("BuyButton").GetComponent<Button>();
			
			buyBtn.transform.GetChild(0).GetComponent<Text>().text = "Max";
			buyBtn.interactable= false;
			Debug.Log("MAx");
	   }
	   
	   
	 
	   
   }
    
	public void OpenAdPanel()
	{
		AdPanel.SetActive(true);
	}
	
	public void CloseAdPanel()
	{
		AdPanel.SetActive(false);
	}
		
  
}

[System.Serializable]
public class ItemTemplate
{	public string itemName;
	public int itemId;
	public bool isUpgradable;
	public Sprite image;
	public string itemDescription;
	public int[] price = {100,200,300,400};
	public int itemLevel = 0;
	public int[] itemValue = {4,5,6,7};
	
	  
	  
	
}
