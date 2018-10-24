public class Item {

	string name;
	float weigth;

	public Item (string name, float weight) {
		this.name = name;
		this.weigth = weight;
	}

	public string GetName(){return name;}
	public float GetWeight(){return weigth;}
}
