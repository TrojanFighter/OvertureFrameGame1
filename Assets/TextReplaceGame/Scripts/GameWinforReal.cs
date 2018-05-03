using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Overture.TextReplacement
{
	public class GameWinforReal : MonoBehaviour
	{

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		void OnTriggerEnter2D(Collider2D other)
		{
			//calls collider function
			if (other.gameObject.GetComponent<Healthandgameover>())
			{
				//ModifyScoreTSP(1, -1, 0); JEFF LOOK HERE
				//SceneManager.LoadScene ("gamewinscene"); JEFF IGNORE THIS
			}
		}

	}
}