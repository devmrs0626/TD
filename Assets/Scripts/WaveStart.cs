using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveStart : MonoBehaviour
{
    public Sprite start;
    public Sprite stop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseUp()
    {
        GameManager.instance.waveProgressing = !GameManager.instance.waveProgressing;
        if(GameManager.instance.waveProgressing == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = stop;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = start;
        }
    }
}
