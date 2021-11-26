using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreManager : MonoBehaviour
{

    public static HighscoreManager Instance;

    private string keyToSave = "keyHighscore";

    [Header("References")]

    public TextMeshProUGUI uiTextHighScore;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        uiTextHighScore.text = PlayerPrefs.GetString(keyToSave, "No Highscore");
    }

    public void SavePlayerWin(Player p)
    {
        if (p.playerName == "") return;
        PlayerPrefs.SetString(keyToSave, p.playerName);
        UpdateText();
    }
}
