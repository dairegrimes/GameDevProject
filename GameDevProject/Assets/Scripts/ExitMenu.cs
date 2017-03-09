using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class ExitMenu : MonoBehaviour {


	public Button startText;
	public Button exitText;

	void Start () {

		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		
	}
	
	public void StartLevel () //this function will be used on our Play button

	{
		SceneManager.LoadScene (1); //this will load our first level from our build settings. "1" is the second scene in our game
	}

	public void ExitGame () //This function will be used on our "Yes" button in our Quit menu

	{
		Application.Quit(); //this will quit our game. Note this will only work after building the game

	}
}
