using System.Drawing;
class Wall : Item
{
    public Wall()
    {
        name = "Wall";
        sprite = '#';
        forgroundColor = Color.White;
        isSolid = true;
    }
}