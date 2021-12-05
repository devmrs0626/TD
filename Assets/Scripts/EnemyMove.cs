using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class EnemyMove : MonoBehaviour
{
    public float speed = 0.05f;
    int index = 1;
    Vector2 targetPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.waveProgressing == true && index < FindPath.FinalNodeList.Count)
        {
            targetPosition = new Vector2(FindPath.FinalNodeList[index].x, FindPath.FinalNodeList[index].y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed);
            if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y)
            {
                index++;
            }
        }
    }
}
