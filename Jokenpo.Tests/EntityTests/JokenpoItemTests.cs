using Jokenpo.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jokenpo.Tests.EntityTests
{
    [TestClass]
    public class JokenpoItemTests
    {
        [TestMethod]
        public void Dado_um_novo_jokenpo_o_mesmo_nao_pode_ter_vencedor()
        {
            JokenpoItem _jokenpoValid = new JokenpoItem('R', 'P');

            Assert.AreEqual(_jokenpoValid.PlayerWinner, 0);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow('R', 'S')]
        [DataRow('R', 'L')]
        [DataRow('P', 'R')]
        [DataRow('P', 'K')]
        [DataRow('S', 'P')]
        [DataRow('S', 'L')]
        [DataRow('L', 'K')]
        [DataRow('L', 'P')]
        [DataRow('K', 'S')]
        [DataRow('K', 'R')]
        public void Dado_um_jogo_jokenpo_jogador1_deve_ganhar(char p1, char p2)
        {
            JokenpoItem _jokenpo = new JokenpoItem(p1, p2);

            _jokenpo.Play();

            Assert.AreEqual(_jokenpo.PlayerWinner, 1);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow('R', 'R')]
        [DataRow('P', 'P')]
        [DataRow('S', 'S')]
        [DataRow('L', 'L')]
        [DataRow('K', 'K')]
        public void Dado_um_jogo_jokenpo_onde_jogador1_e_jogador2_jogarem_igual_deve_empatar(char p1, char p2)
        {
            JokenpoItem _jokenpo = new JokenpoItem(p1, p2);

            _jokenpo.Play();

            Assert.AreEqual(_jokenpo.PlayerWinner, 0);
        }
    }
}