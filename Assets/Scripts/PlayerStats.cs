using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public static int money;

    public Text moneyText;



    // Start is called before the first frame update
    void Start()
    {
        money = 500;
    }

    // Update is called once per frame
    void Update()
    {

        moneyText.text = string.Format("" + money);

    }
}
