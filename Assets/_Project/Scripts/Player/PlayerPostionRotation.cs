using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPostionRotation : MonoBehaviour
{
   
   [SerializeField] Transform player;
    [SerializeField] Transform playerShootPoint;
	public CurrentPlayerComponentData playerData;

    void Start()
    {
        player = GetComponent<Transform>();
        playerShootPoint = this.gameObject.transform.GetChild(0);

    }

    // Update is called once per frame
    void Update()
    {
        
      playerData.SetPlayerPosition(player.transform.position,playerShootPoint.position);
	  playerData.SetPlayerRotation( player.transform.rotation);

      
    }
}
