using UnityEngine;

public class CollectiblesRotation : MonoBehaviour
{
    public float velocity = 50f;

    void Update()
    {
        transform.Rotate(0, velocity * Time.deltaTime, 0);
    }
}
