using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Video;

namespace Overture
{
    public class Lvl2TargetPosition : MonoBehaviour {
        
        public VideoPlayer video_player;
        
        // Use this for initialization
        void Start ()
        {
            transform.position = new Vector3(-0.18f, -0.53f, 0f);
        }

        void moveLeaf()
        {
            if (video_player.time > 116f)
            {
                transform.position = new Vector3(-2.1f, -2.1f, 0f);
            } 
            else if (video_player.time > 114f)
            {    
                transform.position = new Vector3(-2.45f , -3.86f, 0f);
            }  else if (video_player.time > 103f)
            {
                transform.position = new Vector3( -2.1f, -2.1f, 0f);
            }  else if (video_player.time > 98f)
            {
                transform.position = new Vector3( -2.45f, -3.86f, 0f);
            }  else if (video_player.time > 89.2f)
            {
                transform.position = new Vector3( .45f, -1.57f, 0f);
            }  else if (video_player.time > 88.8f)
            {
                transform.position = new Vector3( .33f, -1.65f, 0f);
            }  else if (video_player.time > 88.6f)
            {
                transform.position = new Vector3( .33f, -1.82f, 0f);
            }  else if (video_player.time > 88.2f)
            {
                transform.position = new Vector3( .2f, -1.94f, 0f);
            }  else if (video_player.time > 88f)
            {
                transform.position = new Vector3( .24f, -2.15f, 0f);
            }  else if (video_player.time > 87.6f)
            {
                transform.position = new Vector3( .24f, -2.31f, 0f);
            }  else if (video_player.time > 87.2f)
            {
                transform.position = new Vector3( .2f, -2.56f, 0f);
            }  else if (video_player.time > 87.0f)
            {
                transform.position = new Vector3( .2f, -2.8f, 0f);
            }  else if (video_player.time > 86.8f)
            {
                transform.position = new Vector3( .12f, -2.85f, 0f);
            }  else if (video_player.time > 86.6f)
            {
                transform.position = new Vector3( .2f, -3.01f, 0f);
            }  else if (video_player.time > 86.4f)
            {
                transform.position = new Vector3( .08f, -3.09f, 0f);
            }  else if (video_player.time > 86.2f)
            {
                transform.position = new Vector3( .12f, -3.3f, 0f);
            }  else if (video_player.time > 86.0f)
            {
                transform.position = new Vector3( .04f, -3.54f, 0f);
            }  else if (video_player.time > 85.0f)
            {
                transform.position = new Vector3( -.25f, -3.91f, 0f);
            }  else if (video_player.time > 84.7f)
            {
                transform.position = new Vector3( -.29f, -3.96f, 0f);
            }  else if (video_player.time > 84.0f)
            {
                transform.position = new Vector3( -.41f, -4.28f, 0f);
            }  else if (video_player.time > 47.5f)
            {
                transform.position = new Vector3( -1.09f, -4.34f, 0f);
            }  else if (video_player.time > 42.8f)
            {
                transform.position = new Vector3( -2.22f, -2.12f, 0f);
            }  else if (video_player.time > 37.4f)
            {
                transform.position = new Vector3( -.12f, -2.17f, 0f);
            }  else if (video_player.time > 36.9f)
            {
                transform.position = new Vector3( 1.03f, -2.99f, 0f);
            }  else if (video_player.time > 36.7f)
            {
                transform.position = new Vector3( 1.52f, -2.34f, 0f);
            }  else if (video_player.time > 36.5f)
            {
                transform.position = new Vector3( 1.89f, -1.88f, 0f);
            }  else if (video_player.time > 36.3f)
            {
                transform.position = new Vector3( 2.14f, -1.51f, 0f);
            }  else if (video_player.time > 36.1f)
            {
                transform.position = new Vector3( 2.39f, -1.31f, 0f);
            }  else if (video_player.time > 35.9f)
            {
                transform.position = new Vector3( 2.51f, -1.1f, 0f);
            }  else if (video_player.time > 35.6f)
            {
                transform.position = new Vector3( 2.76f, -.86f, 0f);
            }  else if (video_player.time > 35.2f)
            {
                transform.position = new Vector3( 2.84f, -.65f, 0f);
            }  else if (video_player.time > 29.5f)
            {
                transform.position = new Vector3( 3.01f, -.41f, 0f);
            }  else if (video_player.time > 25.0f)
            {
                transform.position = new Vector3( -1.6f, -2.44f, 0f);
            }  else if (video_player.time > 14.34f)
            {
                transform.position = new Vector3( -.11f, -4.32f, 0f);
            }  else if (video_player.time > 9.57f)
            {
                transform.position = new Vector3( -.11f, -.66f, 0f);
            }  else if (video_player.time > 9.37f)
            {
                transform.position = new Vector3( -.32f, -.29f, 0f);
            }  else if (video_player.time > 7.24f)
            {
                transform.position = new Vector3( -.11f, -.46f, 0f);
            }  else if (video_player.time > 4.7f)
            {
                transform.position = new Vector3( -.4f, -.66f, 0f);
            }
        }

        // Update is called once per frame
        void Update () {
		    moveLeaf();
        }
    }

}

