using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/EquipDatabase", fileName = "EquipData")]
public class EquipDatabase_SO : ScriptableObject
{
	[Range(0,10)]
    [SerializeField] private int weaponNumber;
    [Range(0, 10)]
    [SerializeField] private int previousWeapn;
  
  public void SetWeaponNumber(int i)
  {
        previousWeapn = weaponNumber;
	    weaponNumber = i;
  }

    public int GetPreviousWeaponNumber()
    {
        return previousWeapn;
    }
}
