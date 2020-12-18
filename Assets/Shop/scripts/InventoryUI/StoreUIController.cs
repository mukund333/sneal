using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StoreUIController : MonoBehaviour
{
    [SerializeField] private GameObject itemTemplates;
    [SerializeField] private GameObject currencyTemplates;

    public MerchantInvetoryDetails merchantInvetoryDetails;
    
    private Transform _scrollViewContent;

    private PlayerInventoryUIController _playerInventoryUI;

    private void Start()
    {
        _playerInventoryUI = FindObjectOfType<PlayerInventoryUIController>();
    }

    


    public void PopulateInventory(MerchantInvetoryDetails inventoryList)
    {
        ClearInventory();
        merchantInvetoryDetails = inventoryList;

        foreach (var item in inventoryList.InventoryItems)
        {
            CreateInventoryItem(item);
        }
    }

    public void CreateInventoryItem( Item item)
    {
       
            GameObject newItem = Instantiate(itemTemplates, _scrollViewContent);

            newItem.transform.localScale = Vector3.one;

            newItem.transform.Find("Image/ItemImage").GetComponent<Image>().sprite = item.sprite;
            newItem.transform.Find("Name").GetComponent<Text>().text = item.itemName;
            newItem.transform.Find("Description").GetComponent<Text>().text = item.Description;

            foreach(var cur in item.PurchasePrice)
            {
                GameObject newCurrency = Instantiate(currencyTemplates, newItem.transform.Find("Currency/List"));
                newItem.transform.localScale = Vector3.one;

                newCurrency.transform.Find("Image").GetComponent<Image>().sprite = cur.Currency.Image;
                newCurrency.transform.Find("Amount").GetComponent<Text>().text = cur.Amount.ToString();
            }

            newItem.transform.Find("Currency/BuyBtn").GetComponent<Button>().onClick.AddListener(BuyOnClick);


        
    }

    private void Update()
    {
        
    }

    private void ClearInventory()
    {
        merchantInvetoryDetails = null;

        if (_scrollViewContent == null)
        {
            _scrollViewContent = transform.Find("Scroll View/Viewport/Content");
        }

        foreach (Transform child in _scrollViewContent)
        {
            Destroy(child.gameObject);
        }
    }

    public void BuyOnClick()
    {
        Item purchasedItem = merchantInvetoryDetails.InventoryItems.Find(x => x.itemName.Equals(
                             EventSystem.current.currentSelectedGameObject.transform.parent.parent.Find("Name").GetComponent<Text>().text));

        if(purchasedItem == null)
        {
            Debug.Log("Unable to find item in merchant database");

        }else if(purchasedItem.PurchasePriceInCopper() >=  _playerInventoryUI.playerInventoryDetails.CopperCoins)
        {
            Debug.Log("Cannot afford item");
            return;
        }


        _playerInventoryUI.PurchaseItem(purchasedItem);
        merchantInvetoryDetails.InventoryItems.Remove(purchasedItem);
        PopulateInventory(merchantInvetoryDetails);
    }
}
