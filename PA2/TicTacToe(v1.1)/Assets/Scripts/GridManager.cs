using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GridManager : MonoBehaviour
{
    public GameObject line;
    public GameObject xButton;
    public GameObject oButton;
    private SpriteRenderer rend;

    bool unplayed = true;
    private int m = 3;
    private int n = 3;
    private int k = 3;
    private int turn = 0;

    private void Start()
    {
        Grid();
        Players();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(CastRay() != null)
            {
                int index = PlayerTurn();
                if (index % 2 == 1) // player X
                {
                    if(CastRay().name == "x(Clone)")
                    {
                        rend = CastRay().GetComponent<SpriteRenderer>();
                        rend.sortingOrder = 2;
                    }
                }
                else // player O
                {
                    if (CastRay().name == "o(Clone)")
                    {
                        rend = CastRay().GetComponent<SpriteRenderer>();
                        rend.sortingOrder = 2;
                    }
                }
            }
        }
    }

    private void Grid()
    {
        int temp = m;
        for (int i = 1; i < m; i++)
        {
            temp -= 2;
            Instantiate(line, new Vector3(0, temp, 0), Quaternion.identity);
        }

        temp = n;
        for (int i = 1; i < n; i++)
        {
            temp -= 2;
            Instantiate(line, new Vector3(temp, 0, 0), Quaternion.Euler(0, 0, 90));
        }
    }

    private void Players()
    {
        for (int i = -1; i < m - 1; i++)
        {
            for (int j = -1; j < n - 1; j++)
            {
                Instantiate(xButton, new Vector3(i, j, 0), Quaternion.identity);
                rend = xButton.GetComponent<SpriteRenderer>();
                rend.sortingOrder = 0;
            }
        }

        for (int i = -1; i < m - 1; i++)
        {
            for (int j = -1; j < n - 1; j++)
            {
                Instantiate(oButton, new Vector3(i, j, 0), Quaternion.identity);
                rend = oButton.GetComponent<SpriteRenderer>();
                rend.sortingOrder = 0;
            }
        }
    }

    public int PlayerTurn()
    {
        turn++;
        return turn % 2;
    }

    GameObject CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.DrawLine(ray.origin, hit.point);
            Debug.Log("Hit object: " + hit.collider.gameObject.name);
            return hit.collider.gameObject;
        }
        return null;
    }
}