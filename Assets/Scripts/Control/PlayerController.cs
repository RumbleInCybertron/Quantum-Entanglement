 using UnityEngine;

namespace RPG.Control
{
    using System;
    using RPG.Movement;
    using RPG.Combat;
    using RPG.Core;

    public class PlayerController : MonoBehaviour
    {
        Health health;

        private void Start()
        {
            health = GetComponent<Health>();
        }

        private void Update()
        {
            if (health.IsDead()) return;
            if (InteractWithCombat()) return;    // TODO Remove later: return early if interacted with combat. Works like a continue. It skips over the rest of the body (i.e. exits Update)
            if (InteractWithMovement()) return;
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
               CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target == null) continue;

                if(!GetComponent<Fighter>().CanAttack(target.gameObject))
                {
                    continue;
                }

               if(Input.GetMouseButton(0))
               {
                    GetComponent<Fighter>().Attack(target.gameObject);     
               }
               return true;                                     
            }
            return false;                                       
        }

        private bool InteractWithMovement()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (hasHit)
            {
               if( Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().StartMoveAction(hit.point);
                }
                return true;
            }
            return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}
