using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPostionRotation : MonoBehaviour
{
   
    Transform player;
	public PlayerData playerData;

    void Start()
    {
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
      playerData.SetPlayerPosition(player.transform.position);
	  playerData.SetPlayerRotation( player.transform.rotation);
      
    }
}
