public class FireBall : Spell
{
    private const byte FIREBALL_RECIPE = (byte)(SpellElements.Fire);
    public override byte SpellRecipe => FIREBALL_RECIPE;
    public override string SpellMessage()
    {
        return "Cast Fireball";
    }

    public FireBall()
    {

    }
}