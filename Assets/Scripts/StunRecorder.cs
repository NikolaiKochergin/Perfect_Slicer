using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StunRecorder : MonoBehaviour
{
    public event UnityAction Stunnig;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Obstacle obstacle))
        {
            Stunnig?.Invoke();
        }
    }
}
