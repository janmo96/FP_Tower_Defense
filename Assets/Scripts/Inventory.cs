using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int wood;
    public int stone;

    public Text woodAmount;
    public Text stoneAmount;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        woodAmount.text = string.Format("" + wood);
        stoneAmount.text = string.Format("" + stone);
        

    }
}
