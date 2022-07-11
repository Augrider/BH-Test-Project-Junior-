using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DefaultGameUI : MonoBehaviour, IGameUI
{
    [SerializeField] private AnnouncementElement announcement;
    [SerializeField] private ScoreTable scoreTable;

    [SerializeField] private float startGameAnnouncementTime = 2;
    [SerializeField] private float endGameAnnouncementTime = 5;

    //TODO: Learn how to add data into strings correctly
    [Multiline]
    [SerializeField] private string startGameAnnouncement;

    [Multiline]
    [SerializeField] private string endGameAnnouncement;


    // Start is called before the first frame update
    void Awake()
    {
        GameUILocator.Provide(this);
        Debug.Log("UI Ready");
    }

    void OnDestroy()
    {
        GameUILocator.Provide(null);
    }


    public void OnStartGame(Action onStartGameCallback = null)
    {
        announcement.ShowWithTimer(startGameAnnouncement, startGameAnnouncementTime, onStartGameCallback);
    }

    public void OnGameOver(ScoreRecord[] winners, Action onGameOverCallback = null)
    {
        announcement.ShowWithTimer(GetEndGameAnnouncement(winners), endGameAnnouncementTime, onGameOverCallback);
    }


    public void RefreshScore(ScoreRecord[] scoreRecords)
    {
        Debug.Log("Score changed!");
        scoreTable.RefreshRecords(scoreRecords);
    }



    private string GetEndGameAnnouncement(ScoreRecord[] winners)
    {
        return String.Format(endGameAnnouncement, GetWinnersNames(winners));
    }

    private static string GetWinnersNames(ScoreRecord[] winners)
    {
        return String.Join(", ", winners.Select(t => t.playerName));
    }
}
