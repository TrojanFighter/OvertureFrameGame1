using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Overture.TextReplacement
{
	public class textmove : MonoBehaviour
	{

		private float moveSpeed = 0f; //sets a var for move speed
		private float gametimer = 1;

		// Use this for initialization

		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
			gametimer += 1;

			if (gametimer >= 60 * 13)
			{
				moveSpeed = 0.07f;
			}

			if (gametimer >= 60 * 30)
			{
				moveSpeed = 0.1f;
			}

			if (gametimer >= 60 * 75)
			{
				moveSpeed = 0.12f;
			}

			transform.Translate(-moveSpeed * Time.deltaTime * 60, 0, 0); //sets text to move

		}
	}
}