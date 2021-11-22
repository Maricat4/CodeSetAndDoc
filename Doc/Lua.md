# Lua

## 注释

注释:

```
--
```



多行注释：

```
--[[
 多行注释
 多行注释
 --]]
```



标识符：最好不要用下划线加大写字符的标示符，因为lua的保留字也是这样的。

全局变量与删除变量

默认情况下，变量总是认为是全局的。
如果想删除一个全局变量，只需要将变量赋值为nil。

## 数据类型:

| 数据类型 | 描述                                                         |
| :------- | :----------------------------------------------------------- |
| nil      | 这个最简单，只有值nil属于该类，表示一个无效值（在条件表达式中相当于false）。 |
| boolean  | 包含两个值：false和true。                                    |
| number   | 表示双精度类型的实浮点数                                     |
| string   | 字符串由一对双引号或单引号来表示                             |
| function | 由**C 或 Lua**编写的函数                                     |
| userdata | 表示任意存储在变量中的**C数据结构**                          |
| thread   | 表示执行的独立线路，用于执行协同程序                         |
| table    | Lua 中的表（table）其实是一个**"关联数组"（associative arrays）**，数组的索引可以是数字、字符串或表类型。在 Lua 里，table 的创建是通过"构造表达式"来完成，最简单构造表达式是{}，用来创建一个空表。 |

## 逻辑运算符

逻辑运算符and 的运算结果为：如果它的第一个操作数为“false”，则返回第一个操作数，否则返回第二个操作数。

逻辑运算符or 的运算结果为：如果它的第一个操作数不为“false”，则返回第一个操作数，否则返回第二个操作数。

not运算符的运算结果始终为

## 数值for循环

Lua 编程语言中数值for循环语法格式:

```
for var=exp1,exp2,exp3 do  
    <执行体>  
end  
```

var从exp1变化到exp2，每次变化以exp3为步长递增var，并执行一次"执行体"。exp3是可选的，如果不指定，默认为1。

## 泛型for循环

泛型for循环通过一个迭代器函数来遍历所有值，类似java中的foreach语句。

Lua 编程语言中泛型for循环语法格式:

```
--打印数组a的所有值  
for i,v in ipairs(a) 
	do print(v) 
end  
```

i是数组索引值，v是对应索引的数组元素值。ipairs是Lua提供的一个迭代器函数，用来迭代数组。

## 函数格式

Lua 编程语言函数定义格式如下：

```
optional_function_scope function function_name( argument1, argument2, argument3..., argumentn)
   function_body
 return result_params_comma_separated
end
```

解析：
- **optional_function_scope**: 该参数是可选的制定函数是全局函数还是局部函数？未设置该参数默认为全局函数，如果你需要设置函数为局部函数需要使用关键字local。
- **function_name:**指定函数名称。
- **argument1, argument2, argument3..., argumentn:**函数参数，多个参数以逗号隔开，函数也可以不带参数。
- **function_body:**函数体，函数中需要执行的代码语句块。
- **result_params_comma_separated:**函数返回值，Lua语言函数可以返回多个值，每个值以逗号隔开。

## 运算符

### 算术运算符

| 操作符 | 描述 | 实例               |
| :----- | :--- | :----------------- |
| +      | 加法 | A + B 输出结果 30  |
| -      | 减法 | A - B 输出结果 -10 |
| *      | 乘法 | A * B 输出结果 200 |
| /      | 除法 | B / A w输出结果 2  |
| %      | 取余 | B % A 输出结果 0   |
| ^      | 乘幂 | A^2 输出结果 100   |
| -      | 负号 | -A 输出结果v -10   |

### 关系运算符

