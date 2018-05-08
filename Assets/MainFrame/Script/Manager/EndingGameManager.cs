using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Overture.FrameGame
{
	
	public class EndingGameManager : MonoBehaviourEX<EndingGameManager>
	{
		public StageConfig m_config;

		public EmailConfig m_mailconfig,m_specialmailconfig;

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
			if(m_specialmailconfig==null)m_specialmailconfig= Resources.Load<EmailConfig>("Configs/SpecialEmailConfig");
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
					GameSaveManager.ClearStoredScore();
						

					GameStateManager.SetCurrentState(GameStateManager.GameState.MailReading);

					break;
				case GameStateManager.GameState.MailReading:
					if (!stateInited)
					{
						EmailProgressNum = m_ProgressConfig.m_CurrentProgress;
						ExtractStoredScore();
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
					
					SceneManager.LoadScene("MainFrame");
					GameStateManager.SetCurrentState(GameStateManager.GameState.Reset);
					break;
				case GameStateManager.GameState.Ending:
					break;
				default:
					break;
			}
		}


		void ShowCurrentMail()
		{
			if (EmailProgressNum >= m_config._LevelEmailID.Count)
			{
				EndingChecking();
			}
			
			if (m_specialmailconfig._specialEmailToLoad.Count > 0)
			{
				for (int i = 0; i < m_specialmailconfig._specialEmailToLoad.Count; i++)
				{
				
					Debug.Log(m_specialmailconfig._Titles[i]+" "+ m_specialmailconfig._SenderName[i]+""+m_specialmailconfig._EmailBody[i]);
					EmailContent emailContent=new EmailContent();
					emailContent.TITLE = m_specialmailconfig._Titles[i];
					emailContent.SENDER = m_specialmailconfig._SenderName[i];
					emailContent.BODY_TEXT = m_specialmailconfig._EmailBody[i];
							
					m_EmailManager.FillInEmail(emailContent);
				}
				
				m_specialmailconfig._specialEmailToLoad.Clear();
			}

			//Debug.Log("Showing Mail ID: "+m_config._LevelEmailID[EmailProgressNum]);
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

		void ExtractStoredScore()
		{
			if (GameSaveManager.hasExtractedScore)
			{
				return;
			}

			m_ProgressConfig.TRexScore += GameSaveManager.StoredTRexScore;
			m_ProgressConfig.StegosaursScore += GameSaveManager.StoredStegosaursScore;
			m_ProgressConfig.PterosaursScore += GameSaveManager.StoredPterosaursScore;
			m_ProgressConfig.FailureCount += GameSaveManager.StoredFailureCount;
			GameSaveManager.ClearStoredScore();
		}

		/*
		public void SubmitScore(int _TRexScore, int _StegosaursScore, int _PterosaursScore, int _FailureCount)
		{
			m_ProgressConfig.TRexScore += _TRexScore;
			m_ProgressConfig.StegosaursScore += _StegosaursScore;
			m_ProgressConfig.PterosaursScore += _PterosaursScore;
			m_ProgressConfig.FailureCount += _FailureCount;
		}*/

		public void ReturnToDesktop()
		{
			SetGameStateManager((int)GameStateManager.GameState.MailReading);
			SceneManager.LoadScene("MainFrame");
		}
		
		public void ReturnToTechnicalDifficulty()
		{
			SetGameStateManager((int)GameStateManager.GameState.MailReading);
			SceneManager.LoadScene("TechnicalDifficulty");
		}


		void EndingChecking()
		{
			if (m_ProgressConfig.m_CurrentProgress >= m_EndingConfig.LastProgressNum)
			{
				if (m_ProgressConfig.TRexScore > m_ProgressConfig.StegosaursScore && m_ProgressConfig.TRexScore > m_ProgressConfig.PterosaursScore)
				{
					SetGameStateManager((int)GameStateManager.GameState.Ending);
					SceneManager.LoadScene(m_EndingConfig.TRexEndingSceneName);
				}
				else if(m_ProgressConfig.StegosaursScore > m_ProgressConfig.TRexScore && m_ProgressConfig.StegosaursScore > m_ProgressConfig.PterosaursScore)
				{
					SetGameStateManager((int)GameStateManager.GameState.Ending);
					SceneManager.LoadScene(m_EndingConfig.StegosaursEndingSceneName);
				}
				else if(m_ProgressConfig.PterosaursScore > m_ProgressConfig.TRexScore && m_ProgressConfig.PterosaursScore > m_ProgressConfig.StegosaursScore)
				{
					SetGameStateManager((int)GameStateManager.GameState.Ending);
					SceneManager.LoadScene(m_EndingConfig.PterosaursEndingSceneName);
				}
			}
		}

		public void SpecialEmailStoredToShow(List<int> specialEmailID)
		{
			m_specialmailconfig._specialEmailToLoad = specialEmailID;
		}

	}
}