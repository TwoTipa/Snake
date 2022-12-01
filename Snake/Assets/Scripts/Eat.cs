using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Eat : MonoBehaviour
{
    int _power;
    [SerializeField]
    TextMeshPro text;

    public int Power { get => _power; set => _power = value; }

    private void Start()
    {
        _power = Random.Range(1,10);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().Eat(_power);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        text.text = _power+"";
    }

}
