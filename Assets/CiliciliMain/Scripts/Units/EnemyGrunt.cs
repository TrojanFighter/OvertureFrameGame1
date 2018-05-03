using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyGrunt : MonoBehaviour {
	public float speedMultiplier = 1f;
	public bool randomHoriz = false;
	public string keyword;

	public float selfdestroytime = 16f;

	public TextMesh m_keywordText;
	//public Text m_keywordText;
	
	private Transform trans;
	public float speed;
	public float horizSpeed;
	
	void Awake() {
		this.useGUILayout = false;
		this.trans = this.transform;
		AwakeOrSpawned();
	}
	
	void OnSpawned() {
		AwakeOrSpawned();
	}
	
	private void AwakeOrSpawned() {
		this.speed = Random.Range(-2f, -3f) * Time.deltaTime * this.speedMultiplier;
		if (this.randomHoriz) {
			this.horizSpeed = Random.Range(-1f, 1f) * Time.deltaTime * this.speedMultiplier;
		}

		m_keywordText.text = keyword;

		StartCoroutine(DestoryInTime());
	}

	IEnumerator DestoryInTime()
	{
		yield return new WaitForSeconds(selfdestroytime);
		Destroy(gameObject);
	}

	// Update is called once per frame
	void Update () {
		var pos = this.trans.position;
		pos.x += this.horizSpeed;
		pos.y += speed;
		this.trans.position = pos; 
		
		//this.trans.Rotate(Vector3.down * 300 * Time.deltaTime);
	}
/*
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("BulletCollider2D"))
		{
			char letter= other.gameObject.GetComponent<CommentBullet>().m_letter;
			if (keyword.Contains(letter.ToString()))
			{
				keyword=keyword.Replace(letter.ToString(), "");
				m_keywordText.commentText = keyword;
				if (keyword.Length == 0)
				{
					Destroy(gameObject);
				}
			}
		}
		
	}*/

	public void InputLetter(char letter)
	{
		if (keyword.Contains(letter.ToString()))
		{
			keyword=keyword.Replace(letter.ToString(), "");
			m_keywordText.text = keyword;
			if (keyword.Length == 0)
			{
				Destroy(gameObject);
			}
		}
	}
}
