# NCMConverter
原项目地址:[ncmdump](https://github.com/taurusxin/ncmdump)
## 食用方式
下载dll[libncmdump](https://github.com/taurusxin/ncmdump/files/13992246/libncmdump.zip)，更名为taurusxin.LibNcmDump.dll，放在输出目录（或者始终复制）

### 方法
请先using NCMConverter
- ### `int Converter.Convert(string sourceFileName)`
`sourceFileName`:源文件绝对路径
返回值:基本不用管，return 0成功，return 1失败
结果：在源文件目录下生成转化后的文件

- ### `int Converter.Convert(string sourceFileName,string destFolderName)`
`sourceFileName`:源文件绝对路径
`destFolderName`:输出目录绝对路径
返回值:基本不用管，return 0成功，return 1失败
结果：在`destFolderName`下生成转化后的文件
