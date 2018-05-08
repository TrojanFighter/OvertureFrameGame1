using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Overture.FrameGame
{
	
	public class FrameGameManager : MonoBehaviourEX<FrameGameManager>
	{
		public StageConfig m_config;

		public EmailConfig m_mailconfig;

		public ProgressConfig m_ProgressConfig;
		public EndingConfig m_EndingConfig;

		public bool stateInited=false;
		public int EmailProgressNum= 0;

		public EmailManager m_EmailManager;

		public GameObject m_ProceedToWorkButton, m_OnAirAlert;

		public override void Awake()
		{
			base.Awake();
			//DontDestroyOnLoad(this);
		}

		void Start()
		{
			LoadResources();
		}

		void LoadResources()
		{
			if(m_config==null)m_config = Resources.Load<StageConfig>("Configs/StageConfig");
			if(m_mailconfig==null)m_mailconfig= Resources.Load<EmailConfig>("Configs/EmailConfig");
			if(m_ProgressConfig==null)m_ProgressConfig= Resources.Load<ProgressConfig>("Configs/ProgressConfig");
			if(m_EndingConfig==null)m_EndingConfig= Resources.Load<EndingConfig>("Configs/EndingConfig");
		}


		//Function to restart the game
		/*public void Restart()
		{
			SetGameStateManager(0);
			SceneManager.LoadScene("MainFrame");
		}*/

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
			//if (Input.GetKeyDown(KeyCode.R))
			{
				//Restart();
			}

			//Handle each game state
			switch (GAME_STATE)
			{
				case GameStateManager.GameState.Reset:
					//Increment our week number
					EmailProgressNum = 0;
					m_ProgressConfig.m_CurrentProgress = EmailProgressNum;
					m_ProgressConfig.FailureCount = 0;
					m_ProgressConfig.TRexScore = 0;
					m_ProgressConfig.StegosaursScore = 0;
					m_ProgressConfig.PterosaursScore = 0;
						

					GameStateManager.SetCurrentState(GameStateManager.GameState.MailReading);

					break;
				case GameStateManager.GameState.MailReading:
					if (!stateInited)
					{
						EmailProgressNum = m_ProgressConfig.m_CurrentProgress;
						EnableProceedToWork(false);
						ShowCurrentMail();
						stateInited = true;
					}

					if (m_EmailManager.isEmailClosed)
					{
						EnableProceedToWork(true);
					}

					break;
				case GameStateManager.GameState.SavingProgress:
					if (!stateInited)
					{
						EmailProgressNum++;
						m_ProgressConfig.m_CurrentProgress = EmailProgressNum;
						m_ProgressConfig.SetDirty();
						stateInited = true;
					}
					break;
				case GameStateManager.GameState.Gaming:
					if (!stateInited)
					{
						//EmailProgressNum++;
						stateInited = true;
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
							
				m_EmailManager.FillInEmail(emailContent);
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
			ShowOnAirAlert(true);
			StartCoroutine(GoToWork());
		}

		IEnumerator GoToWork()
		{
			int lastEmailProgress = EmailProgressNum;
			SetGameStateManager((int)GameStateManager.GameState.SavingProgress);
			yield return new WaitForSeconds(3f);
			SetGameStateManager((int)GameStateManager.GameState.Gaming);
			SceneManager.LoadScene(m_config._LevelScene[lastEmailProgress]);
		}

		void ShowOnAirAlert(bool show)
		{
			m_OnAirAlert.SetActive(show);
			m_OnAirAlert.GetComponent<Animator>().Play(0);
		}

		public void SubmitScore(int _TRexScore, int _StegosaursScore, int _PterosaursScore, int _FailureCount)
		{
			m_ProgressConfig.TRexScore += _TRexScore;
			m_ProgressConfig.StegosaursScore += _StegosaursScore;
			m_ProgressConfig.PterosaursScore += _PterosaursScore;
			m_ProgressConfig.FailureCount += _FailureCount;
		}

		public void ReturnToDesktop()
		{
			SetGameStateManager((int)GameStateManager.GameState.MailReading);
			SceneManager.LoadScene("MainFrame");
		}

		public void AbortToDeskTop()
		{
			SetGameStateManager((int)GameStateManager.GameState.MailReading);
			SceneManager.LoadScene("MainFrame");
		}

	}
}