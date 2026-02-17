using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dice2 : MonoBehaviour
{
    //varible declaration
    public GameObject[] pips;
    public int roll = 0;
    public int die2;
    public float time;
    public int speed = 50;
    public bool spin;
    public bool change;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    
    //same code as roll button script new scirpt is made to have this die be independent and have different values
    void Update()
    {
        if (spin == true)
        {
            rotateDie2();
            for (int i = 0; i < pips.Length; i++)
            {
                pips[i].SetActive(false);
            }
        }
        if (change == true)
        {
            getDie2();
        }
    }

    public void getDie2()
    {
        
        roll = Random.Range(1, 7);
        die2 = roll;
        if (roll == 1)
        {
            pips[0].SetActive(true);
            for (int i = 1; i < pips.Length; i++)
            {
                pips[i].SetActive(false);
            }
        }
        else if (roll == 2)
        {
            for (int i = 0; i < pips.Length; i++)
            {
                pips[i].SetActive(false);
            }
            pips[1].SetActive(true);
            pips[3].SetActive(true);
        }
        else if (roll == 3)
        {
            for (int i = 0; i < pips.Length; i++)
            {
                pips[i].SetActive(false);
            }
            pips[1].SetActive(true);
            pips[0].SetActive(true);
            pips[3].SetActive(true);
        }
        else if (roll == 4)
        {
            for (int i = 0; i < pips.Length; i++)
            {
                pips[i].SetActive(false);
            }
            pips[1].SetActive(true);
            pips[2].SetActive(true);
            pips[3].SetActive(true);
            pips[4].SetActive(true);
        }
        else if (roll == 5)
        {
            for (int i = 0; i < 5; i++)
            {
                pips[i].SetActive(true);
            }
            pips[5].SetActive(false);
            pips[6].SetActive(false);
        }
        else if (roll == 6)
        {
            for (int i = 1; i < pips.Length; i++)
            {
                pips[i].SetActive(true);
            }
            pips[0].SetActive(false);
        }
        change = false;
    }


    //gets the roll number from die 2
    public int getRoll()
    {
        return die2;
    }

    public void rotateDie2()
    {
        time += Time.deltaTime;
        if (time < 1)
        {
            Vector3 newRotation = transform.eulerAngles;
            newRotation.z += speed * time;
            transform.eulerAngles = newRotation;
        }
        else
        {
            time = 0;
            spin = false;
            change = true;
        }
    }
    public void spinner2()
    {
            spin = true;
    }
}
