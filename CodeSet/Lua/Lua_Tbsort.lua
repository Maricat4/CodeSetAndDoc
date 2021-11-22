--table sort 只会排序key = 1,2,3,4……的元素
local function dump(tb)
    print("--------------")
    for key, value in pairs(tb) do
        print(key,value) 
    end
    print("--------------")
end
-- local tb = {123,23,13,4,123,42134}
-- local tb1 = {a = 1,b = 324,c = 45,d = 23}
-- dump(tb)
-- dump(tb1)
-- table.sort(tb)
-- table.sort(tb1)
-- dump(tb)
-- dump(tb1)


-- --对于key不是1,2,3……这些元素，可以构造成key为1,2,3……的表，再进行排序
-- local tb2 = {}

-- for key, value in pairs(tb1) do
--     tb2[#tb2+1] = {key,value}
-- end
-- table.sort(tb2,function (a,b)
--     if a[2]>b[2] then
--         return true
--     end
--     return false
-- end)
-- for index, value in ipairs(tb2) do
--     dump(value)
-- end
-- dump(tb2)
local tb3 = {123,23,nil,13,4,12,nil}
-- local tb4 = {"as","bolt",nil}
-- table.sort(tb3,function (a, b)
--     print(a,b)
--     if a>b then
--         return false
--     end
--     return true
-- end)
-- table.sort(tb4)
print(#tb3)
-- dump(tb3)
-- print(tostring("as">nil))
-- for k,v in ipairs(tb3) do
--     print(v)
-- end
--[[

]]

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