| 操作符 | 描述                                                         | 实例                  |
| :----- | :----------------------------------------------------------- | :-------------------- |
| ==     | 等于，检测两个值是否相等，相等返回 true，否则返回 false      | (A == B) 为 false。   |
| ~=     | 不等于，检测两个值是否相等，相等返回 false，否则返回 true<   | (A ~= B) 为 true。    |
| >      | 大于，如果左边的值大于右边的值，返回 true，否则返回 false    | (A > B) 为 false。    |
| <      | 小于，如果左边的值大于右边的值，返回 false，否则返回 true    | (A < B) 为 true。     |
| >=     | 大于等于，如果左边的值大于等于右边的值，返回 true，否则返回 false | (A >= B) is not true. |
| <=     | 小于等于， 如果左边的值小于等于右边的值，返回 true，否则返回 false | (A <= B) is true.     |

### 逻辑运算符

| 操作符 | 描述                                                         | 实例                   |
| ------ | ------------------------------------------------------------ | ---------------------- |
| and    | 逻辑与操作符。 如果两边的操作都为 true 则条件为 true。       | (A and B) 为 false。   |
| or     | 逻辑或操作符。 如果两边的操作任一一个为 true 则条件为 true。 | (A or B) 为 true。     |
| not    | 逻辑非操作符。与逻辑运算结果相反，如果条件为 true，逻辑非为 false。 | not(A and B) 为 true。 |

### 其他运算符

下表列出了 Lua 语言中的连接运算符与计算表或字符串长度的运算符：

| 操作符 | 描述                               | 实例                                                         |
| :----- | :--------------------------------- | :----------------------------------------------------------- |
| ..     | 连接两个字符串                     | a..b ，其中 a 为 "Hello " ， b 为 "World", 输出结果为 "Hello World"。 |
| #      | 一元运算符，返回字符串或表的长度。 | #"Hello" 返回 5                                              |

### 运算符优先级

从高到低的顺序：

```
^
not    - (unary)
*      /
+      -
..
<      >      <=     >=     ~=     ==
and
or
```

## Lua模块与包

模块类似于一个封装库。Lua 的模块是由变量、函数等已知元素组成的 table，因此创建一个模块很简单，就是创建一个 table，然后把需要导出的常量、函数放入其中，最后返回这个 table 就行。

eg:

```
-- 文件名为 module.lua
-- 定义一个名为 module 的模块
module = {}
 
-- 定义一个常量
module.constant = "这是一个常量"
 
-- 定义一个函数
function module.func1()
    io.write("这是一个公有函数！\n")
end
 
local function func2()
    print("这是一个私有函数！")
end
 
function module.func3()
    func2()
end
 
return module
```

### require函数--加载模块及加载机制

```lua
--两种加载方式
require("<模块名>")
require "<模块名>"
--使用模块
local m = require("module")
print(m.constant)
m.func3()
```

### 加载机制

对于自定义的模块，模块文件不是放在哪个文件目录都行，函数 require 有它自己的文件路径加载策略。require 用于搜索 Lua 文件的路径是存放在全局变量 package.path 中，当 Lua 启动后，会以环境变量 LUA_PATH 的值来初始这个环境变量。如果没有找到该环境变量，则使用一个编译时定义的默认路径来初始化。

eg:

```lua
print(package.path)
--[[
D:\Lib\lua-5.4.3_Win64_bin\lua\?.lua;
D:\Lib\lua-5.4.3_Win64_bin\lua\?\init.lua;
D:\Lib\lua-5.4.3_Win64_bin\?.lua;
D:\Lib\lua-5.4.3_Win64_bin\?\init.lua;
D:\Lib\lua-5.4.3_Win64_bin\..\share\lua\5.4\?.lua;
D:\Lib\lua-5.4.3_Win64_bin\..\share\lua\5.4\?\init.lua;
.\?.lua;
.\?\init.lua
]]--
```

调用require("module")时就会尝试打开一下文件目录：

