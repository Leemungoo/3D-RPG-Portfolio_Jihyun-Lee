using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameObject restartImage;
    public static bool isPlayerDie;

    private bool isGameOver;
    public bool IsGameOver
    {
        get { return isGameOver; }
        set
        {
            isGameOver = value;
        }
    }

    public static GameManager instance = null; 

    private void Awake()
    {
        restartImage = GameObject.Find("RestartButton");

        #region Singleton
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        #endregion
    }

    void Start()
    {
        restartImage.gameObject.SetActive(false);
        IsGameOver = false;
        isPlayerDie = false;
    }

    void Update()
    {
        if (isGameOver)
        {
            restartImage.SetActive(true);
            isPlayerDie = true;

            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("Scene Reload");
                SceneManager.LoadScene("Main");

                IsGameOver = false;
                isPlayerDie = false;
            }
        }

        else
        {
            restartImage.SetActive(false);
        }
    }
}
