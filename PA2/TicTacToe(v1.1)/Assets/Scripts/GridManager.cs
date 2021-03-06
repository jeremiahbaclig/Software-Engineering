using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.SceneManagement;

public class GridManager : MonoBehaviour
{
    public GameObject line;
    public GameObject xButton;
    public GameObject oButton;
    public GameObject square;
    public SpriteRenderer rend;
    public CheckStarter start;

    private int m = 3;
    private int n = 3;
    private int k = 3;
    int[,] boardState;
    public bool gameOver = false;
    public int winner = 0;
    private const float FACTOR_SHAPE = 2.75F;
    private const float FACTOR_LINE = 1.5F;


    //The functions for the initial game start up
    public void Start()
    {
        Grid();
        Players();
        SetBoardState(m, n);
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
                square = Instantiate(square, new Vector3((i - 1) * FACTOR_SHAPE, (j - 1) * FACTOR_SHAPE, 0), Quaternion.identity);
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


    void SetObjectFalse(string name)
    {
        GameObject.Find(name).SetActive(false);
    }

    public GameObject FindObject(string name)
    {
        return GameObject.Find(name);
    }

    public int[,] GetBoardState()
    {
        return boardState;
    }

    //Functions for the players turns
    //This function is called for Player X's turn
    public void PlayerX(Vector3 pos, string name)
    {
        //Sets the position to be unclickable

        SetObjectFalse(name);

        string[] coords = name.Split(',');
        boardState[Int32.Parse(coords[0]), Int32.Parse(coords[1])] = 1;

        /*Debug.Log("X: " + coords[0] + " " + coords[1]);
        Debug.Log("Clicked position: " + pos);*/

        Instantiate(xButton, pos, Quaternion.identity);
    }

    //This function is called for Player Y's turn
    public void PlayerO(Vector3 pos, string name)
    {
        //Sets the position to be unclickable
        SetObjectFalse(name);

        string[] coords = name.Split(',');
        boardState[Int32.Parse(coords[0]), Int32.Parse(coords[1])] = -1;

        /*Debug.Log("O: " + coords[0] + " " + coords[1]);
        Debug.Log("Clicked position: " + pos);*/

        Instantiate(oButton, pos, Quaternion.identity);
    }


    //Function for checking the board states
    public bool CheckBoardState()
    {
        int counter = 0;
        for (int i = 0; i < m; i++) // check rows
        {
            for (int j = 0; j < n; j++)
            {
                counter += boardState[i, j];
                if (counter == n)
                {
                    winner = 1;
                    return true;
                }
                else if (counter == -n)
                {
                    winner = -1;
                    return true;
                }
            }
            counter = 0;
        }

        for (int i = 0; i < m; i++) // check rows
        {
            for (int j = 0; j < n; j++)
            {
                counter += boardState[j, i];
                if (counter == m)
                {
                    winner = 1;
                    return true;
                }
                else if (counter == -m)
                {
                    winner = -1;
                    return true;
                }
            }
            counter = 0;
        }

        for (int i = 0; i < m; i++) // check diag
        {
            counter += boardState[i, i];
            if (counter == (m + n) / 2)
            {
                winner = 1;
                return true;
            }
            else if (counter == -((m + n) / 2))
            {
                winner = -1;
                return true;
            } 
        }
        counter = 0;

        int counterDiag = 0;
        for (int i = m-1; i >= 0; i--) // check counter-diag
        {
            for (int j = 0; j < n; j++)
            {
                if (counterDiag == j)
                {
                    counter += boardState[i, counterDiag];
                    counterDiag += 100;
                }
                if (counter == (m + n) / 2)
                {
                    winner = 1;
                    return true;
                }
                else if (counter == -((m + n) / 2))
                {
                    winner = -1;
                    return true;
                }
            }
            counterDiag -= 99;
        }
        counter = 0;

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
        if (counter == (m * n))
        {
            winner = -99;
            return true;
        }

        return false;
    }


    //Function for keeping track of the turns
    public int PlayerTurn()
    {
        CheckStarter.turn++;
        return CheckStarter.turn % 2;
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

    public void CheckWin(bool winStatus)
    {
        if (winStatus == true)
        {
            GameObject[] objectsList = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < objectsList.Length; i++)
            {
                GameObject.Find(objectsList[i].name).SetActive(false);
            }

            if (winner == 1)
            {
                SceneManager.LoadScene("XWinScene");
                Debug.Log("X WINS");
            }
            else if (winner == -1)
            {
                SceneManager.LoadScene("OWinScene");
                Debug.Log("O WINS");
            }
            else if (winner == -99)
            {
                SceneManager.LoadScene("TieScene");
                Debug.Log("TIE");
            }
            

       //     SceneManager.LoadScene("Menu");
        }
    }

    //Function for when the game is actually being played
    void Update()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        
        if (Input.GetMouseButtonDown(0))
        {
            if(CastRay() != null && CastRay().name.Contains(","))
            {
                //To keep track of the turns
                int index = PlayerTurn();

                //For the objects on the screen
                String name = CastRay().name;
                pos = GameObject.Find(name).transform.position;

                Debug.Log("name: " + name);
                Debug.Log("pos: " + pos);

                if (index % 2 == 1) // player X
                {
                    PlayerX(pos, name);    
                }
                else if (index % 2 == 0) // player O
                {
                    PlayerO(pos, name);
                }
            }
        }

        CheckWin(CheckBoardState());
    }
}