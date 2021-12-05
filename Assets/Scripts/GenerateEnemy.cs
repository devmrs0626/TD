using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour
{
    public GameObject enemy;
    public int delayTime = 3;
    float time = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.waveProgressing == true)
        {
            if(time >= delayTime)
            {
                time = 0;
                Instantiate(enemy);
            }
            time += Time.deltaTime;
        }
    }
}
