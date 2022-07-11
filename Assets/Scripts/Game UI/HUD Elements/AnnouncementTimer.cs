using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnnouncementTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    private bool inProgress = false;


    internal void StartCountdown(float showTime)
    {
        CheckForTimerInProgress();

        StartCoroutine(ProcessTimer(showTime));
    }


    internal void StartCountdown(float showTime, Action onTimerFinishedCallback)
    {
        CheckForTimerInProgress();

        StartCoroutine(ProcessTimer(showTime, onTimerFinishedCallback));
    }



    private IEnumerator ProcessTimer(float showTime, Action onTimerFinishedCallback = null)
    {
        inProgress = true;

        int currentShown = Mathf.CeilToInt(showTime);
        float currentTime = showTime;

        SetTimerText(currentShown);
        timerText.enabled = true;

        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            var currentCeil = Mathf.CeilToInt(currentTime);

            if (currentCeil != currentShown)
            {
                currentShown = currentCeil;
                SetTimerText(currentShown);
            }

            yield return null;
        }

        onTimerFinishedCallback?.Invoke();

        inProgress = false;
        timerText.enabled = false;
    }


    //TODO: Add effects when numbers change
    private void SetTimerText(int time)
    {
        timerText.SetText(time.ToString());
    }


    private void CheckForTimerInProgress()
    {
        if (!inProgress)
            return;

        Debug.LogWarning("Timer is already running! Stopping current");
        StopAllCoroutines();
    }
}
