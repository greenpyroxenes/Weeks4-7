using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.VFX;

public class RollButton : MonoBehaviour
{
    //initalze variables
    public GameObject[] pips;
    public int roll = 0;
    public TextMeshProUGUI winnings;
    public TextMeshProUGUI target;
    public TextMeshProUGUI betting;
    public Slider slider;
    public int money = 20;
    public int targNum;
    public int targNum2;
    public int targNum3;
    public int die1;
    public int dice2;
    public int combined;
    public float speed = 50;
    public float time;
    public Dice2 dice;
    public Spawner spawns;
    public string win;
    public string targ;
    public string bet;
    public bool spin = false;
    public bool change = false;
    public bool wins = false;
    public bool lose = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set inital text and values
        setTarget();
        updateText();
        setText();
        money = 20;
        betUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        //update the bet number if the slider is moved
        betUpdate();
        //if spin is true rotate dice and make the pips go invisible
        if (spin == true)
        {
            rotateDie();
            for (int i = 0; i < pips.Length; i++)
            {
                pips[i].SetActive(false);
            }
        }
        //when change value is true change the values of the die and spawn the chips based on a streak of wins
        if (change == true)
        {
            getDie1();
            spawns.spawning();
        }
    }

    //roll a random number from 1-6, make that number equal to the die number
    //the roll is how many pips will be shown based on a series of if statements checking the number
    //The pips are in a list so they can be easily acessed and changed with active and non active
    public void getDie1()
    {
        roll = Random.Range(1, 7);
        die1 = roll;
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
        //add dice together then stop process
        addDice();
        change = false;
    }

    //adds the value of the 1st die and second die
    //if value is equal to any of the target numbers add money
    //if not equal lose money equal to bet
    //then set new target and update text
    public void addDice()
    {
        combined = die1 + dice.getRoll();
        if (targNum == combined || targNum2 == combined || targNum3 == combined)
        {
            money += (int)slider.value;
            wins = true;
            lose = false;

        }
        else
        {
            if (money > 0)
            {
                money -= (int)slider.value;
            }
            lose = true;
            wins = false;
        }
        setTarget();
        updateText();
        setText();
    }

    //chose a random number between 2-12 to make the target
    //this is done 3 times for more chance to win
    //if the target numbers are the same, reroll until not the same
    public void setTarget()
    {
        targNum = Random.Range(2, 13);
        targNum2 = Random.Range(2, 13);
        targNum3 = Random.Range(2, 13);
        while (targNum2 == targNum || targNum2 == targNum3)
        {
            targNum2 = Random.Range(2, 13);
        }
        while (targNum3 == targNum || targNum3 == targNum2)
        {
            targNum3 = Random.Range(2, 13);
        }
    }

    //sets text to variables
    public void updateText()
    {
        win = "Winnings: $" + money;
        targ = "Target Numbers: " + targNum + ", " + targNum2 + ", " + targNum3;
    }
    //makes the text in the gui reflect the variables
    public void setText()
    {
        winnings.text = win.ToString();
        target.text = targ.ToString();
    }

    //change the bet number based on the slider value
    public void betUpdate()
    {
        bet = "Bet: $" + slider.value;
        betting.text = bet.ToString();
    }

    //rotate the die quickly to make it look like rolling
    public void rotateDie()
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

    //what is called when button is pressed to make spin happen followed by dice values
    public void spinner()
    {
        spin = true;
    }


    //gets money variable for other scripts
    public int getMoney()
    {
        return money;
    }

}
