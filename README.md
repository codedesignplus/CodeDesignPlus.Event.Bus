
<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Build status](https://dev.azure.com/codedesignplus/Software%20Development%20Kit/_apis/build/status/CodeDesignPlus.Event.Bus%20-%20CI)](https://dev.azure.com/codedesignplus/Software%20Development%20Kit/_build/latest?definitionId=6)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=CodeDesignPlus.Event.Bus.Key&metric=bugs)](https://sonarcloud.io/dashboard?id=CodeDesignPlus.Event.Bus.Key)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=CodeDesignPlus.Event.Bus.Key&metric=code_smells)](https://sonarcloud.io/dashboard?id=CodeDesignPlus.Event.Bus.Key)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=CodeDesignPlus.Event.Bus.Key&metric=coverage)](https://sonarcloud.io/dashboard?id=CodeDesignPlus.Event.Bus.Key)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=CodeDesignPlus.Event.Bus.Key&metric=duplicated_lines_density)](https://sonarcloud.io/dashboard?id=CodeDesignPlus.Event.Bus.Key)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=CodeDesignPlus.Event.Bus.Key&metric=ncloc)](https://sonarcloud.io/dashboard?id=CodeDesignPlus.Event.Bus.Key)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=CodeDesignPlus.Event.Bus.Key&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=CodeDesignPlus.Event.Bus.Key)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=CodeDesignPlus.Event.Bus.Key&metric=alert_status)](https://sonarcloud.io/dashboard?id=CodeDesignPlus.Event.Bus.Key)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=CodeDesignPlus.Event.Bus.Key&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=CodeDesignPlus.Event.Bus.Key)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=CodeDesignPlus.Event.Bus.Key&metric=sqale_index)](https://sonarcloud.io/dashboard?id=CodeDesignPlus.Event.Bus.Key)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=CodeDesignPlus.Event.Bus.Key&metric=vulnerabilities)](https://sonarcloud.io/dashboard?id=CodeDesignPlus.Event.Bus.Key)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=CodeDesignPlus.Event.Bus.Key&metric=security_rating)](https://sonarcloud.io/dashboard?id=CodeDesignPlus.Event.Bus.Key)
<!-- PROJECT LOGO -->

<br />
<p align="center">
  <a href="https://github.com/codedesignplus/CodeDesignPlus.Event.Bus/README">
    <img src="logo.png" alt="Logo">
  </a>

  <h3 align="center">CodeDesignPlus.Event.Bus</h3>

  <p align="center">
    Librer�a que contiene servicios base para la implementaci�n del patr�n publish/subscribe.
    <br />
    <a href="https://github.com/codedesignplus/CodeDesignPlus.Event.Bus/README"><strong>Explore the docs �</strong></a>
    <br />
    <br />
    <a href="https://github.com/codedesignplus/CodeDesignPlus.Event.Bus/issues">Report Bug</a>
    �
    <a href="https://github.com/codedesignplus/CodeDesignPlus.Event.Bus/issues">Request Feature</a>
  </p>
</p>



<!-- TABLE OF CONTENTS -->
## Table of Contents

* [About the Project](#about-the-project)
  * [Built With](#built-with)
* [Getting Started](#getting-started)
  * [Prerequisites](#prerequisites)
  * [Installation](#installation)
* [Usage](#usage)
* [Roadmap](#roadmap)
* [Contributing](#contributing)
* [License](#license)
* [Contact](#contact)
* [Acknowledgements](#acknowledgements)



<!-- ABOUT THE PROJECT -->
## About The Project

<p align="center">
    <img src="doc/images/CodeDesignPlus.Event.Bus.png" alt="Logo">
</p>

Este proyecto tiene como objetivo proveer las interfaces, servicios, middleware, opciones y m�todos 
de extensi�n para la implementaci�n del patr�n publish/subscribe en sus proyectos Web, Api, Desktop 
desarrollados en .Net Core.

De igual forma esta librer�a es usada para la implementaci�n de la caracter�stica Publish/Subscribe que se desarrollara en el Microservicio Template como se evidencia en la siguiente imagen:

<p align="center">
    <img src="doc/images/Microservice.Features.png" alt="Logo">
</p>

Toda la informaci�n del desarrollo de la librer�a la encontrar disponible en el siguiente enlace:

*Curso Microservicios:* <br>
https://www.youtube.com/playlist?list=PLiNuKK_lURW83zP828ACAHev-RZWOop-3

*Librer�a CodeDesignPlus.Event.Bus* <br>
1. [Introducci�n](https://youtu.be/z2KgqupxqhE)
2. [Abstracciones, Exceptions](https://youtu.be/9JExRLPpehM)
3. [Subscription Manager](https://youtu.be/G8as5anhjqQ)
4. [Background Service Generic, Queue Generic and Extensions](https://youtu.be/hRyZlogi1hc)
5. [Unit Test - Part 1](https://youtu.be/YX4a3A6Oo10)
3. [Unit Test - Part 2](https://youtu.be/vODQyPc3qng)

### Built With

* [.Net 5](https://dotnet.microsoft.com/download)


<!-- GETTING STARTED -->
## Getting Started

Para obtener una copia local en funcionamiento siga los siguientes pasos:

1. Clone este repositorio en su computador.
2. Para abrir el proyecto
    <ul>
        <li>Descargue e instale la versi�n de <a target="_blank" href="https://www.youtube.com/watch?v=U9vh-v1buyc&list=PLiNuKK_lURW8-Nmp8rZNPI2-bs94vzKCj&index=9">Visual Studio Community 2019</a></li>
        <li>Doble click en el archivo <strong>CodeDesignPlus.Event.Bus.sln</strong></li>
    </ul>

### Prerequisites

Para restaurar los paquetes nuget puede ejecutar el siguiente comando solo si no esta usando Visual Studio Community

* powershell
```powershell
dotnet restore .\CodeDesignPlus.Event.Bus.sln
```

### Installation

1. Clone the repo
```powershell
git clone https://github.com/codedesignplus/CodeDesignPlus.Event.Bus.git
```
2. Retore Packages
```powershell
dotnet restore .\CodeDesignPlus.Event.Bus.sln
```

<!-- USAGE EXAMPLES -->
## Usage

Esta es una gu�a practica que lo llevara por una serie de pasos para la implementaci�n de CodeDesignPlus.Event.Bus en su proyecto .Net Core (Web - Api).

* "En Proceso"

Este ejemplo es desarrollado con [Visual Studio Comumnity](#getting-started), sin embargo usted es libre de usar la l�nea de comandos de dotnet para la creaci�n de la soluci�n, proyectos e instalaci�n de paquetes nuget.

Para un detalle completo lo invitamos a ver los videos de la creaci�n de la librer�a:

1. [Introducci�n](https://youtu.be/z2KgqupxqhE)
2. [Abstracciones, Exceptions](https://youtu.be/9JExRLPpehM)
3. [Subscription Manager](https://youtu.be/G8as5anhjqQ)
4. [Background Service Generic, Queue Generic and Extensions](https://youtu.be/hRyZlogi1hc)
5. [Unit Test - Part 1](https://youtu.be/YX4a3A6Oo10)
3. [Unit Test - Part 2](https://youtu.be/vODQyPc3qng)

<!-- ROADMAP -->
## Roadmap

Consulte [issues](https://github.com/othneildrew/Best-README-Template/issues) para obtener una lista de las funciones propuestas y problemas conocidos.

<!-- CONTRIBUTING -->
## Contributing

1. Fork the Project
2. Create your Feature Branch (`git checkout -b features/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<!-- LICENSE -->
## License

Distributed under the MIT License. See [LICENSE](LICENSE.md) for more information.



<!-- CONTACT -->
## Contact

CodeDesignPlus - [@CodeDesignPlus](https://www.facebook.com/Codedesignplus-115087913695067) - codedesignplus@outlook.com

Project Link: [CodeDesignPlus.Core](https://github.com/codedesignplus/CodeDesignPlus.Core)



<!-- ACKNOWLEDGEMENTS -->
## Acknowledgements

Queremos agradecer a cada uno de los miembros de la comunidad latina de desarrollo en la cual participamos llevando contenido d�a a d�a para as� seguir creciendo en conjunto.

* [Asp.Net Core en Espa�ol](https://www.facebook.com/groups/291405831518163/?multi_permalinks=670205453638197)
* [Asp.Net Core](https://www.facebook.com/groups/aspcore/?multi_permalinks=3454898711268798)
* [Asp.net Core -MVC Group](https://www.facebook.com/groups/2400659736836389/?ref=group_browse)
* [Asp.Net MVC (Espa�ol)](https://www.facebook.com/groups/180056992071066/?ref=group_browse)
* [.Net Core](https://www.facebook.com/groups/1547819181920312/?ref=group_browse)
* [.NET En Espa�ol PROGRAMADORES](https://www.facebook.com/groups/1537580353178689/?ref=group_browse)
* [ASP.Net Core/C#/MVC/API/Jquery/Html/Sql/Angular/Bootstrap.](https://www.facebook.com/groups/302195073639460/?ref=group_browse)
* [.NET en Espa�ol](https://www.facebook.com/groups/1191799410855661/?ref=group_browse)
* [Blazor - ASP.NET Core](https://www.facebook.com/groups/324620021830833/?ref=group_browse)
* [C# (.NET)](https://www.facebook.com/groups/354915134536797/?ref=group_browse)
* [ASP.NET MVC(C#)](https://www.facebook.com/groups/663936840427220/?ref=group_browse)
* [Programaci�n C# .Net Peru](https://www.facebook.com/groups/559287427442678/?ref=group_browse)
* [ASP.NET and ASP.NET Core](https://www.facebook.com/groups/160807057346964/?ref=group_browse)
* [ASP.NET AND .NET CORE](https://www.facebook.com/groups/147648562098634/?ref=group_browse)
* [C#, MVC & .NET CORE 3.1](https://www.facebook.com/groups/332314354403273/?ref=group_browse)
* [.NET Core Community](https://www.facebook.com/groups/2128178990740761/?ref=group_browse)
* [Desarrolladores .Net, C#, React](https://www.facebook.com/groups/2907866402565621/?ref=group_browse)
* [Programadores C#](https://www.facebook.com/groups/304179163001281/?ref=group_browse)
* [.NET Core](https://www.facebook.com/groups/136495930173074/?ref=group_browse)
* [ASP.NET EN ESPA�OL](https://www.facebook.com/groups/507683892666901/?ref=group_browse)
* [Desarrolladores Microsoft.Net](https://www.facebook.com/groups/169250349939705/?ref=group_browse)
* [ASP.NET Core](https://www.facebook.com/groups/141597583026616/?ref=group_browse)
* [Grupo de Desarrolladores .Net de Microsoft](https://www.facebook.com/groups/15270556519/?ref=group_browse)



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
