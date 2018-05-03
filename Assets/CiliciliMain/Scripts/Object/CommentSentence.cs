using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Overture.CommentCensor
{

    public class CommentSentence : MonoBehaviour
    {
        public string m_letter;
        public Text m_Text, upvoteReactionText, muteReactionText;
        public TextSizeFollower m_removeTextTSF, m_arrestTextTSF;
        public Comment m_comment;
        public float speed;
        public bool isMoving = false;
        public Canvas m_Canvas;
        public CommentSentenceCollider m_collider;

        public GameObject m_MuteDialog, m_UpvoteDialog;

        public GlobalDefine.CensorAreaTypes m_feedbackState;

        public void SetComment(Comment comment)
        {
            m_comment = comment;
            m_letter = comment.commentText;
            m_Text.text = comment.commentText.ToString();
            upvoteReactionText.text = comment.upvoteReaction;
            muteReactionText.text = comment.muteReaction;
            m_removeTextTSF.FollowTargetSize();
            m_arrestTextTSF.FollowTargetSize();
            m_collider.SetLength(comment.commentText.Length);
        }

        public void SetFeedbackState(GlobalDefine.CensorAreaTypes types)
        {
            m_feedbackState = types;
            switch (types)
            {
                case GlobalDefine.CensorAreaTypes.PreUpvote:
                    m_UpvoteDialog.SetActive(true);
                    upvoteReactionText.gameObject.SetActive(true);
                    m_MuteDialog.SetActive(false);
                    muteReactionText.gameObject.SetActive(false);
                    break;
                case GlobalDefine.CensorAreaTypes.Upvote:
                    m_UpvoteDialog.SetActive(true);
                    upvoteReactionText.gameObject.SetActive(true);
                    m_MuteDialog.SetActive(false);
                    muteReactionText.gameObject.SetActive(false);
                    break;
                case GlobalDefine.CensorAreaTypes.PreMute:
                    m_UpvoteDialog.SetActive(false);
                    upvoteReactionText.gameObject.SetActive(false);
                    m_MuteDialog.SetActive(true);
                    muteReactionText.gameObject.SetActive(true);
                    CommentManager.Instance.BlockComment(m_comment.commentID, true);
                    break;
                case GlobalDefine.CensorAreaTypes.Mute:
                    m_UpvoteDialog.SetActive(false);
                    upvoteReactionText.gameObject.SetActive(false);
                    m_MuteDialog.SetActive(true);
                    muteReactionText.gameObject.SetActive(true);
                    CommentManager.Instance.RemoveComment(m_comment.commentID);
                    break;
                case GlobalDefine.CensorAreaTypes.None:
                    m_UpvoteDialog.SetActive(false);
                    upvoteReactionText.gameObject.SetActive(false);
                    m_MuteDialog.SetActive(false);
                    muteReactionText.gameObject.SetActive(false);
                    CommentManager.Instance.BlockComment(m_comment.commentID, false);
                    break;
                default: break;
            }
        }

        public bool Launch()
        {
            m_Canvas.worldCamera =
                CommentSentenceManager.Instance.sceneCamera; //CommentSentenceManager.Instance.sceneCamera;
            isMoving = true;
            return isMoving;
        }

        private void FixedUpdate()
        {
            if (isMoving)
            {
                transform.localPosition -= new Vector3(speed * Time.deltaTime, 0, 0);
            }

            //var screenPos = Camera.main.WorldToScreenPoint(transform.position);
            //m_Text.rectTransform.position = screenPos;
            /*
            var screenPos = CommentSentenceManager.Instance.sceneCamera.WorldToScreenPoint(transform.position);
            var localPos = Vector2.zero;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(m_Text.transform.parent.GetComponent<RectTransform>(), screenPos,CommentSentenceManager.Instance.sceneCamera, out localPos);
    
            Debug.Log("screenPos:"+screenPos+"  localPos:"+localPos);
            m_Text.transform.localPosition = localPos;*/

            //Vector2 player2DPosition = CommentSentenceManager.Instance.sceneCamera.WorldToScreenPoint(transform.position);
            //m_Text.rectTransform.position = player2DPosition;

            //m_Text.rectTransform.localPosition = GlobalMethod.WorldToScreenPoint(transform.position,m_Canvas.GetComponent<RectTransform>(), CommentSentenceManager.Instance.sceneCamera);
            //m_Text.transform.localScale=Vector3.one;
        }
/*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("CommentCollectorCollider2D"))
        {
            if (other.GetComponent<CiliPlayer>())
            {
                //other.GetComponent<CiliPlayer>().CollectLetter(m_letter);
                Destroy(this.gameObject);
            }
        }
    }*/

        public void Recycle()
        {

            Destroy(gameObject);

        }
    }
}