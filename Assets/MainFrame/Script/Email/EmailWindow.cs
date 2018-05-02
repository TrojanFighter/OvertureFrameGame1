using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Overture.FrameGame
{
	public class EmailWindow : MonoBehaviour
	{
		public void Init(EmailManager manager)
		{
			m_emailManager = manager;
			m_emailManager.RegisterEmail(this);
		}

		public EmailManager m_emailManager;
		public Text m_Title,m_Author,m_EmailBody;
		public void OnClick_Close()
		{
			m_emailManager.UnRegisterEmail(this);
		}

		public void FillInContent(EmailContent content)
		{
			m_Title.text = content.TITLE;
			m_Author.text = content.SENDER;
			m_EmailBody.text = content.BODY_TEXT;
		}
		
		
	}
}
