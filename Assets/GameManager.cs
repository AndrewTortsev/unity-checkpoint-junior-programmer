using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Serializable]
    private class UserData
    {
        public UserData(int score, string login)
        {
            Score = score;
            Login = login;
        }

        [SerializeField]
        private int score;
        [SerializeField]
        private string login;
        public int Score { get => score; private set => score = value; }
        public string Login { get => login; private set => login = value; }
    }

    private static string login = "Player";
    private static bool PrettyPrint = true;

    private GameManager()
    {

    }
    public static GameManager INSTANCE { get; private set; }

    public bool IsGameOver { get; private set; }
    public string CurrentPlayerLogin { get; private set; }
    public string BestPlayerLogin { get; private set; }
    public int BestPlayerScore { get; private set; }

    void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
            DontDestroyOnLoad(gameObject);
        }
        LoadBestUserData();

    }

    public static void RetartGame()
    {
        GameManager.INSTANCE.IsGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadBestUserData()
    {
        if (File.Exists(GetSaveFilePath()))
        {
            ReadUserDataFromFile();
        }
    }

    public static void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private string GetSaveFilePath()
    {
        return string.Format("{0}/Save File.json", Application.persistentDataPath);
    }

    private string GetJsonUserData()
    {
        UserData userData = GetUserData();
        return JsonUtility.ToJson(userData, PrettyPrint);
    }

    private UserData GetUserData()
    {
        return new UserData(this.BestPlayerScore, this.BestPlayerLogin);
    }

    private UserData LoadUserDataFromFile()
    {
        string jsonData = File.ReadAllText(GetSaveFilePath());
        return JsonUtility.FromJson<UserData>(jsonData);
    }
    private void SaveBestUserData()
    {
        string jsonData = GetJsonUserData();

        File.WriteAllText(GetSaveFilePath(), jsonData);
    }

    private void ReadUserDataFromFile()
    {
        UserData userData = LoadUserDataFromFile();
        this.BestPlayerLogin = userData.Login;
        this.BestPlayerScore = userData.Score;
    }

    public void CompareAndSaveUserData(int score)
    {
        if (BestPlayerScore < score)
        {
            BestPlayerScore = score;
            BestPlayerLogin = CurrentPlayerLogin;

            SaveBestUserData();
        }
    }
    public void GameOver()
    {
        IsGameOver = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
