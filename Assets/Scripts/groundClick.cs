using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundClick : MonoBehaviour
{
    Vector2 mousePosition;
    Camera Camera;
    public GameObject previewGrid;
    public GameObject previewGroup;
    public GameObject landSelectMenu;
    public GameObject towerSelectMenu;
    public static bool selectMenuOn;
    public static int towerX;
    public static int towerY;
    public static int clickCount;
    public static int clickTowerNumber;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("Camera").GetComponent<Camera>();
        previewGrid.SetActive(false);
        landSelectMenu.SetActive(false);
        towerSelectMenu.SetActive(false);
        selectMenuOn = false;
        clickCount = 0;
        clickTowerNumber = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(selectMenuOn == false)
        {
            previewGrid.SetActive(false);
            landSelectMenu.SetActive(false);
            towerSelectMenu.SetActive(false);
        }
        mousePosition = Camera.ScreenToWorldPoint(Input.mousePosition);
        float x = mousePosition.x;
        float y = mousePosition.y;
        //GameObject[] SelectButtonList = GameObject.FindGameObjectsWithTag("SelectButton");
        RaycastHit2D raycastHit2D = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (Input.GetMouseButtonDown(0))
        {
            if (raycastHit2D.collider)
            {
                Debug.Log(raycastHit2D.collider.gameObject.layer);
                if (raycastHit2D.collider.gameObject.layer == LayerMask.NameToLayer("Grid"))
                {
                    towerX = Mathf.RoundToInt(x);
                    towerY = Mathf.RoundToInt(y);
                    landSelectMenu.transform.localPosition = new Vector2(towerX, towerY);
                    previewGrid.transform.localPosition = new Vector3(towerX, towerY, -4);
                    landSelectMenu.SetActive(true);
                    towerSelectMenu.SetActive(false);
                    previewGrid.SetActive(true);
                    selectMenuOn = true;
                    clickCount = 0;
                }
                else if (raycastHit2D.collider.gameObject.layer == LayerMask.NameToLayer("Land"))
                {
                    towerX = Mathf.RoundToInt(x);
                    towerY = Mathf.RoundToInt(y);
                    towerSelectMenu.transform.localPosition = new Vector2(towerX, towerY);
                    previewGrid.transform.localPosition = new Vector3(towerX, towerY, -4);
                    landSelectMenu.SetActive(false);
                    towerSelectMenu.SetActive(true);
                    previewGrid.SetActive(true);
                    selectMenuOn = true;
                    clickCount = 0;
                }
                else if (raycastHit2D.collider.gameObject.layer == LayerMask.NameToLayer("SelectButton"))
                {

                }
                else if (raycastHit2D.collider.gameObject.layer == LayerMask.NameToLayer("Background"))
                {
                    clickCount = 0;
                    selectMenuOn = false;
                    previewGrid.SetActive(false);
                    landSelectMenu.SetActive(false);
                    towerSelectMenu.SetActive(false);
                    for (int i = 0; i < previewGroup.transform.childCount; i++)
                    {
                        previewGroup.transform.GetChild(i).gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                Debug.Log("null");
            }
            
            /*
            Debug.Log("towerX=>     " + towerX);
            Debug.Log("towerY=>     " + towerY);
            Debug.Log("x=>     " + x);
            Debug.Log("y=>     " + y);
            if(selectMenuOn == true && towerX - 0.5f <= x && x <= towerX + 0.5f && towerY - 0.5f <= y && y <= towerY + 0.5f)
            {
                Debug.Log("removed");
                landSelectMenu.SetActive(false);
                selectMenuOn = false;
                previewGrid.SetActive(false);
            }
            else
            {
                if(raycastHit2D.collider == gameObject.GetComponent<BoxCollider2D>())
                {
                    Debug.Log("box collider click");
                }
                bool buttonClick = false;
                for (int i = 0; i < SelectButtonList.Length; i++)
                {
                    if (raycastHit2D.collider == SelectButtonList[i].GetComponent<CircleCollider2D>())
                    {
                        Debug.Log("button click");
                        buttonClick = true;
                        break;
                    }
                }
                if (buttonClick == false)
                {
                    towerX = Mathf.Round(x);
                    towerY = Mathf.Round(y);
                    landSelectMenu.transform.localPosition = new Vector2(towerX, towerY);
                    previewGrid.transform.localPosition = new Vector2(towerX, towerY);
                    landSelectMenu.SetActive(true);
                    selectMenuOn = true;
                    previewGrid.SetActive(true);
                }
            }*/

            /*
            if(selectMenuOn == false)
            {
                float x = Mathf.Round(mousePosition.x);
                float y = Mathf.Round(mousePosition.y);
                landSelectMenu.transform.localPosition = new Vector2(x, y);
                previewGrid.transform.localPosition = new Vector2(x, y);
                landSelectMenu.SetActive(true);
                selectMenuOn = true;
                previewGrid.SetActive(true);
            }
            else if(buttonClick == false)
            {
                landSelectMenu.SetActive(false);
                selectMenuOn = false;
                previewGrid.SetActive(false);
            }*/
        }
    }
}
