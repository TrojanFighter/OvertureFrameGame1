using System.Collections;
using System.Collections.Generic;
using Overture.FrameGame;
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
				//FrameGameManager.Instance.SubmitScore(1,-1,0,0);
				//FrameGameManager.Instance.ReturnToDesktop();
				GameSaveManager.StoreScore(1,-1,0,0);
				SceneManager.LoadScene ("MainFrame");
				//ModifyScoreTSP(1, -1, 0); JEFF LOOK HERE
				//SceneManager.LoadScene ("gamewinscene"); JEFF IGNORE THIS
			}
		}

	}
}