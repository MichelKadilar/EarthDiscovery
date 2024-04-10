using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LapManager : MonoBehaviour
{
    public List<SimpleCheckpoint> checkpoints;
    public UIManager uIManager;
    public int totalLaps = 3;

    private List<PlayerRank> playerRanks = new List<PlayerRank>();
    private PlayerRank mainPlayerRank;
    public UnityEvent onPlayerFinished = new UnityEvent();

    void Start()
    {
        StartNewGame();
        ListenCheckpoints(true);
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
        // Get players in the scene
        foreach (CarIdentity carIdentity in FindObjectsOfType<CarIdentity>())
        {
            playerRanks.Add(new PlayerRank(carIdentity));
        }
        mainPlayerRank = playerRanks.Find(player => player.identity.gameObject.tag == "Player");
        uIManager.UpdateLapText(((mainPlayerRank.lapNumber == 0) ? 1 : mainPlayerRank.lapNumber) + "/" + totalLaps);
        uIManager.UpdateWinnerText("");
    }

    public void CheckpointActivated(CarIdentity car, SimpleCheckpoint checkpoint)
    {
        PlayerRank player = playerRanks.Find((rank) => rank.identity == car);
        if (checkpoints.Contains(checkpoint) && player != null)
        {
            // if player has already finished ir first lap don't do anything
            if (player.hasFinished) return;
            
            int checkpointNumber = checkpoints.IndexOf(checkpoint);
            // first time ever the car reach the first checkpoint
            bool startingFirstLap = checkpointNumber == 0 && player.lastCheckpoint == -1;
            // finish line checkpoint is triggered & last checkpoint was reached
            bool lapIsFinished = checkpointNumber == 0 && player.lastCheckpoint >= checkpoints.Count - 1;
            if (startingFirstLap || lapIsFinished)
            {
                player.lapNumber += 1;
                player.lastCheckpoint = 0;

                // if this was the final lap
                if (player.lapNumber > totalLaps)
                {
                    player.hasFinished = true;
                    // getting final rank, by finding number of finished players
                    player.rank = playerRanks.FindAll(player => player.hasFinished).Count;

                    // if first winner, display its name
                    if (player.rank == 1)
                    {
                        uIManager.UpdateWinnerText("1er, félicaition tu as gagné !");
                    }
                    else if (player == mainPlayerRank) // display player rank if not winner
                    {
                        uIManager.UpdateWinnerText("Bravo, tu as fini à la " + mainPlayerRank.rank + "e place !");
                    }

                    if (player == mainPlayerRank) onPlayerFinished.Invoke();
                }
                else
                {
                    if (car.gameObject.tag == "Player") uIManager.UpdateLapText(player.lapNumber + "/" + totalLaps);
                }
            }
            // next checkpoint reached
            else if (checkpointNumber == player.lastCheckpoint + 1)
            {
                player.lastCheckpoint += 1;
            }
        }
    }
}