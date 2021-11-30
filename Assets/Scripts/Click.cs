using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Click : MonoBehaviour
{
    public GameObject previewGrid;
    public GameObject previewDangerGrid;
    public GameObject previewTower;
    public GameObject tower;
    public int towerNumber;
    Vector2 mousePosition;
    Camera Camera;
    GameObject instantiatedTower;
    bool canBuild = true;

    public UnityEvent landBuild;

    void BuildLand()
    {
        Debug.Log("CLICK: " + gameObject.name);
        switch (GameManager.instance.clickCount)
        {
            case 0:
                GameManager.instance.clickTowerNumber = towerNumber;
                GameManager.instance.clickCount++;
                previewGrid.SetActive(false);
                previewTower.transform.localPosition = new Vector3(GameManager.instance.towerX, GameManager.instance.towerY, -3);
                previewTower.SetActive(true);
                break;
            case 1:
                if (GameManager.instance.clickTowerNumber == towerNumber)
                {
                    previewTower.SetActive(false);
                    instantiatedTower = Instantiate(tower, new Vector3(GameManager.instance.towerX, GameManager.instance.towerY, -1), Quaternion.identity);
                    Debug.Log("LAND BUILD");
                    landBuild.Invoke();
                    GameManager.instance.clickCount = 0;
                    GameManager.instance.selectMenuOn = false;
                }
                else
                {
                    GameManager.instance.clickTowerNumber = towerNumber;
                    previewTower.transform.localPosition = new Vector3(GameManager.instance.towerX, GameManager.instance.towerY, -3);
                    previewTower.SetActive(true);
                }
                break;
            default:
                GameManager.instance.clickCount = 0;
                break;

        }
    }

    void BuildTower()
    {
        Debug.Log("CLICK: " + gameObject.name);
        switch (GameManager.instance.clickCount)
        {
            case 0:
                GameManager.instance.clickTowerNumber = towerNumber;
                GameManager.instance.clickCount++;
                previewGrid.SetActive(false);
                previewTower.transform.localPosition = new Vector3(GameManager.instance.towerX, GameManager.instance.towerY, -3);
                previewTower.SetActive(true);
                break;
            case 1:
                if (GameManager.instance.clickTowerNumber == towerNumber)
                {
                    Debug.Log("TOWER BUILD");
                    previewTower.SetActive(false);
                    instantiatedTower = Instantiate(tower, new Vector3(GameManager.instance.towerX, GameManager.instance.towerY, -2), Quaternion.identity);
                    GameManager.instance.clickCount = 0;
                    GameManager.instance.selectMenuOn = false;
                }
                else
                {
                    GameManager.instance.clickTowerNumber = towerNumber;
                    previewTower.transform.localPosition = new Vector3(GameManager.instance.towerX, GameManager.instance.towerY, -3);
                    previewTower.SetActive(true);
                }
                break;
            default:
                GameManager.instance.clickCount = 0;
                break;

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
            if(GameManager.instance.clickCount == 0)
            {
                previewTower.SetActive(false);
            }
            if (raycastHit2D.collider == gameObject.GetComponent<CircleCollider2D>())
            {
                if(gameObject.layer == LayerMask.NameToLayer("LandBuildButton"))
                {
                    BuildLand();
                }
                else if(gameObject.layer == LayerMask.NameToLayer("TowerBuildButton"))
                {
                    BuildTower();
                }
            }
            else
            {
                Debug.Log("ELSE");
                previewTower.SetActive(false);
            }
        }
        if(towerNumber == 0)
        {
            foreach (Collider2D col in Physics2D.OverlapBoxAll(new Vector2(GameManager.instance.towerX, GameManager.instance.towerY), new Vector2(1, 1), 0))
            {
                Debug.Log("충돌체 있음");
                if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    Debug.LogError("CAN NOT BUILD");
                    canBuild = false;
                    break;
                }
            }
                
        }
        if(canBuild == false)
        {
            previewDangerGrid.transform.position = new Vector3(GameManager.instance.towerX, GameManager.instance.towerY, -4);
            previewDangerGrid.SetActive(true);
            canBuild = true;
        }
    }
}
