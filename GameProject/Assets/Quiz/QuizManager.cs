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
    public Button[] buttons;
    public int currentQuestion;
    [SerializeField] Camera mainCamera;

    public TMP_Text questionText;

    private void Start()
    {
        mainCamera = Camera.main;
        GenerateQuestions();
    }
    public IEnumerator SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Answers>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].correctAnswer == i + 1)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    options[i].GetComponent<Answers>().isCorrect = true;
                    options[i].GetComponent<Image>().color = new Color(0, 255, 0, 1f);
                    yield return new WaitForSeconds(5f);
                    options[i].GetComponent<Image>().color = new Color(0, 0, 0, 0);
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                { 
                    options[i].GetComponent<Answers>().isCorrect = false;
                    options[i].GetComponent<Image>().color = new Color(255, 0, 0, 1f);
                    yield return new WaitForSeconds(5f);
                    options[i].GetComponent<Image>().color = new Color(0, 0, 0, 0);
                }
            }
        }
    }
    public void Correct()
    {
        QnA.RemoveAt(currentQuestion);
        GenerateQuestions();
    }
    public void Wrong()
    {
        //Trigger particle - cevap yanlýþ 
        QnA.RemoveAt(currentQuestion);
        GenerateQuestions();
    }

    private void GenerateQuestions()
    {
        currentQuestion = Random.Range(0, QnA.Count);

        questionText.text = QnA[currentQuestion].Question;
        StartCoroutine(SetAnswers());
    }
}



