using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    // Start is called before the first frame update
    public int quality_of_execution = 50;
    public Canvas this_canvas;
    public Text end_text;
    public InputField input;
    void Start()
    {
        end_text.text = $"arch@root:~$ Твоё колличество баллов {quality_of_execution} / 100";
    }

    // Update is called once per frame
    void Update()
    {
        if (input.text.Equals("next"))
            SceneManager.LoadScene(0);
    }
}
