using System;
using System.Collections.Generic;
using System.Linq;

public class Pile
{
    public int Count;
    public List<PileCombination> Combinations = new List<PileCombination>();
}

public class PileCombination
{
    public List<Pile> Piles = new List<Pile>();
}

public class PileTree
{
    Dictionary<int, Pile> CorePileList = new Dictionary<int, Pile>();

    Pile TreeRoot = null;

    public PileTree(int startingCount)
    {
        TreeRoot = GetPileTree(startingCount);
    }

    public Pile GetPileTree(int total)
    {
        if (total < 1) return null;

        Pile root = null;

        for (int i = 1; i <= total; i++)
        {
            Pile newRoot = new Pile() { Count = i };

            int count = i;
            while (count > 1)
            {
                count--;
                PileCombination childCombo = new PileCombination();
                childCombo.Piles.Add(CorePileList[count]);
                childCombo.Piles.Add(CorePileList[i - count]);
                newRoot.Combinations.Add(childCombo);
            }

            CorePileList.Add(newRoot.Count, newRoot);
            root = newRoot;
        }

        return root;
    }

    public List<int[]> GetPileCombinations(int pileSize)
    {
        if (pileSize > TreeRoot.Count)
            throw new ArgumentOutOfRangeException("pileSize");

        List<int[]> combinations = new List<int[]>();

        Pile corePile = CorePileList[pileSize];
        foreach (PileCombination combo in corePile.Combinations)
        {
            var pileValues = combo.Piles.Select(x => x.Count);

        }

        return combinations;
    }
}
