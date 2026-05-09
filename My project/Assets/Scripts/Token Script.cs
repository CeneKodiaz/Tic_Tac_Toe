using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TokenScript : MonoBehaviour
{
    public int turn = 0;
    public int index = 0;
    public SpriteRenderer spriteRenderer;
    public Sprite[] tokenSprites;
    private TurnScript turnScript;
    public bool isOccupied = false;
    public enum TokenType
    {
        None,
        X,
        O
    }
    public TokenType Tokentype;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        turnScript = GameObject.FindGameObjectWithTag("TurnManager").GetComponent<TurnScript>();
        spriteRenderer.sprite = null;
        isOccupied = false;
        Tokentype = TokenType.None;
        turn = Random.Range(0, 2);
    }
    void OnMouseDown()
    {
        if (isOccupied) return;
        turn = turnScript.ChangeTurn();
        int index = turn % 2;
        spriteRenderer.sprite = tokenSprites[index];
        switch (index)
        {
            case 0:
            Tokentype = TokenType.X;
                turnScript.win(gameObject);
                break;
            case 1:
            Tokentype = TokenType.O;
                turnScript.win(gameObject);
                break;
        }
        isOccupied = true;
    }
}
