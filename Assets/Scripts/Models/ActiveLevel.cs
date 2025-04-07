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


    public ActiveLevel(Level level)
    {
        this.level = level;
        scoringSystem = new TimingSystem();
        circuit = level.treemaker();
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

}