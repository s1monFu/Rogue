using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{

    public static int coinCnt;
    public Text coinText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (coinText != null)
        {
            coinText.text = "Coin: " + coinCnt;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            coinCnt+=1;
            Destroy(gameObject);
        }
    }
}
