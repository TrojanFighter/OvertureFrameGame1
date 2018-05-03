using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Overture.CommentCensor
{

	public class CommentSentenceCollider : MonoBehaviour
	{
		public Vector3 colliderSize;
		public CommentSentence m_sentence;

		public void SetLength(int length)
		{
			transform.localScale = new Vector3(colliderSize.x * length, colliderSize.y, colliderSize.z);
		}

	}
}
