using UnityEngine;
using System.Collections;
using System.IO;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] private Transform _scoresHolderTransform;
    [SerializeField] private GameObject _scoreboardEntryPrefab;

    private int _maxNumberOfEntries = 6;
    private string _savePath => $"{Application.persistentDataPath}/highscores.json";

    private void Start()
    {
        ScoreboardSavedData scoreboardSaveData = LoadSavedData();
        UpdateUI(scoreboardSaveData);
        SaveData(scoreboardSaveData);
    }

    public bool AddEntry(ScoreboardEntryData entryData)
    {
        ScoreboardSavedData savedData = LoadSavedData();
        bool isAdded = false;

        for(int i = 0; i < savedData.highscores.Count; i++)
        {
            if (entryData.score > savedData.highscores[i].score)
            {
                savedData.highscores.Insert(i, entryData);
                isAdded = true;
                break;
            }
        }

        if (!isAdded && savedData.highscores.Count < _maxNumberOfEntries)
        {
            savedData.highscores.Add(entryData);
            isAdded = true;
        }

        if (savedData.highscores.Count > _maxNumberOfEntries)
        {
            savedData.highscores.RemoveRange(
                _maxNumberOfEntries, 
                savedData.highscores.Count - _maxNumberOfEntries
            );
        }
        if (isAdded)
        {
            SaveData(savedData);
            UpdateUI(savedData);
        }
        return isAdded;
    }

    private void UpdateUI(ScoreboardSavedData scoreboardSaveData)
    {
        foreach(Transform entry in _scoresHolderTransform)
        {
            Destroy(entry.gameObject);
        }
        foreach(ScoreboardEntryData entryData in scoreboardSaveData.highscores)
        {
            Instantiate(_scoreboardEntryPrefab, _scoresHolderTransform).
                GetComponent<ScoreboardEntryUI>().Init(entryData);
        }
    }

    private ScoreboardSavedData LoadSavedData()
    {
        if (!File.Exists(_savePath))
        {
            File.Create(_savePath).Dispose();
            return new ScoreboardSavedData();
        }

        using (StreamReader streamReader = new StreamReader(_savePath))
        {
            string jsonStr = streamReader.ReadToEnd();
            if (jsonStr == null || jsonStr.Length <= 0) return new ScoreboardSavedData();
            return JsonUtility.FromJson<ScoreboardSavedData>(jsonStr);
        }
    }

    private void SaveData(ScoreboardSavedData scoreboardSaveData)
    {
        using (StreamWriter streamWriter = new StreamWriter(_savePath))
        {
            string jsonStr = JsonUtility.ToJson(scoreboardSaveData, true);
            streamWriter.Write(jsonStr);
        }
    }
}
