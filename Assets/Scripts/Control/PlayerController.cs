 using UnityEngine;

namespace RPG.Control
{
    using System;
    using RPG.Movement;
    using RPG.Combat;

    public class PlayerController : MonoBehaviour
    {
        private void Update()
        {
            if(InteractWithCombat()) return;    // TODO Remove later: return early if interacted with combat. Works like a continue. It skips over the rest of the body (i.e. exits Update)
            if(InteractWithMovement()) return;
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
               CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if(!GetComponent<Fighter>().CanAttack(target))
                {
                    continue;
                }

               if(Input.GetMouseButtonDown(0))
               {
                    GetComponent<Fighter>().Attack(target);     // TODO Remove later: who we are going to attack when we start the attacking process.
               }
               return true;                                     // TODO Remove later: Returns even if the player is only hovering over an enemy with the mouse
            }
            return false;                                       // TODO Remove later: Didn't find any combat targets to interact with.
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
