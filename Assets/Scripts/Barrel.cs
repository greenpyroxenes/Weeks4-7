using Unity.Properties;
using UnityEngine;
using UnityEngine.InputSystem;

public class Barrel : MonoBehaviour
{

    bool alive;
    SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(alive == true)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                //sr.SetActive(true);
            }
        }
    }
}
