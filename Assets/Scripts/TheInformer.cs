using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TheInformer : MonoBehaviour
{

    public TextMeshProUGUI inform;
    public string info;
    public bool mouseOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        float distance = Vector2.Distance(transform.position, mousePos);

        if(distance < 2)
        {
            mouseOver = true;
        }
        else
        {
            mouseOver = false;
        }

        if(mouseOver == true)
        {
            inform.text = info;
        }
    }
}
