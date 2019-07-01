using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasic : MonoBehaviour
{
    [Header("Player Speed")]
    [SerializeField]
    public float GameSpeed = 0.5f;

    [Header("Round Cooldown Setting")]
    float RoundCoolDown; // Player flip once = One Round   Set to avoid round over too fast
    float _RoundCoolDownValue;

    [Header(" ")]
    public int MoveCount;

    public delegate void OnVariableChangeDelegate(int newVal);
    public event OnVariableChangeDelegate OnVariableChange;

    // Start is called before the first frame update
    void Start()
    {
        _RoundCoolDownValue = GameSpeed;
        RoundCoolDown = 0;
        MoveCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(RoundCoolDown < _RoundCoolDownValue)RoundCoolDown += Time.deltaTime;
    }

    public bool IsRoundAviable()
    {
        if(RoundCoolDown >= _RoundCoolDownValue)
        {
            RoundCoolDown = 0;
            return true;
        }
        return false;
    }

    public void _Move()
    {
        StartCoroutine(Delay_Move());
    }

    void AddMoveValue()
    {
        MoveCount++;
        OnVariableChange(MoveCount);
    }

    IEnumerator Delay_Move()
    {
        yield return new WaitForSecondsRealtime(GameSpeed);
        AddMoveValue();
        yield return 0;
    }
}
