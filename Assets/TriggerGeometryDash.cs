using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class TriggerGeometryDash : MonoBehaviour
{
    public Camera mainPlayerCam; // Cam, that your player actively uses
    public Camera geometryCamera; // Camera to which the player is switched to
    public GameObject Geometry;
    public GameObject memorynumber;
    public GameObject GeometryWall;

    public PlayerMovement playerMovement;
    

    void OnTriggerEnter2D(Collider2D Geometrycollision)
    {
        if (Geometrycollision.tag == "Player")
        {
            mainPlayerCam.enabled = false;
            geometryCamera.enabled = true;
           
            

            memorynumber.SetActive(false);
            GeometryWall.SetActive(true);
            geometryCamera.transform.position = new Vector3(-5.8f, -51.2026f, -20f);

            //playerMovement.enabled = false;

            // Activate all child GameObjects of GeometryWall
            foreach (Transform child in GeometryWall.transform)
            {
                child.gameObject.SetActive(true);
            }

            Geometry.SetActive(true);
        }
    }



}






