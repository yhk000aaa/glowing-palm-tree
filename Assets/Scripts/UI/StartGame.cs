using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public int zoomInSpeed = 4;

    private bool isStart = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            if (transform.localScale.x <= 1.3)
                transform.localScale += Vector3.one * zoomInSpeed * Time.deltaTime;
        }
         
    }
    public void GameOn()

    {
        isStart = true;
    }
}
