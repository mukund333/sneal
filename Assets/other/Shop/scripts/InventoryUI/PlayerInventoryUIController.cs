using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.LowLevel;
using System.Collections.Generic;

public class PlayerInventoryUIController : MonoBehaviour
{
    [SerializeField] private GameObject _playerInventoryWindow;
    public PlayerInventoryDetails playerInventoryDetails;
    private PlayerInventoryDetails cashingInventoryList;
	
	 [SerializeField]private EquipDatabase_SO equipDB;

    private Text _BagSpaceText;
    private Text _copperCurrencyText;
    private Text _silverCurrencyText;
    private Text _goldCurrencyText;


    [SerializeField] private GameObject _itemTemplate;
    private Transform _scrollViewContent;

    private void Awake()
    {
        _playerInventoryWindow = transform.parent.Find("PlayerInventory").gameObject;
        _BagSpaceText = _playerInventoryWindow.transform.Find("Footer/BagDetails/Amount").GetComponent<Text>();
        _copperCurrencyText = _playerInventoryWindow.transform.Find("Footer/CurrencyDetails/CopperCoin/CopperAmount").GetComponent<Text>();
        _silverCurrencyText = _playerInventoryWindow.transform.Find("Footer/CurrencyDetails/SilverCoin/SilverAmount").GetComponent<Text>();
        _goldCurrencyText = _playerInventoryWindow.transform.Find("Footer/CurrencyDetails/GoldCoin/GoldAmount").GetComponent<Text>();
        _scrollViewContent = _playerInventoryWindow.transform.Find("scrollview/Viewport/Content");
    }

    private void Start()
    {
        //Add logic for detecting available bag slots
        _BagSpaceText.text = string.Format("{0}/{1}",
                             playerInventoryDetails.totalBagsSlots - playerInventoryDetails.playerInventoryItems.Count,
                             playerInventoryDetails.totalBagsSlots
                                );

       
        //Update the currency 
        
        UpdateCurrency();
		ShowUI();

    }

    private void ShowUI()
    {
        
        PopulateInventory(playerInventoryDetails);
    }
    
    private void PopulateInventory(PlayerInventoryDetails inventoryList)
    {
       ClearInventory();

       cashingInventoryList = inventoryList;
        
      

        foreach (var item in inventoryList.playerInventoryItems)
        {
            CreateInventoryItem(item);
        }
    }


	// optimaze this operation with  object pool unity training shop ui  
    public void CreateInventoryItem( Item item)
    {
       
            GameObject newItem = Instantiate(_itemTemplate, _scrollViewContent);

            newItem.transform.localScale = Vector3.one;

            newItem.transform.Find("Image/ItemImage").GetComponent<Image>().sprite = item.sprite;
			  newItem.transform.Find("Name").GetComponent<Text>().text = item.itemName;
			
			
			
			newItem.transform.Find("Equip").GetComponent<Button>().onClick.AddListener(EquipOnClick);
           


        
    }
	// optimaze this operation with  object pool unity training shop ui  
    private void ClearInventory()
    {
        cashingInventoryList = null;
		
		Debug.Log("<color=red> optimazation: </color> <color=yellow> ClearInventory() , CreateInventoryItem( Item item) optimaze these operation with  object pool unity training shop ui</color>");
        if (_scrollViewContent == null)
        {
            _scrollViewContent = _playerInventoryWindow.transform.Find("scrollview/Viewport/Content");
        }

        foreach (Transform child in _scrollViewContent)
        {
            Destroy(child.gameObject);
        }
    }

    public void UpdateCurrency()
    {
        int[] cur = playerInventoryDetails.GetCoinCurrency();

        _copperCurrencyText.text = cur[0].ToString();
        _silverCurrencyText.text = cur[1].ToString();
        _goldCurrencyText.text = cur[2].ToString();
    }

    public void PurchaseItem(Item purchasedItem)
    {
        //deduct the money from the player
        playerInventoryDetails.CopperCoins -= purchasedItem.PurchasePriceInCopper();
        //add the item to the players inventory
        cashingInventoryList.playerInventoryItems.Add(purchasedItem);
		
		UpdateCurrency();
		
		PopulateInventory(cashingInventoryList);
       
      

        
    }
	
	public void EquipOnClick()
	{
		Item equipItem = cashingInventoryList.playerInventoryItems.Find(x => x.itemName.Equals(
                           EventSystem.current.currentSelectedGameObject.transform.parent.Find("Name").GetComponent<Text>().text));
							 
		//Debug.Log(""+equipItem.itemIdentityNumber);
		equipDB.SetWeaponNumber(equipItem.itemIdentityNumber);


      

    }
}
