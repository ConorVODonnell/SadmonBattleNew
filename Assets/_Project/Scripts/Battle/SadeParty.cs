using System.Collections.Generic;

[System.Serializable]
public class SadeParty
{
    public SadeParty(bool isPlayerParty) {
        playerParty = isPlayerParty;
    }

    bool playerParty;

    public List<SadeTA> party = new List<SadeTA>();

    public void AssignToParty(SadeTA sademon) {
        party.Add(sademon);
        sademon.isPlayer = playerParty;
    }
}
