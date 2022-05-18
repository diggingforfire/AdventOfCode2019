using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _14._01
{
    static class Program
    {
        static void Main()
        {
            var reactions =
                File.ReadAllLines("input.txt")
                    .Select(line => line.Split("=>"))
                    .Select(parts => new
                    {
                        Input = parts[0].TrimEnd().Split(",").Select(part => part.TrimStart().Split(" ")).ToArray(),
                        Output = parts[1].TrimStart().Split(" ")
                    })
                    .Select(parts => new Reaction
                    {
                        Inputs = parts.Input.Select(part => new Chemical
                            {
                                Amount = int.Parse(part[0]),
                                Name = part[1]
                            }).ToList()
                        ,
                        Output = new Chemical
                        {
                            Amount = int.Parse(parts.Output[0]),
                            Name = parts.Output[1]
                        }
                    })
                    .ToList();


            var fuelReaction = reactions.GetReactionByOutputName("FUEL");


            //var groupedInputs = reactions.SelectMany(reaction => reaction.Inputs).GroupBy(chemical => chemical.Name).Select(grp => new
            //{
            //    ChemicalS = grp.ToList(),
            //    TotalAmount = grp.Sum(c => c.Amount)
            //}).ToList();

            GetNestedReactions(fuelReaction, reactions);

            var reaction = fuelReaction;

            while (!reaction.Inputs.All(i => i.Reaction.Processed))
            {
                foreach (var input in reaction.Inputs)
                {
                    if (!input.Reaction.Processed)
                    {
                        var otherInputs = reaction.Inputs.Except(new[] { input });
                        if (!otherInputs.Any(i => i.ContainsReaction(input.Name)))
                        {
                            var oreos = GetOreos(input.Reaction, input.Amount);
                            input.Reaction.Processed = true;
                        }
                    }


                }
            }



           // var groupedOreos = oreos.GroupBy(o => o.Item1).ToDictionary(grp => grp.Key, all => all.Sum(p => p.Item2)).ToList();


            //var result = groupedOreos.Sum(g =>
            //{ 
            //    var amount = (int)Math.Ceiling((double)g.Value / g.Key.Output.Amount) * g.Key.OreAmount;
            //    return amount;
            //});


        }

        static int GetOreCount(string name, int amount)
        {
            return 0;
        }
            
        static List<(Reaction, int)> GetOreos(Reaction reaction, int amount = 1, List<(Reaction, int)> oreos = null, Dictionary<string, int> dictionary = null)
        {
            dictionary ??= new Dictionary<string, int>();
            oreos ??= new List<(Reaction, int)>();

            if (reaction.HasOreInput())
            {
                oreos.Add((reaction, amount));
            }
            else
            {
                foreach (var input in reaction.Inputs)
                {
                    var resultAmount = (int)Math.Ceiling( (double)amount / reaction.Output.Amount) * input.Amount;
                    GetOreos(input.Reaction, resultAmount, oreos, dictionary);
                    
                }
            }

            return oreos;
        }

        static bool HasOreInput(this Reaction reaction)
        {
            return reaction.Inputs.SingleOrDefault(chemical => chemical.Name == "ORE") != null;
        }
        static Reaction GetReactionByOutputName(this List<Reaction> reactions, string name)
        {
            return reactions.Single(reaction => reaction.Output.Name == name);
        }

        static List<(Reaction Reaction, Chemical Input)> GetNestedReactions(Reaction reaction, List<Reaction> reactions, List<(Reaction Reaction, Chemical Input)> foundReactions = null)
        {
            foundReactions ??= new List<(Reaction Reaction, Chemical Input)>();

            foreach (var input in reaction.Inputs)
            {
                var matchingReaction = reactions.SingleOrDefault(r => r.Output.Name == input.Name);
                if (matchingReaction != null)
                {
                    input.SourceReaction = reaction;
                    input.Reaction = matchingReaction;
                    GetNestedReactions(matchingReaction, reactions, foundReactions);
                }
            }

            return foundReactions;
        }
    }

    class Reaction
    {
        public override string ToString()
        {
            return $"{string.Join(',', Inputs)} => {Output}";
        }

        public bool Processed { get; set; }

        public List<Chemical> Inputs { get; set; }
        public Chemical Output { get; set; }

        public int OreAmount => Inputs.Single(chemical => chemical.Name == "ORE").Amount;
    }

    class Chemical
    {
        public override string ToString()
        {
            return $"{Amount} {Name}";
        }

        public bool ContainsReaction(string chemical)
        { 
            if (Reaction?.Inputs.Any(i => i.Name == chemical) ?? false)
            {
                return true;
            } 
            
            return Reaction?.Inputs.Any(i => i.ContainsReaction(chemical)) ?? false;
            
        }

        public Reaction Reaction { get; set; }
        public Reaction SourceReaction { get; set; }

        
        public int Amount { get; set; }
        public string Name { get; set; }
    }
}
