using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
	public AudioSource click;
	
    public void StartTheGame()                   //--Start Game--//
    {
	  click.Play();
	  SceneManager.LoadScene("Game"); 
    }
	
    public void QuitTheGame()                  //--Quit game--//
    {
	  click.Play();
	  Application.Quit();
    }
}
