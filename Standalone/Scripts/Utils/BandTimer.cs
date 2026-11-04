using System.Threading;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class BandTimer
{
    [SerializeField]
    private float interval;
    public float Interval { get { return interval; } set { interval = value; } }

    [SerializeField]
    private bool autoStart = false;
    public bool AutoStart { get { return autoStart; } set { autoStart = value; } }

    [SerializeField]
    private bool oneShot = false;

    public bool OneShot { get { return oneShot; } set { oneShot = value; } }

    private float passedTime = 0;

    public float TimeLeft { get { return interval - passedTime; } }

    [SerializeField]
    public UnityEvent OnTimeout = new UnityEvent();

    private CancellationTokenSource cts;

    private enum TimerStatus
    {
        Running,
        Paused,
        Stopped
    }

    private TimerStatus status = TimerStatus.Stopped;

    public BandTimer()
    {
        if (AutoStart)
            Start();
    }

    public void Start()
    { 
        if(cts != null)
        {
            cts.Cancel();
            cts.Dispose();
        }
        passedTime = 0;
        cts = new CancellationTokenSource();
        status = TimerStatus.Running;
        Run(cts);
    }

    private async void Run(CancellationTokenSource cts)
    {
        while (!IsStopped())
        {   
            if(cts.IsCancellationRequested)
                return;
            if (IsRunning())
            {
                await Awaitable.EndOfFrameAsync();
                passedTime += Time.deltaTime;
                if (passedTime >= interval)
                {
                    OnTimeout?.Invoke();
                    if (OneShot)
                        Stop();
                    else passedTime -= interval;
                }
            }
        }
    }

    public void Pause(bool pause)
    {
        if(IsStopped())
            return;
        status = pause ? TimerStatus.Paused : TimerStatus.Running;
    }

    public void Stop()
    {
        status = TimerStatus.Stopped;
        passedTime = 0;
        if (cts != null)
        {
            cts.Cancel();
            cts.Dispose();
            cts = null;
        }
    }

    public bool IsPaused()
    {
        return status == TimerStatus.Paused;
    }

    public bool IsRunning()
    {
        return status == TimerStatus.Running;
    }

    public bool IsStopped()
    {
        return status == TimerStatus.Stopped;
    }
}
