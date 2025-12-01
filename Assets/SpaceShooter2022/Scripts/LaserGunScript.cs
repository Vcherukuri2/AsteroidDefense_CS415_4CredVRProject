using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LaserGunScript : MonoBehaviour
{
    [SerializeField] private Animator laserAnimator;
    [SerializeField] private AudioClip laserAudio;
    [SerializeField] private Transform raycastPoint;
    private AudioSource laserAudioSource;
    private RaycastHit hit;
    private void Awake()
    {
        if (GetComponent<AudioSource>() != null)
        {
            laserAudioSource = GetComponent<AudioSource>();
        }
    }
    public void LaserGunFired()
    {
        laserAnimator.SetTrigger("Fire");

        laserAudioSource.PlayOneShot(laserAudio);

        if (Physics.Raycast(raycastPoint.position, raycastPoint.forward, out hit, 800))
        {
            if (hit.transform.GetComponent<AsteroidHitScript>() != null)
            {
                hit.transform.GetComponent<AsteroidHitScript>().AsteroidHit();
            }
            if (hit.transform.GetComponent<IRaycastInterface>() != null)
            {
                hit.transform.GetComponent<IRaycastInterface>().RaycastHit();
            }
        }
    }
}
