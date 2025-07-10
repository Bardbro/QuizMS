using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Scorekeeper : MonoBehaviour
{
    int correcctAnswers = 0;
    int questionSeen = 0;
    public int GetCorrectAbswers()
    {
        return correcctAnswers;
    }
    public void IncrementCorrectAnswers()
    {
        correcctAnswers++;
    }
    public int GetQuestionSeen()
    {
        return questionSeen;
    }
    public void IncrementQuestionSeen()
    {
        questionSeen++;
    }

    public int CalculateScoure()
    {
        return Mathf.RoundToInt(correcctAnswers/(float)questionSeen * 100);
    }
}
