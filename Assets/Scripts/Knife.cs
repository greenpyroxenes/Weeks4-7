using UnityEngine;
using UnityEngine.InputSystem;

public class Knife : MonoBehaviour
{

    public bool mouseOver;
    public int random;
    public SpriteRenderer spriteRender;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if(spriteRender.bounds.Contains(mousePos) == true && Mouse.current.leftButton.wasPressedThisFrame == true)
        {
            mouseOver = true;
        }
        else
        {
            mouseOver = false;
        }

        if (Mouse.current.leftButton.wasPressedThisFrame && mouseOver == true)
        {
            random = Random.Range(0, 10);
            if(random == 5)
            {

            }
        }
    }
}
