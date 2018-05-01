using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Overture.FrameGame
{
	public class GameManager : MonoBehaviour
	{
		//The week we are on
		public int Stage = 0, ProgressNum= 0;
		//The selected email
		
		
		//State of email site. Either viewing all emails or the body of an email
		public enum EmailSiteState
		{
			AllEmails,
			OneEmail
		};

		public GameObject ALL_EMAIL_SCREEN,
			ONE_EMAIL_SCREEN,
			END_GAMESCREEN;


		//Function to restart the game
		public void Restart()
		{
			SetGameStateManager(0);
			SceneManager.LoadScene("A1");
		}

		//Set the game state manager
		public void SetGameStateManager(int i)
		{
			//Set the state to the given state
			GameStateManager.SetCurrentState((GameStateManager.GameState) i);
		}

		private void Update()
		{
			//Get the game state
			GameStateManager.GameState GAME_STATE = GameStateManager.STATE;

			//Always be able to reset
			if (Input.GetKeyDown(KeyCode.R))
			{
				Restart();
			}

			//Handle each game state
			switch (GAME_STATE)
			{
				case GameStateManager.GameState.Init:
					//Increment our week number
					Stage++;
					ProgressNum++;

					GameStateManager.SetCurrentState(GameStateManager.GameState.MailReading);

					break;
				case GameStateManager.GameState.MailReading:
					break;
				case GameStateManager.GameState.Gaming:
					break;
				case GameStateManager.GameState.GameEndingScreen:
					break;
				case GameStateManager.GameState.Restarting:
					break;
				default:
					break;
			}
		}
		
		


	}
}