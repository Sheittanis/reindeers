using UnityEngine;
using System.Collections;

public class s_spawn : MonoBehaviour
{
    public float timer;
    public GameObject gift; //prefab it

    public s_elf sElf;
    // Use this for initialization
    void Start()
    {
        timer = 6.0f;
        // elf = this.GetComponent<s_elf>();
        sElf = GameObject.Find("elf").GetComponent<s_elf>();
    }

    // Update is called once per frame
    public void Update()
    {
        //activity
        timer -= Time.deltaTime;
        if (timer < 0 && sElf.Active)
        {
            //random position for gift spawn - boundaries within the arena
            Vector3 position = new Vector3(Random.Range(-29.0f, -21.0f), Random.Range(-2.0f, 2.0f), 0f);
            Instantiate(gift, position, Quaternion.identity);
            timer = 6.0f;
            if (sElf.elf_health < 10)
            {
                //makes the elf harder (more gifts) if its low on  hp)
                timer = 2.0f;
            }
        }
    }
}
