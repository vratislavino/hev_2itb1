using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField]
    private bool ChangeStateInTime = true;

    private StateEnum playerState;

    [SerializeField]
    private float StateDuration;

    private float timeToChangeState;

    [SerializeField]
    List<Material> materials;

    [SerializeField]
    private MeshRenderer quadRenderer;

    // Start is called before the first frame update
    void Start()
    {
        playerState = (StateEnum) Random.Range(0,3);
        quadRenderer.material = materials[(int) playerState];
        
        timeToChangeState = StateDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ChangeStateInTime)
            return;

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
        quadRenderer.material = materials[(int)playerState];
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
