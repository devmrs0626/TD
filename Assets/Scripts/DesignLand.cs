using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignLand : MonoBehaviour
{
    public Vector2Int bottomLeft;

    public Sprite land;
    public Sprite landReverse;
    public Sprite landTop;
    public Sprite landRight;
    public Sprite landBottom;
    public Sprite landLeft;
    public Sprite landTopLeft;
    public Sprite landTopRight;
    public Sprite landBottomLeft;
    public Sprite landBottomRight;
    public Sprite landReverseTopLeft;
    public Sprite landReverseTopRight;
    public Sprite landReverseBottomLeft;
    public Sprite landReverseBottomRight;

    bool topLeftCheck;
    bool topRightCheck;
    bool bottomLeftCheck;
    bool bottomRightCheck;

    bool[,] check = new bool[3, 3];


    // 1    2
    //   ¤±
    // 3    4

    // Start is called before the first frame update
    void Start()
    {
        topLeftCheck = false;
        topRightCheck = false;
        bottomLeftCheck = false;
        bottomRightCheck = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Design()
    {
        List<Node> FinalNodeList = FindPath.FinalNodeList;
        int towerX = GameManager.instance.towerX;
        int towerY = GameManager.instance.towerY;
        int i = GameManager.instance.towerX - bottomLeft.x;
        int j = -GameManager.instance.towerY - bottomLeft.y;
        for(int b = j - 1; b <= j + 1; b++)
        {
            for(int a = i - 1; a <= i + 1; a++)
            {

            }
        }
    }
}
