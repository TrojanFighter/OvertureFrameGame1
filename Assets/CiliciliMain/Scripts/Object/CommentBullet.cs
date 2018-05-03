using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Overture.CommentCensor
{

	public class CommentBullet : MonoBehaviour
	{
		public char m_letter;
		public Text m_Text;
		public float speed;
		public bool isMoving = false;
		public Canvas m_Canvas;

		public void SetText(char text)
		{
			m_letter = text;
			m_Text.text = text.ToString();
		}

		public bool Launch()
		{
			m_Canvas.worldCamera = CommentSentenceManager.Instance.sceneCamera;
			isMoving = true;
			return isMoving;
		}

		private void FixedUpdate()
		{
			if (isMoving)
			{
				transform.localPosition += new Vector3(0, speed * Time.deltaTime, 0);
			}

			//var screenPos = Camera.main .WorldToScreenPoint(transform.position);
			//m_Text.rectTransform.position = screenPos;
			/*var localPos = Vector2.zero;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(m_Text.rectTransform, screenPos,CommentSentenceManager.Instance.sceneCamera, out localPos);
	
			m_Text.transform.localPosition = localPos;*/
			//m_Text.transform.position = CommentSentenceManager.Instance.sceneCamera.WorldToScreenPoint(transform.position);

			//m_Canvas.scaleFactor
			//Screen.currentResolution
			//Vector2 player2DPosition = CommentSentenceManager.Instance.sceneCamera.WorldToScreenPoint(transform.position);
			//m_Text.rectTransform.localPosition = GlobalMethod.WorldToScreenPoint(transform.position,m_Canvas.GetComponent<RectTransform>(), CommentSentenceManager.Instance.sceneCamera);

			//m_Text.rectTransform.localPosition = GlobalMethod.WorldToScreenPoint(transform.position,m_Canvas.GetComponent<RectTransform>(), CommentSentenceManager.Instance.sceneCamera);
			//m_Text.transform.localScale=Vector3.one;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.gameObject.layer == LayerMask.NameToLayer("EnemyCollider2D"))
			{
				other.gameObject.GetComponent<EnemyGrunt>().InputLetter(m_letter);
				Destroy(gameObject);
			}
		}
	}
}