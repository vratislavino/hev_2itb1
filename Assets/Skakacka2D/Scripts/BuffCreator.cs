using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffCreator : MonoBehaviour
{
    [SerializeField]
    private float duration = 5f;

    [SerializeField]
    private BuffType buffType;

    [SerializeField]
    private float multiplier = 1.2f;

    private static Dictionary<BuffType, Type> typeByTypeBuff = new Dictionary<BuffType, Type>() {
        { BuffType.Speed, typeof(SpeedBuff) }
    };

    private void OnTriggerEnter2D(Collider2D col) {
        var player = col.GetComponent<PlayerMovement2D>();
        if(player) {
            // nastala kolize s playerem!
    
            var buff = (Buff)player.gameObject.GetComponent(typeByTypeBuff[buffType]);
            if(buff) {
                buff.Collect(duration, multiplier, buffType);
            } else {
                buff = (Buff) player.gameObject.AddComponent(typeByTypeBuff[buffType]);
                buff.Collect(duration, multiplier, buffType);
            }
        }
    }
}
