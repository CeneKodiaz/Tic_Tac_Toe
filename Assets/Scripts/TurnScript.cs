using System;
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
    }
    public void win(GameObject slot)
    {
        Debug.Log("state=" + slot.GetComponent<TokenScript>().Tokentype);
    }

    public int ChangeTurn()
    {
        Turn++;
        return Turn;
    }

}
