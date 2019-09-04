using System.Drawing;
class Entity
{
    public Position position { get; set; }
    public char sprite { get; set; }
    public Color forgroundColor { get; set; }
    public Color backgroundColor { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public Entity()
    {
        position = new Position(40, 10);
        forgroundColor = Color.White;
        backgroundColor = Color.Empty;
        sprite = ' ';
        name = "";
        description = "";
    }
}