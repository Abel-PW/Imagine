using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Echo : MonoBehaviour
{
    public GameObject echo;

    public float duration = 3;
    public float size = 500;
    public float timer;

    public bool timerActive = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shriek();
        }

        if (timerActive)
        {
            timer += Time.deltaTime;
            if (timer >= duration)
            {
                timer = 0f;
                timerActive = false;
                echo.SetActive(false);
            }
        }
    }

    private void Shriek()
    {
        echo.SetActive(true);
        timerActive = true;
    }
}