```lua
--[[
no file 'D:\Lib\lua-5.4.3_Win64_bin\lua\module.lua'
	no file 'D:\Lib\lua-5.4.3_Win64_bin\lua\module\init.lua'
	no file 'D:\Lib\lua-5.4.3_Win64_bin\module.lua'
	no file 'D:\Lib\lua-5.4.3_Win64_bin\module\init.lua'
	no file 'D:\Lib\lua-5.4.3_Win64_bin\..\share\lua\5.4\module.lua'
	no file 'D:\Lib\lua-5.4.3_Win64_bin\..\share\lua\5.4\module\init.lua'
	no file '.\module.lua'
	no file '.\module\init.lua'
	no file 'D:\Lib\lua-5.4.3_Win64_bin\module.dll'
	no file 'D:\Lib\lua-5.4.3_Win64_bin\..\lib\lua\5.4\module.dll'
	no file 'D:\Lib\lua-5.4.3_Win64_bin\loadall.dll'
	no file '.\module.dll'
]]--
```

## Lua协同程序（coroutine)

线程与协程：
***相同点***：拥有独立的堆栈，独立的局部变量，独立的指令指针，同时又与其它协同程序共享全局变量和其它大部分东西。

***不同点***：一个具有多个线程的程序可以同时运行几个线程，而协同程序却需要彼此协作的运行。在任一指定时刻只有一个协同程序在运行，并且这个正在运行的协同程序只有在明确的被要求挂起的时候才会被挂起。协同程序有点类似同步的多线程，在等待同一个线程锁的几个线程有点类似协同。

### 基本语法

| 方法                | 描述                                                         |
| :------------------ | :----------------------------------------------------------- |
| coroutine.create()  | 创建coroutine，返回coroutine， 参数是一个函数，当和resume配合使用的时候就唤醒函数调用 |
| coroutine.resume()  | 重启coroutine，和create配合使用                              |
| coroutine.yield()   | 挂起coroutine，将coroutine设置为挂起状态，这个和resume配合使用能有很多有用的效果 |
| coroutine.status()  | 查看coroutine的状态 注：coroutine的状态有三种：dead，suspend，running，具体什么时候有这样的状态请参考下面的程序 |
| coroutine.wrap（）  | 创建coroutine，返回一个函数，一旦你调用这个函数，就进入coroutine，和create功能重复 |
| coroutine.running() | 返回正在跑的coroutine，一个coroutine就是一个线程，当使用running的时候，就是返回一个corouting的线程号 |

## Lua闭包

闭包就是能够读取其他函数内部变量的函数。----百度百科 

在lua语言中，函数是严格遵循词法定界(lexical scoping)的第一类值(first-class value)。
词法定界：它意味着lua语言中的函数可以访问包含其自身的外部函数的变量。

### 第一类值

第一类值：函数不仅可以被存储在全局变量中，还可以被存储在表字段和局部变量中。

***<u>NOTE</u>***

1. 局部函数的语法糖展开：

```lua
local function foo(params) body end
--等价于如下定义
lcoal foo;foo = function(params) body end
--这个语法糖可以避免第注意二中的问题
```



2. 局部递归函数，使用变量赋值的形式来定义

```lua
--错误，这里会尝试调用全局的fact函数
local fact = function (n)
    if n == 0 then
        return 1
    else return n*fact(n-1)
    end
end

--可以先声明fact变量后定义函数
local fact
fact = function (n)
    if n == 0 then
        return 1
    else return n*fact(n-1)
    end 
end

```

### 词法定界

当编写一个其他函数B包含的函数A时，被包含的函数A可以访问包含其的函数B的所有局部变量，我们将这种特性称为词法定界（lexical scoping)。



一个简单的理解就是，函数作为第一类值，能够逃逸出它们变量的定界范围！

**<u>*EG:*</u>**

```Lua
local function newCounter()
    local count = 0
    return function ()
            count = count + 1 --访问了count
            return count
        end
end
-- 有以下示例
local c1 = newCounter()
print(newCounter())
print(newCounter())
print(newCounter()())
print(c1())
print(c1())
print(c1())
--有以下输出
--[[
function: 0000000000fb16b0
function: 0000000000fb1260
1
1
2
3
]]
```



闭包的使用场景：

1. 高阶函数的参数。
2. 对于那些创建了其他函数的函数。
3. 对于回调函数。
4. 重新定义函数（甚至是预定义函数）。
5. 创建安全的运行时环境，即所谓的沙盒。





