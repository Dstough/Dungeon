using System.Drawing;
class Wall : Item
{
    public Wall()
    {
        sprite = '#';
        forgroundColor = Color.White;
        isSolid = true;
    }
}