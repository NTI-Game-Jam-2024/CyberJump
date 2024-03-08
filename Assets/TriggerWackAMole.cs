using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class TriggerWackAMole : MonoBehaviour
{
    public Camera mainPlayerCam; // Cam, that your player actively uses
    public Camera MoleCamera; // Camera to which the player is switched to
    public GameObject Mole;
    public GameObject player;
    
    
    
    
    void OnTriggerEnter2D(Collider2D Geometrycollision)
    {
        if (Geometrycollision.tag == "Player")
        {
            mainPlayerCam.enabled = false;
            MoleCamera.enabled = true;
            MoleCamera.transform.position = new Vector3(92.4f, -29.5f, -20f);
            player.SetActive(false);

            Mole.SetActive(true);
            
            foreach (Transform child in Mole.transform)
            {
                child.gameObject.SetActive(true);
            }





        }
    }



}






