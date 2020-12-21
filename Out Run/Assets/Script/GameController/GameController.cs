using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //Variables
    [Tooltip("Player Distance in Game")]
    public float Distance;

    [Tooltip("Player Gold in Game")]
    public int Gold;

    //Player Total Gold
    private int TotalGold;

    //Player Distance Record
    private float MaxDistance = 0;

    [HideInInspector]
    public bool Play = false;

    //Objetos
    [Tooltip("MainMenu Panel")]
    public GameObject ButtonPanel;
    [Tooltip("Setting Panel")]
    public GameObject SettingPanel;
    [Tooltip("GameOver Panel")]
    public GameObject GameOverPanel;
    [Tooltip("UI in Game")]
    public GameObject Gui;

    //Text
    public Text GoldText;
    public Text DistanceText;
    public TextMeshProUGUI MaxDistanceText;
    public TextMeshProUGUI TotalGoldText;
    public TextMeshProUGUI YouscoreText;

    //Instance
    public static GameController Instance_Gm { get; private set; }


    void Start()
    {
        TotalGold = PlayerPrefs.GetInt("TotalGold");
        MaxDistance = PlayerPrefs.GetFloat("MaxD");
        Instance_Gm = this;  
    }

    void Update()
    {
        //Text in game Setting
        if (Play == true)
        {
            Distance = Time.timeSinceLevelLoad;
            GoldText.text = Gold.ToString();
            DistanceText.text = Mathf.Round(Distance).ToString();
        }
        if (Input.GetKey(KeyCode.F))
        {
            PlayerPrefs.SetFloat("MaxD",0.0f);
            PlayerPrefs.SetInt("TotalGold",0);
        }
    }

    public void StartGame()
    {
        ButtonPanel.SetActive(false);
        Play = true;
        PlayerController.Instance_PlayerController.Run = true;
        Generator.Instance_Generator.StartGenerator();
        Gui.SetActive(true);
    }

    public void GameOver()
    {
        Generator.Instance_Generator.CancelGenerator();
        Play = false;
        Gui.SetActive(false);
        GameOverPanel.SetActive(true);

        //in this demo use playerpref to save player data
        if (Distance > MaxDistance)
        {
            PlayerPrefs.SetFloat("MaxD",Distance);
        }

        PlayerPrefs.SetInt("TotalGold", Gold + TotalGold);

        MaxDistanceText.text = Mathf.Round(PlayerPrefs.GetFloat("MaxD")).ToString();
        TotalGoldText.text = PlayerPrefs.GetInt("TotalGold").ToString();
        YouscoreText.text = Mathf.Round(Distance).ToString();

    }

    public void OpenSettings() {

        ButtonPanel.SetActive(false);
        SettingPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void CancelSetting()
    {
        SettingPanel.SetActive(false);
        ButtonPanel.SetActive(true);

    }


}
