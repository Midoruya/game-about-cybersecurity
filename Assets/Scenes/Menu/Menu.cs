using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button level_one;
    public Button close;

    private void RunLevelOne()
    {
        SceneManager.LoadScene(1); 
    }

    private void Close()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        level_one.onClick.AddListener(RunLevelOne);
        close.onClick.AddListener(Close);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
