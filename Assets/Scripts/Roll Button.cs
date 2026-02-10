using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class RollButton : MonoBehaviour
{
    public GameObject pipPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame == true)
        {
            getDie();
        }
    }

    public int setDie()
    {
        int die = 0;
        die = Random.Range(0, 6);
        return die;
    }

    public void getDie()
    {
        int roll = setDie();
        if(roll == 1)
        {
            Instantiate(pipPrefab);
        }
    }
}
