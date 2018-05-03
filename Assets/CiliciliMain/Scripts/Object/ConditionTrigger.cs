using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Overture.CommentCensor
{

	public class ConditionTrigger : MonoBehaviour
	{

		public GlobalDefine.CensorAreaTypes m_areaType;

		private void OnTriggerEnter(Collider other)
		{
			if (other.GetComponent<CommentSentenceCollider>())
			{
				Debug.Log("CommentSentenceCollider: " + other);
				CommentSentence sentence = other.GetComponent<CommentSentenceCollider>().m_sentence;
				sentence.SetFeedbackState(m_areaType);
				//if(sentence)
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.GetComponent<CommentSentenceCollider>())
			{
				CommentSentence sentence = other.GetComponent<CommentSentenceCollider>().m_sentence;
				sentence.SetFeedbackState(GlobalDefine.CensorAreaTypes.None);
			}
		}
	}
}