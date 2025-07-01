using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{

    [SerializeField] float timeToAnswering = 30f; // Thời gian để trả lời câu hỏi
    [SerializeField] float timeToshowAnswer = 10f; // Thời gian để hiển thị câu trả lời đúng
    float timeValue; // Biến để lưu thời gian hiện tại
    public float fillFraction; // Biến để lưu giá trị phần trăm thời gian đã trôi qua
    public bool isAnsweringQuestion; // Biến để kiểm tra xem có đang trả lời câu hỏi hay không
    public bool loadNextQuestion;
    void Update()
    {
        updateTimer();
        // Hiển thị thời gian còn lại
    }
    public void cancelTimer()
    {
        timeValue = 0f;
    }

    void updateTimer()
    {
        timeValue -= Time.deltaTime;
        // Kiểm tra nếu thời gian đã hết
        if (isAnsweringQuestion)
        {
            if (timeValue > 0)
            {
                fillFraction = timeValue / timeToAnswering;
            }
            else
            {
                isAnsweringQuestion = false;
                timeValue = timeToshowAnswer;
            }
        }
        else
        {
            if (timeValue > 0)
            {
                fillFraction = timeValue / timeToshowAnswer;
            }
            else
            {
                isAnsweringQuestion = true;
                timeValue = timeToAnswering;
                loadNextQuestion = true;
            }
        }
        // Debug.Log(isAnsweringQuestion+ ":" +timeValue + " : " + fillFraction);
        
    }
}
