using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartTail : MonoBehaviour
{

    public Tail tail;

    private GameObject _nextPart;
    private GameObject _prevPart;

    private CharacterController _mePart;

    public Player _player;

    public GameObject NextPart { get => _nextPart; set => _nextPart = value; }
    public GameObject PrevPart { get => _prevPart; set => _prevPart = value; }
    public CharacterController MePart { get => _mePart;}

    private void Start()
    {
        _mePart = gameObject.GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        if (_player.isMove)
        {
            var prev = tail.FullTail.Find(_mePart).Previous.Value;
            _mePart.Move(new Vector3((prev.transform.position.x - _mePart.transform.position.x)*0.3f, 0, (prev.transform.position.z - _mePart.transform.position.z)*0.3f));
        }
        //_mePart.Move(new Vector3(0, 0, (_prevPart.transform.position.z - _mePart.transform.position.z)*0.1f));
    }
}
