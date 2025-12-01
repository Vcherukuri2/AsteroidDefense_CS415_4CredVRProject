using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnerScript : MonoBehaviour
{
    public Vector3 spawnerSize;
    public float spawnRate;

    [SerializeField] private GameObject asteroidModel;

    private float spawnTimer = 1f;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, spawnerSize);

    }

    private void Update()
    {
        if (GameControllerScript.state == GameControllerScript.GameState.Game)
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer > spawnRate)
            {
                spawnTimer = 0f;
                SpawnAsteroid();
            }
        }
        if (GameControllerScript.state == GameControllerScript.GameState.GameOver)
        {
            if(transform.childCount > 0)
            {
                Destroy(transform.GetChild(0).gameObject);  
            }
        }

    }

    private void SpawnAsteroid()
    {
        Vector3 spawnPoint = transform.position + new Vector3(UnityEngine.Random.Range(-spawnerSize.x / 2, spawnerSize.x / 2),
                                                              UnityEngine.Random.Range(-spawnerSize.y / 2, spawnerSize.y / 2),
                                                              UnityEngine.Random.Range(-spawnerSize.z / 2, spawnerSize.z / 2));
        GameObject asteroid = Instantiate(asteroidModel, spawnPoint, transform.rotation);   
        asteroid.transform.SetParent(this.transform);
    }
}
