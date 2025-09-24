using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{

    public Button Exitbutton;
    // Start is called before the first frame update
    void Start()
    {
        Exitbutton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        Exitbutton.onClick.AddListener(Application.Quit);
    }
}
