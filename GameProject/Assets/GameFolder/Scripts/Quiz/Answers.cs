using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answers : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    public Color startColor;

    private void Start()
    {
        startColor = GetComponent<Image>().color;
    }

    public void Answer()
    {
        if (isCorrect)
        {
            GetComponent<Image>().color = Color.green;
            quizManager.Correct();
            FunctionTimer.Create(() => GetComponent<Image>().color = new Color(0, 0, 0, 0), 2f);
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            quizManager.Wrong();
            FunctionTimer.Create(() => GetComponent<Image>().color = new Color(0, 0, 0, 0), 2f);
        }
    }
}
