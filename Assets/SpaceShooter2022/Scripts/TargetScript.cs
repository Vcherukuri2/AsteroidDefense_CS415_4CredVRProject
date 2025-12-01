using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetScript : MonoBehaviour, IRaycastInterface
{
    
    public GameObject startMenu;
    public GameObject gameOver;
    public void RaycastHit()
    {
        if (GameControllerScript.state == GameControllerScript.GameState.Start)
        {
            GameControllerScript.state = GameControllerScript.GameState.Game;
            startMenu.SetActive(false);
        } else if (GameControllerScript.state == GameControllerScript.GameState.Game)
        {
            GameControllerScript.sliderfill = 1.0f;
        } else {
            GameControllerScript.state = GameControllerScript.GameState.Start;
            startMenu.SetActive(true);
            gameOver.SetActive(false);
            GameControllerScript.timeElapsed = 0f;
        }
    }
}
