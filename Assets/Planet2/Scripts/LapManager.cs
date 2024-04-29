using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using Debug = UnityEngine.Debug;

public class LapManager : MonoBehaviour
{
    public List<SimpleCheckpoint> checkpoints;
    public UIManager uIManager;
    public int totalLaps = 3;

    private List<PlayerRank> playerRanks = new List<PlayerRank>();
    private PlayerRank mainPlayerRank;
    public UnityEvent onPlayerFinished = new UnityEvent();
    public GameObject uIWinner;
    public AudioSource audioWinner;
    public AudioSource audioTheme;

    void Start()
    {
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
        playerRanks.Clear();
        // Get players in the scene
        foreach (CarIdentity carIdentity in FindObjectsOfType<CarIdentity>())
        {
            playerRanks.Add(new PlayerRank(carIdentity));
        }

        Debug.Log("Players: " + playerRanks.Count);
        mainPlayerRank = playerRanks.Find(player => player.identity.gameObject.tag == "Player");
        uIManager.UpdateLapText(mainPlayerRank.lapNumber + "/" + totalLaps);
        uIManager.UpdateWinnerText("");
        uIManager.UpdateSubTextWinner("");
        audioWinner.Stop();
        audioTheme.Play();
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

                if (car.gameObject.tag == "Player")
                {
                    uIManager.UpdateLapText(player.lapNumber + "/" + totalLaps);
                }
                
                // if this was the final lap
                if (player.lapNumber >= totalLaps)
                {
                    player.hasFinished = true;
                    // getting final rank, by finding number of finished players
                    player.rank = playerRanks.FindAll(player => player.hasFinished).Count;
                    
                    // if first winner, display its name
                    if (player.rank == 1 && player == mainPlayerRank)
                    {
                        uIManager.UpdateWinnerText("1er, félicitations, tu as gagné !");
                        uIManager.UpdateSubTextWinner("Clique sur ECHAP pour récupérer ta récompense !");
                        uIWinner.SetActive(true);
                        audioTheme.Stop();
                        audioWinner.Play();
                    }
                    else if (player == mainPlayerRank) // display player rank if not winner
                    {
                        uIManager.UpdateWinnerText("Dommage, tu as fini à la " + mainPlayerRank.rank + "e place !");
                        uIManager.UpdateSubTextWinner("Clique sur ECHAP pour recommencer !");
                        audioTheme.Stop();
                    }

                    if (player == mainPlayerRank) onPlayerFinished.Invoke();
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