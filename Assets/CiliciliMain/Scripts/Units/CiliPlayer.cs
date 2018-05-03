
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Overture.CommentCensor
{

	public class CiliPlayer : MonoBehaviour
	{
		public string customEventName = "";
		public string storedLetters = "cilicili"; //string.Empty;
		public Text m_storedLetters;
		public Canvas m_Canvas;

		public float FireGap = 0.1f, lastFireTime = 0f;

		public GameObject ProjectilePrefab;

		public float MOVE_SPEED = 5f;
		private Transform trans;

		// Use this for initialization
		void Awake()
		{
			this.useGUILayout = false;
			this.trans = this.transform;
		}

		void Start()
		{
			m_Canvas.worldCamera = CommentSentenceManager.Instance.sceneCamera;
		}

		void OnBecameInvisible()
		{

		}

		// Update is called once per frame
		void FixedUpdate()
		{
			var moveAmountX = Input.GetAxis("Horizontal") * MOVE_SPEED * Time.fixedDeltaTime;
			var moveAmountY = Input.GetAxis("Vertical") * MOVE_SPEED * Time.fixedDeltaTime;


			var pos = this.trans.position;
			pos.x += moveAmountX;
			pos.y += moveAmountY;
			this.trans.position = pos;

			if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
			{
				if (Time.fixedTime - lastFireTime > FireGap)
				{
					FireNextLetter();
					lastFireTime = Time.fixedTime;
				}
			}
		}

		public void CollectLetter(char letter)
		{
			storedLetters = storedLetters + letter;
			m_storedLetters.text = storedLetters;
		}

		public char getnextletter()
		{
			if (storedLetters.Length <= 0)
			{
				return Char.MinValue;
			}
			else
			{
				char nextletter = storedLetters[0];
				storedLetters = storedLetters.Remove(0, 1);
				m_storedLetters.text = storedLetters;
				return nextletter;
			}
		}

		public void FireNextLetter()
		{
			char nextletter = getnextletter();
			if (nextletter == Char.MinValue) return;
			var spawnPos = this.trans.position;
			spawnPos.y += 1f;

			Transform bullet =
				Instantiate(ProjectilePrefab.transform, spawnPos, ProjectilePrefab.transform.rotation) as Transform;
			if (bullet != null)
			{
				CommentBullet bulletc = bullet.GetComponent<CommentBullet>();
				bulletc.SetText(nextletter);
				bulletc.Launch();
			}
		}
	}
}