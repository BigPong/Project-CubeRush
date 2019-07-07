using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Event_ChangeRoom : MonoBehaviour
{
    public GameObject End;
    PlayerBasic playerBasic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerBasic = other.GetComponent<PlayerBasic>();
            playerBasic.transform.DOMove(End.transform.position, 3f).SetEase(Ease.InCubic);
        }
    }
}
