--闭包 Closures

-- local sunday,monday = "monday","sunday"
-- local t = {sunday = "monday",[sunday]= monday}
-- --local t = {"sunday" = "monday", "monday" = "sunday"}

-- print(sunday)
-- print(t.sunday)
-- print(t.sunday,t[sunday],t[t.sunday])

-- --print(t.sunday,t["monday"],t["monday"])

-- local a = {}
-- a.a = a

-- print(a.a.a.a)

-- a.a.a.a = 3


-- print(a.a.a.a)


-- --函数是第一类值（first class value)
-- local a = {p = print}
-- a.p("hello lua")

-- print = math.sin --print指向sine函数
-- a.p(print(1)) --a.p仍然是print函数


-- math.sin = a.p
-- math.sin(12,32,42)
--TODO

--正常创建
local function foo(x)
    return 2*x
end
--创建函数的表达式
local foo1 = function (x) return 2*x end
foo = 3
print(foo)

local function derivative(f,delta)
    delta = delta or 1e-4
    return function (x)
        return (f(x+delta) - f(x))/delta
    end
end

local f1 = derivative(math.cos,1e-5)

print(f1(math.pi/2))

local fact
fact = function (n)
    if n == 0 then
        return 1
    else return n*fact(n-1)
    end 
end

print(fact(5))

local function foo(m)
    if m == 0 then
        return 1
    else return m*foo(m-1)
    end 
end

print(foo(5))


--词法定界
local names = {"Peter","Paul","Mary"}
local grades = {Mary = 10,Paul = 7,Peter = 8}
table.sort(names,function (n1, n2)
    return grades[n1] > grades[n2] --比较分数
end)

for key, value in pairs(names) do
    print(value)
end

local function sortbygrade(names,grades)
    table.sort(names,function (n1, n2)
        return grades[n1] < grades[n2] --比较分数
    end)
end
sortbygrade(names,grades)
for key, value in pairs(names) do
    print(value)
end

local function newCounter()
    local count = 0
    return function ()
            count = count + 1
            return count
        end
end

local c1 = newCounter()
-- print(newCounter())
-- print(newCounter())
-- print(c1)
-- print(c1)
-- print(c1())

print(newCounter())
print(newCounter())
print(newCounter()())
print(c1())
print(c1())
print(c1())

