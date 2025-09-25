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

    //private void Awake()
    //{
    //    Time.timeScale = 1;
    //}

    // Start is called before the first frame update
    void Start()
    {
        Startbutton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }
}
