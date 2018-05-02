using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Overture.FrameGame
{
	public class EmailWindow : MonoBehaviour
	{

		public Text m_Title,m_Author,m_EmailBody;
		public void OnClick_Close()
		{
			Destroy(gameObject);
		}

		public void FillInContent(EmailContent content)
		{
			m_Title.text = content.TITLE;
			m_Author.text = content.SENDER;
			m_EmailBody.text = content.BODY_TEXT;
		}
	}
}
