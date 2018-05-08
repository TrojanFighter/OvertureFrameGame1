using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Overture.CensorBar
{

    public class VideoDisplay: MonoBehaviour
    {
        public VideoPlayer m_videoPlayer;
        public Text m_TimeLabel;
        private int videoLength;
        string minuteCount, secondsCount;
        float frames;
        private int failSeconds;
        private string scene;
        private Lvl1Scoring lvl1ScoringScript;
        private Lvl2Scoring lvl2ScoringScript;

        void Start()
        {
            scene = SceneManager.GetActiveScene().name;
            if (scene == "Censor Level 1") lvl1ScoringScript = GameObject.Find("CensorBar").GetComponent<Lvl1Scoring>();
            if (scene == "Censor Level 2") lvl2ScoringScript = GameObject.Find("CensorBar").GetComponent<Lvl2Scoring>();
            videoLength = (int) m_videoPlayer.clip.length;
            minuteCount = (videoLength / 60).ToString();
            if (minuteCount.Length <= 1)
            {
                minuteCount = "0" + minuteCount;
            }

            secondsCount = (videoLength % 60).ToString();
            if (secondsCount.Length <= 1)
            {
                secondsCount = "0" + secondsCount;
            }
        }

        void Update()
        {
//		frames++;
//        string currentMinute = ((int) m_videoPlayer.time / 60).ToString();
//        if (currentMinute.Length <= 1)
//        {
//            currentMinute = "0" + currentMinute;
//        }
//		string currentSecond = ((int) m_videoPlayer.time % 60).ToString();
//        if (currentSecond.Length <= 1)
//        {
//            currentSecond = "0" + currentSecond;
//        }
//            m_TimeLabel.text =
//                m_videoPlayer.time
//                    .ToString(); //currentMinute+":"+currentSecond+ "/" + minuteCount+":"+secondsCount;/*secondsCount*/
            //m_TimeLabel.text = "Video: " + m_videoPlayer.frame.ToString();

//     DISPLAY FAIL SECONDS

            if (scene == "Censor Level 1")
            {
                failSeconds = lvl1ScoringScript.FailFrames / 60;
            } else if (scene == "Censor Level 2")
            {
                failSeconds = lvl2ScoringScript.FailFrames / 60;
            }
            
        //Debug.Log(failSeconds);
       
        m_TimeLabel.text = failSeconds.ToString(); 
        }
    }
}