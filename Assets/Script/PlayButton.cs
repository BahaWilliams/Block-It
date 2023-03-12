using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    [SerializeField] float loadGameTime = 1f;

    void LoadGame()
    {
        Debug.Log("Game Load");
        SceneManager.LoadScene(1);
    }

    public void LoadGameTime()
    {
        Invoke("LoadGame", loadGameTime);
    }
}
