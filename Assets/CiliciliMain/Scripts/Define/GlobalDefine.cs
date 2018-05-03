using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Overture.CommentCensor
{

    public class Comment
    {
        public int commentID;
        public string commentText;
        public DateTime date;
        public float InVideoTime;
        public string CommenterName;
        public int offset;
        public GlobalDefine.CensorTypes m_correctCensorTypes;
        public string upvoteReaction, muteReaction;

        public float TRexesReactionUp, StegosaursReactionUp, PterosaursReactionUp;
        public float TRexesReactionDoNothing, StegosaursReactionDoNothing, PterosaursReactionDoNothing;
        public float TRexesReactionRemove, StegosaursReactionRemove, PterosaursReactionRemove;
    }

    public static class GlobalMethod
    {
        public static Vector3 WorldToScreenPoint(Vector3 SetWorldPostion, RectTransform canvas, Camera UICamera)
        {
            Vector2 UICameraPostion = Vector2.zero; // 先宣告一個回傳Vector2.
            RectTransform CanvasRectTransform = canvas; // 取得Canvas的RectTransform.
            Vector2 ScreenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, SetWorldPostion);
// 將照射3D物件的社Camera指定進去， 並將要轉換的3D座標輸入進去
// 就可以得到3D Camera轉換為該Space下的Screen Space.

            RectTransformUtility.ScreenPointToLocalPointInRectangle(CanvasRectTransform, ScreenPos, UICamera,
                out UICameraPostion);
// 最後用這個API將Screen Space轉換為UGUI的座標，分別將UI Canvas的RectTransform傳入
// 後面依序是要轉換的ScreenPostion跟UI Camera以及輸到到那一個變數.　

            return UICameraPostion;
        }
    }

    public enum Level
    {
        Aone=0,
        Atwo=1,
        Athree,
        Bone,
        Cone
    }

    public static class GlobalDefine
    {

        public enum CensorTypes
        {
            OK = 0,
            Upvote,
            Mute
        }

        public enum CensorAreaTypes
        {
            None,
            PreUpvote,
            Upvote,
            PreMute,
            Mute
        }

        public static class PathDefines
        {
            public const string XML_Path = "XML/";
        }

        public static class FileName
        {
            public static string[] Comments=new string[]{"CommentsA1","CommentsA2","CommentsA3","CommentsB1","CommentsC1"};
        }
    }
}