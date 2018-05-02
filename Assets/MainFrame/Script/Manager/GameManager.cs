using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Overture.FrameGame
{
	
	public class GameManager : MonoBehaviour
	{
		public StageConfig m_config;

		public EmailConfig m_mailconfig;

		public bool stateInited=false;
		public int EmailProgressNum= 0;

		public EmailManager MEmailManager;

		public bool canProceedToWork = false;


		public GameObject m_ProceedToWorkButton, m_OnAirAlert;

		void Awake()
		{
			DontDestroyOnLoad(this);
		}

		void Start()
		{
			LoadResources();
		}

		void LoadResources()
		{
			if(m_config==null)m_config = Resources.Load<StageConfig>("Configs/StageConfig");
			if(m_mailconfig==null)m_mailconfig= Resources.Load<EmailConfig>("Configs/EmailConfig");
		}


		//Function to restart the game
		public void Restart()
		{
			SetGameStateManager(0);
			SceneManager.LoadScene("MainFrame");
		}

		//Set the game state manager
		public void SetGameStateManager(int i)
		{
			//Set the state to the given state
			GameStateManager.SetCurrentState((GameStateManager.GameState) i);
			stateInited = false;
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
					EmailProgressNum = 1;

					GameStateManager.SetCurrentState(GameStateManager.GameState.MailReading);

					break;
				case GameStateManager.GameState.MailReading:
					if (!stateInited)
					{
						EnableProceedToWork(false);
						ShowCurrentMail();
						stateInited = true;
					}
					break;
				case GameStateManager.GameState.Gaming:
					break;
				case GameStateManager.GameState.GameEndingScreen:
					if (!stateInited)
					{
						EmailProgressNum++;
					}
					break;
				case GameStateManager.GameState.Restarting:
					break;
				default:
					break;
			}
		}

		void CheckEnding()
		{
			Debug.LogError("Email ID Out of Range!");
		}

		void ShowCurrentMail()
		{
			if (EmailProgressNum > m_config._LevelEmailID.Count)
			{
				CheckEnding();
			}

			Debug.Log("Showing Mail ID: "+m_config._LevelEmailID[EmailProgressNum]);
			string emailIDstring = m_config._LevelEmailID[EmailProgressNum];
			string[] emailID = emailIDstring.Split(',');

			if (emailID.Length <= 0)
			{
				Debug.LogError("Email ID Parse Error!");
			}

			for (int i = 0; i < emailID.Length; i++)
			{
				
				Debug.Log(m_mailconfig._Titles[int.Parse(emailID[i])]+" "+ m_mailconfig._SenderName[int.Parse(emailID[i])]+""+m_mailconfig._EmailBody[int.Parse(emailID[i])]);
				EmailContent emailContent=new EmailContent();
				emailContent.TITLE = m_mailconfig._Titles[int.Parse(emailID[i])];
				emailContent.SENDER = m_mailconfig._SenderName[int.Parse(emailID[i])];
				emailContent.BODY_TEXT = m_mailconfig._EmailBody[int.Parse(emailID[i])];
							
				MEmailManager.FillInEmail(emailContent);
			}

		}

		public void EnableProceedToWork(bool enable)
		{
			if (enable)
			{
				m_ProceedToWorkButton.SetActive(enable);
			}
		}

		public void On_ClickGoToWork()
		{
			SetGameStateManager((int)GameStateManager.GameState.Gaming);
			SceneManager.LoadScene(m_config._LevelScene[EmailProgressNum]);
		}

		public void ShowOnAirAlert(bool show)
		{
			m_OnAirAlert.SetActive(show);
		}


	}
}