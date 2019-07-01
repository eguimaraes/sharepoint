Add-SPSolution
   [-LiteralPath] <String>
   [-AssignmentCollection <SPAssignmentCollection>]
   [-Confirm]
   [-Language <UInt32>]
   [-WhatIf]
   [<CommonParameters>]
   Add-SPSolution -LiteralPath c:\contoso_solution.wsp
   Add-SPSolution -LiteralPath $PWD\"TableauWP.wsp"
   

Install-SPSolution
       [-Identity] <SPSolutionPipeBind>
       [-AllWebApplications]
       [-AssignmentCollection <SPAssignmentCollection>]
       [-CASPolicies]
       [-CompatibilityLevel <String>]
       [-Confirm]
       [-Force]
       [-FullTrustBinDeployment]
       [-GACDeployment]
       [-Language <UInt32>]
       [-Local]
       [-Time <String>]
       [-WebApplication <SPWebApplicationPipeBind>]
       [-WhatIf]
       [<CommonParameters>]

Install-SPSolution -Identity contoso_solution.wsp -GACDeployment

Install-SPSolution -Identity contoso_solution.wsp -GACDeployment -CompatibilityLevel {14,15}

Install-SPFeature
       [-Path] <String>
       [-AssignmentCollection <SPAssignmentCollection>]
       [-CompatibilityLevel <Int32>]
       [-Confirm]
       [-Force]
       [-WhatIf]
       [<CommonParameters>]
Install-SPFeature -path "MyCustomFeature"
