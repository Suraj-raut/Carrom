using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLine : MonoBehaviour
{
	private GameObject coins;
	
   void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Coins")
		{
			coins = collision.gameObject;
			GetObject();
		}
	}
	  void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Coins")
		{
			coins = collision.gameObject;
			GetObject();
		}
	}
	
	void GetObject()
	{
		coins.GetComponent<Collider2D>().isTrigger = true;
		coins.GetComponent<Collider2D>().isTrigger = false;
	   
	}
	
}
