using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Trampoline : MonoBehaviour, IPushTrap
{
    public float pushHeight = 6f;
    public CinemachineImpulseSource impulseSource;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(Tag.Player))
        {
            GetComponent<Animator>().SetTrigger("on");
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            
            ((IPushTrap)this).pushPlayer(pushHeight, rb);
            if(impulseSource != null) impulseSource.GenerateImpulse();
        }
    }
}
