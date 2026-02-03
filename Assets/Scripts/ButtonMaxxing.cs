using UnityEngine;

public class ButtonMaxxing : MonoBehaviour
{
    SpriteRenderer spriren;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriren = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ColourChange()
    {
        spriren.color = Random.ColorHSV();
    }
}
