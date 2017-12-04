namespace App.Core.Shared.Models.Messages
{
    /// <summary>
    /// Model of the response from a malware check.
    /// </summary>
    public class MediaMalwareScanResult
    {
    public bool LatestScanMalwareDetected { get; set; }
    public string LatestScanResults { get; set; }
    }
}