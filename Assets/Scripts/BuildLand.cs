using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildLand : MonoBehaviour
{
    public GameObject previewGrid;
    public GameObject previewDangerGrid;
    public GameObject previewTower;
    public GameObject land;
    Vector2 mousePosition;
    Camera Camera;
    GameObject instantiatedTower;
    bool canBuild = true;

    public UnityEvent landBuild;

    void Build()
    {
        Debug.Log("CLICK: " + gameObject.name);
        switch (GameManager.instance.clickCount)
        {
            case 0:
                GameManager.instance.clickCount++;
                previewGrid.SetActive(false);
                previewTower.transform.localPosition = new Vector3(GameManager.instance.towerX, GameManager.instance.towerY, -3);
                previewTower.SetActive(true);
                break;
            case 1:
                if (canBuild == true)
                {
                    previewTower.SetActive(false);
                    instantiatedTower = Instantiate(land, new Vector3(GameManager.instance.towerX, GameManager.instance.towerY, -1), Quaternion.identity);
                    Debug.Log("LAND BUILD");
                    landBuild.Invoke();
                    GameManager.instance.clickCount = 0;
                    GameManager.instance.selectMenuOn = false;
                }
                else
                {
                    previewTower.transform.localPosition = new Vector3(GameManager.instance.towerX, GameManager.instance.towerY, -3);
                    previewTower.SetActive(true);
                }
                break;
            default:
                GameManager.instance.clickCount = 0;
                break;

        }
    }

    void CheckBuildable()
    {
        bool enemyCheck = false;
        foreach (Collider2D col in Physics2D.OverlapBoxAll(new Vector2(GameManager.instance.towerX, GameManager.instance.towerY), new Vector2(1, 1), 0))
        {
            //Debug.Log("c " + col.gameObject.layer);
            if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                Debug.LogError("CAN NOT BUILD");
                canBuild = false;
                enemyCheck = true;
                break;
            }
        }
        if (enemyCheck == false)
        {
            canBuild = true;
        }
        else
        {
            enemyCheck = true;
        }
        if (canBuild == true)
        {
            previewDangerGrid.SetActive(false);
        }
        else
        {
            previewDangerGrid.transform.position = new Vector3(GameManager.instance.towerX, GameManager.instance.towerY, -4);
            previewDangerGrid.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D raycastHit2D = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("click script");
            if (GameManager.instance.clickCount == 0)
            {
                previewTower.SetActive(false);
            }
            if (raycastHit2D.collider == gameObject.GetComponent<CircleCollider2D>())
            {
                Build();
            }
            else
            {
                Debug.Log("ELSE");
                previewTower.SetActive(false);
            }
        }
        CheckBuildable();
    }
}
