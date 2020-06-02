using System.Runtime.Serialization;
using Jokenpo.Domain.Commands.Contracts;

namespace Jokenpo.Domain.Commands
{
    public class PlayJokenpoCommand : ICommand
    {
        public PlayJokenpoCommand()
        { }

        public PlayJokenpoCommand(JokenpoEnum playerOne,
                                  JokenpoEnum playerTwo)
        {
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
        }

        /// <summary>
        /// Jogada do player 1
        /// </summary>
        public JokenpoEnum PlayerOne { get; set; }

        /// <summary>
        /// Jogada do player 2
        /// </summary>
        public JokenpoEnum PlayerTwo { get; set; }
    }

    public enum JokenpoEnum
    {
        /// <summary>
        /// Rock
        /// </summary>
        [EnumMember(Value = "R")]
        Rock = 'R',

        /// <summary>
        /// Paper
        /// </summary>
        [EnumMember(Value = "P")]
        Paper = 'P',

        /// <summary>
        /// Scissors
        /// </summary>
        [EnumMember(Value = "S")]
        Scissors = 'S',

        /// <summary>
        /// Lizard
        /// </summary>
        [EnumMember(Value = "L")]
        Lizard = 'L',

        /// <summary>
        /// Spock
        /// </summary>
        [EnumMember(Value = "K")]
        Spock = 'K'
    }
}