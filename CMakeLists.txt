# Referenced from StackOverflow article
# https://stackoverflow.com/questions/2074144/generate-c-sharp-project-using-cmake/46247927#46247927

cmake_minimum_required( VERSION 3.25.1 )

project( Astra
         LANGUAGES CSharp
)

include( CSharpUtilities )

add_executable(
    Astra
    Viewer/App.config
    Viewer/App.xaml
    Viewer/App.xaml.cs
    Viewer/MainWindow.xaml
    Viewer/MainWindow.xaml.cs
    Viewer/Properties/AssemblyInfo.cs
    Viewer/Properties/Resources.Designer.cs
    Viewer/Properties/Resources.resx
    Viewer/Properties/Settings.Designer.cs
    Viewer/Properties/Settings.settings
)

csharp_set_designer_cs_properties(
    Viewer/Properties/AssemblyInfo.cs
    Viewer/Properties/Resources.Designer.cs
    Viewer/Properties/Resources.resx
    Viewer/Properties/Settings.Designer.cs
    Viewer/Properties/Settings.settings
)

csharp_set_xaml_cs_properties(
    Viewer/App.xaml
    Viewer/App.xaml.cs
    Viewer/MainWindow.xaml
    Viewer/MainWindow.xaml.cs
)

set_property(
    SOURCE
    Viewer/App.xaml
    PROPERTY
    VS_XAML_TYPE "ApplicationDefinition"
)

set_property(
    TARGET
    Astra
    PROPERTY
    VS_DOTNET_TARGET_FRAMEWORK_VERSION
    "v4.8" )

set_property(
    TARGET
    Astra
    PROPERTY
    WIN32_EXECUTABLE
    TRUE
)

set_property(
    TARGET
    Astra
    PROPERTY
    VS_DOTNET_REFERENCES
    "Microsoft.CSharp"
    "PresentationCore"
    "PresentationFramework"
    "System"
    "System.Core"
    "System.Data"
    "System.Data.DataSetExtensions"
    "System.Net.Http"
    "System.Xaml"
    "System.Xml"
    "System.Xml.Linq"
    "WindowsBase"
)
