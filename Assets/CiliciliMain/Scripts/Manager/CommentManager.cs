using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace Overture.CommentCensor
{


    public class CommentManager : MonoBehaviourEX<CommentManager>
    {
        public VideoPlayer m_videoPlayer;
        private Dictionary<int, Comment> m_CommentDictionary;
        private Dictionary<int, CommentUIPrefab> m_CommentUIDictionary;
        private int nextcommentID = 0;
        private Dictionary<float, int> m_CommentReferenceDictionary;
        public Transform CommentRoot;
        public CommentUIPrefab m_CommentUIPrefab;
        public Level m_CurrentLevel;

        public override void Awake()
        {
            base.Awake();
            Init();
        }

        void Init()
        {
            m_CommentDictionary = new Dictionary<int, Comment>();
            m_CommentReferenceDictionary = new Dictionary<float, int>();
            m_CommentUIDictionary = new Dictionary<int, CommentUIPrefab>();
            m_CommentDictionary = XMLReader.ReadCommentsFile(GlobalDefine.PathDefines.XML_Path +GlobalDefine.FileName.Comments[(int)m_CurrentLevel]);

            foreach (KeyValuePair<int, Comment> comment in m_CommentDictionary)
            {
                m_CommentReferenceDictionary.Add(comment.Value.InVideoTime, comment.Key);
            }

            /*AddComment("hello", 1f, DateTime.Now,2);
            AddComment("anyone here?", 2.5f, DateTime.Now,1);
            AddComment("bad example you made!", 3.5f, DateTime.Now,2);
            AddComment("stupid", 4.5f, DateTime.Now,3);
            AddComment("pet a cat", 5.5f, DateTime.Now,4);
            AddComment("good job", 6.8f, DateTime.Now,2);
            AddComment("bad game!", 8.5f, DateTime.Now,1);
            AddComment("this video sucks", 9.5f, DateTime.Now,3);
            AddComment("pet a cat", 10.5f, DateTime.Now,4);
            AddComment("good job", 11.8f, DateTime.Now,2);
            AddComment("dont do it wrong", 15.5f, DateTime.Now,4);
            AddComment("hey", 15.8f, DateTime.Now,2);
            AddComment("nonsense", 16.8f, DateTime.Now,2);
            AddComment("written in c#", 18.5f, DateTime.Now,1);
            AddComment("there are zombies around", 19.5f, DateTime.Now,3);
            AddComment("come from bilibili", 20.5f, DateTime.Now,4);
            AddComment("control", 21.8f, DateTime.Now,2);
            AddComment("+c+v", 22.8f, DateTime.Now,0);
            AddComment("to make this happen", 23.5f, DateTime.Now,2);
            AddComment("basically not finnished", 25.5f, DateTime.Now,3);
            AddComment("come from bilibili", 26.5f, DateTime.Now,4);*/
            RefreshUI();
        }

        public void AddComment(string commenttext, float commentvideoTime, DateTime commentdate, int linePosition = 0)
        {
            nextcommentID++;
            m_CommentDictionary.Add(nextcommentID,new Comment(){commentText = commenttext,InVideoTime = commentvideoTime,date = commentdate,offset = linePosition});
            m_CommentReferenceDictionary.Add(commentvideoTime, nextcommentID);
        }

        public void RefreshUI()
        {
            if (CommentRoot.childCount > 0)
            {
                m_CommentUIDictionary.Clear();
                for (int i = 0; i < CommentRoot.childCount; i++)
                {
                    Destroy(CommentRoot.GetChild(i).gameObject);
                }
            }

            if (m_CommentDictionary.Count > 0)
            {
                foreach (KeyValuePair<int, Comment> pair in m_CommentDictionary)
                {
                    CommentUIPrefab GO = Instantiate(m_CommentUIPrefab) as CommentUIPrefab;
                    GO.SetUIComment(pair.Value.commentText, pair.Value.InVideoTime, pair.Value.date);
                    GO.transform.SetParent(CommentRoot);
                    GO.transform.localScale = Vector3.one;
                    m_CommentUIDictionary.Add(pair.Key, GO);
                }
            }
        }

        void FixedUpdate()
        {
            foreach (float commentTime in m_CommentReferenceDictionary.Keys)
            {
                //if (Mathf.Abs(commentTime - Time.fixedTime) < Time.fixedDeltaTime / 2)
                if (Mathf.Abs(commentTime - (float)m_videoPlayer.time) < Time.fixedDeltaTime / 2)    
                {
                    LaunchComment(m_CommentReferenceDictionary[commentTime]);
                }
            }
        }

        public void LaunchComment(int commentID)
        {
            if (!m_CommentDictionary.ContainsKey(commentID))
            {
                Debug.LogError("No commentID: " + commentID);
                return;
            }

            CommentSentenceManager.Instance.LaunchComment(m_CommentDictionary[commentID]);
        }

        public void BlockComment(int commentID, bool block = true)
        {
            //Debug.Log("Block Comment" + commentID);
            if (m_CommentUIDictionary.ContainsKey(commentID))
            {
                //Debug.Log("Blocked Comment" + commentID);
                m_CommentUIDictionary[commentID].BlockComment(block);
            }
        }

        public void RemoveComment(int commentID)
        {
            //Debug.Log("Remove Comment" + commentID);
            if (m_CommentUIDictionary.ContainsKey(commentID))
            {
                //Debug.Log("Removed Comment" + commentID);
                m_CommentUIDictionary[commentID].SelfDestory();
                m_CommentUIDictionary.Remove(commentID);
            }
        }
    }
}
