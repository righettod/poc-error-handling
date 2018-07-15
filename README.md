# Introduction

This repository is the code sandbox of the [OWASP Error Handling Cheat Sheet](https://www.owasp.org/index.php/Error_Handling_Cheat_Sheet).

All sandbox projects are stored in the **poc** folder.

Every project expose a single service that throw a exception in order to simulate an non-catched exception by the application and then simulate an unexpected error.

# IDE used

The following IDE has been used:
* Java based projects (sub folder with `java-` prefix) has been created using [IntelliJ IDEA Community Edition](https://www.jetbrains.com/idea/download/).
* .Net based projects (sub folder with `aspnet-` prefix) has been created using [Visual Studio Community Edition](https://visualstudio.microsoft.com/downloads/).

Projects can be directly **opened** and **run** using the associated IDE (a *Run Configuration* has been added for Java project).

# Command line to test the error handling

The following `curl` command line can be used to trigger the error handling.

Project: *java-classic-web-application*

```
curl -v http://localhost:9090/service
```

Project: *java-springboot-web-application*

```
curl -v http://localhost:8080/greeting
```

Project: *aspnet-core-web-application*

```
curl -v http://localhost:[PORT]/api/values
```

Project: *aspnet-webapi-web-application*

```
curl -v http://localhost:[PORT]/api/values
```
