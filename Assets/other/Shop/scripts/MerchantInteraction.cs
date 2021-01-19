using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantInteraction : MonoBehaviour
{
    [SerializeField]private MerchantInvetoryDetails _inventoryList;
    [SerializeField]private GameObject _storeUI;
    [SerializeField]private StoreUIController storeUIController;

    private void Awake()
    {
        _storeUI = GameObject.FindGameObjectWithTag("Store");
        storeUIController = _storeUI.GetComponent<StoreUIController>();
    }

    private void Start()
    {
        storeUIController.PopulateInventory(_inventoryList);

        
    }

   


}
