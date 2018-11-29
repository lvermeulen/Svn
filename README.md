![Icon](https://i.imgur.com/X3pvC1T.png)
# Svn
[![Build status](https://ci.appveyor.com/api/projects/status/x3un8b54yj0uh8l8?svg=true)](https://ci.appveyor.com/project/lvermeulen/svn) [![license](https://img.shields.io/github/license/lvermeulen/svn.svg?maxAge=2592000)](https://github.com/lvermeulen/svn/blob/master/LICENSE) [![NuGet](https://img.shields.io/nuget/v/svn.svg?maxAge=86400)](https://www.nuget.org/packages/svn/) ![](https://img.shields.io/badge/.net-4.5-yellowgreen.svg) ![](https://img.shields.io/badge/netstandard-1.4-yellowgreen.svg)

A collection of SVN utilities.

## Features:
* svn info [TARGET[@REV]...]

## Usage:

* Get the current revision number for folder "C:\my\svn\repo" and output it to an environment variable named SVNRevision:
~~~~
    svncommander 
        --command "info" 
        --argument "revision" 
        --directory "C:\my\svn\repo"
        --output "envvar"
        --name "SVNRevision"
        --pathToSvnExe "C:\Program Files\TortoiseSVN\bin\svn.exe"
~~~~
