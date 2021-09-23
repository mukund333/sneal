using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
	[System.Serializable]class ShopItem{
		public Sprite Image;
		public int Price;
		public bool IsPurchased = false;
	}
	
	[SerializeField] List<ShopItem> ShopItemsList;
	
	GameObject ItemTemplate;
	GameObject g;
	public Transform ShopScrollView;
	Button buyBtn;
	

    void Start()
    {
			ItemTemplate = ShopScrollView.GetChild(0).gameObject;
			int len = ShopItemsList.Count;
			for(int i =0 ;i < len; i++)
			{
				g= Instantiate(ItemTemplate,ShopScrollView);
				g.transform.GetChild(0).GetComponent<Image>().sprite = ShopItemsList[i].Image;
				g.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = ShopItemsList[i].Price.ToString();
				buyBtn = g.transform.GetChild(2).GetComponent<Button>();
				buyBtn.interactable = !ShopItemsList[i].IsPurchased;
				buyBtn.AddEventListener(i,OnShopItemBtnClicked);
			}
			
			Destroy(ItemTemplate);
    }

	void OnShopItemBtnClicked(int itemIndex){
		
		if(Game.Instance.HasEnoughCoins(ShopItemsList[itemIndex].Price)){
			Game.Instance.UseCoins(ShopItemsList[itemIndex].Price);
			ShopItemsList[itemIndex].IsPurchased = true;
			buyBtn =  ShopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
			buyBtn.interactable= false;
			buyBtn.transform.GetChild(0).GetComponent<Text>().text = "PURCHASED";
			
		}else{
			Debug.Log("not enough coins");
		}
		
		 
	}
}
