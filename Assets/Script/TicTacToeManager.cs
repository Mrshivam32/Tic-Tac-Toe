using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TicTacToeManager : MonoBehaviour
{
    public Button[] buttons;
    public Text resultText;

    string currentPlayer = "X";
    string[] board = new string[9];
    bool gameOver = false;

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        currentPlayer = "X";
        gameOver = false;
        resultText.text = "Player X Turn";

        for (int i = 0; i < buttons.Length; i++)
        {
            board[i] = "";
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
            buttons[i].interactable = true;

            int index = i;
            buttons[i].onClick.RemoveAllListeners();
            buttons[i].onClick.AddListener(() => OnButtonClick(index));
        }
    }

    void OnButtonClick(int index)
    {
        if (gameOver) return;

        board[index] = currentPlayer;
        buttons[index].GetComponentInChildren<TextMeshProUGUI>().text = currentPlayer;
        buttons[index].interactable = false;

        if (CheckWin())
        {
            resultText.text = "Player " + currentPlayer + " Wins!";
            gameOver = true;
            return;
        }

        if (CheckDraw())
        {
            resultText.text = "Game Draw!";
            gameOver = true;
            return;
        }

        ChangePlayer();
    }

    void ChangePlayer()
    {
        currentPlayer = currentPlayer == "X" ? "O" : "X";
        resultText.text = "Player " + currentPlayer + " Turn";
    }

    bool CheckWin()
    {
        int[,] winPatterns = new int[,]
        {
            {0,1,2},
            {3,4,5},
            {6,7,8},
            {0,3,6},
            {1,4,7},
            {2,5,8},
            {0,4,8},
            {2,4,6}
        };

        for (int i = 0; i < 8; i++)
        {
            if (board[winPatterns[i, 0]] == currentPlayer &&
                board[winPatterns[i, 1]] == currentPlayer &&
                board[winPatterns[i, 2]] == currentPlayer)
            {
                return true;
            }
        }

        return false;
    }

    bool CheckDraw()
    {
        for (int i = 0; i < board.Length; i++)
        {
            if (board[i] == "")
                return false;
        }

        return true;
    }

    public void RestartGame()
    {
        StartGame();
    }
}