using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Overture.CommentCensor
{

    public class CommentSentenceManager : MonoBehaviourEX<CommentSentenceManager>
    {

        public Transform[] LauncherPoints;
        public float LetterGapTime;
        public CommentSentence SentencePrefab;
        public Camera sceneCamera;
        public Collider draggingCollider;
        public bool isDragging = false;
        public Transform m_CommentRoot;

        public void LaunchComment(Comment comment)
        {
            StartCoroutine(PrintComment(comment));
        }

        IEnumerator PrintComment(Comment comment)
        {
            //int textlength = commenttext.Length;
            //string[] commentchars = comment.commentText.Split(' ');
            //int textlength = commentchars.Length;
            int textlength = 1;
            for (int i = 0; i < textlength; i++)
            {
                SpawnSentence(comment, comment.offset);
                yield return new WaitForSeconds(LetterGapTime);
            }
        }

        public void SpawnSentence(Comment word, int offset)
        {
            m_CommentRoot.transform.SetParent(m_CommentRoot);
            CommentSentence commentSentence = GameObject.Instantiate(SentencePrefab) as CommentSentence;
            commentSentence.transform.SetParent(m_CommentRoot);
            commentSentence.SetComment(word);
            commentSentence.transform.position = LauncherPoints[0].transform.position + Vector3.down * offset;
            commentSentence.m_Canvas.worldCamera = sceneCamera;
            commentSentence.Launch();
        }

        private void Update()
        {
            DetectDrag();
        }

        void DetectDrag()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray myRay = CommentSentenceManager.Instance.sceneCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit myRayHit = new RaycastHit();

                Debug.DrawRay(myRay.origin, myRay.direction * 100f, Color.yellow, 0.1f);
                int waypointlayerMask = 1 << LayerMask.NameToLayer("Sentences");

                if (Physics.Raycast(myRay, out myRayHit, 100, waypointlayerMask))
                {
                    //Debug.Log(myRayHit.m_collider.gameObject.name);		
                    Debug.Log("Dragging " + gameObject.name + " " + Input.mousePosition);
                    draggingCollider = myRayHit.collider;
                    isDragging = true;
                }
            }

            if (isDragging && draggingCollider != null)
            {
                Ray myRay1 = CommentSentenceManager.Instance.sceneCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit myRayHit1 = new RaycastHit();

                Debug.DrawRay(myRay1.origin, myRay1.direction * 100, Color.red, 0.1f);
                Debug.Log("Dragging");
                int waypointboardlayerMask = 1 << LayerMask.NameToLayer("DragBoard");
                if (Physics.Raycast(myRay1, out myRayHit1, 100, waypointboardlayerMask))
                {
                    Debug.Log("Found" + myRayHit1.collider.gameObject.name);
                    //myRayHit.point
                    draggingCollider.GetComponent<CommentSentenceCollider>().m_sentence.transform.position =myRayHit1.point;
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                draggingCollider = null;
            }
        }
    }
}
