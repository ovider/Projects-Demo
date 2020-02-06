Imports System.Runtime.CompilerServices
Imports AutoMapper
Imports Unity

NotInheritable Class MappingConfig
    Public Shared Sub RegisterMaps(container As IUnityContainer)
        Dim cfg = New MapperConfiguration(AddressOf ConfigureMappings)

        container.RegisterInstance(Of IConfigurationProvider)(cfg)

        Dim mapper = cfg.CreateMapper()

        container.RegisterInstance(mapper)
    End Sub

    Private Shared Sub ConfigureMappings(config As IMapperConfigurationExpression)
        '' include all the profiles from the assembly

        Dim baseProfileType = GetType(Profile)

        Dim profiles = GetType(MappingConfig).Assembly.GetTypes() _
            .Where(Function(t) t.IsSubclassOf(baseProfileType)) _
            .Where(Function(t) Not t.IsAbstract) _
            .Select(Function(t) Activator.CreateInstance(t)) _
            .OfType(Of Profile) _
            .ToList()

        For Each profile In profiles
            config.AddProfile(profile)
        Next
    End Sub

End Class
