using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerMonitor : MonoBehaviour
{
    public VideoPlayer m_videoPlayer;
    public Text m_TimeLabel;
    private int videoLength;
    string minuteCount,secondsCount;
    
    void Start()
    {
        videoLength = (int)m_videoPlayer.clip.length;
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
        string currentMinute = ((int) m_videoPlayer.time / 60).ToString();
        if (currentMinute.Length <= 1)
        {
            currentMinute = "0" + currentMinute;
        }
        string currentSecond = ((int) m_videoPlayer.time % 60).ToString();
        if (currentSecond.Length <= 1)
        {
            currentSecond = "0" + currentSecond;
        }
        m_TimeLabel.text =currentMinute+":"+currentSecond+ "/" + minuteCount+":"+secondsCount;
    }
}
