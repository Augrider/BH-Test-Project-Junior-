using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class ScoreTable : MonoBehaviour
{
    [SerializeField] private TextFieldPair[] playerRecords;


    public void RefreshRecords(ScoreRecord[] scoreRecords)
    {
        var sortedRecords = scoreRecords.OrderByDescending(t => t.playerScore).ToArray();
        var playersAmount = scoreRecords.Length;

        for (int i = 0; i < playerRecords.Length; i++)
        {
            if (i >= playersAmount)
            {
                ResetRecord(i);
                continue;
            }

            SetRecord(sortedRecords[i], i);
        }

        Debug.Log("Scores updated");
    }



    private void SetRecord(ScoreRecord scoreRecord, int i)
    {
        playerRecords[i].playerName.SetText(scoreRecord.playerName);
        playerRecords[i].playerScore.SetText(scoreRecord.playerScore.ToString("D2"));
    }

    private void ResetRecord(int i)
    {
        playerRecords[i].playerName.SetText("");
        playerRecords[i].playerScore.SetText("");
    }


    [System.Serializable]
    private struct TextFieldPair
    {
        public TextMeshProUGUI playerName;
        public TextMeshProUGUI playerScore;
    }
}
