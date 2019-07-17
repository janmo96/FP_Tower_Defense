using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsRecieved : MonoBehaviour
{

    public GameObject Texts;
    public GameObject textInstance;

    Text textComp;
    // Start is called before the first frame update
    void Start()
    {
      textComp = textInstance.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
           StartCoroutine(RecieveText(5, "Wood"));
        }
    }

    public IEnumerator RecieveText(int amount, string itemName)
    {
        if(amount > 0) { 

        textComp.text = string.Format("You Got " + "" + "<color=#ffff00ff>" + amount + "</color>" + " " + "<color=#ff0000ff>" + itemName + "</color>");

      GameObject textGO = Instantiate(textInstance, Texts.transform);


        yield return new WaitForSeconds(5f);

        Destroy(textGO);

        } else
        {
            yield return new WaitForSeconds(0.1f);
        }
    }




}
