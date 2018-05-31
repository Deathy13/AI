using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace TowerDefense
{
    public class Enemy : MonoBehaviour
    {
        public float maxhealth = 100f;
        [Header("UI")]
        public GameObject healthBarUI;
        public Vector2 healthBarOffset = new Vector2(0f, 05f);
        private Slider healthSlider;
        private float health = 100f;
        void Start()
        {
            health = maxhealth;
        }
        Vector3 GetHealthBarPos()
        {
            Camera cam = Camera.main;
            Vector2 position = cam.WorldToScreenPoint(transform.position);
            return position + healthBarOffset;
        }
        void Update()
        {
            if (healthSlider)
            {
                healthSlider.transform.position = GetHealthBarPos();
            }
        }
        public void SpawnHealthBare(Transform parent)
        {
            GameObject clone = Instantiate(healthBarUI, GetHealthBarPos(), Quaternion.identity, parent);
            healthSlider = clone.GetComponent<Slider>();








        }
        public void DealDamage(float damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }

    }
}