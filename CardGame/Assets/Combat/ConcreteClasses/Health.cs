public class Health : Resource {

    private float Amount { get; set; }

    public Health(float amount) {
        this.Amount = amount;
    }

    public override float GetAmount() {
        return Amount;
    }

    public override void SetAmount(float amount) {
        this.Amount = amount;
    }
}
