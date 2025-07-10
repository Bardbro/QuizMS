 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Endscreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalscoreText;
    Scorekeeper scorekeeper;
    void Start()
    {
        scorekeeper = FindAnyObjectByType<Scorekeeper>();
    }
    public void ShowFinalScore()
    {
        finalscoreText.text = "Final Score: " + scorekeeper.CalculateScoure() + "%";
    }

  
}
