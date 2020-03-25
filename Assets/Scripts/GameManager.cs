using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] branchPrefabs;

    public List<GameObject> branches;

    private bool createTrunk = true;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i += 2)
        {
            GameObject trunkEmpty = Instantiate(branchPrefabs[0]);
            trunkEmpty.transform.parent = gameObject.transform;
            trunkEmpty.transform.localPosition = new Vector3(0f, i * 2.43f, 0f);
            Debug.Log("1 " + i * 2.43f);

            branches.Add(trunkEmpty);

            GameObject trunkBranch = Instantiate(getRandomBranch());
            trunkBranch.transform.parent = gameObject.transform;
            trunkBranch.transform.localPosition = new Vector3(0f, (i + 1) * 2.43f, 0f);
            Debug.Log("2 " + (i  + 1) * 2.43f);

            branches.Add(trunkBranch);
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private GameObject getRandomBranch()
    {
        int random = Random.Range(0, 150);

        if (random <= 50)
            return branchPrefabs[1];
        else if (random <= 100)
            return branchPrefabs[2];

        return branchPrefabs[0];
    }

    public void cutFirstTrunk(string directionTrunk)
    {
        //Destroy(branches[0]);
        branches[0].GetComponent<Trunk>().onAnimateDestroy(directionTrunk);
        branches.RemoveAt(0);

        int i = 0;
        for (i = 0; i < branches.Count; i++)
        {
            branches[i].transform.localPosition = new Vector3(branches[i].transform.position.x, i * 2.43f, branches[i].transform.position.z);
        }

        GameObject trunk = Instantiate(createTrunk ? branchPrefabs[0] : getRandomBranch());
        trunk.transform.parent = gameObject.transform;
        trunk.transform.localPosition = new Vector3(0f, i * 2.43f, 0f);

        branches.Add(trunk);

        createTrunk = !createTrunk;
    }

    public string getDirectionFirstTrunk()
    {
        return branches[0].tag.ToString();
    }

    public void reset()
    {
        for (int i = 0; i < branches.Count; i++)
        {
            Destroy(branches[i]);
        }
        branches.RemoveRange(0, branches.Count);

        Start();
    }
}
