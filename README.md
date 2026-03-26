# thingworx-deployment-utility
An utility written in C# that allows quick deployment between environments for ThingWorx projects and creation of Extension packages

Prerequisites to run this utility:
- Windows running .NET 8.0
- ThingWorx instance allowing connection via AppKey

# How to download it (choose one of the 2 options below):
1. Download the extension from the Releases section on top of the page, link here for ease of use: [Releases](https://github.com/vrosu/thingworx-deployment-utility/releases).
2. Install Microsoft Visual Studio Community 2022 (64-bit). This application was created using MS VS Community Version 17.14.29 (March 2026)
   - Download the entirey repository
   - Click on File / Open / Project/Solution
   - Select the ThingWorxDeploymentUtility.sln
   - Run or modify it like any other C# application


# Capabilities:
This utility provides 2 main capabilities:
1. Provides an easy way to transfer Projects between 2 environments as Source Controlled Entities. This functionality is using the standard ThingWorx APIs that are used in Composer to perform the same actions.
   <img width="986" height="577" alt="image" src="https://github.com/user-attachments/assets/9c5e7a3c-c1e8-4202-aa2e-09b7a9e02cde" />
The projects are transferred
2. Generate and download Extensions and SourceControlledExports packages. This capability is useful in order to be able to download locally a generated extension or SCE package, in order to either import it manually or store it in another storage system. Note that extensions are not importable directly via this utility and must be imported manually.

Note: the same functionality can be achieved in a ThingWorx application, however, since deploying an application from Environment 1 to Environment 2 would require the AppKey for Environment 2 to be used/stored in Environment 1, this would violate the separation between environments

# How to use:

Before using the intended capabilities, ThingWorx environments need to be registered in the application (minimum 2).
This functionality is achieved by the Settings button:
<img width="975" height="578" alt="image" src="https://github.com/user-attachments/assets/6587df68-062d-4442-a827-56489d5e687d" />
Steps to register a ThingWorx environment:
1. Click on Settings button
2. Fill in in the resulting popup window the necessary details. The Environment URL must end with /Thingworx. A valid File Repository must be provided. The utility requires 2 **already existing folders** in the File Repository:
   1. **Repository Packaging Path**: path where the SCE packages will be generated when pressing the "1. Generate SCE Package in Environment 1"
   2. **Repository Receiving Path**: path where the SCE package will be copied when pressing the "2. Copy SCE Package to Environment 2"
3. Click on Save
Environments can be deleted by pressing the "-" sign.

## 1. Transferring projects as SCE from one environment to another:

  1. Select the **source environment** in the LEFT section
  2. Select the **target environment** in the RIGHT section
  3. Select the desired **project** in the LEFT section. The following steps follow this workflow: <img width="551" height="102" alt="image" src="https://github.com/user-attachments/assets/a748e561-c3fe-430b-a517-4366deca48a3" />
  5. Click on the "**1. Generate SCE Package in Environment 1**" button. A popup will show up to inform you the package was created.
  6. Select the created ZIP package that contains the SCE entities in the LEFT section. Make sure you selected the right package.
  7. Click on the "**2. Copy SCE Package to Environment 2**" button. A popup will show up after the transfer to inform you the package was transferred successfully.
  8. Select the transferred ZIP package in the RIGHT section. Make sure you selected the right package.
  9. Click on the "**3. Import selected SCE Package in Environment 2**" button. The project will be imported as SCE and once the import finished a popup will show up to inform you about this.
  10. Click on the Application Log link on the RIGHT section and verify manually that the import finished successfully. This step is optional, but highly recommended.
## 2. Generate and download Extensions and SCE packages:

   1. Select the **source environment** in the LEFT section
   2. Select the desired **project** in the LEFT section.
   3. Click on the "**1. Generate SCE Package in Environment 1**" button. A popup will show up to inform you the package was created.
   4. Select the created ZIP package that contains the SCE entities in the LEFT section. Make sure you selected the right package.
   5. Depending on the desired action:
        1. To generate and download an Extension:
           1. Click on the black download icon <img width="146" height="42" alt="image" src="https://github.com/user-attachments/assets/9117c8a6-4ae2-43f0-a944-7d6a675528a4" />
           2. Insert the desired values in the popup window <img width="337" height="146" alt="image" src="https://github.com/user-attachments/assets/7a18e9a3-8956-4d42-a6ee-00e60f47cd7b" />
           3. Click on "Create Extension" button. This will trigger the extension creation and subsequently the local download process.
           4. A Explorer window will open in the current working directory where the application has been started from and BOTH the Extension and the corresponding SCE package will be there:<img width="369" height="53" alt="image" src="https://github.com/user-attachments/assets/e6981f4e-455c-4f0d-bd24-e9fe8e56efec" />
        2. To download an SCE package:
           1. Click on the white download icon <img width="124" height="44" alt="image" src="https://github.com/user-attachments/assets/9684929d-e0c4-4052-99e2-304d9eb2299e" />
           2. A Explorer window will open in the current working directory where the application has been started from and the  SCE package will be there.
## 3. Display differences between selected SCE packages
   1. Select any 2 SCE packages in the LEFT section
   2. Click on the "Display selected SCE Package differences". A message box will appear highlighting which entities are different in the selected packages. Note this functionality picks up differences in property timestamps so false negatives can show up.
      
      <img width="405" height="561" alt="image" src="https://github.com/user-attachments/assets/fb7d5dc9-ad27-42f3-b001-ca9b0ff483d4" />




In case you encounter issues or have suggestions for enhancements:
 - Please open issues [here](https://github.com/vrosu/thingworx-deployment-utility/issues) but be aware there's no guaranteed SLA or SLT.
 - Feel free to fork it - it's an Open Source extension and Pull Requests are accepted
 - Do not open PTC Technical Support tickets for this Extension, since it's not a PTC supported product.

# Disclaimer

By downloading this software, the user acknowledges that it is unsupported, not reviewed for security purposes, and that the user assumes all risk for running it.

Users accept all risk whatsoever regarding the security of the code they download.

This software is not an official PTC product and is not officially supported by PTC.

PTC is not responsible for any maintenance for this software.

PTC will not accept technical support cases logged related to this Software.

This source code is offered freely and AS IS without any warranty.

The author of this code cannot be held accountable for the well-functioning of it.

The author shared the code that worked at a specific moment in time using specific versions of PTC products at that time, without the intention to make the code compliant with past, current or future versions of those PTC products.

The author has not committed to maintain this code and he may not be bound to maintain or fix it.

# License

I accept the MIT License (https://opensource.org/licenses/MIT) and agree that any software downloaded/utilized will be in compliance with that Agreement. However, despite anything to the contrary in the License Agreement, I agree as follows:

I acknowledge that I am not entitled to support assistance with respect to the software, and PTC will have no obligation to maintain the software or provide bug fixes or security patches or new releases.

The software is provided “As Is” and with no warranty, indemnitees or guarantees whatsoever, and PTC will have no liability whatsoever with respect to the software, including with respect to any intellectual property infringement claims or security incidents or data loss.
