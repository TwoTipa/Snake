using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tail : MonoBehaviour
{
    public LinkedList<CharacterController> FullTail = new();
    [SerializeField]
    PartTail prefabTail;
    [SerializeField]
    TextMeshPro text;

    [SerializeField]
    Transform player;

    private void Start()
    {

        FullTail.AddLast(player.GetComponent<CharacterController>());
        AddTail();
        AddTail();
        AddTail();
        AddTail();
        AddTail();
        AddTail();
        AddTail();
        AddTail();
        AddTail();
    }

    public void AddTail()
    {
        var newTail = Instantiate(prefabTail, FullTail.Last != null ? new Vector3(FullTail.Last.Value.transform.position.x, FullTail.Last.Value.transform.position.y, FullTail.Last.Value.transform.position.z-0.4f)  : new Vector3(player.position.x, player.position.y, player.position.z- 0.4f), new Quaternion());
        newTail.tail = gameObject.GetComponent<Tail>();
        newTail._player = player.GetComponent<Player>();
        if (FullTail.Last == null)
        {
            newTail.PrevPart = player.gameObject;
        }
        else
        {
            newTail.PrevPart = FullTail.Last.Value.gameObject;
        }
        FullTail.AddLast(newTail.GetComponent<CharacterController>());
        
    }

    private void Update()
    {
        text.text = FullTail.Count-1+"";
    }

}
