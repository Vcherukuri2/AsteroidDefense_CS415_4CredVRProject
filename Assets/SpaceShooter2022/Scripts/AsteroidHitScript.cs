using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHitScript : MonoBehaviour
{
    [SerializeField] private GameObject asteroidExplosion;

    public void AsteroidHit()
    {
        Instantiate(asteroidExplosion, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
