using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cube : MonoBehaviour
{
    private TextMeshPro _number;
    private int _hp;
    private int _maxHP;

    [SerializeField]
    private MeshRenderer renderCube;
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private Material material;
    private Material materialChange;

    public int Hp { get => _hp; set => _hp = value; }

    private void Start()
    {
        _number = gameObject.GetComponentInChildren<TextMeshPro>();
        _maxHP = Random.Range(1, 30);
        _hp = _maxHP;
        materialChange = new Material(material);
        renderCube.material = materialChange;
    }

    

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player pl = other.GetComponent<Player>();
            CharacterController tail = pl.tail.FullTail.First.Next.Value;
            pl.tail.FullTail.Remove(tail);
            Destroy(tail.gameObject);
            _hp -= 1;
            if (_hp <= 0)
            {
                gameObject.SetActive(false);
            }
            if (pl.tail.FullTail.Count <= 1)
            {
                gameManager.TogleWin(gameManager.LoseWin);
            }
        }
    }

    private void Update()
    {
        _number.text = _hp+"";
        materialChange.color = new Color(0.56f, 1-_hp*0.04f, 0.191f);
    }

    public void ResetCube()
    {
        _hp = _maxHP;
        gameObject.SetActive(true);
    }
}
