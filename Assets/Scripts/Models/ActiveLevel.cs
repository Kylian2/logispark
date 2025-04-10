using System.Collections.Generic;
using LogiSpark.Models;
using Unity.VisualScripting;

public class ActiveLevel
{

    private readonly Level level;

    private ScoringSystem scoringSystem;

    private List<GateNOT> not;
    private List<GateAND> and;
    private List<GateOR> or;
    private List<GateXOR> xor;
    private List<GateNAND> nand;
    private List<Wire> wire;

    private Tree<LogicGate> circuit;

    private string gateType = ""; // Contient le nom de la porte actuellement sélectionnée
    private Dictionary<string, ButtonInventoryGate> inventoryGates; // Contient les portes logiques de l'inventaire du niveau actuel

    private Dictionary<string, List<Tree<LogicGate>>> emplacements;

    public ActiveLevel(Level level)
    {
        this.level = level;
        scoringSystem = new TimingSystem();
        emplacements = new Dictionary<string, List<Tree<LogicGate>>>();
        circuit = level.treemaker(emplacements);
        inventoryGates = new Dictionary<string, ButtonInventoryGate>();
    }

    public void InstanciateGates()
    {
        not = new List<GateNOT>();
        and = new List<GateAND>();
        or = new List<GateOR>();
        xor = new List<GateXOR>();
        nand = new List<GateNAND>();
        wire = new List<Wire>();

        for(int i = 0; i < level.GetNot(); i++)
        {
            not.Add(new GateNOT());
        }
        for(int i = 0; i < level.GetAnd(); i++)
        {
            and.Add(new GateAND());
        }
        for(int i = 0; i < level.GetOr(); i++)
        {
            or.Add(new GateOR());
        }
        for(int i = 0; i < level.GetXor(); i++)
        {
            xor.Add(new GateXOR());
        }
        for(int i = 0; i < level.GetNand(); i++)
        {
            nand.Add(new GateNAND());
        }
        for(int i = 0; i < level.GetWire(); i++)
        {
            wire.Add(new Wire());
        }
    }

    public Level GetLevel()
    {
        return level;
    }

    public void StartScore()
    {
        scoringSystem.Start();
    }
    public void StopScore()
    {
        scoringSystem.Stop();
    }
    public int GetInGameScore()
    {
        return scoringSystem.GetInGameScore();
    }

    public ScoringSystem GetScoringSystem()
    {
        return scoringSystem;
    }

    public bool Evaluate()
    {
        return circuit.EvaluateCircuit();
    }

    public Tree<LogicGate> GetCircuit()
    {
        return circuit;
    }

    public int GetNbDoors(){
        return level.GetNbDoors();
    }

    public string GetGateType()
    {
        return gateType;
    }

    public void SetGateType(string gateType)
    {
        this.gateType = gateType;
    }

    public void AddGate(string gateType, ButtonInventoryGate buttonInventoryGate)
    {
        inventoryGates.Add(gateType, buttonInventoryGate);
    }

    public ButtonInventoryGate GetButtonInventoryGate(string gateType)
    {
        return inventoryGates[gateType];
    }

    public void DeselectGates(string selectedGateType)
    {
        foreach (KeyValuePair<string, ButtonInventoryGate> paire in inventoryGates)
        {
            if(paire.Key != selectedGateType)
            {
                paire.Value.Deselect();
            }
        }
    }

    public Dictionary<string, List<Tree<LogicGate>>> GetEmplacements()
    {
        return emplacements;
    }
}