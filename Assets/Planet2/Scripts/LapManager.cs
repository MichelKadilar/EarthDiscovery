using System.Collections.Generic;
using UnityEngine;
public class LapManager : MonoBehaviour
{
    public List<SimpleCheckpoint> checkpoints;
    public int totalLaps = 3;
    public UIManager uIManager;
    private int lastPlayerCheckpoint = -1;
    private int currentPlayerLap = 1;
    private bool firstLap = true;

    void Start()
    {
        ListenCheckpoints(true);
        uIManager.UpdateLapText(currentPlayerLap + "/" + totalLaps);
    }

    private void ListenCheckpoints(bool subscribe)
    {
        foreach (SimpleCheckpoint checkpoint in checkpoints)
        {
            if (subscribe) checkpoint.onCheckpointEnter.AddListener(CheckpointActivated);
            else checkpoint.onCheckpointEnter.RemoveListener(CheckpointActivated);
        }
    }

    public void StartNewGame()
    {
        currentPlayerLap = 1;
        firstLap = true;
        uIManager.UpdateLapText(currentPlayerLap + "/" + totalLaps);
    }

    public void CheckpointActivated(GameObject car, SimpleCheckpoint checkpoint)
    {
        if (checkpoints.Contains(checkpoint))
        {
            if (firstLap)
            {
                firstLap = false;
                return;
            }
            int checkpointNumber = checkpoints.IndexOf(checkpoint);
            // first time ever the car reach the first checkpoint
            bool startingFirstLap = checkpointNumber == 0 && lastPlayerCheckpoint == -1;
            // finish line checkpoint is triggered & last checkpoint was reached
            bool lapIsFinished = checkpointNumber == 0 && lastPlayerCheckpoint >= checkpoints.Count - 1;
            if (startingFirstLap || lapIsFinished)
            {
                currentPlayerLap += 1;
                lastPlayerCheckpoint = 0;

                // if this was the final lap
                if (currentPlayerLap > totalLaps)
                {
                    Debug.Log("You won");
                }
                else
                {
                    uIManager.UpdateLapText(currentPlayerLap + "/" + totalLaps);
                }
            }
            // next checkpoint reached
            else if (checkpointNumber == lastPlayerCheckpoint + 1) lastPlayerCheckpoint += 1;
        }
    }
}