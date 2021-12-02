using System.Collections.Generic;
using UnityEngine;

public class RingOfFire : Spell
{
    private const byte RINGOFFIRE_RECIPE = (byte)(SpellElements.Fire | SpellElements.Air);
    private const int FIREBALL_COUNT = 8;
    private const float RADIUS = 1;
    private readonly Color32 _spellColor = new Color32(0x00, 0xE4, 0xFF, 0xFF);

    public override byte SpellRecipe => RINGOFFIRE_RECIPE;
    public override string SpellMessage()
    {
        return "Cast RingOfFire";
    }

    public override void Initiate(SpellObject spellObject)
    {
        base.Initiate(spellObject);
        Vector3 origin = spellObject.transform.position;
        SpellPool.ReleaseSpellObject(spellObject);

        Vector3[] pointsOnCircle = GetPointsOnCircle(origin, RADIUS, FIREBALL_COUNT);
        for (int i = 0; i < pointsOnCircle.Length; i++)
        {
            Vector3 direction = origin - pointsOnCircle[i];
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            SpellObject fireBall = SpellFactory.CreateSpellObject(SpellElements.Fire, origin, rotation);
        }

        _spellObject.GetComponent<MeshRenderer>().material.color = _spellColor;
    }
    private Vector3[] GetPointsOnCircle(Vector3 origin, float radius, int count)
    {
        List<Vector3> points = new List<Vector3>();
        float theta = Mathf.PI * 2 / count;

        for (int i = 1; i <= count; i++)
        {
            float xPos = radius * Mathf.Cos(theta * i) + origin.x;
            float yPos = radius * Mathf.Sin(theta * i) + origin.z;
            Vector3 newPoint = new Vector3(xPos, origin.y, yPos);
            points.Add(newPoint);
        }
        return points.ToArray();
    }

}

