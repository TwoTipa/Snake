using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private GameObject _nextLevelWin;
    [SerializeField] private GameObject _restartLevelWin;
    [SerializeField] private GameObject _menuWin;
    public int Lvl = 1;

    [SerializeField] private int _roomCount = 6;
    [SerializeField] private Transform _player;
    [SerializeField] private Player _playerMove;
    [SerializeField] private Tail _tail;

    [SerializeField] private GameObject _foodPref;
    [SerializeField] private GameObject _wallPref;
    [SerializeField] private GameObject _barricadePref;
    [SerializeField] private GameObject _finishPref;
    [SerializeField] private GameObject _roadPref;

    private void Update()
    {
        _levelText.text = "׃נמגוםü: " + Lvl;
    }



    // Windows
    [SerializeField]
    public Image menuWin;
    [SerializeField]
    public Image LoseWin;
    [SerializeField]
    public Image WinWin;//ֲûםüֲûםüֲûםü

    public void TogleWin(Image win)
    {
        win.gameObject.SetActive(!win.gameObject.activeSelf);
        _playerMove.isMove = false;
    }

    public void Exit()
    {
        Application.CancelQuit();
    }

    public void Restart()
    {
        Debug.Log("Restart");
        _playerMove.isMove = true;
        _playerMove.GoToStart();


    }

    public void Win()
    {
        Debug.Log("Win");
        if (Lvl == 3)
        {
            Lvl = 1;
            _playerMove.StartPos = 0f;
            _playerMove.tail.FullTail.Clear();
            _playerMove.tail.FullTail.AddLast(_playerMove.GetComponent<CharacterController>());
            _playerMove.GoToStart();
        }
        else
        {
            Lvl += 1;
        }
        _playerMove.isMove = true;
    }
}
