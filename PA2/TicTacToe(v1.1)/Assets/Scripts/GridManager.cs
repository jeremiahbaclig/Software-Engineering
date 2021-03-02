using UnityEngine;
using UnityEditor;
using System;

public class GridManager : MonoBehaviour
{
    public GameObject line;
    public GameObject xButton;
    public GameObject oButton;
    public GameObject square;
    private SpriteRenderer rend;

    private int m = 3;
    private int n = 3;
    private int k = 3;
    int[,] boardState;
    public bool gameOver = false;
    public int winner = 0;
    private int turn = 0;
    private const float FACTOR_SHAPE = 2.75F;
    private const float FACTOR_LINE = 1.5F;

    private void Start()
    {
        Grid();
        Players();
        SetBoardState(m, n);
    }

    void Update()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        if (Input.GetMouseButtonDown(0))
        {
            if(CastRay() != null && CastRay().name.Contains(","))
            {
                int index = PlayerTurn();
                if (index % 2 == 1) // player X
                {
                    string name = CastRay().name;

                    rend = CastRay().GetComponent<SpriteRenderer>();
                    pos = GameObject.Find(name).transform.position;
                    GameObject.Find(name).SetActive(false);

                    string[] coords = name.Split(',');
                    boardState[Int32.Parse(coords[0]), Int32.Parse(coords[1])] = 1;
                    Debug.Log("X: " + coords[0] + " " + coords[1]);

                    Instantiate(xButton, pos, Quaternion.identity);       
                }
                else if (index % 2 == 0) // player O
                {
                    string name = CastRay().name;

                    rend = CastRay().GetComponent<SpriteRenderer>();
                    pos = GameObject.Find(name).transform.position;
                    GameObject.Find(name).SetActive(false);

                    string[] coords = name.Split(',');
                    boardState[Int32.Parse(coords[0]), Int32.Parse(coords[1])] = -1;
                    Debug.Log("O: " + coords[0] + " " + coords[1]);

                    Instantiate(oButton, pos, Quaternion.identity);
                }
            }
        }

        gameOver = GetBoardState();
        if(gameOver == true)
        {
            GameObject[] objectsList = GameObject.FindGameObjectsWithTag("Player");
            for (int i=0; i< objectsList.Length; i++)
            {
                GameObject.Find(objectsList[i].name).SetActive(false);
            }

            if (winner == 1)
            {
                Debug.Log("X WINS");
            }
            else if(winner == -1)
            {
                Debug.Log("O WINS");
            }
            else if(winner == -99)
            {
                Debug.Log("TIE");
            }
        }
    }

    private void Grid()
    {
        float temp = m;
        for (int i = 1; i < m; i++)
        {
            temp -= 2;
            Instantiate(line, new Vector3(0, temp * FACTOR_LINE, 0), Quaternion.identity);

        }

        temp = n;
        for (int i = 1; i < n; i++)
        {
            temp -= 2;
            Instantiate(line, new Vector3(temp * FACTOR_LINE, 0, 0), Quaternion.Euler(0, 0, 90));
        }
    }

    private void Players()
    {
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                square = Instantiate(square, new Vector3((i-1) * FACTOR_SHAPE, (j-1) * FACTOR_SHAPE, 0), Quaternion.identity);
                if (j == 0)
                {
                    square.name = i.ToString() + "," + (j + (n - 1)).ToString();
                }
                else if (j == n - 1)
                {
                    square.name = i.ToString() + "," + (j - (n - 1)).ToString();
                }
                else
                {
                    square.name = i.ToString() + "," + j.ToString();
                }
                rend = square.GetComponent<SpriteRenderer>();
                rend.sortingOrder = -3;
            }
        }
    }

    private void SetBoardState(int rows, int cols)
    {
        boardState = new int[rows, cols];
    }

    public bool GetBoardState()
    {
        int counter = 0;
        for (int i = 0; i < m; i++) // check rows
        {
            for(int j = 0; j < n; j++)
            {
                if (boardState[i, j] == -1)
                {
                    counter++;
                }
                else if (boardState[i, j] == 1)
                {
                    counter--;
                }
            }
            if(counter == n)
            {
                winner = -1;
                return true;
            }
            else if(counter == -n)
            {
                winner = 1;
                return true;
            }
            else
                counter = 0;
        }

        for (int i = 0; i < m; i++) // check cols
        {
            for (int j = 0; j < n; j++)
            {
                if (boardState[j, i] == -1)
                {
                    counter++;
                }
                else if (boardState[i, j] == 1)
                {
                    counter--;
                }
            }
            if (counter == m) // need code for O win
            {
                winner = -1;
                return true;
            }
            else if (counter == -m) 
            {
                winner = 1;
                return true;
            }
            else
                counter = 0;
        }

        for (int i = 0; i < m; i++) // check diag
        {
            for (int j = 0; j < n; j++)
            {
                if (i == j)
                {
                    if (boardState[i, j] == -1)
                    {
                        counter++;
                    }
                    else if (boardState[i, j] == 1)
                    {
                        counter--;
                    }
                }
            }
            if (counter == m) 
            {
                winner = -1;
                return true;
            }
            else if (counter == -m)
            {
                winner = 1;
                return true;
            }
            else
                counter = 0;
        }

        for (int i = 0; i < m; i++) // check counter-diag
        {
            for (int j = n-1; j >= 0 ; j--)
            {
                if (boardState[i, j] == -1)
                {
                    counter++;
                }
                else if (boardState[i, j] == 1)
                {
                    counter--;
                }
            }
            if (counter == m)
            {
                winner = -1;
                return true;
            }
            else if (counter == -m)
            {
                winner = 1;
                return true;
            }
            else
                counter = 0;
        }

        for (int i = 0; i < m; i++) // check tie
        {
            for (int j = 0; j < n; j++)
            {
                if (boardState[i, j] != 0)
                {
                    counter++;
                }
            }
        }
        if(counter == (m * n))
        {
            winner = -99;
            return true;
        }

        return false;
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
            return hit.collider.gameObject;
        }
        return null;
    }
}