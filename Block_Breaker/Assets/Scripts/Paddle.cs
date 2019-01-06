using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float screenWidthInUnits = 16f;
    [SerializeField] private float minX = 1f;
    [SerializeField] private float maxX = 15f;

    GameSession currentGameSession;
    Ball activeBall;

    // Use this for initialization
    void Start()
    {
        currentGameSession = FindObjectOfType<GameSession>();
        activeBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePosition;
    }


    private float GetXPos()
    {
        float mousePositionInUnits;
        if (currentGameSession.IsAutoPlayEnabled())
        {
            mousePositionInUnits = activeBall.transform.position.x;
        }
        else
        {
            mousePositionInUnits = (Input.mousePosition.x / Screen.width) * screenWidthInUnits;
        }

        return mousePositionInUnits;
    }
}
