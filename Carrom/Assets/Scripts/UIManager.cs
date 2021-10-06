using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject WinningPanel;
	
	public void PlayAgain()
	{
		WinningPanel.SetActive(false);
		CoinCollector.Playerscore = 0;
		CoinCollector.Opponentscore = 0;
	}
	
	public void BackToMenu()
	{
		SceneManager.LoadScene("Menu");
	}
	
	
}
