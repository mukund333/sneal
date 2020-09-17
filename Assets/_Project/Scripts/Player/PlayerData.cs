using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Player")]
public class PlayerData : ScriptableObject
{
    public string Name;

    public int index;

    public int baseHealth;

    // public Sprite[] shootSprites;

    // public int fps;
}
