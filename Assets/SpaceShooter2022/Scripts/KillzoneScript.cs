using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillzoneScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameOver;
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.gameObject.CompareTag("Asteroid"))
        {
            GameControllerScript.state = GameControllerScript.GameState.GameOver;
            gameOver.SetActive(true);
            Destroy(other.gameObject);
        }
    }
}
