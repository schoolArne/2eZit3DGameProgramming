using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonHit : MonoBehaviour
{
    public int pointsToGiveToPlayer;
    public AudioClip balloonPopSound;
    public GameManager gameManager;
    private void OnCollisionEnter(Collision collision)
    {
        gameManager.addPointsToTotalPoints(pointsToGiveToPlayer);
        PlayPopSound(balloonPopSound);
        Destroy(transform.root.gameObject);
        Debug.Log("current total points: " + gameManager.getTotalPoints());
    }
    public void SetGameManagerReference(GameManager manager)
    {
        gameManager = manager;
    }

    private void PlayPopSound(AudioClip audioClipToPLay)
    {
        GameObject soundObject = new GameObject("TemporarySoundObject");
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();

        audioSource.clip = audioClipToPLay;
        audioSource.volume = 50;

        soundObject.transform.position = transform.position;

        audioSource.Play();
    }
}
