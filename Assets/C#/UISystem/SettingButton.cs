using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingButton : MonoBehaviour
{
    public Button Settingbutton;
    public GameObject SettingWindows;
    // Start is called before the first frame update
    void Start()
    {
        Settingbutton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        Settingbutton.onClick.AddListener(DialogLive);
    }

    void DialogLive()
    { 
        SettingWindows.SetActive(true);
    }

}
