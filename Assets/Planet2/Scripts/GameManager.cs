using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public PlayerControls playerControls;
    public AIControls[] aiControls;
    public CarMovementBot[] carMovementBots;
    public LapManager lapTracker;
    public TricolorLights tricolorLights;
    public UIManager uIManager;
    public AudioSource audioSource;
    public AudioClip lowBeep;
    public AudioClip highBeep;

    private bool isCountingDown = true;
    private List<CarStartPosition> carStartPositions = new List<CarStartPosition>();

    private void Awake()
    {
        carStartPositions.Clear();
        foreach (CarIdentity carIdentity in FindObjectsOfType<CarIdentity>())
        {
            Rigidbody rb = carIdentity.GetComponentInParent<Rigidbody>();
            carStartPositions.Add(new CarStartPosition(carIdentity, rb.transform.position, rb.transform.rotation));
        }
        FreezePlayers(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopRacing();
            ResetCarsToStartPosition();
        }
    }
    
    // Enable or disable the winner text in the UI
    public void EnableWinnerText(bool enable)
    {
        uIManager.UpdateWinnerText(enable ? "WINNER !" : "");
    }

    public void StartGame()
    {
        ResetCarsToStartPosition();
        tricolorLights.SetAllLightsOff();
        StartCoroutine("Countdown");
    }

    void ResetCarsToStartPosition()
    {
        foreach (CarStartPosition carStart in carStartPositions)
        {
            Rigidbody rb = carStart.carIdentity.GetComponentInParent<Rigidbody>();

            if (rb != null)
            {
                ApplyBrake(rb, true);

                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true;

                rb.transform.position = carStart.startPosition;
                rb.transform.rotation = carStart.startRotation;
                rb.isKinematic = false;

                ApplyBrake(rb, false);
            }
        }
    }

    void ApplyBrake(Rigidbody car, bool applyBrake)
    {
        foreach (var wheel in car.GetComponentsInChildren<WheelCollider>())
        {
            if (applyBrake)
            {
                wheel.motorTorque = 0;
                wheel.brakeTorque = 10000; // Applique un frein puissant pour arrêter la voiture
                wheel.steerAngle = 0;
            }
            else
            {
                wheel.brakeTorque = 0; // Enlève le frein
            }
        }
    }

    private IEnumerator Countdown()
    {
        isCountingDown = true; // Commence le compte à rebours

        yield return new WaitForSeconds(1);
        if (!isCountingDown) yield break;

        yield return new WaitForSeconds(1);
        tricolorLights.SetProgress(1);
        uIManager.UpdateWinnerText("1");
        if(audioSource.enabled) audioSource.PlayOneShot(lowBeep);

        yield return new WaitForSeconds(1);
        tricolorLights.SetProgress(2);
        uIManager.UpdateWinnerText("2");
        if (audioSource.enabled) audioSource.PlayOneShot(lowBeep);

        yield return new WaitForSeconds(1);
        tricolorLights.SetProgress(3);
        uIManager.UpdateWinnerText("3");
        if (audioSource.enabled) audioSource.PlayOneShot(lowBeep);

        yield return new WaitForSeconds(1);
        tricolorLights.SetProgress(4);
        StartRacing();
        uIManager.UpdateWinnerText("GO !");
        if (audioSource.enabled) audioSource.PlayOneShot(highBeep);

        yield return new WaitForSeconds(2f);
        tricolorLights.SetAllLightsOff();
        uIManager.UpdateWinnerText("");
    }

    public void StopRacing()
    {
        isCountingDown = false; 
        StopCoroutine("Countdown");
        FreezePlayers(true);
    }

    private void StartRacing()
    {
        FreezePlayers(false);
    }

    private void FreezePlayers(bool freeze)
    {
        foreach (var aiControl in aiControls)
        {
            if (aiControl != null)
            {
                aiControl.enabled = !freeze;
            }
        }
        foreach (var car in carMovementBots)
        {
            if (car != null)
            {
                car.enabled = !freeze;
            }
        }
        if (playerControls != null)
        {
            playerControls.enabled = !freeze;
        }
    }
}