## Lua面向对象

对象由属性和方法组成。LUA中最基本的结构是table，所以需要用table来描述对象的属性。为了达到

```lua
--栈类实例
Stack = {}
function Stack:push(var)
    self[#self+1] = var
end
function Stack:pop()
    local var = self[#self]
    table.remove(self,#self)
    return var
end
function Stack:top()
    return self[#self]
end
function Stack:isempty()
    return #self == 0
end

function Stack:new()
    O = {}
    setmetatable(O,self)
    self.__index = self
    return O
end
```



表与对象的共同点：

1. 可以拥有状态（可以理解为数据成员）
2. 拥有一个与其值无关的标识（self,类似this指针)
3. 两个具有相同值的对象（表）是两个不同的对象
4. 具有与创建者被创建位置无关的生命周期





1. 独立生命周期原则：利用元表（定义lua对象的未知操作的行为的对象）以及self机制（使用冒号操作符隐藏传入自己这个对象的参数）实现独立生命周期原则
2. 类的概念：参考基于原型的语言来实现类（模子）的概念，让对象在原型中查找未知操作与属性。
3. 继承：重复利用new（一般类中生成新对象的方法），会产生一种元表的元表的链来形成继承的特性，同时，通过在子类中重写父类的方法，会先在子类中查询这个方法，如果没找到，才会去父类（元表中定义的原型）去寻找。
4. 多重继承：把一个函数当作元方法去遍历多个父类，找到想要找的key
5. 私有性：通过两个表表示一个对象：一个表用来保存对象的状态，另一个表用来保存对象的操作（或者接口）。
6. 单方法对象：对象只有一个方法，可以不用创建接口表，只要将这个单独的方法以对象的表示形式返回即可。
7. 对偶表示（dual Representation):实现私有性的另一种方法---对偶表示(把表当作键，同时又把对象本身当作这个表的键)

## Lua内存管理，Lua的垃圾回收机制

## Lua-Environment

​		为了维持全局变量的存在，Lua语言中在内部维护了一个表来用作全局环境。通常，在加载一个代码段时，函数load（或函数loadfile）会使用预定义的上值来初始化全局环境。并且Lua语言编译器会将代码段中的所有自由名称x转换为_ENV.x。因此。如下：

```lua
local z = 10
x = y + z
--这个代码段等价于
local _ENV = the global envirment--全局环境
local z = 10
_ENV.x = _ENV.y + z
```

Lua语言处理全局变量的方式：

1. 编译器在编译所有代码段前，在外层创建局部变量_ENV;
2. 编译器将所有自由名称var变换为_ENV.var;
3. 函数load（或函数loadfile）使用全局环境初始化代码段的第一个上值，即lua语言内部维护的一个普通的表。

### _ENV的使用

其主要用途是用来改变代码段使用的环境。***<u>NOTE:一旦改变环境所有的全局访问就都将使用新表。</u>***

```LUA
do 
    _ENV = {}
    a = 1 --会变成_ENV.a = 1
    print(a) --会变成_ENV.print(_ENV.a)因此会报错，attmpt to call global 'print'(a nil value)
end
```

如果新环境为空，就会丢失所有的全局变量，包括函数print***<u>,因此，应该首先把一些有用的值放入新环境，比如全局环境。</u>***eg:

```lua
do 
    a = 15
    _ENV = {_G = _G}
    a = 1
    g.print(_ENV,a,g.a)
end
```



**<u>另外一种把旧环境装入新环境的方式是使用继承：</u>**

```lua
local function fun1()
    local newgt = {} --创建新环境
    setmetatable(newgt,{__index = _G}) --继承
    _ENV = newgt --设置新环境
    print(a)
    a = 10
    print(a,_G.a)
    _G.a = 20
    print(a,_G.a)
end
```

**<u>*！！！如果定义一个名为_ENV的局部变量，那么对自由名称的引用会绑定到这个新变量上*</u>**

