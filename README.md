# Intus Task Project

It is .Net 7 Blazor WebAssembly Project.
It is follow Layered Architecture And seperated DAL, BLL, DTO Project. Here implemented
Async Programming, Navigation, Dependency Injection etc.

### Here is two main project
- Blazor.Server: .Net 7 Web API with Entity Framework Code First Approach
- Blazor.Client: Blazor WebAssembly App

## Prerequisite to run this applicaton
First install Visual Studio 2022 with .Net 7.0 sdk. Open this project into visual studio 2022. 

```bash
Then Go to the appsettings.json file in Blazor.Server.
```
![appsettings](https://github.com/sthossan/IntusProject/blob/master/upload-images/appst.JPG?raw=true)

```bash
Change Db credentials from appsettings.json
```
![connection](https://github.com/sthossan/IntusProject/blob/master/upload-images/connection.JPG?raw=true)

```bash
Then select Blazor.Server as startup project and press F5
```
![ssp](https://github.com/sthossan/IntusProject/blob/master/upload-images/s-s-p.png?raw=true)


### This project using Entity Framework 7 Code First Approach. Automatically DB will create and migrate when this project starts.

## Pages
All page seperated by two category one is Form another is List.By default show order page.

Fill the form inputs and click save button, it will save in DB and automatically show in list without page refreshing.
## Order Page
![1](https://github.com/sthossan/IntusProject/blob/master/upload-images/o-list.JPG?raw=true)

Click pencil icon from list, which you want to edit. After click pencil icon Data show in the form inputs fields and automatically button text change to Save Changes.

![2](https://github.com/sthossan/IntusProject/blob/master/upload-images/o-edit.JPG?raw=true)

## Window Page
Here TotalSubElements will be change after SubElements CUD process.
![3](https://github.com/sthossan/IntusProject/blob/master/upload-images/w-list.JPG?raw=true)

![4](https://github.com/sthossan/IntusProject/blob/master/upload-images/w-edit.JPG?raw=true)

## SubElement Page
![5](https://github.com/sthossan/IntusProject/blob/master/upload-images/s-list.JPG?raw=true)

![6](https://github.com/sthossan/IntusProject/blob/master/upload-images/s-edit.JPG?raw=true)