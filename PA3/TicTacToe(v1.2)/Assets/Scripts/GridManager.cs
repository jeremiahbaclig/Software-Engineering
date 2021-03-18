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
    public GameObject border;
    public SpriteRenderer rend;
    public CheckStarter start;

    public static int m = 5;
    public static int n = 5;
    public static int k = 3;
    public static bool single = true;
    public static bool cpuStart = false;

    int[,] boardState;
    public bool gameOver = false;
    public int winner = 0;

    //The functions for the initial game start up
    public void Start()
    {
        Grid();
        Players();
        SetBoardState(m, n);
    }

    private void Grid()
    {
        border = GameObject.FindGameObjectWithTag("Border");
        float x = border.transform.position.x;
        float y = border.transform.position.y;
        float length = border.GetComponent<Renderer>().bounds.size.x;
        float height = border.GetComponent<Renderer>().bounds.size.y;

        for(int i=1; i<m; i++)
        {
            GameObject lineHorizontal = Instantiate(line, new Vector3(x - length / 4, (y + height / 2) - i*(height/m), 0), Quaternion.identity);
            lineHorizontal.gameObject.transform.localScale = new Vector3(m*15, 0.25F, 0);
            lineHorizontal.name += " Horizontal";
            lineHorizontal.tag = "Horizontal";
        }
        for (int j = 1; j < n; j++)
        {
            GameObject lineVertical = Instantiate(line, new Vector3((x - length/2) + j *(height / n), (y + height / 2), 0), Quaternion.Euler(0, 0, 90));
            lineVertical.gameObject.transform.localScale = new Vector3(n*15, 0.25F, 0);
            lineVertical.name += " Vertical";
            lineVertical.tag = "Vertical";
        }
    }

    private void Players()
    {
        border = GameObject.FindGameObjectWithTag("Border");
        float x = border.transform.position.x;
        float y = border.transform.position.y;
        float length = border.GetComponent<Renderer>().bounds.size.x;
        float height = border.GetComponent<Renderer>().bounds.size.y;

        Vector3 topLeft = new Vector3(x - length/2, y + height/ 2, 0);

        for (int j = 0; j < n; j++) {
            for (int i = 0; i < m; i++)
            {
                square = Instantiate(square, new Vector3(topLeft.x, topLeft.y, 0), Quaternion.identity);
                square.gameObject.transform.localScale = new Vector3(2.0F / m, 2.0F / n, 0);

                float paddingY = square.GetComponent<Renderer>().bounds.size.y;
                float paddingX = square.GetComponent<Renderer>().bounds.size.x;

                square.transform.position = new Vector3((topLeft.x + paddingX / 2) + paddingX * i, (topLeft.y - paddingY / 2) - paddingY * j, 0);

                square.name = i.ToString() + "," + j.ToString();

                rend = square.GetComponent<SpriteRenderer>();
                rend.sortingOrder = -3;
            }
        }
        border.gameObject.transform.localScale = new Vector3(2.15F, 2.05F, 0);
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

    public GameObject[] FindObjectsTag(string tag)
    {
        return GameObject.FindGameObjectsWithTag(tag);
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

        xButton = Instantiate(xButton, pos, Quaternion.identity);
        xButton.gameObject.transform.localScale = new Vector3(2.0F / m, 2.0F / n, 0);

        rend = xButton.GetComponent<SpriteRenderer>();
        rend.sortingOrder = 3;
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

        oButton = Instantiate(oButton, pos, Quaternion.identity);
        oButton.gameObject.transform.localScale = new Vector3(2.0F / m, 2.0F / n, 0);

        rend = oButton.GetComponent<SpriteRenderer>();
        rend.sortingOrder = 3;
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

        if (single && !cpuStart && CheckStarter.turn % 2 == 0)
        {
            System.Random rnd = new System.Random();

            while (true)
            {
                int x = rnd.Next(0, m);
                int y = rnd.Next(0, n);
                name = x + "," + y;
                pos = GameObject.Find(name).transform.position;

                if (pos != null && GameObject.Find(name).activeSelf == true)
                {
                    PlayerO(pos, name);
                    int index = PlayerTurn();
                    Debug.Log("PLAYED: " + name + " now turn % 2 = " + index);
                    break;
                }
                else
                {
                    continue;
                }
            }
        } else if (single && cpuStart)
        {
            if (CheckStarter.turn == 0)
                CheckStarter.turn++;
            if (CheckStarter.turn % 2 == 1) { 
                System.Random rnd = new System.Random();

                while (true)
                {
                    int x = rnd.Next(0, m);
                    int y = rnd.Next(0, n);
                    name = x + "," + y;
                    pos = GameObject.Find(name).transform.position;

                    if (pos != null && GameObject.Find(name).activeSelf == true)
                    {
                        Debug.Log("PLAYED: " + GameObject.Find(name));
                        PlayerX(pos, name);
                        int index = PlayerTurn();
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            if(CastRay() != null && CastRay().name.Contains(",") && GameObject.Find(CastRay().name).activeSelf)
            {
                //To keep track of the turns
                //For the objects on the screen
                String name = CastRay().name;
                pos = GameObject.Find(name).transform.position;

                if (CheckStarter.turn % 2 == 1) // player X
                {
                    PlayerX(pos, name);
                    CheckStarter.turn++;
                }
                else if (CheckStarter.turn % 2 == 0) // player O
                {
                    PlayerO(pos, name);
                    CheckStarter.turn++;
                }
            }
        }

        if(m == n && m == k) // can remove this once uneven wins are implemented
            CheckWin(CheckBoardState());
    }
}