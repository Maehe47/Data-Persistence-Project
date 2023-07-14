using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{

    public DataManager data;

    public TextMeshProUGUI highScoreText;
    public TMP_InputField playerNameInput;
    public int highScore;
    public string highScoreName;
    public string playerName;


    
    
    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("DataManager").GetComponent<DataManager>();

        highScore = data.highScore ;
        highScoreName = data.highScoreName;

        highScoreText.text = "Highscore: " + highScoreName + " " + highScore ;

    }

    // Update is called once per frame
    void Update()
    {

        playerName = playerNameInput.text;
        data.playerName = playerName;

    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    

}
