public class Bonus : Item {
	int score;

	public Bonus (string name, float weight, int score) : base(name, weight){
		this.score = score;
	}
	public int GetScore(){return score;}

}
