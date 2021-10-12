using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{

    string placement = "rewardedVideo";
	
	[SerializeField]private GameObject shop;
	BuyItemShop buyItemShop;


    private void Start()
    {
		shop = GameObject.Find("shop");
		buyItemShop =  shop.GetComponent<BuyItemShop>();
		
        Advertisement.AddListener(this);
        Advertisement.Initialize("4393029", true);
    }


    public void ShowAd(string p)
    {
        Advertisement.Show(p);
    }



    public void OnUnityAdsDidError(string message)
    {
        
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
			buyItemShop.coins += 500;
			
			
			buyItemShop.CloseAdPanel();
			Debug.Log("500 gold added");
        }
        else if (showResult == ShowResult.Failed)
        { 
            
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        
    }

    public void OnUnityAdsReady(string placementId)
    {
        
    }
}
