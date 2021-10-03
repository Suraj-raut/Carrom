using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour    //---Four pocket at corners have this script to dected the collision of coins--//
{
    public Text ScoreText;
	private static int score = 0;

	
	void Update()
	{
		ScoreText.GetComponent<Text>().text = "Score : " + score;   //---UI display for score---//
	}
	void OnTriggerEnter2D(Collider2D collision)                     //----If coins comes in contact with the pocket trigger--//
	{
		if(collision.gameObject.tag == "WhiteCoins")
		{
			score += 20;                                             //--20 points for white coin--//                       
			Destroy(collision.gameObject);                           //--Destroy the coin--//         
		}
		
		if(collision.gameObject.tag == "BlackCoins")
		{
			score += 10;                                              //--10 points for black coin--//   
			Destroy(collision.gameObject);                           //--Destroy the coin--//         
		}
		
		if(collision.gameObject.tag == "Queen")
		{
			score += 50;                                               //--50 points for queen --//   
			Destroy(collision.gameObject);                            //--Destroy the coin--//         
		}
		
	}
}
