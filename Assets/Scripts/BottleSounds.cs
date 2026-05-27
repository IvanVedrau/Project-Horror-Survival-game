using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleSounds : MonoBehaviour
{

    private AudioSource audioPlayer;
    private bool playSound = false;
    private Rigidbody rigidBody;

    public GameObject bottleParentObject;
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (playSound == false)
        {
            playSound = true;
            audioPlayer.Play();
            rigidBody.isKinematic = true;
            Destroy(bottleParentObject, 3);
        }
    }
}
