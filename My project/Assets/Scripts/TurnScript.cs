using System;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TurnScript : MonoBehaviour
{
    public TokenScript tokenScript;
    [SerializeField] private GameObject[] GameSlots;
    public int Turn = 0;
    [SerializeField] private int gamelength = 9;
    public Dictionary<int, int> winConditions = new Dictionary<int, int>()
    {
        {1, 123},
        {2, 456},
        {3, 789},
        {4, 147},
        {5, 258},
        {6, 369},
        {7, 159},
        {8, 357}
    };
    void Awake()
    {
        GameSlots = GameObject.FindGameObjectsWithTag("TokenSlot");
        Array.Reverse(GameSlots);
    }
    public void win(GameObject slot)
    {
        Debug.Log("state=" + slot.GetComponent<TokenScript>().Tokentype);
            int slotposition = Array.IndexOf(GameSlots, slot);
            List<int> positions;
            switch (slotposition)
            {
                case 0:
                    positions = new List<int>() { 1, 4, 7 };
                    CheckWin(positions);
                    break;
                case 1:
                    positions = new List<int>() {1, 5};
                    CheckWin(positions);
                    break;
                case 2:
                    positions = new List<int>() {1, 6, 8};  
                    CheckWin(positions);
                    break;
                case 3:
                    positions = new List<int>() {2, 4};
                    CheckWin(positions);
                    break;
                case 4:
                    positions = new List<int>() {2, 5, 8, 7};
                    CheckWin(positions);
                    break;
                case 5:
                    positions = new List<int>() {2, 6};
                    CheckWin(positions);
                    break;
                case 6:
                    positions = new List<int>() {3, 4, 8};
                    CheckWin(positions);
                    break;
                case 7:
                    positions = new List<int>() {3, 5};
                    CheckWin(positions);
                    break;
                case 8:
                    positions = new List<int>() {3, 6, 7};
                    CheckWin(positions);
                    break;
        }
    }

    public int ChangeTurn()
    {
        Turn++;
        gamelength--;
        if (gamelength <= 0)
        {
            Debug.Log("Game Over: It's a draw!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart the game\
            return Turn;
        }
        return Turn;
    }

    public void CheckWin(List<int> positions)
    {
        Debug.Log("Checking win conditions for positions: " + string.Join(", ", positions));
        return;
    }
}
