using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LifeDisplay : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;

    [SerializeField]
    private PlayerCollision playerCollision;

    // Start is called before the first frame update
    void Start()
    {

        playerCollision.LivesChanged += OnLivesChanged;
        //if(a)
    }

    private void OnLivesChanged(int lives)
    {
        text.text = lives.ToString();
    }

    public void RestartClicked()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void ExitClicked()
    {
        Application.Quit();
    }

}
