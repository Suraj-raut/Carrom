using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour    //---Four pocket at corners have this script to dected the collision of coins--//
{
    public Text PlayerScoreText;
	public static int Playerscore = 0;
	
	public Text OpponentScoreText;
	public static int Opponentscore = 0;
	
	[SerializeField]
	private GameObject GameManager;

    public AudioSource PocketTheCoin;
	
	void Update()
	{
		PlayerScoreText.GetComponent<Text>().text = Playerscore + "/160";   //---UI display for score---//
		OpponentScoreText.GetComponent<Text>().text = Opponentscore + "/160";
	}
	void OnTriggerEnter2D(Collider2D collision)                     //----If coins comes in contact with the pocket trigger--//
	{
		
		if(GameManager.GetComponent<GameManager>().counter % 2 == 0) //---If counter is even player is active so give point to                                                                              opponent
		{
			PocketTheCoin.Play();
			if(collision.gameObject.tag == "WhiteCoins")
		   {
			Playerscore += 20;                                             //--20 points for white coin--//                       
			Destroy(collision.gameObject);                                //--Destroy the coin--//   
				
		   }
		
		   if(collision.gameObject.tag == "BlackCoins")
		   {
			Playerscore += 10;                                              //--10 points for black coin--//   
			Destroy(collision.gameObject);                           //--Destroy the coin--//  
		
		   }
		
		  if(collision.gameObject.tag == "Queen")
		  {
			Playerscore += 50;                                               //--50 points for queen --//   
			Destroy(collision.gameObject);                            //--Destroy the coin--// 
			
		  }
		}
		if(GameManager.GetComponent<GameManager>().counter % 2 != 0) //---If counter is odd opponent is active so give point to                                                                              opponent
		{
	
			if(collision.gameObject.tag == "WhiteCoins")
		   {
			Opponentscore += 20;                                             //--20 points for white coin--//                       
			Destroy(collision.gameObject);                                    //--Destroy the coin--//         
		   }
		
		   if(collision.gameObject.tag == "BlackCoins")
		   {
			Opponentscore += 10;                                              //--10 points for black coin--//   
			Destroy(collision.gameObject);                           //--Destroy the coin--//         
		   }
		
		  if(collision.gameObject.tag == "Queen")
		  {
			Opponentscore += 50;                                               //--50 points for queen --//   
			Destroy(collision.gameObject);                            //--Destroy the coin--//         
		  }
		}
		
		
	}
}
