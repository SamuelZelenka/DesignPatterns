using UnityEngine;

public class SpellPool : MonoBehaviour
{
    [SerializeField] private SpellObject spellObjectPrefab;
    [SerializeField] private int _capacity;

    private static SpellPool _instance;
    public GameObjectPool<SpellObject> spellPool;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        spellPool = new GameObjectPool<SpellObject>(spellObjectPrefab, transform);
        spellPool.capacity = _capacity;
    }

    public static SpellObject AcquireSpellObject()
    {
        return _instance.spellPool.Acquire();
    }
    public static void ReleaseSpellObject(SpellObject spellObject)
    {
        _instance.spellPool.Release(spellObject);
    }
}
