using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LandManager : MonoBehaviour
{
    public Vector2Int bottomLeft;
    public UnityEvent landCheck;
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
        for(int a = 0; a < gameObject.transform.childCount; a++)
        {
            Transform child = gameObject.transform.GetChild(a);
            if(i - 1 <= child.position.x && child.position.x <= i + 1 && j - 1 <= child.position.y && child.position.y <= j + 1)
            {
                landCheck.AddListener(child.gameObject.GetComponent<DesignLand>().Design);
            }
        }
        landCheck.Invoke();
        for (int a = 0; a < gameObject.transform.childCount; a++)
        {
            Transform child = gameObject.transform.GetChild(a);
            if (i - 1 <= child.position.x && child.position.x <= i + 1 && j - 1 <= child.position.y && child.position.y <= j + 1)
            {
                landCheck.RemoveListener(child.gameObject.GetComponent<DesignLand>().Design);
            }
        }
    }
}
