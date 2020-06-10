using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject panel;
    void Start()
    {
        panel = GameObject.FindWithTag("UI Component");
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0) && !(panel.activeSelf) && GetComponent<RectTransform>().rect.Contains(Input.mousePosition))
        {
            panel.SetActive(true);
        }
        else if(Input.GetMouseButtonUp(0) && panel.activeSelf && !(panel.GetComponent<RectTransform>().rect.Contains(Input.mousePosition)))
        { 
            panel.SetActive(false);
        }
    }
}
