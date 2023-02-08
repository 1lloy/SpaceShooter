using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int Score;
    public string ScorePrefix = string.Empty;
    public TextMeshProUGUI ScoreText = null;

    private void Start()
    {
        Score = 0;
    }
    void Update()
    {
        if (ScoreText != null)
        {
            ScoreText.text = ScorePrefix + Score.ToString();
        }
    }

    public static void GameOver()
    {
        AudioSource track = GameObject.Find("Music").GetComponent<AudioSource>();
        track.Pause();
        Animator loseanim = GameObject.Find("RetryBG").GetComponent<Animator>();
        loseanim.SetTrigger("Open");
    }
}
