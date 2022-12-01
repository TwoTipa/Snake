using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController player;
    public Camera camera;

    public Tail tail;

    [SerializeField]
    private CharacterController prefabTail;

    private float _startPos;

    public bool isMove = true;

    [SerializeField]
    float Speed = 0.2f;

    public float StartPos { get => _startPos; set => _startPos = value; }

    private void Start()
    {
        player = gameObject.GetComponent<CharacterController>();
        _startPos = gameObject.transform.position.z;
    }

    private void Update()
    {
        camera.transform.position = new Vector3(0, player.transform.position.y+4, player.transform.position.z-4);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMove)
        {
            player.Move(new Vector3(Input.GetAxisRaw("Horizontal")*Speed, 0, 0.1f));
        }
    }

    public void Eat(int count)
    {
        for (int i = 0; i < count; i++)
        {
            tail.AddTail();
        }
    }

    public void SetStartPos()
    {
        _startPos = gameObject.transform.position.z;
    }

    public void GoToStart()
    {
        gameObject.SetActive(false);
        gameObject.transform.position = new Vector3(0, 0.172f, _startPos);
        tail.AddTail();
        gameObject.SetActive(true);
    }

}
