using System.Collections.Generic;
using System.Linq;

namespace Jokenpo.Domain.Entities
{
    public class JokenpoItem : Entity
    {
        public JokenpoItem(char playerOne,
                           char playerTwo)
        {
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
            PlayerWinner = 0; // Draw
        }

        public char PlayerOne { get; private set; }
        public char PlayerTwo { get; private set; }
        public short PlayerWinner { get; private set; }

        public void Play()
        {
            if (PlayerOne == PlayerTwo) return;

            var possibleWins = Rules().FirstOrDefault(x => x.Key.Equals(PlayerOne));

            if (possibleWins.Value.Contains(PlayerTwo))
                PlayerWinner = 1;
            else
                PlayerWinner = 2;
        }

        private Dictionary<char, char[]> Rules()
        {
            var rules = new Dictionary<char, char[]>();

            rules.Add('R', new[] { 'S', 'L' }); //Rock wins
            rules.Add('P', new[] { 'R', 'K' }); //Paper wins
            rules.Add('S', new[] { 'P', 'L' }); //Scissors wins
            rules.Add('L', new[] { 'K', 'P' }); //Lizard wins
            rules.Add('K', new[] { 'S', 'R' }); //Spock wins

            return rules;
        }
    }
}