using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberGameCameraSwitcher : MonoBehaviour
{
    public Camera mainPlayerCam; // Cam, that your player actively uses
    public Camera numberCamera; // Camera to which the player is switched to
    public GameObject numberText;
    public GameObject geometry;
    public GameObject gemoertyWall;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Something collided with this object (the invisible object). Now we need to know if that was the player
        if (collision.tag == "Player")
        {
            // Switch cameras
            mainPlayerCam.enabled = false;
            numberCamera.enabled = true;
            numberText.SetActive(true);
            numberCamera.transform.position = new Vector3(-81f, -16.4f, -20f);

            GameObject[] geoWalls = GameObject.FindGameObjectsWithTag("geoWall");
            foreach (GameObject wall in geoWalls)
            {
                wall.SetActive(false);
            }
            geometry.SetActive(false);
            gemoertyWall.SetActive(false);


        }

    }
}


 



