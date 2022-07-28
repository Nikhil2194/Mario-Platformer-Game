using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public float resetSpeed = 0.5f;
    public float cameraSpeed = 0.3f;

    public Bounds cameraBounds;

    private float offsetZ;
    private Vector3 lastTargetPosition;
    private Vector3 currentVelocity;

    private bool followsPlayer;


    private void Awake()
    {
        BoxCollider2D myCol = GetComponent<BoxCollider2D>();
        myCol.size = new Vector2(Camera.main.aspect * 2f * Camera.main.orthographicSize, 15f);
       // cameraBounds = myCol.size;
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
