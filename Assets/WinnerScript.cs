using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;





public class WinnerScript : MonoBehaviour
{
    public bool numberGame = false;
    public bool moleGame = false;
    public bool geoGame = false;
    // Start is called before the first frame updat

    // Update is called once per frame
    void Update()
    {
        if(numberGame && moleGame && geoGame)
        {
            Application.Quit();
        }
    }
}
