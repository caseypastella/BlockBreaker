using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //Config Params
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float screenWidthMax = 15f;
    [SerializeField] float screenWidthMin = 1f;

    //chache
    gamestatus theGameSession;
    Ball theBall;
    
    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<gamestatus>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
       
        
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(autoPlay(), screenWidthMin, screenWidthMax); 
        transform.position = paddlePos;

        

    }
    private float autoPlay()
    {
        if (theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;

        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
