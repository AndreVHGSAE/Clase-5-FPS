using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isPlaying;

    public float GameTime=60;

    [SerializeField]
    private TMP_Text GameTimeText;

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
            GameTime = 0;
        }
        else
        {
            GameTime -= Time.deltaTime;
        }
    }

    void UpdateTimeText()
    {
        int min = (int)GameTime / 60;
        int seg = (int)GameTime % 60;
        GameTimeText.text = "Time: " + min.ToString("00") + ":" + seg.ToString("00");
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void AddTime(float time)
    {
        GameTime += time;
    }
}