```lua
a = 2
do
    local _ENV = {print = print,a = 14}
    print(a)--14
end
print(a)--2

```

***使用私有环境定义一个函数,使用普遍的定界规则，我们可以有几种方式操作环境，例如可以让多个函数共享一个公共环境，或者让一个函数改变它与其他函数共享的环境***

```lua
function factory(_ENV)
    return function() return a end
 end
f1 = factort{a=18}
f2 = factory{a = 19}
print(f1()) --18
print(f2()) --19
```



## Lua与C++

luaC语言API的学习：

lua.h:声明了lua提供的基础函数，包括创建新lua环境的函数、调用lua函数的函数、读写环境中的全局变量的函数，以及注册供Lua语言调用新函数的函数等。
lauxlib.h:声明了辅助库（auxiliary library,auxlib)，辅助库使用基础API来提高更高层次的抽象，特别是对标准库用到的相关机制进行抽象。

**<u>*NOTE:辅助库不能访问Lua的内部元素，而只能通过lua.h中声明的官方基础API完成所有工作，辅助库能实现什么，你的程序就能实现什么.*</u>**

lua标准库没有定义任何C语言全局变量，它将其所有的状态都保存在动态的结构体lua_state当中，lua中所有函数都接受一个指向该结构的指针作为参数。

### lua与C/C++通信的组件-虚拟栈

通信的两个问题：

1.动态类型与静态类型体系不匹配
2.自动内存管理与手动内存管理不匹配

通信过程：

1.当我们想要从lua中获取一个值时，需要调用lua,lua就会将指定的值压入栈。
2.当我们想要将一个值传给lua,首先要将这个值压入栈，然后调用lua将其从栈中弹出。

例如调用一个函数：

1. 压入函数以及参数
2. 调用lua_pcall()指定在栈中的函数与参数

其中栈中的每个元素都能保存Lua中任意类型的值。？

错误处理（补全）

## 扩展应用

lua作为配置语言来配置一个程序。

1. 利用LuaAPI语言解析该文件（加载代码段，然后调用lua_pcall运行编译后的代码段，如果有错误，会将错误信息压入栈），并获取相关的变量的值。

为什么使用lua作为配置语言？

1. lua处理了语法细节。
2. 可以使用lua来实现一些更复杂的配置（如查询环境变量来选择合适的窗口大小）
3. 使用它以后向程序中添加新的配置机制时会很方便。

lua作为配置语言时候的实例：
利用表简化配置。

# Lua数据结构

## table

table是什么？
lua语言中的表本质上是一种辅助数组（associative array）,这种数组不仅可以使用数值作为索引，也可以使用字符串或其他任意类型的值作为索引（nil除外）。

### 初始化

#### 表构造器（列表式构造器，记录式构造器）

```lua
--空构造器
a = {}

--列表式构造器
b = {1,2,34,6}
--b[1] => 1
--b[2] => 2
--b[3] => 34
--b[4] => 6

--记录式构造器
c = {x=0,y=0}
--c[x] => 0
--c[y] => 0

--嵌套构造器及混用列表以及记录式构造器
d = {1,2,{x=0,y=0},{x=10,y=1},color = "blue"}
--d[1]=>1
--d[2]=>2
--d[3]=>{x=0,y=0}
--d[4]=>{x=10,y=1}
--d[color] = "blue"

```

这两种构造器的局限：

1. 不能使用负数索引初始化表元素
2. 不能使用不规范的标识符作为索引

#### 显式指定key构造器

对于以上需求可以使用另外一种更通用的构造器，通过方括号括起来的表达式显式地指定每一个索引；

```
opnames = {["+"]="add",["-"]="sub",["*"]="mul",["/"]="div"}
```

**注：在构造器中，最后一个元素可选是否加逗号**

```
opnames = {["+"]="add",["-"]="sub",["*"]="mul",["/"]="div",}
d = {1,2,{x=0,y=0},{x=10,y=1},color = "blue",}
```

### 表索引，表的元素访问

同一个表中存储的值可以具有不同的类型索引（即不同数据类型的键）。

