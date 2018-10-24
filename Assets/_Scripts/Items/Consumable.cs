public class Consumable : Item {

	int totalUses;
	int uses;
	System.Func<int, bool> UseFunction;
	int useInput;


	public Consumable(string name, float weight, int totalUses, System.Func<int, bool> UseFunction, int useInput) : base(name, weight){
		this.totalUses = totalUses;
		this.uses = totalUses;
		this.UseFunction = UseFunction;
		this.useInput = useInput;
	}

	public bool Use(){
		if (!UseFunction (useInput))
			return false;
		uses--;
		if (uses == 0)
			GameBehaviour.im.RemInv(this,true);
		return true;
	}

	public int GetTotalUses(){return totalUses;}

}
