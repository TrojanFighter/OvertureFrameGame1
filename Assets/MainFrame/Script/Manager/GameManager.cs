using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Overture.FrameGame
{
	public class GameManager : MonoBehaviour
	{
		//The week we are on
		public int WEEK = 0, ProgressCounter = 0;
		//The selected email
		EmailController SELECTED_EMAIL;
		
		
		//State of email site. Either viewing all emails or the body of an email
		public enum EmailSiteState
		{
			AllEmails,
			OneEmail
		};

		public GameObject ALL_EMAIL_SCREEN,
			ONE_EMAIL_SCREEN,
			END_GAMESCREEN;

		public EmailSiteState EmailReadingState = EmailSiteState.AllEmails;

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
					WEEK++;
					ProgressCounter++;

					GameStateManager.SetCurrentState(GameStateManager.GameState.MailReading);

					break;
				case GameStateManager.GameState.MailReading:
					
					//Handle the state of player input
					switch (EmailReadingState)
					{
						case EmailSiteState.AllEmails:
							//If this isn't on, turn it on.
							if (!ALL_EMAIL_SCREEN.activeSelf)
							{
								//DAY_BEGIN_SCREEN.SetActive(false);
								//PROCESS_SCREEN.SetActive(false);
								ONE_EMAIL_SCREEN.SetActive(false);
								//BM.ApplyColors(BackgroundManager.BackgroundStates.Inbox);
								ALL_EMAIL_SCREEN.SetActive(true);
							}

							//Update the list, refresh more mails
							ALL_EMAIL_SCREEN.GetComponent<AllEmailScreenManager>().UpdateList();
							break;
						case EmailSiteState.OneEmail:
							ONE_EMAIL_SCREEN.GetComponent<OneEmailScreenManager>().SetEmail(SELECTED_EMAIL);
							//If this isn't on, turn it on, and turn the other one off.
							if (!ONE_EMAIL_SCREEN.activeSelf)
							{
								//DAY_BEGIN_SCREEN.SetActive(false);
								//PROCESS_SCREEN.SetActive(false);
								ALL_EMAIL_SCREEN.SetActive(false);
								//BM.ApplyColors(BackgroundManager.BackgroundStates.Email);
								ONE_EMAIL_SCREEN.SetActive(true);
							}

							break;
						default:
							Debug.Log("Error, shouldn't happen. Email site state is invalid.");
							break;
					}
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
		
		//Function that displays the given email
		public void DisplayEmail(EmailController EMAIL)
		{
			//Keep track of which email we want to show
			SELECTED_EMAIL = EMAIL;

			//Set the state to just one email
			SetCurrentState(EmailSiteState.OneEmail);
		}
		
		//Function that sets the state of the email
		public void SetCurrentState(EmailSiteState TEMP)
		{
			EmailReadingState = TEMP;
		}

	}
}