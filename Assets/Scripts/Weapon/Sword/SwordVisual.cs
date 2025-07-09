using UnityEngine;


public class SwordVisual : MonoBehaviour
{

    [SerializeField] private Sword sword;

    private Animator animator;
    private const string ATTACK = "Attack";


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        sword.OnSwordSwing += Sword_OnSwordSwing;
    }

    private void Sword_OnSwordSwing(object sender, System.EventArgs e)
    {
        animator.SetTrigger(ATTACK);
    }

    public void TriggerEndAttackAnimation()
    {
        sword.AttackColliderTurnOff();
    }
    private void OnDestroy()
    {
        sword.OnSwordSwing -= Sword_OnSwordSwing;
    }

}
