# Release 3.1.1

- Nuke 7.0.0 support
- Build project reworked with using source generators
- The version of the projects is now unified and set for all projects in the Build.Configuration file. Version applies to installer and .dll packages
- Installer project reworked
- Installer project now supports SingleUser and MultiUser builds
- Installer project now supports feature tree for Revit versions

  ![image](https://github.com/Nice3point/RevitTemplates/assets/20504884/d5a3431d-7704-422c-8eba-9c06a00cf0a3)
- New MS Build target. Triggers when the project is cleaned up and deletes the plugin files in the revit addin folder
- Full changelog: https://github.com/Nice3point/RevitTemplates/compare/3.0.1...3.1.1