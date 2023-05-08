﻿using Employee.Common.Dtos.Job;

namespace Employee.Common.Interfaces;

public interface IJobService
{
    Task<int> CreateJobAsync(JobCreate jobCreate);
    Task UpdateJobAsync(JobUpdate jobUpdate);
    Task<List<JobGet>> GetJobsAsync();
    Task<JobGet> GetJobAsync(int id);
    Task DeleteJobAsync(JobDelete jobDelete);
}
