# C#运行环境

## 什么是.net(dotnet)?

全称应该为.net framework。.NET框架是一个多语言组件开发和执行环境，它提供了一个跨语言的统一编程环境。.NET框架又包括三个主要组成部分：公共语言运行库（CLR：Common Language Runtime）、[服务框架](https://baike.baidu.com/item/服务框架)（Services Framework）和上层的两类应用模板——传统的Windows应用程序模板（Win Forms）和基于ASP.NET的面向Web的网络应用程序模板（Web Forms和Web Services）。

.NET FrameWork的核心是其运行库执行环境，称为公共语言运行库(CLR，Common Language Runtime)。

.Net 编程语言的编译器会将代码编译成中间语言（Intermediate Language,IL）代码。IL代码看起来像面向对象的机器码，使用工具ildasm.exe可以打开包含.net代码的dll或exe文件来检查il代码。CLR包含了一个及时（just-in-time,jit)编译器，当程序开始运行时，jit编译器会从il代码生成本地代码。

## .net编程语言的编译过程以及CLR作用？

**在.net中，**
**(1)将源代码编译成mircrosoft中间语言（Intermediate Language,IL）代码。**
**(2)CLR把IL编译为平台专用的本地代码。**
**IL代码在.net程序集中可用。在运行时，jit编译器编译IL代码，创建特定于平台的本地代码。**

**CLR还包括一个带有类型加载器的类型系统，类型加载器负责从程序集中加载类型。CLR的另一个功能是垃圾回收器，垃圾回收器从托管堆中清除不再引用的内存。CLR还负责线程的处理。在C#中创建托管的线程不一定来自底层操作系统。线程的虚拟化和管理由CLR负责。**

