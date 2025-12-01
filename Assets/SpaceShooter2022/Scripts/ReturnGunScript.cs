using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ReturnGunScript : MonoBehaviour
{
    [SerializeField] private Pose originPose;
    // Start is called before the first frame update
    private XRGrabInteractable grabinteract;

    private void Awake()
    {
        grabinteract = GetComponent<XRGrabInteractable>();
        originPose.position = transform.position;
        originPose.rotation = transform.rotation;

    }

    private void OnEnable() => grabinteract.selectExited.AddListener(LaserGunReleased);
    

    private void OnDisable() => grabinteract.selectExited.RemoveListener(LaserGunReleased);
    
    private void LaserGunReleased(SelectExitEventArgs arg0)
    {
        transform.position = originPose.position;
        transform.rotation = originPose.rotation;
    }
}
