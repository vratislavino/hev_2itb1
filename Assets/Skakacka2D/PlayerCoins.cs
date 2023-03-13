using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCoins : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;

    private int coins = 0;
    private int Coins {
        get { return coins; }
        set { 
            coins = value;
            text.text = coins.ToString();
        }
    }

    public void AddCoin() {
        Coins++;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
