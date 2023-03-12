using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishGame : MonoBehaviour
{
    [SerializeField] Text attemptsText;
    [SerializeField] Text coinsText;

    void Start()
    {
        int attempts = HitDetection.hitting.GetAttempts();
        attemptsText.text = "TOTAL ATTEMPS: " + attempts.ToString();

        int coin = CoinCollection.coins.totalCoinCollected;
        coinsText.text = "TOTAL COINS: " + coin.ToString();
    }

    public void HomeButton()
    {
        SceneManager.LoadScene(0);
    }
}
