using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz quiz;
    Endscreen endscreen;

    void Awake()
    {
        // Ensure only one instance of GameManager exists
         quiz = FindAnyObjectByType<Quiz>();
        endscreen = FindAnyObjectByType<Endscreen>();
    }
    void Start()
    {
        
        quiz.gameObject.SetActive(true);
        endscreen.gameObject.SetActive(false);

    }

    void Update()
    {
        if (quiz.isCompleted)
        {
            quiz.gameObject.SetActive(false);
            endscreen.gameObject.SetActive(true);
            endscreen.ShowFinalScore();
        }
    }
    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
