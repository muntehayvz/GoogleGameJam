using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Typer : MonoBehaviour
{
    public WordBank wordBank = null;
    public TMP_Text wordOutput = null;

    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;

    int scorePerLetter = 1;

    public AudioSource source;
    public AudioClip keyboardSound;

    private void Start()
    {
        SetCurrentWord();
    }

    private void SetCurrentWord()
    {
        currentWord = wordBank.GetWord();
        SetRemainingWord(currentWord, currentWord);

    }

    private void SetRemainingWord(string newString, string visualString)
    {
        remainingWord = newString;
        wordOutput.text = visualString;

    }


    private void Update()
    {
        ChechInput();

    }

    private void ChechInput()
    {
        if (Input.anyKeyDown)
        {
            string keyPressed = Input.inputString;

            if (keyPressed.Length == 1)
                EnterLetter(keyPressed);

        }
    }

    private void EnterLetter(string typedLetter)
    {
        if (IsCorrectLetter(typedLetter))
        {
            RemoveLetter();

            source.PlayOneShot(keyboardSound);
            ScoreManager.Instance.IncreaseScore(scorePerLetter);

            if (IsWordCompelete())
                SetCurrentWord();


        }
    }

    private bool IsCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter) == 0;

    }

    private void RemoveLetter()
    {
        string newString = remainingWord.Remove(0, 1);
        string coloredstring = $"<color=green>{newString}</color>";
        SetRemainingWord(newString, coloredstring);

    }

    private bool IsWordCompelete()
    {
        return remainingWord.Length == 0;
    }
}
