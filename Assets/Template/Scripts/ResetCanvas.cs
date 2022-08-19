using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This function sets the scoreboard position so that it is visible by both players on Oculus devices.

public class ResetCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ResetCanvasPos();
    }

    void ResetCanvasPos()
    {
        GameObject canvas = GameObject.Find("Canvas");//get scoreboard
        var canvasePos = canvas.GetComponent<RectTransform>();//get RectTransform component of scoreboard
        canvasePos.localPosition = new Vector3(-15,10,15);//position in world coordinates
        canvasePos.localScale = new Vector3(0.1f, 0.1f, 0.1f);//scale down since oroginal size is very big
        canvasePos.sizeDelta = new Vector2(20,10);//width and height
    }
}
