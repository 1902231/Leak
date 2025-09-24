using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DleteWindowsButton : MonoBehaviour
{
    public Button deletebutton;
    public GameObject SettingWindows;
    // Start is called before the first frame update
    void Start()
    {
        deletebutton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        deletebutton.onClick.AddListener(DialogDie);
    }

    void DialogDie()
    {
        SettingWindows.SetActive(false);
    }

}
