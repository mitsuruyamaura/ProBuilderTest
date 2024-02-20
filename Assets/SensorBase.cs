using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SensorBase : MonoBehaviour {
    public GameObject target;
    public AudioClip sound;

    public virtual void OnTriggerEnter(Collider other) {
        this.gameObject.SetActive(false); // センサーの使用は１回のみ
    }
}
