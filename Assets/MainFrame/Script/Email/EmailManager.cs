using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Overture.FrameGame
{
	public class EmailManager : MonoBehaviour
	{

		public EmailWindow emailPrefab;

		public Transform[] emailSlots;

		public List<EmailWindow> m_currentEmailWindow;

		private bool inited = false;

		public bool isEmailClosed {
			get { return m_currentEmailWindow.Count <= 0; }
		}

		public void Init()
		{
			if (inited)
			{
				return;
			}
			m_currentEmailWindow=new List<EmailWindow>();
		}

		public void UnInit()
		{
			foreach (EmailWindow email in m_currentEmailWindow)
			{
				email.OnClick_Close();
			}
		}

		public void FillInEmail(EmailContent emailContent)
		{
			EmailWindow emailWindow = Instantiate(emailPrefab, emailSlots[m_currentEmailWindow.Count]);
			emailWindow.transform.localPosition=Vector3.zero;
			emailWindow.FillInContent(emailContent);
			m_currentEmailWindow.Add(emailWindow);
		}
	}
}