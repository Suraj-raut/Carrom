using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int counter = 0;
	public GameObject playerStriker;
	public GameObject opponentsStriker;
	
	private int WinningScore = 160;
	
	public GameObject WinningPanel;
	public Text ResultText;
	
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(counter % 2 == 0)                                           //---When the counter is even then its player turn--//
		{
			playerStriker.SetActive(true);
			opponentsStriker.SetActive(false);
		}
		else                                                          //---if the counter is odd its opponent's turn--//
		{
			playerStriker.SetActive(false);
			opponentsStriker.SetActive(true);
		}
		
		if(CoinCollector.Playerscore >= WinningScore || CoinCollector.Opponentscore >= WinningScore) //---Winning panel active if                                                                                               either scores are above 160--//
		{
			WinningPanel.SetActive(true);
			if(CoinCollector.Playerscore == WinningScore)
			{
				ResultText.GetComponent<Text>().text = "You Win..!!";
			}
			if(CoinCollector.Opponentscore == WinningScore)
			{
				ResultText.GetComponent<Text>().text = "Opponent Win..!!";
			}
		}
    }
}
