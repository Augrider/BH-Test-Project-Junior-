using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnnouncementElement : MonoBehaviour
{
    [SerializeField] private Canvas elementCanvas;
    [SerializeField] private TextMeshProUGUI announcementText;

    [SerializeField] private AnnouncementTimer timer;

    [SerializeField] private float defaultShowTime = 2;


    public void Show(string message)
    {
        announcementText.SetText(message);
        StartCoroutine(WaitAndHide(defaultShowTime));
    }

    public void Show(string message, float showTime)
    {
        announcementText.SetText(message);
        StartCoroutine(WaitAndHide(showTime));
    }


    public void ShowWithTimer(string message, float showTime)
    {
        timer.StartCountdown(showTime);
        Show(message, showTime);
    }

    public void ShowWithTimer(string message, float showTime, Action onTimerFinishedCallback = null)
    {
        timer.StartCountdown(showTime, onTimerFinishedCallback);
        Show(message, showTime);
    }



    private IEnumerator WaitAndHide(float showTime)
    {
        elementCanvas.enabled = true;

        yield return new WaitForSeconds(showTime);

        elementCanvas.enabled = false;
    }
}
