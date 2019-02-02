public class Item
{
  public string name {get; set;}
  public float damageBoost {get; set;}
  public float speedBoost {get; set;}
  public float healthBoost {get; set;}

  public Item()
  {
    name = "unknown";
    damageBoost = 0.0f;
    speedBoost = 0.0f;
    healthBoost = 0.0f;
  }

  public Item(string name)
  {
    this.name = name;
    damageBoost = 0.0f;
    speedBoost = 0.0f;
    healthBoost = 0.0f;
  }
}
