namespace TEK.Core.App.Job.Models
{
    public sealed class JobScheduleSetting
    {
        public JobScheduleCron JobSchedule { get; set; }
    }

    public class JobScheduleCron
    {
        public string DeviceSchedule { get; set; }
    }
}
