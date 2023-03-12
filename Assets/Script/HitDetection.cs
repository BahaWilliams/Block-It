using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HitDetection : MonoBehaviour
{
    public static HitDetection hitting;

    [SerializeField] GameObject gameOverUI;
    [SerializeField] Text attemptsUI;
    [SerializeField] static int attempts = 0;
    [SerializeField] Button restartButton;
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] AudioClip loseMusic;

    void Start()
    {
        hitting = this;
        attemptsUI.text = "ATTEMPTS: " + attempts.ToString();
        restartButton.onClick.AddListener(RestartGame);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Vector2 boxSize = collision.collider.bounds.size;
        Vector2 boxPosition = collision.collider.transform.position;

        if (collision.gameObject.tag == "Box")
        {
            if (collision.contacts[0].point.y > boxPosition.y + boxSize.y / 2)
            {
                Debug.Log("Jump");
                Controller.controller.Jumping();
                Controller.controller.canJump = true;
            }

            else if (collision.contacts[0].point.y < boxPosition.y - boxSize.y / 2)
            {
                Debug.Log("Lose");
                Time.timeScale = 0;
                gameOverUI.SetActive(true);
                LoseAttempts();
                backgroundMusic.Stop();
            }

            else if (collision.contacts[0].point.x < boxPosition.x - boxSize.x / 2)
            {
                Debug.Log("Lose");
                Time.timeScale = 0;
                gameOverUI.SetActive(true);
                LoseAttempts();
                backgroundMusic.Stop();
            }
        }    
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fake")
        {
            Destroy(collision.gameObject);
            Debug.Log("Fooled");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Controller.controller.canJump = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            Time.timeScale = 0;
            Debug.Log("Lose");
            gameOverUI.SetActive(true);
            LoseAttempts();
            backgroundMusic.Stop();
        }

        if (collision.gameObject.tag == "Finish")
        {
            backgroundMusic.Stop();
            SceneManager.LoadScene(2);
        }
    }

    void LoseAttempts()
    {
        attempts++;
        attemptsUI.text = "ATTEMPS: " + attempts.ToString();
        GetComponent<AudioSource>().PlayOneShot(loseMusic);
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public int GetAttempts()
    {
        return attempts;
    }
}
