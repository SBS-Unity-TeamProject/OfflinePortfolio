using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRange : MonoBehaviour
{
    [SerializeField] GameObject playerRange;
    public PlayerStates playerStates;
    CircleCollider2D Collider;
    void Update()
    {
        playerRange.transform.localScale = new Vector2(playerStates.Range,playerStates.Range);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}
