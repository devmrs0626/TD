using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour
{
    public GameObject enemy;

    IEnumerator Generate()
    {
        for(int i = 0; i < 100; i++)
        {
            Instantiate(enemy);
            yield return new WaitForSeconds(3);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Generate");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
