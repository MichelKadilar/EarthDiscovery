using UnityEngine;

[System.Serializable]
public class CarStartPosition
{
    public CarIdentity carIdentity;
    public Vector3 startPosition;
    public Quaternion startRotation;

    public CarStartPosition(CarIdentity carIdentity, Vector3 pos, Quaternion rot)
    {
        this.carIdentity = carIdentity;
        this.startPosition = pos;
        this.startRotation = rot;
    }
}