namespace RunnerApi
{
    public interface Blink
    {
        void BeginBlink(float period);
        void StopBlink();
        bool IsBlinked();
    }
}
