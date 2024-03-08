using UnityEngine;
using System.Collections;
using TMPro;

public class Mole : MonoBehaviour
{
    public GameObject[] sprites; // Array som h�ller alla sprites
    private SpriteRenderer currentSpriteRenderer;// aktiva spriten
    public int streak = 0;
    private SpriteRenderer[] allSpriteRenderers;//renderer f�r alla sprite
    public float spawnTid = 0.7f;// tiden en b�ver �r uppe


    public Camera mainPlayerCam;
    public Camera wackAMoleCam;

    public WinnerScript win;


    private void Start()
    {
        //g�r igenom alla sprites och sl�gger in dom i spritrenderer
        allSpriteRenderers = new SpriteRenderer[sprites.Length];
        for (int i = 0; i < sprites.Length; i++)
        {
            allSpriteRenderers[i] = sprites[i].GetComponent<SpriteRenderer>();
        }

        InvokeRepeating("ChangeSpriteColor", 0f, 4f); // kallar p� ChangeSpriteColor() var 4 sekund
    }

    private void ChangeSpriteColor()
    {
        if (streak == 4) //vicotory
        {
            
            mainPlayerCam.enabled = true;
            wackAMoleCam.transform.position = new Vector3(-5.8f, -29.5f, -20f);
            wackAMoleCam.enabled = false;
            
            gameObject.SetActive(false);
           
        }
        foreach (SpriteRenderer spriteRenderer in allSpriteRenderers)//g�r alla sprites samma skala
        {
            spriteRenderer.transform.localScale = new Vector3(13f, 13f, 1f);
        }
        int randomIndex = Random.Range(0, sprites.Length); //g�r ett random index
        GameObject selectedSprite = sprites[randomIndex]; // selectar ett random sprite

        currentSpriteRenderer = selectedSprite.GetComponent<SpriteRenderer>();

        StartCoroutine(TurnRedForTwoSeconds()); 
    }

    private IEnumerator TurnRedForTwoSeconds()
    {
        currentSpriteRenderer.color = Color.red;//byter valda spritens f�rg till r�d

        yield return new WaitForSeconds(spawnTid);//s� l�nge f�rgen ska vara byten

        if (currentSpriteRenderer.transform.localScale == Vector3.one)//om man lyckade klicka p� spriten n�r den �r r�d
        {
            streak++;
        }
        else streak = 0;
        currentSpriteRenderer.color = Color.white; // g�r alla sprits r�da igen

    }
}
