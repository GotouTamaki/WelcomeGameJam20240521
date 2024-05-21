using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    [SerializeField] protected int _score;
    [SerializeField] protected SESoundData.SE _seType = SESoundData.SE.GetItem;

    protected virtual void GetItem()
    {
        ScoreManager.Instance.AddScore(_score);
        AudioManager.Instance.PlaySE(_seType);
        Destroy(this.gameObject);

#if UNITY_EDITOR
        Debug.Log($"アイテムを獲得！");
#endif
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetItem();
        }
    }
}
