using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class Score : MonoBehaviour
{
    [SerializeField] private GameObject _scoreboard;

    private int _value = 0;
    private Text _text;

    private static int _betweenScenesValue;

    public int Value
    {
        get { return _value; }
    }

    private void Start()
    {
        _text = GetComponent<Text>();
        _value = _betweenScenesValue;
        RedrawText();
    }

    public void Restart()
    {
        _betweenScenesValue = 0;
        _value = _betweenScenesValue;
        RedrawText();
    }

    public void Increase(int value)
    {
        _value += value;
        RedrawText();
    }

    public void SaveScore()
    {
        ScoreboardEntryData entry = new ScoreboardEntryData
        {
            score = _value,
            date = DateTime.Today.ToString("d")
        };
        _scoreboard.GetComponent<Scoreboard>().AddEntry(entry);
        _betweenScenesValue = _value;
    }

    private void RedrawText()
    {
        _text.text = _value.ToString().PadLeft(3, '0');
    }
}
