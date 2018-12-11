MyAuthWS
-----
This is a C# Webservice Sample with SOAP Header Authentication<br>
https://dotblogs.com.tw/michaelfang/2018/12/11/webservice-soap-header

```
MyWebService    (webservice with soap header authentication)
MyAuthWS.Tests  (unit test)
```
Installation
------------
```
git clone MyAuthWS https://github.com/michaelfangtw/MyAuthWS.git
```

Git Notes
------------
```
d:
cd D:\git\MyAuthWS
git init
git add .
git status
git commit -m "first commit"
rem MyCodeFirstLab
git remote add origin https://github.com/michaelfangtw/MyAuthWS.git
rem origin =remote repos
rem master =local repos
git push -u origin master
```

Usage
------------
Open /src/MyAuthWS.sln via Visual Studio 2017

Issues
-------
Found a bug? Create an issue on GitHub.


For transparency and insight into the release cycle, releases will be numbered with the follow format:

`<major>.<minor>.<patch>`

And constructed with the following guidelines:

* Breaking backwards compatibility bumps the major (無法向前相容)
* New additions without breaking backwards compatibility bumps the minor (可向前相容的功能新增)
* Bug fixes and misc changes bump the patch (修正Bug)

For more information on semantic versioning, please visit http://semver.org/.

License
-------

Copyright (c) 2018 [Michael Fang](http://funtech.tw)  
Licensed under the MIT License.











