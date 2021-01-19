using UnityEngine;
using System.Collections;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "Item/Currency", fileName = "Generic Currency Name")]
public class Currency : ScriptableObject
{
    public string Name;
    public Sprite Image;

}
