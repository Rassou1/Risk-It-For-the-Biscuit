using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RussianRoulette : MonoBehaviour
{

    int bulletCount = 1;
    public int moneyIn;
    int moneyOut;
    double multiplier;

    public TMP_InputField amountInput;

    [SerializeField]
    Button playButton;
    [SerializeField]
    Button raiseButton;
    [SerializeField]
    Button lowerButton;

    GameObject player;
    PlayerStats playerStats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        lowerButton.onClick.AddListener(LowerNumber);
        raiseButton.onClick.AddListener(RaiseNumber);
        
        amountInput.onValueChanged.AddListener(delegate { InputBetValue(amountInput); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        player = GameObject.Find("Player");
        playerStats = player.GetComponent<PlayerStats>();
    }

    void SetMultiplier()
    {
        multiplier = 1 + (0.15 * bulletCount);
    }

    void InputBetValue(TMP_InputField input)
    {
        moneyIn = int.Parse(input.text);
    }

    void Win()
    {
        moneyOut = (int)(multiplier * moneyIn);
        Debug.Log("Win");
        playerStats.money += moneyOut;
    }

    void Lose()
    {
        moneyOut = 0;
        Debug.Log("Lose");
        playerStats.money += moneyOut;
    }

    void PlayGame()
    {
        if (moneyIn > playerStats.money)
        {
            Debug.Log("bet 2 much </3");
            return;
        }

        SetMultiplier();
        playerStats.money -= moneyIn;
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
