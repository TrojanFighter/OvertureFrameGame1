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

		public EmailCluster m_EmailCluster;

		public bool canProceedToWork = false;


		public GameObject m_ProceedToWorkButton;

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

		void ShowCurrentMail()
		{
			//GameObject mailCluster= Resources.Load<GameObject>()
			Debug.Log(m_mailconfig._Titles[EmailProgressNum]+" "+ m_mailconfig._SenderName+""+m_mailconfig._EmailBody[EmailProgressNum]);
			
			EmailContent emailContent=new EmailContent();
			emailContent.TITLE = m_mailconfig._Titles[EmailProgressNum];
			emailContent.SENDER = m_mailconfig._SenderName[EmailProgressNum];
			emailContent.BODY_TEXT = m_mailconfig._EmailBody[EmailProgressNum];
			
			m_EmailCluster.FillInEmail(emailContent);
		}

		public void EnableProceedToWork(bool enable)
		{
			if (enable)
			{
				m_ProceedToWorkButton.SetActive(enable);
			}
		}


	}
}