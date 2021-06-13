namespace ReversePlatformer
{
    public interface IJumpable
    {
        (JumpableTypes, bool) onJumpableApproach();
    }
}