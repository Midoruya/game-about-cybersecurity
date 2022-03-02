using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Starting : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas this_canvas;
    public Canvas level_canvas;
    public InputField start;
    
    void Start()
    {
        this_canvas.enabled = true;
        this_canvas.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (start.text.Equals("start"))
        {
            level_canvas.enabled = true;
            level_canvas.gameObject.SetActive(true);
            this_canvas.enabled = false;
            this_canvas.gameObject.SetActive(false);
        }
    }
}
