using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamThirdperson : MonoBehaviour
{
    public Transform camTarget;  // Target for the camera to follow
    public float pLerp = 0.2f;  // Position lerp factor
    public float rLerp = 0.1f;  // Rotation lerp factor

    // Start is called before the first frame update
    void Start()
    {
        // Initialization code can go here if needed
    }

    // Update is called once per frame
    void Update()
    {
        // Use Vector3.Lerp to smoothly interpolate the camera's position towards the target's position
        transform.position = Vector3.Lerp(transform.position, camTarget.position, pLerp);

        // Use Quaternion.Lerp to smoothly interpolate the camera's rotation towards the target's rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, camTarget.rotation, rLerp);
    }
}
