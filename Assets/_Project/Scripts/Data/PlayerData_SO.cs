using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Player")]
public class PlayerData_SO : ScriptableObject
{
   

    // public Sprite[] shootSprites;

    // public int fps;

    public class CharLevelUps
    {
        public int maxHealth;
    }

    #region Fields
    public bool setManually = false;
    public bool saveDataOnClose = false;


    public string Name;

    public int index;

    public int currentHealth = 0;
    public int maxHealth = 0;

    public CharLevelUps[] charLevelUps;
    #endregion

   
}
