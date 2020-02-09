﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class HighScore : MonoBehaviour
{
    [SerializeField]
    private Transform _entryContainer;

    [SerializeField]
    private Transform _entryTemplate;

    private List<Transform> highScoreEntryTransformList;

    private UnityAction _endOfGameListener;

    void Awake()
    {
        _endOfGameListener = new UnityAction(StoreNewEntryFromEvent);
        _entryTemplate.gameObject.SetActive(false);

        //This should be removed in the real version of the script. It's only for testing.
        PlayerPrefs.SetString("playerScore", "0");
        PlayerPrefs.SetString("playerName", "ABC");

        string jsonString = PlayerPrefs.GetString("highScoreTable");
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);

        //sort the list
        for (int i = 0; i <= highScores.highScoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highScores.highScoreEntryList.Count; j++)
            {
                if (highScores.highScoreEntryList[j].score > highScores.highScoreEntryList[i].score)
                {
                    //swap the entries
                    HighScoreEntry tmp = highScores.highScoreEntryList[i];
                    highScores.highScoreEntryList[i] = highScores.highScoreEntryList[j];
                    highScores.highScoreEntryList[j] = tmp;
                }
            }
        }

        highScoreEntryTransformList = new List<Transform>();
        int entryCounter = 0;
        foreach (HighScoreEntry highScoreEntry in highScores.highScoreEntryList)
        {
            if (entryCounter == 5)
            {
                break;
            }
            CreateHighScoreEntryTransform(highScoreEntry, _entryContainer, highScoreEntryTransformList);
            entryCounter++;
        }

    }

    void OnEnable()
    {
        EventManager.StartListening("theEnd", _endOfGameListener);
    }

    void OnDisable()
    {
        EventManager.StopListening("theEnd", _endOfGameListener);
    }

    private void CreateHighScoreEntryTransform(HighScoreEntry entry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 30f;

        Transform entryTransform = Instantiate(_entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "th"; break;
            case 1: rankString = "1st"; break;
            case 2: rankString = "2nd"; break;
            case 3: rankString = "3rd"; break;
        }

        entryTransform.Find("rank").GetComponent<Text>().text = rankString;

        int score = entry.score;

        entryTransform.Find("score").GetComponent<Text>().text = score.ToString();

        string name = entry.name;

        entryTransform.Find("player").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);
    }

    private int? ConvertStringToInt(string intString)
    {
        int i = 0;
        return (Int32.TryParse(intString, out i) ? i : (int?)null);
    }

    private void StoreNewEntryFromEvent()
    {
        string playerScore = PlayerPrefs.GetString("playerScore");
        int prefScoreAsInt = ConvertStringToInt(playerScore).GetValueOrDefault();
        string playerName = PlayerPrefs.GetString("playerName");
        AddHighScoreEntry(prefScoreAsInt, playerName);
    }

    private void AddHighScoreEntry(int score, string name)
    {
        // create high score
        HighScoreEntry highScoreEntry = new HighScoreEntry { score = score, name = name };

        // load saved high scores
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);

        // add new entry
        highScores.highScoreEntryList.Add(highScoreEntry);

        // save updated high scores
        string json = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("highScoreTable", json);
        PlayerPrefs.Save();
    }

    private class HighScores
    {
        public List<HighScoreEntry> highScoreEntryList;
    }

    [System.Serializable]
    private class HighScoreEntry
    {
        public int score;
        public string name;
    }
}
