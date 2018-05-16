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

		public EmailConfig m_specialmailconfig,m_endingEmailConfig;

		public ProgressConfig m_ProgressConfig;
		public EndingConfig m_EndingConfig;

		public bool stateInited=false;
		public EndingState m_EndingState= EndingState.TRex;

		public EmailManager m_EmailManager;
		
		public string firstSceneName;


		public override void Awake()
		{
			base.Awake();
			//DontDestroyOnLoad(this);
		}

		void Start()
		{
			LoadResources();
			ExtractStoredScore();
			ShowCurrentMail();
		}

		void LoadResources()
		{
			if(m_config==null)m_config = Resources.Load<StageConfig>("Configs/StageConfig");
			if(m_endingEmailConfig==null)m_endingEmailConfig= Resources.Load<EmailConfig>("Configs/EndingEmailConfig");
			if(m_ProgressConfig==null)m_ProgressConfig= Resources.Load<ProgressConfig>("Configs/ProgressConfig");
			if(m_EndingConfig==null)m_EndingConfig= Resources.Load<EndingConfig>("Configs/EndingConfig");
			if(m_endingEmailConfig==null)m_endingEmailConfig= Resources.Load<EmailConfig>("Configs/EndingEmailConfig");
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


		void ShowCurrentMail()
		{
			
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
			
			EndingChecking();

			//Debug.Log("Showing Mail ID: "+m_config._LevelEmailID[EmailProgressNum]);
			
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

			if (m_ProgressConfig.FailureCount >= m_ProgressConfig.FailureTolerance)
			{
				m_EndingState = EndingState.FAILURE;
			}
			else
			{
				
				
				if (m_ProgressConfig.TRexScore >= m_ProgressConfig.StegosaursScore && m_ProgressConfig.TRexScore >= m_ProgressConfig.PterosaursScore)
				{
					m_EndingState = EndingState.TRex;
					//SetGameStateManager((int)GameStateManager.GameState.Ending);
					//SceneManager.LoadScene(m_EndingConfig.TRexEndingSceneName);
				}
				else if(m_ProgressConfig.StegosaursScore >= m_ProgressConfig.TRexScore && m_ProgressConfig.StegosaursScore >= m_ProgressConfig.PterosaursScore)
				{
					m_EndingState = EndingState.STEGOSARUS;
					//SetGameStateManager((int)GameStateManager.GameState.Ending);
					//SceneManager.LoadScene(m_EndingConfig.StegosaursEndingSceneName);
				}
				else if(m_ProgressConfig.PterosaursScore >= m_ProgressConfig.TRexScore && m_ProgressConfig.PterosaursScore >= m_ProgressConfig.StegosaursScore)
				{
					m_EndingState = EndingState.PTEROSAUR;
					//SetGameStateManager((int)GameStateManager.GameState.Ending);
					//SceneManager.LoadScene(m_EndingConfig.PterosaursEndingSceneName);
				}
			}
			/*
			string emailIDstring = m_endingEmailConfig._EmailBody  [(int)m_EndingState];
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
			}*/
			EmailContent emailContent=new EmailContent();
			emailContent.TITLE = m_endingEmailConfig._Titles[(int)m_EndingState];
			emailContent.SENDER = m_endingEmailConfig._SenderName[(int)m_EndingState];
			emailContent.BODY_TEXT = m_endingEmailConfig._EmailBody[(int)m_EndingState];
							
			m_EmailManager.FillInEmail(emailContent);

		}

		void Update()
		{
			GameStateManager.GameState GAME_STATE = GameStateManager.STATE;

			//Always be able to reset
			if (Input.GetKey(KeyCode.Alpha1)&&Input.GetKey(KeyCode.Alpha9))
			{
				GAME_STATE = GameStateManager.GameState.Reset;
				m_ProgressConfig.m_CurrentProgress = 0;
				m_ProgressConfig.FailureCount = 0;
				m_ProgressConfig.TRexScore = 0;
				m_ProgressConfig.StegosaursScore = 0;
				m_ProgressConfig.PterosaursScore = 0;
				GameSaveManager.ClearStoredScore();
				GameStateManager.SetCurrentState(GameStateManager.GameState.MailReading);
				
				SceneManager.LoadScene(firstSceneName);
			}

			
		}
	}
}