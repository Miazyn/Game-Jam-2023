using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class BuildStructure : MonoBehaviour
{

    RaycastHit hit;
    Vector3 movePoint;
    //[SerializeField] SO_Structures structureSO;
    public GameObject prefab;
    bool delayedStart = false;

    [SerializeField] SpriteRenderer ghostRenderer;
    [SerializeField] Material validMat;
    [SerializeField] Material invalidMat;

    [SerializeField] float maxBuildDistance = 200f;

    BoxCollider2D _col;

    Grid grid;

    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
        _col = prefab.GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        GetMousePos();
        StartCoroutine(StartDelay());
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(0.2f);
        delayedStart = true;
    }

    private void Update()
    {
        GetMousePos();

        if (CanPlaceItem())
        {
            Debug.Log("Valid");
            //ghostRenderer.material = validMat;
        }
        else
        {
            Debug.Log("Invalid");
            //ghostRenderer.material = invalidMat;
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            PlacingItem();
        }

        if (Mouse.current.rightButton.wasReleasedThisFrame)
        {
            Destroy(gameObject);
        }
    }

    void GetMousePos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        mousePos = new Vector3(mousePos.x, mousePos.y, 0f);
        transform.position = mousePos;
    }


    bool CanPlaceItem()
    {
        var CheckValidPlacementBox = Physics2D.OverlapBox(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) + (Vector3)_col.offset, _col.size, 0f);

        if (CheckValidPlacementBox != null)
        {
            Debug.Log(CheckValidPlacementBox);
            if(CheckValidPlacementBox == _col)
            {
                return true;
            }
            return false;
        }

        return true;
    }

    bool PlacingItem()
    {
        if (!CanPlaceItem())
        {
            return false;
        }

        if (!delayedStart)
        {
            return false;
        }

        Instantiate(prefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);

        //Destroy(gameObject);

        return true;
    }

}