表的元素访问：
1 点操作符
2 []操作符

```lua
t1 = {1,2,3,4,x=10,y=5}
--点操作符及[]操作符
index = 1
index1 = "x"
print(t1.x)
print(t1["x"])
print(t1[index])
print(t1[index1])

```

***Note1:*** a.x等价于a["x"],a[x]表示的是变量x对应的值索引的表

***Note2***: 由于可以使用任意类型的索引表，因此会存在“+1”，“01”，“1”指向的也是不同的元素。当不能确定表索引的真实数据类型时，可以使用显式的类型转换。

```lua
i = 10;j="10";k="+10"
a = {[i]="number key",[j]="string key",[k]="another string key"}
--访问数值类型的key
print(a[tonumber(j)])
```

***Note3:***整型与浮点型不存在上述***Note2*** 的问题，当数值类型被作为表索引时，任何能够转换为整型的浮点数都会被转换为整型数。例如：当执行表达式a[2.0]=10时，键2.0会被转换为2。相反，不能转换为整型数的浮点数不会发生上述的类型转换。

### 表元素的删除与添加

未经初始化的表元素为nil，将nil赋值给表元素即可将其删除。

表元素的添加：

```lua
t1 = {1,2,3,4}
--添加
t1["x"] = 5
t1.y = 6
--删除
t1[1] = nil
t1[2] = nil
```

### 表的标准函数库

| 序号 | 方法 & 用途                                                  |
| :--- | :----------------------------------------------------------- |
| 1    | **table.concat (table [, sep [, start [, end]]]):**<br>concat是concatenate(连锁, 连接)的缩写. table.concat()函数列出参数中指定table的数组部分从start位置到end位置的所有元素, 元素间以指定的分隔符(sep)隔开。 |
| 2    | **table.insert (table, [pos,] value):**<br/>在table的数组部分指定位置(pos)插入值为value的一个元素. pos参数可选, 默认为数组部分末尾. |
| 3    | **table.maxn (table)**<br/>指定table中所有正数key值中最大的key值. 如果不存在key值为正数的元素, 则返回0。(**Lua5.2之后该方法已经不存在了,本文使用了自定义函数实现**) |
| 4    | **table.remove (table [, pos])**<br/>返回table数组部分位于pos位置的元素. 其后的元素会被前移. pos参数可选, 默认为table长度, 即从最后一个元素删起。 |
| 5    | **table.sort (table [, comp])**<br/>对给定的table进行升序排序。 |

## Lua元表（Metatable)

元表的作用？ ***<u>元表可以修改一个值在面对一个未知操作时的行为。</u>***

一个表只能有一个元表，

在 Lua table 中我们可以访问对应的key来得到value值，但是却无法对两个 table 进行操作。因此 Lua 提供了元表(Metatable)，允许我们改变table的行为，每个行为关联了对应的元方法。

有两个很重要的函数来处理元表：

- **setmetatable(table,metatable):** 对指定table设置元表(metatable)，如果元表(metatable)中存在__metatable键值，setmetatable会失败 。
- **getmetatable(table):** 返回对象的元表(metatable)。

以下实例演示了如何对指定的表设置元表：

```lua
mytable = {}                          -- 普通表 
mymetatable = {}                      -- 元表
setmetatable(mytable,mymetatable)     -- 把 mymetatable 设为 mytable 的元表 

```

以下为元表常用的字段：

- 算术类元方法:   字段:__ add(+), __ mul(*), __ sub(-), __ div(/), __ unm, __ mod(%),  __ pow, (__concat)
- 关系类元方法： 字段：__ eq, _ _lt(<), __ le(<=)，其他Lua自动转换 a~=b --> not(a == b) a > b --> b < a a >= b --> b <= a (注意NaN的情况)
- table访问的元方法： 字段: __ index, __newindex
  - __ index :  查询：访问表中不存的字段
  - __newindex： 更新：向表中不存在索引赋值 

### __ index方法

