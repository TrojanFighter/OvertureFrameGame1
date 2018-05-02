﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Reference
{
//Manager for the day begin screen
    public class DayBeginScreenManager : MonoBehaviour
    {

        //Gameobject list to enable when we init
        public List<GameObject> INIT_OBJECTS;

        //The text UI part we load what Lily wants
        public Text MESSAGE;

        //Reset function when we turn on this screen
        public void InitScreen()
        {
            foreach (GameObject OBJ in INIT_OBJECTS)
            {
                OBJ.SetActive(true);
            }
        }

        //Function to apply string to message
        public void ApplyString(string MSG)
        {
            MESSAGE.text = MSG;
        }

    }
}
