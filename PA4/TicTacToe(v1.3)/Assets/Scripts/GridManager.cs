using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class GridManager : MonoBehaviour
{
    public GameObject line;
    public GameObject xButton;
    public GameObject oButton;
    public GameObject square;
    public GameObject border;
    public Particles particle;
    public SpriteRenderer rend;
    public CheckStarter start;

    public static int m = 5;
    public static int n = 5;
    public static int k = 3;
    public static bool single = true;
    public static bool cpuStart = false;
    public static bool cpuBasic = false;

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

        for (int j = 0; j < m; j++) {
            for (int i = 0; i < n; i++)
            {
                square = Instantiate(square, new Vector3(topLeft.x, topLeft.y, 0), Quaternion.identity);
                square.gameObject.transform.localScale = new Vector3(2.0F / n, 2.0F / m, 0);

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

    //This function is called for Player X's turn
    public void PlayerX(Vector3 pos, string name)
    {
        //Sets the position to be unclickable
        SetObjectFalse(name);

        string[] coords = name.Split(',');
        boardState[Int32.Parse(coords[1]), Int32.Parse(coords[0])] = 1;

        xButton = Instantiate(xButton, pos, Quaternion.identity);
        if (Math.Max(m, n) > 40) // workaround for visual bug - scales to small sizes
        {
            xButton.gameObject.transform.localScale = new Vector3(0.7F, 0.7F, 0);
            StartCoroutine(ScaleOverTime(0.5F, xButton));
        }
        else if (Math.Max(m, n) > 20)
        {
            xButton.gameObject.transform.localScale = new Vector3(1.0F, 1.0F, 0);
            StartCoroutine(ScaleOverTime(0.4F, xButton));
        }
        else if (Math.Max(m, n) > 10)
        {
            xButton.gameObject.transform.localScale = new Vector3(1.5F, 1.5F, 0);
            StartCoroutine(ScaleOverTime(0.3F, xButton));
        }
        else
        {
            xButton.gameObject.transform.localScale = new Vector3(2.0F, 2.0F, 0);
            StartCoroutine(ScaleOverTime(0.25F, xButton));
        }
        xButton.name = name + " (X)";

        try
        {
            SoundManager.PlaySound("light_ding");
        }
        catch (ArgumentNullException e)
        {
            Debug.Log(e);
        }

        rend = xButton.GetComponent<SpriteRenderer>();
        rend.sortingOrder = 3;
    }

    //This function is called for Player Y's turn
    public void PlayerO(Vector3 pos, string name)
    {
        //Sets the position to be unclickable
        SetObjectFalse(name);

        string[] coords = name.Split(',');
        boardState[Int32.Parse(coords[1]), Int32.Parse(coords[0])] = -1;

        oButton = Instantiate(oButton, pos, Quaternion.identity);
        if(Math.Max(m, n) > 40) // workaround for visual bug - scales to small sizes
        {
            oButton.gameObject.transform.localScale = new Vector3(0.7F, 0.7F, 0);
            StartCoroutine(ScaleOverTime(0.5F, oButton));
        }
        else if (Math.Max(m, n) > 20)
        {
            oButton.gameObject.transform.localScale = new Vector3(1.0F, 1.0F, 0);
            StartCoroutine(ScaleOverTime(0.4F, oButton));
        }
        else if (Math.Max(m, n) > 10)
        {
            oButton.gameObject.transform.localScale = new Vector3(1.5F, 1.5F, 0);
            StartCoroutine(ScaleOverTime(0.3F, oButton));
        }
        else
        {
            oButton.gameObject.transform.localScale = new Vector3(2.0F, 2.0F, 0);
            StartCoroutine(ScaleOverTime(0.25F, oButton));
        }

        oButton.name = name + " (O)";

        try
        {
            SoundManager.PlaySound("dark_ding");
        }
        catch (ArgumentNullException e)
        {
            Debug.Log(e);
        }

        rend = oButton.GetComponent<SpriteRenderer>();
        rend.sortingOrder = 3;
    }

    IEnumerator ScaleOverTime(float time, GameObject button)
    {
        Vector3 originalScale = button.transform.localScale;
        Vector3 destinationScale = new Vector3(2.0F / n, 2.0F / m, 0);

        float currentTime = 0.0f;
        do
        {
            button.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
    }

    //These are for the CheckBoardStates

    private bool checkDiag(int i, int j, ref int counter)
    {
        counter += 1;

        //Try and see if the diagonal corners actually add up
        try
        {
            if (boardState[i, j] != 0 && boardState[i, j] == boardState[i + 1, j + 1])
            {
                checkDiag(i + 1, j + 1, ref counter);
            }
        }
        //If it does not, then return false since this assumes it reaches the corner.
        catch
        {
            return false;
        }

        if (counter == k)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool checkCounterDiag(int i, int j, ref int counter)
    {
        counter += 1;

        //Try and see if the diagonal corners actually add up
        try
        {
            if (boardState[i, j] != 0 && boardState[i, j] == boardState[i + 1, j - 1])
            {
                checkCounterDiag(i + 1, j - 1, ref counter);
            }
        }

        //If it does not, then return false since this assumes it reaches the corner.
        catch
        {
            return false;
        }

        if (counter == k)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Function for checking the board states
    public bool CheckBoardState()
    {
        int counter = 0;

        //Checking Vertically
        for (int i = 0; i < m; i++)
        {
            counter = 0;

            for (int j = 0; j < n; j++)
            {
                //Optimization purposes
                int currentSpace = boardState[i, j];

                //Checks to see if the the space is empty or not a continuation, then resets the counter
                if (counter > 0 && currentSpace != 1)
                {
                    // Debug.Log("Line: " + i + " Space: " + j + " Counter had X's but encountered a non X");
                    counter = 0;
                }
                else if (counter < 0 && currentSpace != -1)
                {
                    // Debug.Log("Line: " + i + " Space: " + j + " Counter had Y's but encountered a non Y");
                    counter = 0;
                }

                //checks to see if the space is an X or an O
                if (currentSpace == 1)
                {
                    counter += 1;
                    // Debug.Log("Counter Added. It is now: " + counter);
                }
                else if (currentSpace == -1)
                {
                    counter -= 1;
                    // Debug.Log("Counter Subtracted. It is now: " + counter);
                }

                //Checks to see if the the space is empty or not a continuation, then resets the counter
                if (counter == k)
                {
                    // Debug.Log("Line: " + i + " Vertical Win for X!");
                    winner = 1;
                    return true;
                }
                else if (counter == -k)
                {
                    // Debug.Log("Line: " + i + " Vertical Win for O!");
                    winner = -1;
                    return true;
                }
            }
        }

        //Checking Horizontal
        for (int j = 0; j < n; j++)
        {
            counter = 0;

            for (int i = 0; i < m; i++)
            {
                //Optimization purposes
                int currentSpace = boardState[i, j];

                //Checks to see if the the space is empty or not a continuation, then resets the counter
                if (counter > 0 && currentSpace != 1)
                {
                    counter = 0;

                }
                else if (counter < 0 && currentSpace != -1)
                {
                    counter = 0;
                }

                //checks to see if the space is an X or an O
                if (currentSpace == 1)
                {
                    counter += 1;
                }
                else if (currentSpace == -1)
                {
                    counter -= 1;
                }

                //Checks to see if the the counter is at it's "Win Size"
                if (counter == k)
                {
                    // Debug.Log("Column: " + i + " Horizontal Win for X!");
                    winner = 1;
                    return true;
                }
                else if (counter == -k)
                {
                    // Debug.Log("Column: " + i + " Horizontal Win for O!");
                    winner = -1;
                    return true;
                }
            }
        }

        //check diagonal
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                counter = 0;
                if (checkDiag(i, j, ref counter))
                {
                    // Debug.Log("Starting at: " + i + "," + j + " Diagonal Win for " + boardState[i, j] + "!");
                    winner = boardState[i,j];
                    return true;
                }
            }
        }

        //check counter diag
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                counter = 0;
                if (checkCounterDiag(i, j, ref counter))
                {
                    // Debug.Log("Starting at: " + i + "," + j + " Counter Diagonal Win for " + boardState[i,j] + "!");
                    winner = boardState[i,j];
                    return true;
                }
            }
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
                SoundManager.PlaySound("winner");
                SceneManager.LoadScene("XWinScene");
                Debug.Log("X WINS");
            }
            else if (winner == -1)
            {
                SoundManager.PlaySound("winner");
                SceneManager.LoadScene("OWinScene");
                Debug.Log("O WINS");
            }
            else if (winner == -99)
            {
                SoundManager.PlaySound("winner");
                SceneManager.LoadScene("TieScene");
                Debug.Log("TIE");
            }
        }
    }

    void EasyBot(Vector3 pos)
    {
        if (single && !cpuStart && CheckStarter.turn % 2 == 0)
        {
            System.Random rnd = new System.Random();

            while (true)
            {
                int x = rnd.Next(0, n);
                int y = rnd.Next(0, m);
                name = y + "," + x;
                pos = GameObject.Find(name).transform.position;

                if (boardState[x, y] == 0)
                {
                    PlayerO(pos, name);
                    int index = PlayerTurn();

                    try
                    {
                        particle.PlayEffectsRed(pos);
                    }
                    catch
                    {
                        //continue
                    }

                    break;
                }
            }
        }
        else if (single && cpuStart)
        {
            if (CheckStarter.turn == 0)
                CheckStarter.turn++;
            if (CheckStarter.turn % 2 == 1)
            {
                System.Random rnd = new System.Random();

                while (true)
                {
                    int x = rnd.Next(0, n);
                    int y = rnd.Next(0, m);
                    name = y + "," + x;
                    pos = GameObject.Find(name).transform.position;

                    if (boardState[x, y] == 0)
                    {
                        PlayerX(pos, name);
                        int index = PlayerTurn();

                        try
                        {
                            particle.PlayEffectsBlue(pos);
                        }
                        catch
                        {
                            //continue
                        }

                        break;
                    }
                }
            }
        }
    }

    public bool AdvancedCheckRight(int i, int j)
    {
        try
        {
            if (boardState[i, j] == boardState[i, j+1] && boardState[i,j+2] == 0)
            {
                return true;
            }
        }
        catch
        {
            return false;
        }

        return false;
    }

    public bool AdvancedCheckDown(int i, int j)
    {
        try
        {
            if (boardState[i, j] == boardState[i+1, j] && boardState[i+2, j] == 0)
            {
                return true;
            }
        }
        catch
        {
            return false;
        }

        return false;
    }

    public bool AdvancedCheckDiag(int i, int j)
    {
        try
        {
            if (boardState[i, j] == boardState[i+1, j+1] && boardState[i + 2, j+2] == 0)
            {
                return true;
            }
        }
        catch
        {
            return false;
        }

        return false;
    }

    void AdvancedBot(Vector3 pos)
    {
        if (single && !cpuStart && CheckStarter.turn % 2 == 0)
        {
            System.Random rnd = new System.Random();

            while (true)
            {
                string name = null;
                int x = 0;
                int y = 0;

                for (int i = 0; i < m; i++)
                {
                    if (!String.IsNullOrEmpty(name))
                        break;

                    for (int j = 0; j < n; j++)
                    {
                        if (!String.IsNullOrEmpty(name))
                            break;

                        if (boardState[i, j] != 0){
                            if (AdvancedCheckRight(i, j))
                            {
                                x = i;
                                y = j + 2;
                                name = y + "," + x;
                                break;
                            }
                            else if (AdvancedCheckDown(i, j))
                            {
                                x = i + 2;
                                y = j;
                                name = y + "," + x;
                                break;
                            }
                            else if (AdvancedCheckDiag(i, j))
                            {
                                x = i + 2;
                                y = j + 2;
                                name = y + "," + x;
                                break;
                            }
                        }
                    }
                }
                
                if (String.IsNullOrEmpty(name))
                {
                    x = rnd.Next(0, n);
                    y = rnd.Next(0, m);
                    name = y + "," + x;
                }

                try
                {
                    pos = GameObject.Find(name).transform.position;
                }
                catch(NullReferenceException e) { }

                if (boardState[x, y] == 0)
                {
                    PlayerO(pos, name);
                    int index = PlayerTurn();

                    try
                    {
                        particle.PlayEffectsRed(pos);
                    }
                    catch
                    {

                    }

                    break;
                }
            }
        }
        else if (single && cpuStart)
        {
            if (CheckStarter.turn == 0)
                CheckStarter.turn++;
            if (CheckStarter.turn % 2 == 1)
            {
                System.Random rnd = new System.Random();

                while (true)
                {
                    string name = null;
                    int x = 0;
                    int y = 0;

                    for (int i = 0; i < m; i++)
                    {
                        if (!String.IsNullOrEmpty(name))
                            break;

                        for (int j = 0; j < n; j++)
                        {
                            if (!String.IsNullOrEmpty(name))
                                break;

                            if (boardState[i, j] != 0)
                            {
                                if (AdvancedCheckRight(i, j))
                                {
                                    x = i;
                                    y = j + 2;
                                    name = y + "," + x;
                                    break;
                                }
                                else if (AdvancedCheckDown(i, j))
                                {
                                    x = i + 2;
                                    y = j;
                                    name = y + "," + x;
                                    break;
                                }
                                else if (AdvancedCheckDiag(i, j))
                                {
                                    x = i + 2;
                                    y = j + 2;
                                    name = y + "," + x;
                                    break;
                                }
                            }
                        }
                    }

                    if (String.IsNullOrEmpty(name))
                    {
                        x = rnd.Next(0, n);
                        y = rnd.Next(0, m);
                        name = y + "," + x;
                    }


                    try
                    {
                        pos = GameObject.Find(name).transform.position;
                    }
                    catch (NullReferenceException e) { }

                    if (boardState[x, y] == 0)
                    {
                        PlayerX(pos, name);
                        int index = PlayerTurn();

                        try
                        {
                            particle.PlayEffectsBlue(pos);
                        }
                        catch
                        {

                        }

                        break;
                    }
                }
            }
        }
    }

    void ClickAction(Vector3 pos)
    {
        if (CastRay() != null && CastRay().name.Contains(",") && !CastRay().name.Contains(")"))
        {
            //To keep track of the turns
            //For the objects on the screen
            String name = CastRay().name;
            pos = GameObject.Find(name).transform.position;

            if (CheckStarter.turn % 2 == 1) // player X
            {
                try
                {
                    particle.PlayEffectsBlue(pos);
                }
                catch
                {

                }
                PlayerX(pos, name);
                CheckStarter.turn++;
            }
            else if (CheckStarter.turn % 2 == 0) // player O
            {
                try
                {
                    particle.PlayEffectsRed(pos);
                }
                catch
                {

                }
                PlayerO(pos, name);
                CheckStarter.turn++;
            }
        }
    }

    //Function for when the game is actually being played
    void Update()
    {
        Vector3 pos = new Vector3(0, 0, 0);

        if (cpuBasic == true)
        {
            EasyBot(pos);
        }
        else
        {
            AdvancedBot(pos);
        }
        
        
        if (Input.GetMouseButtonDown(0))
        {
            ClickAction(pos);
        }

        CheckWin(CheckBoardState());
    }
}