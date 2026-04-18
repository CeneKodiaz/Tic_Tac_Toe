using System;
using Unity.VisualScripting;
using UnityEngine;

public class TurnScript : MonoBehaviour
{
    public TokenScript tokenScript;
    [SerializeField] private GameObject[] GameSlots;
    public int Turn = 0;
    void Awake()
    {
        GameSlots = GameObject.FindGameObjectsWithTag("TokenSlot");
        Array.Reverse(GameSlots);
        Turn = UnityEngine.Random.Range(0, 2);
    }
    public void win(GameObject slot)
    {
        Debug.Log("state=" + slot.GetComponent<TokenScript>().Tokentype);
    }

    public bool tie()
    {
        foreach (GameObject slot in GameSlots)
        {
            if (!slot.GetComponent<TokenScript>().isOccupied)
            {
                return false;
            }
        }
        return true;
    }

    public int ChangeTurn()
    {
        Turn++;
        return Turn;
    }

}
