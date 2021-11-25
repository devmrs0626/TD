using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Click : MonoBehaviour
{
    public GameObject previewGrid;
    public GameObject previewTower;
    public GameObject tower;
    public int towerNumber;
    Vector2 mousePosition;
    Camera Camera;
    GameObject instantiatedTower;

    public UnityEvent landBuild;

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
            if(groundClick.clickCount == 1 && raycastHit2D.collider != gameObject.GetComponent<CircleCollider2D>())
            {

            }
            if (raycastHit2D.collider == gameObject.GetComponent<CircleCollider2D>())
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
                        if(groundClick.clickTowerNumber == towerNumber)
                        {
                            Debug.Log("clickCount2");
                            previewTower.SetActive(false);
                            instantiatedTower = Instantiate(tower, new Vector3(groundClick.towerX, groundClick.towerY, -2), Quaternion.identity);
                            if (instantiatedTower.layer == LayerMask.NameToLayer("Land"))
                            {
                                Debug.Log("LAND BUILD");
                                instantiatedTower.transform.localPosition = new Vector3(groundClick.towerX, groundClick.towerY, -1);
                                landBuild.Invoke();
                            }
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
                /*if (groundClick.clickCount == 1)
                {
                    Debug.Log("clickCount1");
                    previewGrid.SetActive(false);
                    previewTower.transform.localPosition = new Vector3(groundClick.towerX, groundClick.towerY, -3);
                    previewTower.SetActive(true);
                    /*
                    instantiatedTower = Instantiate(tower, new Vector3(groundClick.towerX, groundClick.towerY, 0), Quaternion.identity);
                    Color color = instantiatedTower.GetComponent<SpriteRenderer>().color;
                    color.a = 0.5f;
                    instantiatedTower.GetComponent<SpriteRenderer>().color = color;
                }
                else if(groundClick.clickCount == 2)
                {
                    Debug.Log("clickCount2");
                    previewTower.SetActive(false);
                    instantiatedTower = Instantiate(tower, new Vector3(groundClick.towerX, groundClick.towerY, -2), Quaternion.identity);
                    if(instantiatedTower.tag == "Land")
                    {
                        instantiatedTower.transform.localPosition = new Vector3(groundClick.towerX, groundClick.towerY, -1);
                    }
                    groundClick.clickCount = 0;
                    groundClick.selectMenuOn = false;
                }*/
            }
            else
            {
                Debug.Log("ELSE");
                previewTower.SetActive(false);
            }
        }
    }
}
