﻿namespace EmployeeApi.Common.Dtos.Teams;

public record TeamUpdate(int Id, string Name, List<int> Employees);