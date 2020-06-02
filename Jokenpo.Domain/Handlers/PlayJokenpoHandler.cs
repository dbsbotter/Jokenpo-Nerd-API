using Jokenpo.Domain.Commands;
using Jokenpo.Domain.Handlers.Contracts;
using Jokenpo.Domain.Entities;
using Jokenpo.Domain.Repositories;

namespace Jokenpo.Domain.Handlers
{
    public class PlayJokenpoHandler : IHandler<PlayJokenpoCommand, string>
    {
        private readonly IJokenpoRepository _jokenpoRepository;

        public PlayJokenpoHandler(IJokenpoRepository jokenpoRepository)
        {
            _jokenpoRepository = jokenpoRepository;
        }

        public string Handle(PlayJokenpoCommand command)
        {
            var jokenpo = new JokenpoItem((char)command.PlayerOne,
                                          (char)command.PlayerTwo);

            jokenpo.Play();

            _jokenpoRepository.Create(jokenpo);

            switch (jokenpo.PlayerWinner)
            {
                case 1:
                    return "Player one winner";
                case 2:
                    return "Player two winner";
                default:
                    return "Draw";
            }
        }
    }
}