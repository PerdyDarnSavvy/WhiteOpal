using CardGame.Abstract;

namespace CardGame.Resources {

    // These are so empty because the class it inherits, Resource, has all the basic functions
    public class Health : Resource {
        public Health(int amount, int maxAmount) : base(amount, maxAmount, "Health") {

        }
    }

    public class Stamina : Resource {
        public Stamina(int amount, int maxAmount) : base(amount, maxAmount, "Stamina") {
            
        }
    }
}
