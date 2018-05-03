using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Overture.CommentCensor
{

	public class RecycleTrigger : MonoBehaviour
	{

		private void OnTriggerEnter(Collider other)
		{
			if (other.GetComponent<CommentSentence>())
			{
				other.GetComponent<CommentSentence>().Recycle();
			}
		}
	}
}