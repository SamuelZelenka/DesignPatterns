using UnityEngine;

public class SpellPool : MonoBehaviour
{
    [SerializeField] private SpellObject spellObjectPrefab;
    [SerializeField] private bool _prewarm = false;
    [SerializeField] private int _capacity = 40;

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
        spellPool = new GameObjectPool<SpellObject>(spellObjectPrefab, transform, _prewarm);
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
