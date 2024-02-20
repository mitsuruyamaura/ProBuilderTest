using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor1 : SensorBase
{
    public PostProcessingManager processingManager;

    public override void OnTriggerEnter(Collider other) {
        base.OnTriggerEnter(other);

        Debug.Log(other.name);

        if (other.CompareTag("Player")) {
            //AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);

            //target.GetComponent<DoorMove>().enabled = true;
            processingManager.ChangeProfile();
        }
    }
}
