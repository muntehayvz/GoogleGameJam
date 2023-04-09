using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;
    [SerializeField] Camera mainCamera;

    public TMP_Text questionText;

    private void Start()
    {
        mainCamera = Camera.main;
        GenerateQuestions();
    }
    public void  SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Answers>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].correctAnswer == i + 1)
            {
                    options[i].GetComponent<Answers>().isCorrect = true;
                   // options[i].GetComponent<Image>().color = new Color(0, 255, 0, 1f);
            }
            else 
            {
                options[i].GetComponent<Answers>().isCorrect = false;
                //options[i].GetComponent<Image>().color = new Color(255, 0, 0, 1f);
            }
            
        }
    }
    public void Correct()
    {
        QnA.RemoveAt(currentQuestion);
        Invoke("GenerateQuestions", 2f);
       
    }
    public void Wrong()
    {
        //Trigger particle - cevap yanlýþ 
        QnA.RemoveAt(currentQuestion);
        Invoke("GenerateQuestions", 2f);
    }

    private void GenerateQuestions()
    {
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            questionText.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of Questions");
            Loader.Load(Loader.Scene.SampleScene);
        }
    }
    void SetColorToDefault()
    {

    }
}



