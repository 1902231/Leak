using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Button Startbutton;
    //public string SceneName;

    // Start is called before the first frame update
    void Start()
    {
        Startbutton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        Startbutton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene("Scene0");
    }
}
