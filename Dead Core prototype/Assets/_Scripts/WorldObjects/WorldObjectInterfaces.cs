public interface IDestroyable
{
    void Destroy();
}

public interface IDamageable<T>
{
    T StartHealth { get; set; }
    T CurrentHealth { get; set; }
    void TakeDamage(T amount);
}

public interface IInteractable
{
    void Interact();
}