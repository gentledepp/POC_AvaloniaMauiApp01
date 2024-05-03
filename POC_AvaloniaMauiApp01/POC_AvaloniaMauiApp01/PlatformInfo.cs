namespace POC_AvaloniaMauiApp01;

public interface IPlatformInfo
{
    Platform Platform { get; }
}

public enum Platform
{
    Unknown,
    Windows,
    iOS,
    Android,
    Browser
}