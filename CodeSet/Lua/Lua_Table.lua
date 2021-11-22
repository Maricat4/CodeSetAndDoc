-- table 表的初始化

local var = {x = 1,y = 1,1,2,3,5,print}
for index, value in pairs(var) do
    io.write(index..","..tostring(value)..";\n")
end
print("-----------------")
for index, value in ipairs(var) do
    io.write(index..","..tostring(value)..";\n")
end
print(var.x)

print(_VERSION)

local opnames = {["+"]="add",["-"]="sub",["*"]="mul",["/"]="div"}
for key, value in pairs(opnames) do
    print(key..","..value)
end

local opnames1 = {["-1"]="n1",["-2"]="n2"}
for key, value in pairs(opnames1) do
    print(key..","..value)
end


--添加元素
local var = {1,2,3,5}
var[#var+2] = 6
for key, value in pairs(var) do
    print(key..","..value)
end
print("-----------")
--删除元素
var[1] = nil
for key, value in pairs(var) do
    print(key..","..value)
end


-- 表元素访问
local t1 = {1,2,3,4,x=10,y=5}
--点操作符及[]操作符
local index = 1
local index1 = "x"
print(t1.x)
print(t1["x"])
print(t1[index])
print(t1[index1])

local i = 10;local j="10";local k="+10"
local a = {[i]="number key",[j]="string key",[k]="another string key"}
print(a[tonumber(j)])

--添加与删除
t1 = {1,2,3,4}
--添加
t1["x"] = 5
t1.y = 6
for index, value in pairs(t1) do
    print(index..","..value)
end
print("-------------")
--删除
t1[1] = nil
t1[2] = nil
for index, value in pairs(t1) do
    print(index..","..value)
end
print("-------------------")
local function coutTable(tmp)
    for key, value in pairs(tmp) do
        io.write(key..","..value..";\n")
    end
end
-- 表的标准库
--插入与删除
t1 = {1,2,3,4}
table.insert(t1,1,16)
coutTable(t1)
table.remove(t1,3)
coutTable(t1)
--表内元素的连接
print(table.concat(t1,",",1,#t1))
local function max(a,b)
    return a<b
end
table.sort(t1,max)
print(table.concat(t1,",",1,#t1))

--- #号只会得到数值型的key长度
A = {}
A[-1] = 1
A[0] = 1
A[1] = 1
A[2] = 1
A[3] = 1
A["1"] = 1
for key, value in pairs(A) do
    print(key..","..value)
end
print(#A)
print(_VERSION)

for index, value in ipairs(A) do
    print(index..","..value)
end