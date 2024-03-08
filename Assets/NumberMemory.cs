using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NumberMemory : MonoBehaviour
{
    public Text numberText; // Text för att visa nummer
    public float displayTime = 3f, delayTime = 1f; // hur länge nummrerna visas
    private int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, currentNumbers; //siffror som går att visa
    public int currentLevel = 3; // Börja med att visa 3 nummer
    
    public Camera mainPlayerCam;
    public Camera numberCamera;
    public GameObject Player;
    public GameObject triggerNumberGame;
    public PlayerMovement player;

    public WinnerScript win;
    private void Start() => StartCoroutine(StartGame());

    IEnumerator StartGame()
    {
        while (true)
        {
            if(currentLevel == 8) //ska vara 8, ändras för test
            {
                
                numberText.text = "Vinst";
                
                yield return new WaitForSecondsRealtime(2.5f);
                numberCamera.enabled = false;
                mainPlayerCam.enabled = true;
                
                triggerNumberGame.SetActive(false);
                GetComponent<NumberMemory>().enabled = false;
                //player.Active = true;

                gameObject.SetActive(false);


            }
            currentNumbers = GetRandomNumbers(currentLevel); // Hämta slumpmässiga nummer baserad på aktuell nivå
            yield return StartCoroutine(DisplayNumbers(currentNumbers)); // Visa nummer
            yield return StartCoroutine(PlayerInput()); // tar input
        }
    }

    IEnumerator DisplayNumbers(int[] nums) //displayar nummrerna 
    {
        yield return new WaitForSeconds(delayTime); string disp = "";
        foreach (int num in nums) disp += num + " ";
        numberText.text = disp; yield return new WaitForSeconds(displayTime);
        numberText.text = "";
    }

    IEnumerator PlayerInput()
    {
        bool hasStreak = true;//kollar om man har svarat fel / rätt
        for (int i = 0; i < currentLevel;)//loopar igenom hela talet
        {
            if (!hasStreak) break; //avbryt loopen om man har haft fel
            KeyCode expKey = KeyCode.Alpha1 + currentNumbers[i] - 1; //bestämmer vilken keycode som är rätt för aktuel siffra

            yield return new WaitUntil(() => Input.anyKeyDown); //väntar för knapp tryck

            KeyCode pressedKey = KeyCode.None; //
            foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))//om man klicka på rätt knapp
                {
                    pressedKey = keyCode; break;//så blir tryckt knapp samma som rätt sifrar vilken används senare för att komma vidare
                }
            }
            if (pressedKey != KeyCode.None)
            {
                if (pressedKey == expKey) { i++; }//om dom har samma värde gå vidare
                else hasStreak = false; // bryter loopen om man har fel
            }
        }
        currentLevel += hasStreak ? 1 : -1; //kort kod om som + på 1 om det är true och tar - 1 om false
    }

    int[] GetRandomNumbers(int count)
    {
        int[] randomNumbers = new int[count];
        for (int i = 0; i < count; i++)
            randomNumbers[i] = numbers[Random.Range(0, numbers.Length)];
        return randomNumbers;
    }
}