当你通过键来访问 table 的时候，如果这个键没有值，那么Lua就会寻找该table的metatable（假定有metatable）中的__ index 键。如果__index包含一个表格，Lua会在表格中查找相应的键(即元方法_ __index不一定必须是一个函数，还可以是一个表)，如果是表Lua语言就会访问这个

### __newindex 元方法

***__ newindex 元方法用来对表更新***，***__ index则用来对表访问*** 。当你给表的一个缺少的索引赋值，解释器就会查找__newindex 元方法：如果存在则调用这个函数而不进行赋值操作(即元方法  _ _newindex不一定必须是一个函数，还可以是一个表)。如果是个表，解释器就在此表中执行赋值。



## lua中的nil值对于table的影响

```lua
--table中nillocal 
tb3 = {123,23,nil,13,4,12,nil}
print(#tb3)
--输出6，末尾的nil值不算入长度
for key,value in ipairs(tb3) do
    print(key,value)
end
--[[会输出
1，123
2,23
]]--
for k, v in pairs(tb3) do
    print(k,v)
end
--[[输出
1	123
2	23
4	13
5	4
6	12
]]
```

## table sort

table.sort会对tableh中key=1,2,3……的value值进行比较排序。

```lua
--table sort 只会排序key = 1,2,3,4……的元素
local function dump(tb)
    print("--------------")
    for key, value in pairs(tb) do
        print(key,value) 
    end
    print("--------------")
end
local tb = {123,23,13,4,123,42134}
local tb1 = {a = 1,b = 324,c = 45,d = 23}
dump(tb)
dump(tb1)
table.sort(tb)
table.sort(tb1)
dump(tb)
dump(tb1)
--[[输出如下，只有tb有排序（默认是从小到大排序），tb1并未排序
--------------
1	123
2	23
3	13
4	4
5	123
6	42134
--------------
--------------
c	45
b	324
a	1
d	23
--------------
--------------
1	4
2	13
3	23
4	123
5	123
6	42134
--------------
--------------
c	45
b	324
a	1
d	23
--------------
]]--

--对于key不等一1,2,3……这些元素可以新建表，再自定义比较函数来做排序
local tb2 = {}

for key, value in pairs(tb1) do
    tb2[#tb2+1] = {key,value}
end
table.sort(tb2,function (a,b)
    if a[2]>b[2] then
        return true
    end
    return false
end)
for index, value in ipairs(tb2) do
    dump(value)
end
--输出：
--[
--------------
1	b
2	324
--------------
--------------
1	c
2	45
--------------
--------------
1	d
2	23
--------------
--------------
1	a
2	1
--------------
]--

--不能有nil值进行比较
```

对于nil值的处理。

## table对于元素的删除

避免循环删除问题。这个问题在于会存在一些元素无法正常遍历到。

```lua
--Lua遍历删除table变量
local tb4 = {2,4,2,4,3,6,7,9}
print("-------错误方式------")
for index, value in pairs(tb4) do
    --print(value)
    io.write(value..",")
    if value%2 == 0 then
        table.remove(tb4,index)
    end
end
io.write("\n")
-- dump(tb4)
tb4 = {2,4,2,4,3,6,7,9}
--从后往前
print("-------从后往前------")
for i = #tb4, 1,-1 do
    io.write(tb4[i]..",")
    if tb4[i]%2 == 0 then
        table.remove(tb4,i)
    end
end

io.write("\n")
-- dump(tb4)
tb4 = {2,4,2,4,3,6,7,9}
--从后往前
print("-------while删除------")
local i = 1
while i<=#tb4 do
    io.write(tb4[i]..",")
    if tb4[i]%2 == 0 then 
        table.remove(tb4,i)
    else
        i=i+1
    end
end
--[[输出
-------错误方式------
2,2,3,6,9,
-------从后往前------
9,7,6,3,4,2,4,2,
-------while删除------
2,4,2,4,3,6,7,9,
]]

```



首先要知道函数对应的协议在哪（protobuf)
一是，绑定UI界面
二是，在返回消息里写
