Install-SPSolution -Identity contoso_solution.wsp -GACDeployment
Install-SPSolution -Identity contoso_solution.wsp -GACDeployment -CompatibilityLevel {14,15}
Install-SPSolution -Identity contoso_solution.wsp -GACDeployment -AllWebApplications
