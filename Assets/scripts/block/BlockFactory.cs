using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BlockFactory", menuName = "ScriptableObjects/BlockFactoryScriptableObject", order = 1)]
public class BlockFactory : ScriptableObject
{
    public List<GameObject> Blocks;

    [SerializeField] private int blockIndex;

    public GameObject GetNextBlock(Vector3 position)
    {
        blockIndex = blockIndex % Blocks.Count;
        var block = Instantiate(Blocks[blockIndex], position, Quaternion.identity);
        blockIndex++;
        return block;
    }
}