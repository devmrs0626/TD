using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Vector2 mousePosition;
    Camera Camera;
    public GameObject previewGrid;
    public GameObject previewGroup;
    public GameObject landSelectMenu;
    public GameObject towerSelectMenu;
    public bool selectMenuOn;
    public int towerX;
    public int towerY;
    public int clickCount;
    public int clickTowerNumber;
    public bool waveProgressing;
    public static GameManager instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Camera = GameObject.Find("Camera").GetComponent<Camera>();
        previewGrid.SetActive(false);
        landSelectMenu.SetActive(false);
        towerSelectMenu.SetActive(false);
        selectMenuOn = false;
        clickCount = 0;
        clickTowerNumber = 0;
        waveProgressing = false;

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
        }
    }
}
