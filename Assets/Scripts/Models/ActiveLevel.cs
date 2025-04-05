using System.Collections.Generic;
using LogiSpark.Models;
using Unity.VisualScripting;

public class ActiveLevel
{

    private Level level;

    private List<GateNOT> not;
    private List<GateAND> and;
    private List<GateOR> or;
    private List<GateXOR> xor;
    private List<GateNAND> nand;
    private List<Wire> wire;

    public void instanciateGates()
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

}