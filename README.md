# NCMConverter
原项目地址:[ncmdump](https://github.com/taurusxin/ncmdump)
## 食用方式
下载dll[libncmdump]()，放在输出目录（或者始终复制）

or

(需要客户机联网，不建议使用)调用`Convert.GetDllFile()`自动下载

### 方法
请先using NCMConverter

### 单文件

- #### `int Converter.Convert(string sourceFileName)`

`sourceFileName`:源文件绝对路径

返回值:基本不用管，return 0成功，return 1失败，return -1找不到dll

结果：在源文件目录下生成转化后的文件

- #### `int Converter.Convert(string sourceFileName,string destFolderName)`

`sourceFileName`:源文件绝对路径

`destFolderName`:输出目录绝对路径

返回值:基本不用管，return 0成功，return 1失败，return -1找不到dll

结果：在`destFolderName`下生成转化后的文件

### 目录（当前不支持多层目录，只能转换给定目录下的文件，如有文件夹不会搜索）

- #### `int Converter.ConvertDir(string sourceDirName)`

`sourceFileName`:多个源文件所在的目录路径(如：C:/Music)

返回值:成功转换的个数

结果：将给定目录下所有ncm文件转换并存储在源目录

- #### `int Converter.Convert(string sourceFileName,string destFolderName)`

`sourceFileName`:多个源文件所在的目录路径(如：C:/Music)

`destFolderName`:输出目录绝对路径

返回值:成功转换的个数

结果：在`destFolderName`下生成给定目录下所有ncm文件的生成文件

