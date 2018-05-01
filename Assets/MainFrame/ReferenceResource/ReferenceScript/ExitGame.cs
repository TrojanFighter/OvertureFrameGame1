using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reference
{
//Exit the game on call
    public class ExitGame : MonoBehaviour
    {

        public void ExitGameCall()
        {
            Application.Quit();
        }
    }
}