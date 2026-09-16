using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isPlaying;

    public float GameTime=60;

    [SerializeField]
    private TMP_Text GameTimeText;
    [SerializeField]
    private GameObject pausePanel;

    public InputAction PauseInput;

    private void OnEnable()
    {
        PauseInput.Enable();
    }
    private void OnDisable()
    {
        PauseInput.Disable();
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        { 
            Destroy(this.gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        UpdateTimeText();
        if (GameTime <= 0)
        {
            isPlaying = false;
            SceneManager.LoadScene(3);
            GameTime = 0;
        }
        else
        {
            GameTime -= Time.deltaTime;
        }

        if (PauseInput.WasPerformedThisFrame())
        {
            OpenPauseMenu();
        }
    }

    void UpdateTimeText()
    {
        int min = (int)GameTime / 60;
        int seg = (int)GameTime % 60;
        GameTimeText.text = "Time: " + min.ToString("00") + ":" + seg.ToString("00");
    }

    public void OpenGameOver()
    {
        SceneManager.LoadScene(3);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToTitleScreen()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToWinScreen()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    public void OpenPauseMenu()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePauseMenu()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void AddTime(float time)
    {
        GameTime += time;
    }

}
