using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameControllerScript : MonoBehaviour
{
    [SerializeField] private Image oxytimerImage;
    [SerializeField] private TMP_Text stopwatchText;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private float oxyTime;
    public static float sliderfill = 1.0f;
    public static float timeElapsed = 0f;

    public enum GameState
    {
        Start,
        Game,
        GameOver
    }
    public static GameState state;

    private void Awake()
    {
        state = GameState.Start;
        gameOverMenu.SetActive(false);
    }
    private void Update()
    {
        if (state == GameState.Game)
        {
            timeElapsed += Time.deltaTime;
            int min = Mathf.FloorToInt(timeElapsed / 60f);
            int sec = Mathf.FloorToInt(timeElapsed % 60f);
            int mil = Mathf.FloorToInt((timeElapsed * 100f) % 100f);
            stopwatchText.text = $"{min:00}:{sec:00}:{mil:00}";

            float currOx = AdjustOxyTimer();
            if (currOx == 0)
            {
                state = GameState.GameOver;
                gameOverMenu.SetActive(true);
            }
        } else
        {
            sliderfill = 1.0f;
        }
        
    }
    private float AdjustOxyTimer()
    {
        oxytimerImage.fillAmount = sliderfill - Time.deltaTime/oxyTime;
        sliderfill = oxytimerImage.fillAmount;
        return sliderfill;
    }
}
