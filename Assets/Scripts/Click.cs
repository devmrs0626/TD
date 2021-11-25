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
        switch (groundClick.clickCount)
        {
            case 0:
                groundClick.clickTowerNumber = towerNumber;
                groundClick.clickCount++;
                previewGrid.SetActive(false);
                previewTower.transform.localPosition = new Vector3(groundClick.towerX, groundClick.towerY, -3);
                previewTower.SetActive(true);
                if(canBuild == false)
                {
                    previewDangerGrid.transform.localPosition = new Vector3(groundClick.towerX, groundClick.towerY, -4);
                    previewDangerGrid.SetActive(true);
                }

                break;
            case 1:
                if (groundClick.clickTowerNumber == towerNumber)
                {
                    previewTower.SetActive(false);
                    instantiatedTower = Instantiate(tower, new Vector3(groundClick.towerX, groundClick.towerY, -1), Quaternion.identity);
                    Debug.Log("LAND BUILD");
                    landBuild.Invoke();
                    groundClick.clickCount = 0;
                    groundClick.selectMenuOn = false;
                }
                else
                {
                    groundClick.clickTowerNumber = towerNumber;
                    previewTower.transform.localPosition = new Vector3(groundClick.towerX, groundClick.towerY, -3);
                    previewTower.SetActive(true);
                }
                break;
            default:
                groundClick.clickCount = 0;
                break;

        }
    }

    void BuildTower()
    {
        Debug.Log("CLICK: " + gameObject.name);
        switch (groundClick.clickCount)
        {
            case 0:
                groundClick.clickTowerNumber = towerNumber;
                groundClick.clickCount++;
                previewGrid.SetActive(false);
                previewTower.transform.localPosition = new Vector3(groundClick.towerX, groundClick.towerY, -3);
                previewTower.SetActive(true);
                break;
            case 1:
                if (groundClick.clickTowerNumber == towerNumber)
                {
                    Debug.Log("TOWER BUILD");
                    previewTower.SetActive(false);
                    instantiatedTower = Instantiate(tower, new Vector3(groundClick.towerX, groundClick.towerY, -2), Quaternion.identity);
                    groundClick.clickCount = 0;
                    groundClick.selectMenuOn = false;
                }
                else
                {
                    groundClick.clickTowerNumber = towerNumber;
                    previewTower.transform.localPosition = new Vector3(groundClick.towerX, groundClick.towerY, -3);
                    previewTower.SetActive(true);
                }
                break;
            default:
                groundClick.clickCount = 0;
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
            if(groundClick.clickCount == 0)
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
    }
}
