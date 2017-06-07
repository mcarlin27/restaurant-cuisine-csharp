# Best Restaurants

#### A program that allows users to search for best restaurants by cuisine. 6/7/17

#### By **Marilyn Carlin and Andrew Glines**

## Description

A website created with C# and HTML where a ...


### Specs
| Spec | Input | Output |
| :-------------     | :------------- | :------------- |
| **User can add cuisine type to DB** | add Japanese | Japanese |
| **User can view all cuisine types** | View All Cuisines  | Japanese, Tex-Mex, Modern American, Tapas |
| **User can update existing cuisine types**| Edit Tex-Mex | Mexican |
| **User can delete all cuisine types**| Delete All Cuisine Types | List Cleared! |
| **User can delete individual cuisines** | Delete: Japanese | "Japanese cuisine has been deleted!" |
| **User can add restaurant to DB** | add Saburo's | Saburo's |
| **User can add cuisine type to restaurant** | Saburo's | Saburo's: Sushi |
| **User can view all restaurants** | View All Restaurants  | Saburo's, Jam, Tom Yum |
| **User can update existing restaurant**| Edit Tani's | Shoko's Sushi |
| **User can delete all restaurants**| Delete All Restaurants | List Cleared! |
| **User can delete individual restaurants** | Delete: Shoko's | "Shoko's has been deleted!" |
| **User can query restaurants by cuisine** | View All: Sushi | Shoko's, Saburo's |

## Setup/Installation Requirements

1. To run this program, you must have a C# compiler. I use [Mono](http://www.mono-project.com).
2. Install the [Nancy](http://nancyfx.org/) framework to use the view engine. Follow the link for installation instructions.
3. Clone this repository.
4. Open the command line--I use PowerShell--and navigate into the repository. Use the command "dnx kestrel" to start the server.
5. On your browser, navigate to "localhost:5004" and enjoy!

## Known Bugs
* No known bugs at this time.

## Technologies Used
* C#
  * Nancy framework
  * Razor View Engine
  * ASP.NET Kestrel HTTP server
  * xUnit

* HTML

## Support and contact details

_Email no one with any questions, comments, or concerns._

### License

*{This software is licensed under the MIT license}*

Copyright (c) 2017 **_{Marilyn Carlin, Andrew Glines}_**
