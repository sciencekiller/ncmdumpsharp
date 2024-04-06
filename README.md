# NCMConverter
## 请务必升级到最新版本，旧版本会下载新版本的dll导致报错！ 

原项目地址:[ncmdump](https://github.com/taurusxin/ncmdump)

本nuget包地址:[ncmdumpsharp](https://github.com/sciencekiller/ncmdumpsharp)，以后用不了了记得提issue。今天早上才发现用不了了，是上游dll更新，但是我代码没改，现在改好了，抱歉qwq。

两项目都是开源项目，不收取任何费用，请给一个star。
## 食用方式
下载dll[libncmdump]()，放在输出目录（或者始终复制）

或

(需要客户机联网，不建议使用)调用`Convert.GetDllFile()`自动下载



### 方法
请先using NCMConverter

### 单文件

`int Converter.Convert(string sourceFileName,string outputpath,bool overwrite)`

`sourceFileName`:源文件绝对路径

`outputpath`:（可选）输出目录，留空（值为default）输出到源文件目录

`overwrite`:（可选）覆盖已存在的转换后文件，默认为false

返回值:return 0成功，return 1失败，return -1找不到dll


### 目录（当前不支持多层目录，只能转换给定目录下的文件，如有文件夹不会搜索）

`int Converter.ConvertDir(string sourceDirName,string outputpath,bool scanalldir)`

`sourceFileName`:多个源文件所在的目录路径(如：C:/Music)

`outputpath`:（可选）输出目录，留空（值为default）输出到源文件目录

`scanalldir`:（可选）是否扫描文件下子目录，默认为false

`overwrite`:（可选）覆盖已存在的转换后文件，默认为false

返回值:成功转换的个数

### DLL相关

`Converter.RemoveLocalDLLFile()`用于删除本地DLL

`Convert.GetDllFile(bool overwrite)`从GitHub（其实内置了代理代理的，不会访问不了）下载DLL,overwrite默认为false,为true时会覆盖本地文件



