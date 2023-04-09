using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] private Image _timerImg;

    [SerializeField] private TextMeshProUGUI _timerText;

    private float _currentTime;

    [SerializeField] private float _duration;

    void Start()
    {
        _currentTime = _duration;
        _timerText.text = _currentTime.ToString();
        StartCoroutine(UpdateTime());
    }

    private IEnumerator UpdateTime()
    {
        while (_currentTime > 0)
        {
            _timerImg.fillAmount = Mathf.InverseLerp(0, _duration, _currentTime);
            _timerText.text = _currentTime.ToString();
            yield return new WaitForSeconds(1f);
            _currentTime--;
        }
        _timerText.text = ("Time Up");
        yield return null;
    }
}
