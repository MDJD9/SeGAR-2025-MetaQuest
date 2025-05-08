using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class PickedUpItemName : MonoBehaviour
{
    public string itemName;
    public TMPro.TextMeshPro text;

    public void updateText()
    {
        Debug.Log(this.itemName);
        text.text = itemName;
    }

    public void clearText()
    {
        Debug.Log(this.itemName + " cleared");
        text.text = "";
    }

}
