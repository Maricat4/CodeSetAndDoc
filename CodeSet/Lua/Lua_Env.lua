-- b = 20
-- function fun1()
--     local c = 10
--     a = c + b
-- end
-- fun1()
-- print(c)
-- print(d)
-- print(_ENV.a)

-- for key, value in pairs(_ENV) do
--     print("key:"..key..",".."value:"..tostring(value))
-- end

-- local print,sin = print,print
-- --_ENV = nil
-- print(13)
-- print(tostring(sin))
-- print(tostring(print))
-- print(sin(13))
-- print(math.cos(13))

-- function f(_ENV,b)

--     a = 10
--     b(a)
    
-- end
-- a = f({},print)
-- print(a)
-- function f()
--     x = 10
--     return x
-- end


-- f()
-- varname = "x"
-- value = load("return "..varname)()
-- print(value)

--NOTE load
-- do
--     --NOTE 全局变量的声明
--     function Declare (name,initval)
--         rawset(_G,name,initval or false)
--     end
    
    
    -- setmetatable(_G,{
    --     __newindex = function (_,n)
    --         print(n)
    --         --error("attempt to write to undeclared variable "..n,2)
    --     end,
    --     __index = function (_,n)
    --         print(n)
    --         --error("attempt to read undeclared variable "..n,2)
    --     end,
    -- })
    --绕过元方法去设置变量
    -- rawset(_G,"a",10)
    -- a = 10
    -- print(a)
    -- a = nil
    -- print(a)
    
    -- local t = {}
    -- t.a = 1
    -- t.a = nil
    -- print(t.a)
-- end

--NOTE 检查全局变量的声明（允许nil值的全局变量存在）



--NOTE_ENV的使用--直接把全局环境转入新环境中

-- Aa = 100
-- do 
--     local _ENV = {_G = _G}
--     Aa = 1 --会变成_ENV.a = 1
--     _G.print(_ENV.Aa,_G.Aa) --会变成_ENV.print(_ENV.a)因此会报错，attmpt to call global 'print'(a nil value)
-- end
-- --NOTE _ENV的使用---使用继承来将旧环境装入新环境

-- local function fun1()
--     local newgt = {} --创建新环境
--     setmetatable(newgt,{__index = _G})
--     _ENV = newgt --设置新环境
--     print(Aa)
--     Aa = 10
--     print(Aa,_G.Aa)
--     _G.Aa = 20
--     print(Aa,_G.Aa)
-- end

-- -- fun1()
-- print(Aa)


--NOTE _ENV与普通变量一样,_ENV遵循通常的定界规则
-- _ENV = {_G = _G}
-- local function  foo()
--     _G.print(a)
-- end
-- a = 10
-- foo()
-- _ENV = {_G=_G,a = 20}
-- foo()


--NOTE 私有环境定义一个函数

-- local function factory(_ENV)
--     return function ()
--         return AA
--     end
-- end
-- local f1 = factory{AA = 18}
-- local f2 = factory{AA = 19}

-- print(f1())
-- print(f2())

--NOTE 环境和模块

--NOTE 课后习题
-- local print = print
-- function foo(_ENV,a)
--     print(a+b)    
-- end
-- foo({b=15},12)

-- local foo
-- do 
--     local _ENV = _ENV
--     function foo() print(X) end
-- end
-- X = 13
-- _ENV = nil
-- foo()
-- X = 0