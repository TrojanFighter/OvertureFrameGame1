using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Overture.CommentCensor
{

    public class CommentUIPrefab : MonoBehaviour
    {

        public Comment m_Comment;
        public Text m_Text, m_Time, m_Date;
        public GameObject m_Block;

        public void SetUIComment(string text, float time, DateTime datetime)
        {
            m_Text.text = text;
            string minuteString = (((int) time) / 60).ToString();
            if (minuteString.Length <= 1)
            {
                minuteString = "0" + minuteString;
            }

            string secondString = (((int) time) % 60).ToString();
            if (secondString.Length <= 1)
            {
                secondString = "0" + secondString;
            }

            m_Time.text = minuteString + ":" + secondString;
            string dateString = datetime.ToShortDateString(); //+" "+datetime.ToShortTimeString();
            m_Date.text = dateString.TrimEnd(new char[] {'M', 'P', 'A'});
        }

        public void BlockComment(bool block)
        {
            m_Block.SetActive(block);
        }

        public void SelfDestory()
        {
            Destroy(gameObject);
        }
    }
}
