Dim service As SPWebService = SPWebService.ContentService

Dim myModification As New SPWebConfigModification()
myModification.Path = "configuration/SharePoint/SafeControls"
myModification.Name = "SafeControl[@Assembly='MyCustomAssembly'][@Namespace='MyCustomNamespace'][@TypeName='*'][@Safe='True']"
myModification.Sequence = 0
myModification.Owner = "User Name"
myModification.Type = SPWebConfigModification.SPWebConfigModificationType.EnsureChildNode
myModification.Value = "<SafeControl Assembly='MyCustomAssembly' Namespace='MyCustomNamespace' TypeName='*' Safe='True' />"
service.WebConfigModifications.Add(myModification)

'Call Update and ApplyWebConfigModifications to save changes
service.Update()
service.ApplyWebConfigModifications()
