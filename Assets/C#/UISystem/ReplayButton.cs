using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ReplayButton : MonoBehaviour
{
    public Button Replaybutton;
    //public string SceneName;

    // Start is called before the first frame update
    void Start()
    {
        Replaybutton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        Replaybutton.onClick.AddListener(ReplayGame);
    }

    void ReplayGame()
    {
        SceneManager.LoadScene("StartScene");
    }
}