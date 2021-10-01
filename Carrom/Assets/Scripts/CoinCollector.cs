using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
 

	void OnTriggerEnter2D(Collider2D collision)    //----If coins comes in contact with the pocket trigger--//
	{
		if(collision.gameObject.tag == "Coins")
		{
			Destroy(collision.gameObject);         //--Destroy the coin--//         
		}
	}
}
