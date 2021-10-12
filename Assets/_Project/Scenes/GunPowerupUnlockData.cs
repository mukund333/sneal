using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GunPowerupUnlockData", menuName = "GunPowerupUnlockData")]
public class GunPowerupUnlockData : ScriptableObject
{
    	public  bool zeroBuy = true;
			public  int item;
				public List<int> powerUpList = new List<int>();
				public List<int> itemList = new List<int>();
				public  int buyCount;
				public  bool allUnlock = false;
				
				
			public int Item
			{
				get{return item;}
				set{item = value;}
			}
				
				public  void LoadUnlockData()
				{
					if(buyCount>0)
					{
						zeroBuy=false;
			
						if(buyCount>1)
						{
							allUnlock= true;	
						}
					}
				}
				
				
	public void SetBuyCount(int itemIndex,int itemId)
	{
		//DSA unacdemy array insertion and search element
			//if it is upgradable Powerup 
			Debug.Log(" :"+powerUpList.Count );
			if(powerUpList.Count != 0)
			{
				int found = 0;
				//check duplicate element in list
				for (int i = 0; i < powerUpList.Count; i++) // Loop through List with for
				{
					if(powerUpList[i]==itemIndex)
					{
						found = 1;
						break;
					}
				}
				
				
				if(found == 1)
				{
					Debug.Log("same item :"+itemIndex);
				}else{
					powerUpList.Add(itemIndex);
					itemList.Add(itemId);
					buyCount++;
					Debug.Log("buycount: "+buyCount);
				}
				
				
			}else{
				
				powerUpList.Add(itemIndex);
				//SetFirstItem
				itemList.Add(itemId);
				buyCount++;
				Debug.Log("buycount: "+buyCount);
			}
			
			//then insert into upgradable array 
			//check buycount 
			//if it is first item then set item 

				LoadUnlockData();
	}
}
