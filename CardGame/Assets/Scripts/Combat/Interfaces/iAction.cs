using System.Collections.Generic;
using CardGame.Abstract;

namespace CardGame.Interfaces {
    public interface iAction {
        void execute(List<Character> Targets, Character Source);
    }
}