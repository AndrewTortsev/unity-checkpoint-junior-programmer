using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOvertitle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject title1;
    public GameObject title2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.INSTANCE.IsGameOver)
        {
            title1.SetActive(true);
            title2.SetActive(true);
        }
    }
}
