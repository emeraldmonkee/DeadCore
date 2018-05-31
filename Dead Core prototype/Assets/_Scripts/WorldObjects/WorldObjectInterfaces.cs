public interface IDestroyable
{
    void Destroy();
}

public interface IDamageable<T>
{
    void TakeDamage(T amount);
}

public interface IInteractable
{
    void Interact();
}