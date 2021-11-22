-- -- print("hello world")

-- --注释

-- --[[
-- 多行注释
-- ]]--

-- --变量
-- -- a = 5
-- -- print(a)
-- -- a = nil
-- -- print(a)

-- --表的使用
-- Tab1 = { key1 = "val1", key2 = "val2", "val3" }
-- for k, v in pairs(Tab1) do
--     print(k .. " - " .. v)
-- end
-- --可以有删除的作用 
-- Tab1.key1 = nil
-- for k, v in pairs(Tab1) do
--     print(k .. " - " .. v)
-- end

-- function Dy(n)
--     if n==0 then
--         return 0
--     end
--     if n==1 then
--         return 1
--     end
--     if n==2 then
--         return 2
--     end
--     return Dy(n-1)+Dy(n-2)
-- end

-- --空值的判断
-- A = 5
-- print(Dy(A))
-- A = nil
-- print(A==nil)
-- print(type(A)==nil)

-- --逻辑运算符
-- A = 6;B = 0
-- print(A and B)
-- print(A or B)
-- B = 4
-- print(A and B)
-- print(A or B)

-- prog = {a=1,false,false}
-- local tb={aaaa=100000,a=1,n=2,sa=-5}
-- local tb={["aa"]=100000,a=1,n=2,sa=-5}
-- --local tb={121,34,2134,513451,5131523,14234125,1234}
-- table.sort(tb,function (a,b) print(a) return a > b end)

-- -- print(tb.aaaa)
-- -- for key, value in pairs(tb) do
-- -- for key, value in pairs(tb) do
-- -- for key, value in pairs(tb) 
-- --     print(key,value)
-- -- end
-- --
-- --
-- print(tostring(not -1))

-- if nil then
-- else
--     print("nil")
-- end

-- --print(math.pow(1.1,19))
-- print(0~=nil)
-- print(not 0)
print(tonumber(true))
print(0xffffffff>>31 and 0x00000010)
print(1 ~ 1)
print(nil == nil)


t = {}
table.insert(t,1)
table.insert(t,2)
for i,v in ipairs(t) do
    print(i,v)
end
print("---------")
table.remove( t,1  )
for i,v in ipairs(t) do
    print(i,v)
end