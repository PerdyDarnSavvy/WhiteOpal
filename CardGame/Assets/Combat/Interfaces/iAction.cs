using CardGame.Abstract;

namespace CardGame.Interfaces {
    public interface iAction {
        void execute(Character Target, Character Source);
    }
}