using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickUpSFX;
    [SerializeField] int pointsForCoinPickUp = 100;
    bool wasCollected = false;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && !wasCollected) 
        {
            wasCollected = true;
            FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickUp);
            AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
            gameObject.SetActive(false);// not necessary
            Destroy(gameObject);
        }
    }
}
