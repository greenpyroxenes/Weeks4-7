using System.Collections.Generic;
using UnityEngine;

public class Spawnering : MonoBehaviour
{
    public GameObject knifePrefab;
    public List<GameObject> knives = new List<GameObject>();
    Vector2 pos;
    float yPos = 0.5f;
    float xPos = -2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pos.x = xPos;
        for (int i = 0; i < knives.Count; i++)
        {
            pos.y = yPos;
            Instantiate(knifePrefab, pos, transform.rotation);
            yPos -= 0.75f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
