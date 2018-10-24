public class RaftPart : Item {
	int PartID;
	public RaftPart (string name, float weight, int PartID) : base(name, weight) {
		this.PartID = PartID; 
	}
	public int GetPartID (){return PartID;}
}
