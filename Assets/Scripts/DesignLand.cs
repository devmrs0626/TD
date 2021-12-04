using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignLand : MonoBehaviour
{
    public Vector2Int bottomLeft;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Design()
    {
        int i = GameManager.instance.towerX - bottomLeft.x;
        int j = -GameManager.instance.towerY - bottomLeft.y;
        List<Node> FinalNodeList = FindPath.FinalNodeList;
        for (int b = j - 1; b < j + 2; b++)
        {
            for (int a = i - 1; a < i + 2; a++)
            {

            }
        }
    }
}
