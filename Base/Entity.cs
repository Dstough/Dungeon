class Entity
{
    public Position position { get; set; }
    public char sprite { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public Entity()
    {
        position = new Position(1, 1);
        sprite = ' ';
        name = "";
        description = "";
    }
}