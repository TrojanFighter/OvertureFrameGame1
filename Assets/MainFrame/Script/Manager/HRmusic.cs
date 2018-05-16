using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class HRmusic : MonoBehaviour {
	
	
	private AudioSource _audioSource;
	public VideoPlayer HRVideo;
	private bool _musicPlaying;
	
	
	// Use this for initialization
	void Start ()
	{
		_audioSource = gameObject.GetComponent<AudioSource>();
		_musicPlaying = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (HRVideo.isPlaying && !_musicPlaying)
		{
			_audioSource.PlayDelayed(10.0f);
			_musicPlaying = true;
		}
		
	}
}
