using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

# if UNITY_EDITOR
using UnityEditor;
# endif

public class Menu : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TextMeshProUGUI highscoreText;

    private void Start()
    {
        UpdateHighscore();
    }

    public void StartGame()
    {
        UpdatePlayerName();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
# if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
# else
        Application.Quit();
# endif
    }

    private void UpdatePlayerName()
    {
        string player_name = nameInput.text;
        GameData.Instance.PlayerName = player_name;
    }

    private void UpdateHighscore()
    {
        highscoreText.text = $"Highscore: {GameData.Instance.HighscorePlayer} - {GameData.Instance.Highscore}";
    }
}
