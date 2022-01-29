using UnityEngine;
using UnityEngine.SceneManagement;

public class ForceFieldController : MonoBehaviour
{
    private MeshRenderer _renderer;
    private BoxCollider _collider;
    
    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<BoxCollider>();
        _renderer.enabled = false;
        _collider.enabled = false;
        
        //Testing
        
        /*
         Item testKey = ScriptableObject.CreateInstance<Item>();
        testKey.id = 0;
        testKey.quantity = 0;
        
        for (int i = 0; i < 4; i++)
        {
            InventoryScript.inventory.Add(testKey);
            Debug.Log("Added Test Key");
        }
        */
    }
    void Update()
    {
        if (InventoryScript.inventory.Count > 3)
        {
            _renderer.enabled = true;
            _collider.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
