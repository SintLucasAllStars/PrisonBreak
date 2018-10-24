public class Access : Item {

	int activatoinID;

	public Access (string name, float weight, int ID) : base(name, weight){
		this.activatoinID = ID;
	}

	public int GetActivationID(){return activatoinID;}

}
