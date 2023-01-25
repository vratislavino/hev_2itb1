using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private StateEnum playerState;

    [SerializeField]
    private float StateDuration;

    private float timeToChangeState;

    // Start is called before the first frame update
    void Start()
    {
        playerState = StateEnum.Paper;
        timeToChangeState = StateDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeToChangeState > 0) {
            timeToChangeState -= Time.deltaTime;
            if(timeToChangeState <= 0) {
                ChangeState();
            }
        }
    }

    private void ChangeState() {
        timeToChangeState = StateDuration;
        playerState = GetRandomState(playerState);
    }

    private StateEnum GetRandomState(StateEnum currentState) {
        int current = (int) currentState;
        int random = Random.Range(0, System.Enum.GetValues(typeof(StateEnum)).Length);

        if(random == current) {
            return GetRandomState(currentState);
        } else {
            return (StateEnum)random;
        }
    }
}

public enum StateEnum
{
    Rock,
    Paper,
    Scissors
}
