using System;
using UnityEngine;
using UnityEngine.UI;

public class RussianRoulette : MonoBehaviour
{

    int bulletCount = 1;
    int moneyIn;
    int moneyOut;
    double multiplier;

    [SerializeField]
    Button playButton;
    [SerializeField]
    Button raiseButton;
    [SerializeField]
    Button lowerButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moneyIn = 100;
        playButton.onClick.AddListener(PlayGame);
        lowerButton.onClick.AddListener(LowerNumber);
        raiseButton.onClick.AddListener(RaiseNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetMultiplier()
    {
        multiplier = 1 + (0.15 * bulletCount);
    }

    void Win()
    {
        moneyOut = (int)(multiplier * moneyIn);
        Debug.Log("Win");
    }

    void Lose()
    {
        moneyOut = 0;
        Debug.Log("Lose");
    }

    void PlayGame()
    {
        SetMultiplier();
        System.Random rng = new System.Random();
        if(rng.Next(0, 6) < bulletCount)
        {
            Lose();
            return;
        }
            Win();
    }

    void RaiseNumber()
    {
        if (bulletCount >= 5)
        {
            Debug.Log("Put a number below 5");
            return;
        }
        bulletCount++;
        Debug.Log("Number raised to " + bulletCount);
    }

    void LowerNumber()
    {
        if (bulletCount <= 1)
        {
            Debug.Log("Put a number above 1");
            return;
        }
        bulletCount--;
        Debug.Log("Number lowered to " + bulletCount);
    }

}
