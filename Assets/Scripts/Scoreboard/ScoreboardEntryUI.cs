using UnityEngine;
using System.Collections;
using TMPro;

public class ScoreboardEntryUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _dateText;

    public void Init(ScoreboardEntryData scoreboardEntryData)
    {
        _scoreText.text = scoreboardEntryData.score.ToString();
        _dateText.text = scoreboardEntryData.date.ToString();
    }
}