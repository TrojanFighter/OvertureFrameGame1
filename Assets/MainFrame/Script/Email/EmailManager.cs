using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Overture.FrameGame
{
	public class EmailManager : MonoBehaviour
	{

		public EmailWindow emailPrefab;

		public Transform[] emailSlots;

		public List<EmailWindow> m_currentEmailWindows;

		private bool inited = false;

		public bool isEmailClosed {
			get { return m_currentEmailWindows.Count <= 0; }
		}

		public void Init()
		{
			if (inited)
			{
				return;
			}
			m_currentEmailWindows=new List<EmailWindow>();
		}

		public void UnInit()
		{
			foreach (EmailWindow email in m_currentEmailWindows)
			{
				UnRegisterEmail(email);
			}
		}

		public void FillInEmail(EmailContent emailContent)
		{
			EmailWindow emailWindow = Instantiate(emailPrefab, emailSlots[m_currentEmailWindows.Count]);
			emailWindow.transform.localPosition=Vector3.zero;
			emailWindow.FillInContent(emailContent);
			RegisterEmail(emailWindow);
		}

		public bool RegisterEmail(EmailWindow email)
		{
			if (!m_currentEmailWindows.Contains(email))
			{
				m_currentEmailWindows.Add(email);
				return true;
			}

			return false;
		}
		
		public bool UnRegisterEmail(EmailWindow email)
		{
			if (m_currentEmailWindows.Contains(email))
			{
				m_currentEmailWindows.Remove(email);
				Destroy(email.gameObject);
				return true;
			}

			return false;
		}
	}
}