using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCollider : MonoBehaviour             //----Start collider attached to striker to check overlapping--//
{
	
	public GameObject Striker;
	private bool isSet;

	
	void Update()
	{
		isSet = Striker.GetComponent<StrikerController>().ISStrikerSet;  //---check if the striker is set or not form Strike script
	}
	
   
	void OnTriggerEnter2D(Collider2D collision)
	{
		if(!isSet)                                                                    //--If striker is not set--//
		{
			
		   if(collision.gameObject.tag == "Coins")                                    //--coins enter the collider--//         
		  {
			Striker.GetComponent<CircleCollider2D>().isTrigger = true;     //--Striker's trigger = true to not collide with token 
			Debug.Log("Striker overlaps token");
			Striker.GetComponent<StrikerController>().isOverlap = true;    //--Send is overlap to Striker script--//
	        Striker.GetComponent<StrikerController>().ISStrikerSet = false;//--if overlap we cannot hit the striker -                                                                                        isStrikerSet =  false//
		  }
			
		}
		else
		{
			Striker.GetComponent<CircleCollider2D>().isTrigger = false; //---Set the trigger back to false if we move away from coin
			Striker.GetComponent<StrikerController>().isOverlap = false;//--Overlap = false--//
			
		}
		
	}
	
	void OnTriggerExit2D(Collider2D collision)
	{
			Striker.GetComponent<CircleCollider2D>().isTrigger = false;  //---Unless it didn't detect the collider then also set                                                                        trigger to false //
		    Striker.GetComponent<StrikerController>().isOverlap = false;
			
	}
}
