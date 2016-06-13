using System;
using System.Collections.Generic;
using System.Linq;

public class Mapper
{
    Dictionary<string, Dictionary<string, int>> map; 
    public Mapper(){
        this.map = new Dictionary<string, Dictionary<string, int>>();
    }

    public void Add(BiGram biGram){
        if (biGram.First.Trim().Length > 0 && biGram.Second.Trim().Length > 0){
            if (this.map.ContainsKey(biGram.Hash())){
                var updateGram = this.map[biGram.Hash()];
                if (updateGram.ContainsKey(biGram.Suffix))
                    updateGram[biGram.Suffix] ++;
                else
                    updateGram.Add(biGram.Suffix, 1);
            }
            else
            {
                this.map.Add(biGram.Hash(), new Dictionary<string, int>());
                this.map[biGram.Hash()].Add(biGram.Suffix, 1);
            }
        }
    }

    public BiGram MaxWord(){
        var maxedValue = this.map.OrderByDescending(x=>x.Value.Max(y=>y.Value)).First();
        return MaxWord(maxedValue.Key);
    }

    Random r = new Random();

    public BiGram MaxWord(string start){
        start = start.ToLower();
        var maxedValue = this.map[start];
        
        return new BiGram(){
            First = start.Split('-')[0],
            Second = start.Split('-')[1],
            Suffix = maxedValue.OrderByDescending(y=>y.Value * r.Next(0, 100)).First().Key
        };
    }
}