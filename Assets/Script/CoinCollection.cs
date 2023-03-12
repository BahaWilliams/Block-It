using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinCollection : MonoBehaviour
{
    public static CoinCollection coins;
     
    [SerializeField] int coinCollected;
    [SerializeField] AudioClip coinSFX;

    public int totalCoinCollected;

    private void Awake()
    {
        coins = this;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin")
        {
            coinCollected++;
            GetComponent<AudioSource>().PlayOneShot(coinSFX);
            Destroy(collision.gameObject);
            totalCoinCollected += coinCollected;
            Debug.Log("Total coin " + coinCollected);
        }
    }
}
