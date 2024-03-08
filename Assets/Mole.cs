using UnityEngine;
using System.Collections;
using TMPro;

public class Mole : MonoBehaviour
{
    public GameObject[] sprites; // Array som håller alla sprites
    private SpriteRenderer currentSpriteRenderer;// aktiva spriten
    public int streak = 0;
    private SpriteRenderer[] allSpriteRenderers;//renderer för alla sprite
    public float spawnTid = 0.7f;// tiden en bäver är uppe


    public Camera mainPlayerCam;
    public Camera wackAMoleCam;

    public WinnerScript win;


    private void Start()
    {
        //går igenom alla sprites och slägger in dom i spritrenderer
        allSpriteRenderers = new SpriteRenderer[sprites.Length];
        for (int i = 0; i < sprites.Length; i++)
        {
            allSpriteRenderers[i] = sprites[i].GetComponent<SpriteRenderer>();
        }

        InvokeRepeating("ChangeSpriteColor", 0f, 4f); // kallar på ChangeSpriteColor() var 4 sekund
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
        foreach (SpriteRenderer spriteRenderer in allSpriteRenderers)//gör alla sprites samma skala
        {
            spriteRenderer.transform.localScale = new Vector3(13f, 13f, 1f);
        }
        int randomIndex = Random.Range(0, sprites.Length); //går ett random index
        GameObject selectedSprite = sprites[randomIndex]; // selectar ett random sprite

        currentSpriteRenderer = selectedSprite.GetComponent<SpriteRenderer>();

        StartCoroutine(TurnRedForTwoSeconds()); 
    }

    private IEnumerator TurnRedForTwoSeconds()
    {
        currentSpriteRenderer.color = Color.red;//byter valda spritens färg till röd

        yield return new WaitForSeconds(spawnTid);//så länge färgen ska vara byten

        if (currentSpriteRenderer.transform.localScale == Vector3.one)//om man lyckade klicka på spriten när den är röd
        {
            streak++;
        }
        else streak = 0;
        currentSpriteRenderer.color = Color.white; // gör alla sprits röda igen

    }
}
