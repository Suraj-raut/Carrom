using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCollider : MonoBehaviour
{
	
	public GameObject Striker;
	private bool isSet;
	//public bool overlap;
	
	
	void Update()
	{
		isSet = Striker.GetComponent<StrikerController>().ISStrikerSet;
	}
	
   
	void OnTriggerEnter2D(Collider2D collision)
	{
		if(!isSet)
		{
			
		   if(collision.gameObject.tag == "Coins")
		  {
			Striker.GetComponent<CircleCollider2D>().isTrigger = true;
			Debug.Log("Striker overlaps token");
			Striker.GetComponent<StrikerController>().isOverlap = true; 
	        Striker.GetComponent<StrikerController>().ISStrikerSet = false;
		  }
			
		}
		else
		{
			Striker.GetComponent<CircleCollider2D>().isTrigger = false;
			Striker.GetComponent<StrikerController>().isOverlap = false;
			
		}
		
	}
	
	void OnTriggerExit2D(Collider2D collision)
	{
			Striker.GetComponent<CircleCollider2D>().isTrigger = false;
		    Striker.GetComponent<StrikerController>().isOverlap = false;
			
	}
}
